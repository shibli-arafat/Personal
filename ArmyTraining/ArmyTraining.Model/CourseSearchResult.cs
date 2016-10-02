
namespace ArmyTraining.Model
{
    public class CourseSearchResult
    {
        public CourseSearchResult()
        {
            Courses = new CourseCollection();
        }
        public CourseCollection Courses { get; set; }
        public int TotalCount { get; set; }
    }
}
