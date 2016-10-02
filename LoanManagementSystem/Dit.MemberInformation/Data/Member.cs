using System;
using System.Text;

namespace Dit.Lms.Api
{
    public class Member : DreamData
    {
        public Member()
        {
            Name = string.Empty;
            MothersName = string.Empty;
            FathersName = string.Empty;
            PresentAddress = string.Empty;
            PermanentAddress = string.Empty;
            Nationality = string.Empty;
            Nominee = string.Empty;
            DateOfBirth = DateTime.Today;
        }

        public Member(string name)
            : this()
        {
            Name = name;
        }

        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Photo { get { return string.Format("{0}_Photo.jpg", Id); } }
        public long VoterIdNo { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Institution { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public Religion Religion { get; set; }
        public double InitialBalance { get; set; }
        public double PresentBalance { get; set; }
        public string Nominee { get; set; }
        public string NomineesPhoto { get { return string.Format("{0}_Nominee.jpg", Id); } }
        public Relation RelationWithNominee { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        internal void Validate()
        {
            StringBuilder messageBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(Name)) messageBuilder.AppendLine("Name can't be be blank.");
            if (VoterIdNo == 0) messageBuilder.AppendLine("Voter ID No. can't be be blank.");
            if (string.IsNullOrEmpty(MothersName)) messageBuilder.AppendLine("Mother's name can't be be blank.");
            if (string.IsNullOrEmpty(FathersName)) messageBuilder.AppendLine("Father/Husband's name can't be be blank.");
            if (string.IsNullOrEmpty(PresentAddress)) messageBuilder.AppendLine("Present address can't be be blank.");
            if (string.IsNullOrEmpty(Mobile)) messageBuilder.AppendLine("Please enter mobile number.");
            if (string.IsNullOrEmpty(Nationality)) messageBuilder.AppendLine("Nationality can't be blank.");
            if (DateOfBirth.Date > DateTime.Today.AddYears(-18)) messageBuilder.AppendFormat("Date of birth must be less or equal to {0}.\n", DateTime.Today.AddYears(-18).ToString("dd/MM/yyyy"));
            if (string.IsNullOrEmpty(Nominee)) messageBuilder.Append("Nominee can't be blank.");
            if (!string.IsNullOrEmpty(messageBuilder.ToString())) throw new InvalidDataException(messageBuilder.ToString());
        }

        public override string ToString()
        {
            if (MemberId == 0)
            {
                return string.Format("{0}", Name);
            }
            else
            {
                return string.Format("{0}- {1}", MemberId, Name);
            }
        }

        public MemberReportData ToReportData()
        {
            MemberReportData reportData = new MemberReportData();
            reportData.DateOfBirth = this.DateOfBirth;
            reportData.Email = this.Email;
            reportData.FathersName = this.FathersName;
            reportData.InitialBalance = this.InitialBalance;
            reportData.Institution = this.Institution;
            reportData.MemberId = this.MemberId;
            reportData.Mobile = this.Mobile;
            reportData.MothersName = this.MothersName;
            reportData.Name = this.Name;
            reportData.Nationality = this.Nationality;
            reportData.Nominee = this.Nominee;
            reportData.NomineesPhoto = this.NomineesPhoto;
            reportData.PermanentAddress = this.PermanentAddress;
            reportData.Photo = this.Photo;
            reportData.PresentAddress = this.PresentAddress;
            reportData.PresentBalance = this.PresentBalance;
            reportData.RelationWithNominee = this.RelationWithNominee.ToString();
            reportData.Religion = this.Religion.ToString();
            reportData.VoterIdNo = this.VoterIdNo;
            return reportData;
        }
    }
}
