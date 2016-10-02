using System;
using System.Collections.Generic;
using System.Globalization;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class TrainingBol
    {
        private TrainingDal _TrainingDal;
        private PersonDal _PersonDal;
        private ExpenseHeadDal _ExpenseHeadDal;
        private AllowanceSettingDal _AllowanceSettingDal;
        private CountryDal _CountryDal;

        public TrainingBol()
        {
            _TrainingDal = new TrainingDal();
            _PersonDal = new PersonDal();
            _ExpenseHeadDal = new ExpenseHeadDal();
            _AllowanceSettingDal = new AllowanceSettingDal();
            _CountryDal = new CountryDal();
        }

        public Trainee GetTrainee(TraineeParam traineeParam)
        {
            Trainee trainee = new Trainee();
            AllowanceSetting allowanceSetting = _AllowanceSettingDal.GetAllowanceSetting(1);
            DateTime startDate = DateTime.ParseExact(traineeParam.StartDate, "dd MMM yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(traineeParam.EndDate, "dd MMM yyyy", CultureInfo.InvariantCulture);
            DateTime expenseFrom = DateTime.ParseExact(traineeParam.ExpenseFrom, "dd MMM yyyy", CultureInfo.InvariantCulture);
            DateTime expenseTo = DateTime.ParseExact(traineeParam.ExpenseTo, "dd MMM yyyy", CultureInfo.InvariantCulture);
            TimeSpan dateDiff = expenseTo.Subtract(expenseFrom);
            int noOfDays = dateDiff.Days + 1;
            List<ExpenseHead> expenseHeads = _ExpenseHeadDal.GetExpenseHeads();
            Country country = _CountryDal.GetCountry(traineeParam.CountryId);
            trainee.Person = _PersonDal.GetPerson(traineeParam.PersonId);
            trainee.Rank = trainee.Person.Rank;
            trainee.Expenses = CreateExpenses(traineeParam.PersonId, country.Group, trainee.Person.Rank.Group.Id, expenseHeads, allowanceSetting, noOfDays);

            if (endDate >= startDate.AddMonths(allowanceSetting.EligibilityForSpouse))
            {
                trainee.SpouseExpenses = CreateSpouseExpenses(traineeParam.PersonId, country.Group, trainee.Person.Rank.Group.Id, expenseHeads, allowanceSetting, noOfDays);
            }
            if (endDate >= startDate.AddMonths(allowanceSetting.EligibilityForKids))
            {
                trainee.KidExpenses = CreateKidsExpenses(traineeParam.PersonId, country.Group, trainee.Person.Rank.Group.Id, expenseHeads, allowanceSetting, noOfDays);
            }
            return trainee;
        }

        public List<Training> GetTrainings(TrainingFilter filter, out int totalCount)
        {
            if (string.IsNullOrEmpty(filter.DateFrom))
            {
                filter.DateFrom = "01 Jan 1900";
            }
            if (string.IsNullOrEmpty(filter.DateTo))
            {
                filter.DateTo = "31 Dec 3000";
            }
            return _TrainingDal.GetTrainings(filter, out totalCount);
        }

        public Training GetTraining(int id)
        {
            Training training = _TrainingDal.GetTraining(id);
            if (string.Compare(training.AcceptanceDate, "01 Jan 1900", true) == 0)
            {
                training.AcceptanceDate = string.Empty;
            }
            if (string.Compare(training.BriefingDate, "01 Jan 1900", true) == 0)
            {
                training.BriefingDate = string.Empty;
            }
            if (string.Compare(training.DocForwardDate, "01 Jan 1900", true) == 0)
            {
                training.DocForwardDate = string.Empty;
            }
            if (string.Compare(training.DocumentDate, "01 Jan 1900", true) == 0)
            {
                training.DocumentDate = string.Empty;
            }
            if (string.Compare(training.MedicalDate, "01 Jan 1900", true) == 0)
            {
                training.MedicalDate = string.Empty;
            }
            if (string.Compare(training.NominationDate, "01 Jan 1900", true) == 0)
            {
                training.NominationDate = string.Empty;
            }
            if (string.Compare(training.PaymentFrom, "01 Jan 1900", true) == 0)
            {
                training.PaymentFrom = string.Empty;
            }
            if (string.Compare(training.PaymentTo, "01 Jan 1900", true) == 0)
            {
                training.PaymentTo = string.Empty;
            }
            return training;
        }

        public void DeleteTraining(int id)
        {
            _TrainingDal.DeleteTraining(id);
        }

        public Training SaveTraining(Training training)
        {
            if (string.IsNullOrEmpty(training.AcceptanceDate))
            {
                training.AcceptanceDate = "01 Jan 1900";
            }
            if (string.IsNullOrEmpty(training.BriefingDate))
            {
                training.BriefingDate = "01 Jan 1900";
            }
            if (string.IsNullOrEmpty(training.DocForwardDate))
            {
                training.DocForwardDate = "01 Jan 1900";
            }
            if (string.IsNullOrEmpty(training.DocumentDate))
            {
                training.DocumentDate = "01 Jan 1900";
            }
            if (string.IsNullOrEmpty(training.MedicalDate))
            {
                training.MedicalDate = "01 Jan 1900";
            }
            if (string.IsNullOrEmpty(training.NominationDate))
            {
                training.NominationDate = "01 Jan 1900";
            }
            if (string.IsNullOrEmpty(training.PaymentFrom))
            {
                training.PaymentFrom = "01 Jan 1900";
            }
            if (string.IsNullOrEmpty(training.PaymentTo))
            {
                training.PaymentTo = "01 Jan 1900";
            }
            training.Validate();
            training.Id = _TrainingDal.SaveTraining(training);
            return training;
        }

        public List<TrainingReminder> GetReminders()
        {
            return _TrainingDal.GetReminders();
        }

        private List<Expense> CreateExpenses(int personId, CountryGroup countryGroup, int rankGroupId, List<ExpenseHead> expenseHeads, AllowanceSetting allowanceSetting, int days)
        {
            List<Expense> expenses = new List<Expense>();
            foreach (ExpenseHead expenseHead in expenseHeads)
            {
                Expense expense = new Expense();
                expense.Head = expenseHead;
                if (expenseHead.IsDaily)
                {
                    expense.Quantity = days;
                }
                if (expenseHead.IsAutoCalc)
                {
                    AllowanceSettingDetail settingDetail = allowanceSetting.CompAllowanceSettingDetails.Find(x => x.RankGroup.Id == rankGroupId);
                    if (countryGroup == CountryGroup.Group1)
                    {
                        if (expenseHead.BasedOn == AutoCalcBase.PercentageOfComprehensiveDA)
                        {
                            expense.Amount = settingDetail.ForCountryGroup1 * expenseHead.Value / 100;
                        }
                        else
                        {
                            expense.Amount = 0;
                        }
                    }
                    if (countryGroup == CountryGroup.Group2)
                    {
                        if (expenseHead.BasedOn == AutoCalcBase.PercentageOfComprehensiveDA)
                        {
                            expense.Amount = settingDetail.ForCountryGroup2 * expenseHead.Value / 100;
                        }
                        else
                        {
                            expense.Amount = 0;
                        }
                    }
                    if (countryGroup == CountryGroup.Group3)
                    {
                        if (expenseHead.BasedOn == AutoCalcBase.PercentageOfComprehensiveDA)
                        {
                            expense.Amount = settingDetail.ForCountryGroup3 * expenseHead.Value / 100;
                        }
                        else
                        {
                            expense.Amount = 0;
                        }
                    }
                }
                else
                {
                    expense.Amount = 0;
                }
                expenses.Add(expense);
            }
            return expenses;
        }

        private List<Expense> CreateSpouseExpenses(int personId, CountryGroup countryGroup, int rankGroupId, List<ExpenseHead> expenseHeads, AllowanceSetting allowanceSetting, int days)
        {
            List<Expense> expenses = new List<Expense>();
            foreach (ExpenseHead expenseHead in expenseHeads)
            {
                if (expenseHead.ApplicableForSpouse)
                {
                    Expense expense = new Expense();
                    expense.Head = expenseHead;
                    if (expenseHead.IsDaily)
                    {
                        expense.Quantity = days;
                    }
                    if (expenseHead.IsAutoCalc)
                    {
                        AllowanceSettingDetail settingDetail = allowanceSetting.CompAllowanceSettingDetails.Find(x => x.RankGroup.Id == rankGroupId);
                        if (countryGroup == CountryGroup.Group1)
                        {
                            if (expenseHead.BasedOn == AutoCalcBase.PercentageOfComprehensiveDA)
                            {
                                expense.Amount = settingDetail.ForCountryGroup1 * expenseHead.Value / 100;
                            }
                            else
                            {
                                expense.Amount = 0;
                            }
                        }
                        if (countryGroup == CountryGroup.Group2)
                        {
                            if (expenseHead.BasedOn == AutoCalcBase.PercentageOfComprehensiveDA)
                            {
                                expense.Amount = settingDetail.ForCountryGroup2 * expenseHead.Value / 100;
                            }
                            else
                            {
                                expense.Amount = 0;
                            }
                        }
                        if (countryGroup == CountryGroup.Group3)
                        {
                            if (expenseHead.BasedOn == AutoCalcBase.PercentageOfComprehensiveDA)
                            {
                                expense.Amount = settingDetail.ForCountryGroup3 * expenseHead.Value / 100;
                            }
                            else
                            {
                                expense.Amount = 0;
                            }
                        }
                    }
                    else
                    {
                        expense.Amount = 0;
                    }
                    expenses.Add(expense);
                }
            }
            return expenses;
        }

        private List<Expense> CreateKidsExpenses(int personId, CountryGroup countryGroup, int rankGroupId, List<ExpenseHead> expenseHeads, AllowanceSetting allowanceSetting, int days)
        {
            List<Expense> expenses = new List<Expense>();
            foreach (ExpenseHead expenseHead in expenseHeads)
            {
                if (expenseHead.ApplicableForKids)
                {
                    Expense expense = new Expense();
                    expense.Head = expenseHead;
                    if (expenseHead.IsDaily)
                    {
                        expense.Quantity = days;
                    }
                    if (expenseHead.IsAutoCalc)
                    {
                        AllowanceSettingDetail settingDetail = allowanceSetting.CompAllowanceSettingDetails.Find(x => x.RankGroup.Id == rankGroupId);
                        if (countryGroup == CountryGroup.Group1)
                        {
                            if (expenseHead.BasedOn == AutoCalcBase.PercentageOfComprehensiveDA)
                            {
                                expense.Amount = settingDetail.ForCountryGroup1 * expenseHead.Value / 100;
                            }
                            else
                            {
                                expense.Amount = 0;
                            }
                        }
                        if (countryGroup == CountryGroup.Group2)
                        {
                            if (expenseHead.BasedOn == AutoCalcBase.PercentageOfComprehensiveDA)
                            {
                                expense.Amount = settingDetail.ForCountryGroup2 * expenseHead.Value / 100;
                            }
                            else
                            {
                                expense.Amount = 0;
                            }
                        }
                        if (countryGroup == CountryGroup.Group3)
                        {
                            if (expenseHead.BasedOn == AutoCalcBase.PercentageOfComprehensiveDA)
                            {
                                expense.Amount = settingDetail.ForCountryGroup3 * expenseHead.Value / 100;
                            }
                            else
                            {
                                expense.Amount = 0;
                            }
                        }
                    }
                    else
                    {
                        expense.Amount = 0;
                    }
                    expenses.Add(expense);
                }
            }
            return expenses;
        }
    }
}
