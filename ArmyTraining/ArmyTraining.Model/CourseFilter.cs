
namespace ArmyTraining.Model
{
    public class CourseFilter
    {
        public CourseFilter()
        {
            Keyword = string.Empty;
            PageNumber = 1;
            Count = int.MaxValue;
        }
        public int CourseTypeId { get; set; }
        public string Keyword { get; set; }
        public int PageNumber { get; set; }
        public int Count { get; set; }
        public int TrainingBkgId { get; set; }
    }
}
