using System;

namespace Dit.Lms.Api
{
    public class MemberReportData
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public long VoterIdNo { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Institution { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public double InitialBalance { get; set; }
        public double PresentBalance { get; set; }
        public string Nominee { get; set; }
        public string NomineesPhoto { get; set; }
        public string RelationWithNominee { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
