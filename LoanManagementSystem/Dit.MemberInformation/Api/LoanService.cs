using System;
using System.IO;

namespace Dit.Lms.Api
{
    internal class LoanService : ILoanService
    {
        private ILoanServiceDal _ServiceDal;

        public LoanService()
        {
            _ServiceDal = LoanServiceDalFactory.CreateLoanServiceDal();
        }

        User ILoanService.Login(string loginName, string password)
        {
            try
            {
                User user = _ServiceDal.GetUser(loginName);
                if (user == null) throw new InvalidDataException("Invalid credential, please try again.");
                if (string.Compare(user.LoginName, loginName, true) == 0
                        && string.Compare(user.Password, password) == 0)
                {
                    return user;
                }
                else
                {
                    throw new InvalidDataException("Invalid credential, please try again.");
                }
            }
            catch (InvalidDataException)
            {
                throw;
            }
        }

        User ILoanService.SaveUser(User user)
        {
            if (_ServiceDal.IsDuplicateUser(user.Id, user.LoginName))
            {
                throw new InvalidDataException(string.Format("A user with login name \"{0}\" already exists.\nPlease enter unique login name.", user.LoginName));
            }
            user.IsActive = true;
            user.Id = _ServiceDal.SaveUser(user);
            return user;
        }

        void ILoanService.DeleteUser(int userId)
        {
            _ServiceDal.DeleteUser(userId);
        }

        User ILoanService.GetUser(int userId)
        {
            return _ServiceDal.GetUser(userId);
        }

        UserCollection ILoanService.GetUsers()
        {
            UserCollection users = _ServiceDal.GetUsers();
            return users == null ? new UserCollection() : users;
        }

        Member ILoanService.SaveMember(Member member)
        {
            member.Validate();
            if (_ServiceDal.IsDuplicateMember(member.Id, member.MemberId))
            {
                throw new InvalidDataException(string.Format("A member with member ID \"{0}\" already exists.\nPlease enter unique member ID.", member.MemberId));
            }
            member.IsActive = true;
            member.Id = _ServiceDal.SaveMember(member);
            return member;
        }

        void ILoanService.DeleteMember(int id)
        {
            _ServiceDal.DeleteMember(id);
        }

        Member ILoanService.GetMember(int id)
        {
            return _ServiceDal.GetMember(id);
        }

        Member ILoanService.GetMemberByMemberId(int memberId)
        {
            return _ServiceDal.GetMemberByMemberId(memberId);
        }

        MemberCollection ILoanService.GetMembers(string keyword)
        {
            MemberCollection members = _ServiceDal.GetMembers(keyword);
            return members == null ? new MemberCollection() : members;
        }

        MonthlyDepositCollection ILoanService.GetMonthlyDeposits(int memberId, int yearFrom)
        {
            MonthlyDepositCollection deposits = _ServiceDal.GetMonthlyDeposits(memberId, yearFrom);
            return deposits == null ? new MonthlyDepositCollection() : deposits;
        }

        MonthlyDeposit ILoanService.SaveMonthlyDeposit(MonthlyDeposit deposit, double depositCharge)
        {
            deposit.IsActive = true;
            deposit.Id = _ServiceDal.SaveMonthlyDeposit(deposit, depositCharge);
            return deposit;
        }

        void ILoanService.DeleteMonthlyDeposit(int depositId)
        {
            _ServiceDal.DeleteMonthlyDeposit(depositId);
        }

        MonthlyDeposit ILoanService.GetMonthlyDeposit(int depositId)
        {
            return _ServiceDal.GetMonthlyDeposit(depositId);
        }

        MonthlyDeposit ILoanService.GetLatestMonthlyDeposit(int memberId)
        {
            MonthlyDeposit deposit = _ServiceDal.GetLatestMonthlyDeposit(memberId);
            if (deposit == null)
            {
                deposit = new MonthlyDeposit();
                deposit.Month = Month.June;
                deposit.Year = 2012;
            }
            return deposit;
        }

