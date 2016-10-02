using System.Collections.Generic;
using System;
using System.Text;

namespace DefenseTraining.Model
{
    public class Training : ModelBase
    {
        public Training()
        {
            Course = new Course();
            Country = new Country();
            Trainees = new List<Trainee>();
            HostResponsibilities = new List<ExpenseHead>();
            Reminders = new List<Reminder>();
            RequiredDocs = new List<RequiredDoc>();
        }

        public Course Course { get; set; }
        public Country Country { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string MedicalDate { get; set; }
        public string DocumentDate { get; set; }
        public string BriefingDate { get; set; }
        public string NominationDate { get; set; }
        public string AcceptanceDate { get; set; }
        public string DocForwardDate { get; set; }
        public string PaymentFrom { get; set; }
        public string PaymentTo { get; set; }
        public double UsdRate { get; set; }
        public List<ExpenseHead> HostResponsibilities { get; set; }
        public List<Trainee> Trainees { get; set; }
        public List<Reminder> Reminders { get; set; }
        public List<RequiredDoc> RequiredDocs { get; set; }
        public string CourseName { get { return Course.Name; } }
        public string CommaSeparatedTrainees 
        {
            get
            {
                StringBuilder trainees = new StringBuilder();
                foreach (Trainee trainee in Trainees)
                {
                    trainees.Append(string.Format("{0}- {1} {2}, ", trainee.Person.PersonNo, trainee.Rank.Name, trainee.Person.Name));
                }
                return trainees.ToString().TrimEnd(", ".ToCharArray());
            }
        }

        public string Total 
        {
            get
            {
                double total = 0;
                foreach (Trainee trainee in Trainees)
                {
                    total += double.Parse(trainee.Total);
                }
                return total == 0 ? "0.00" : total.ToString("##########.##");
            }
        }

        public void Validate()
        {
            string message = string.Empty;
            foreach (ExpenseHead hostResp in this.HostResponsibilities)
            {
                foreach (Trainee trainee in this.Trainees)
                {
                    if (trainee.Expenses.Exists(x => x.Head.Id == hostResp.Id && x.IsSelected))
                    {
                        message += string.Format("Expense \"{0}\" is already taken care of by host country. Your don't need to include this in self expense\n", hostResp.Name);
                    }
                    if (trainee.SpouseExpenses.Exists(x => x.Head.Id == hostResp.Id && x.IsSelected))
                    {
                        message += string.Format("Expense \"{0}\" is already taken care of by host country. Your don't need to include this in spouse expense\n", hostResp.Name);
                    }
                    if (trainee.KidExpenses.Exists(x => x.Head.Id == hostResp.Id && x.IsSelected))
                    {
                        message += string.Format("Expense \"{0}\" is already taken care of by host country. Your don't need to include this in kids' expense\n", hostResp.Name);
                    }
                }
            }
            if (!string.IsNullOrEmpty(message))
            {
                throw new Exception(message);
            }
        }
    }
}
