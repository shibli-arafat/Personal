namespace DefenseTraining.Model
{
    public class JointStatement
    {
        public JointStatement()
        {
        }

        public string Service { get; set; }
        public int CourseAvailed { get; set; }
        public int CourseAllotted { get; set; }
        public int SeminarAvailed { get; set; }
        public int SeminarAllotted { get; set; }
        public int SmeeAvailed { get; set; }
        public int SmeeAllotted { get; set; }
        public int VisitAvailed { get; set; }
        public int VisitAllotted { get; set; }
        public int CompetitionAvailed { get; set; }
        public int CompetitionAllotted { get; set; }
        public int ExcerciseAvailed { get; set; }
        public int ExcerciseAllotted { get; set; }
        public int TotlaAvailed { get { return (CourseAvailed + SeminarAvailed + SmeeAvailed + VisitAvailed + CompetitionAvailed + ExcerciseAvailed); } }
        public int TotalAllotted { get { return (CourseAllotted + SeminarAllotted + SmeeAllotted + VisitAllotted + CompetitionAllotted + ExcerciseAllotted); } }
    }
}