        Expense ILoanService.SaveExpense(Expense expense)
        {
            expense.IsActive = true;
            expense.Id = _ServiceDal.SaveExpense(expense);
            return expense;
        }

        void ILoanService.DeleteExpense(int expenseId)
        {
            _ServiceDal.DeleteExpense(expenseId);
        }

        Expense ILoanService.GetExpense(int expenseId)
        {
            return _ServiceDal.GetExpense(expenseId);
        }

        ExpenseCollection ILoanService.GetExpenses(DateTime dateFrom, DateTime dateTo, int expenseHeadId)
        {
            ExpenseCollection expenses = _ServiceDal.GetExpenses(dateFrom, dateTo, expenseHeadId);
            return expenses == null ? new ExpenseCollection() : expenses;
        }

        Income ILoanService.SaveIncome(Income income)
        {
            income.IsActive = true;
            income.Id = _ServiceDal.SaveIncome(income);
            return income;
        }

        void ILoanService.DeleteIncome(int incomeId)
        {
            _ServiceDal.DeleteIncome(incomeId);
        }

        Income ILoanService.GetIncome(int incomeId)
        {
            return _ServiceDal.GetIncome(incomeId);
        }

        ExpenseHead ILoanService.SaveExpenseHead(ExpenseHead expenseHead)
        {
            if (_ServiceDal.IsDuplicateExpenseHead(expenseHead.Id, expenseHead.Name))
            {
                throw new InvalidDataException(string.Format("Expense head \"{0}\" already exists.", expenseHead.Name));
            }
            expenseHead.IsActive = true;
            expenseHead.Id = _ServiceDal.SaveExpenseHead(expenseHead);
            return expenseHead;
        }

        IncomeCollection ILoanService.GetIncomes(DateTime dateFrom, DateTime dateTo, int incomeHeadId)
        {
            IncomeCollection incomes = _ServiceDal.GetIncomes(dateFrom, dateTo, incomeHeadId);
            return incomes == null ? new IncomeCollection() : incomes;
        }

        void ILoanService.DeleteExpenseHead(int expenseHeadId)
        {
            _ServiceDal.DeleteExpenseHead(expenseHeadId);
        }

        ExpenseHead ILoanService.GetExpenseHead(int expenseHeadId)
        {
            return _ServiceDal.GetExpenseHead(expenseHeadId);
        }

        ExpenseHeadCollection ILoanService.GetExpenseHeads()
        {
            ExpenseHeadCollection expenseHeads = _ServiceDal.GetExpenseHeads();
            return expenseHeads == null ? new ExpenseHeadCollection() : expenseHeads;
        }

        IncomeHead ILoanService.SaveIncomeHead(IncomeHead incomeHead)
        {
            if (incomeHead.Id == 1)
            {
                throw new Exception("This is a system data. You can't modify this.\n");
            }
            if (_ServiceDal.IsDuplicateIncomeHead(incomeHead.Id, incomeHead.Name))
            {
                throw new InvalidDataException(string.Format("Income head \"{0}\" already exists.", incomeHead.Name));
            }
            incomeHead.IsActive = true;
            incomeHead.Id = _ServiceDal.SaveIncomeHead(incomeHead);
            return incomeHead;
        }

        void ILoanService.DeleteIncomeHead(int incomeHeadId)
        {
            if (incomeHeadId == 1)
            {
                throw new Exception("This is a system data. You can't delete this.\n");
            }
            _ServiceDal.DeleteIncomeHead(incomeHeadId);
        }

        IncomeHead ILoanService.GetIncomeHead(int incomeHeadId)
        {
            return _ServiceDal.GetIncomeHead(incomeHeadId);
        }

        IncomeHeadCollection ILoanService.GetIncomeHeads()
        {
            IncomeHeadCollection incomeHeads = _ServiceDal.GetIncomeHeads();
            return incomeHeads == null ? new IncomeHeadCollection() : incomeHeads;
        }

