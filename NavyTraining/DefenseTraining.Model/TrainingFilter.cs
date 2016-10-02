namespace DefenseTraining.Model
{
    public class TrainingFilter
    {
        public int Id { get; set; }
        public string PersonNo { get; set; }        
        public int RankId { get; set; }
        public int EventTypeId { get; set; }
        public int CourseId { get; set; }
        public int CountryId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int StartIndex { get; set; }
        public int DataPerPage { get; set; }
    }
}
