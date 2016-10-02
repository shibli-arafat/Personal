namespace DefenseTraining.Model
{
    public class ModelBase
    {
        public ModelBase()
        {
            IsActive = true;
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