        LoanDisbursement ILoanService.SaveLoanDisbursement(LoanDisbursement disbursement)
        {
            disbursement.IsActive = true;
            disbursement.Id = _ServiceDal.SaveLoanDisbursement(disbursement);
            return disbursement;
        }

        void ILoanService.DeleteLoanDisbursement(int disbursementId)
        {
            _ServiceDal.DeleteLoanDisbursement(disbursementId);
        }

        LoanDisbursement ILoanService.GetLoanDisbursement(int disbursementId)
        {
            return _ServiceDal.GetLoanDisbursement(disbursementId);
        }

        LoanDisbursementCollection ILoanService.GetLoanDisbursements()
        {
            LoanDisbursementCollection disbursements = _ServiceDal.GetLoanDisbursements();
            return disbursements == null ? new LoanDisbursementCollection() : disbursements;
        }

        LoanRepayment ILoanService.SaveLoanRepayment(LoanRepayment repayment)
        {
            repayment.IsActive = true;
            repayment.Id = _ServiceDal.SaveLoanRepayment(repayment);
            return repayment;
        }

        void ILoanService.DeleteLoanRepayment(int repaymentId)
        {
            _ServiceDal.DeleteLoanRepayment(repaymentId);
        }

        LoanRepayment ILoanService.GetLoanRepayment(int repaymentId)
        {
            return _ServiceDal.GetLoanRepayment(repaymentId);
        }

        LoanRepaymentCollection ILoanService.GetLoanRepayments()
        {
            LoanRepaymentCollection repayments = _ServiceDal.GetLoanRepayments();
            return repayments == null ? new LoanRepaymentCollection() : repayments;
        }

        void ILoanService.BackupDatabase(string backupDir)
        {
            if (!Directory.Exists(backupDir))
            {
                throw new ApplicationException(string.Format("The backup directory {0} doesn't exixt", backupDir));
            }
            else
            {
                string root = Directory.GetDirectoryRoot(backupDir);
                if (string.Compare(root, backupDir, true) == 0)
                {
                    throw new ApplicationException(string.Format("Please create/select a folder under {0} directory, and backup in that folder.", backupDir));
                }
            }
            string backupFileName = string.Format("LoanManagementSystem_{0}-{1}-{2}.bak", DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
            string backupPath = Path.Combine(backupDir, backupFileName);
            _ServiceDal.BackupDatabase(backupPath);
        }

        void ILoanService.RestoreDatabase(string backupPath)
        {
            _ServiceDal.RestoreDatabase(backupPath);
        }

        void ILoanService.SaveSystemConfig(SystemConfig sysConfig)
        {
            sysConfig.Id = _ServiceDal.SaveSystemConfig(sysConfig);
        }

        SystemConfig ILoanService.GetSystemConfig(int sysConfigId)
        {
            SystemConfig sysConfig = _ServiceDal.GetSystemConfig(sysConfigId);
            sysConfig.ConfigDetails = _ServiceDal.GetConfigDetails(sysConfigId);
            return sysConfig;
        }

        void ILoanService.SaveConfigDetail(SystemConfigDetail configDetail)
        {
            if (_ServiceDal.IsDuplicateSysConfigDetail(configDetail.Id, configDetail.SysConfigId, configDetail.YearFrom))
            {
                throw new InvalidDataException(string.Format("Config detail in fiscal year {0} already exists.", configDetail.FiscalYear));
            }
            configDetail.Id = _ServiceDal.SaveConfigDetail(configDetail);
        }

        SystemConfigDetailCollection ILoanService.GetConfigDetails(int sysConfigId)
        {
            return _ServiceDal.GetConfigDetails(sysConfigId);
        }

        void ILoanService.DeleteSysConfigDetail(int configDetailId)
        {
            _ServiceDal.DeleteSysConfigDetail(configDetailId);
        }

        bool ILoanService.MonthlyDepositExists(int memberId)
        {
            return _ServiceDal.MonthlyDepositExists(memberId);
        }

        void ILoanService.UpdateAllInitialBalance(int updateBy)
        {
            _ServiceDal.UpdateAllInitialBalance(updateBy);
        }
    }
}
