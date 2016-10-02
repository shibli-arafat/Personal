using System;

namespace ArmyTraining.Model
{
    public class TrainingReport
    {
        public int SerialNo { get; set; }
        public int TrainingId { get; set; }
        public string Country { get; set; }
        public string SponsorCountry { get; set; }
        public string Trainee
        {
            get
            {
                if (string.IsNullOrEmpty(this.Decoration))
                {
                    return string.Format("{0} {1} {2}, {3}", this.PersonNo, this.Rank, this.PersonName, this.ServiceName);
                }
                else
                {
                    return string.Format("{0} {1} {2}, {3}, {4}", this.PersonNo, this.Rank, this.PersonName, this.Decoration, this.ServiceName);
                }
            }
        }
        public string Course { get; set; }
        public string Duration { get { return string.Format("{0}- {1}", this.StartDate.ToString("d/M/yy"), this.EndDate.ToString("d/M/yy")); } }
        public string OfferLetterDate { get; set; }
        public string AcceptanceDate { get; set; }
        public string NominationDate { get; set; }
        //Draft Govt. Date
        public string DraftGoDate { get; set; }
        //Govt. Date
        public string GoDate { get; set; }
        public string SelectionLetterDate { get; set; }
        public string LetterToAllConcern { get; set; }
        public string Attachment { get; set; }
        public string Medical { get; set; }
        public string DocumentDate { get; set; }
        public string FltItinerary { get; set; }
        public string EntitlementDate { get; set; }
        public double FinancialInvolvement { get; set; }
        public string CourseType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string PersonNo { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string Rank { get; set; }
        public string Decoration { get; set; }
        public string ServiceName { get; set; }

        public double OtherExpense { get; set; }
        public string Sponsor { get; set; }
        public string TrainingLevel { get; set; }
        public string TrainingBkg { get; set; }
        public string DocName { get; set; }
        public string DocUrl 
        {
            get 
            {
                if (string.IsNullOrEmpty(DocName)) return string.Empty;
                return string.Format("Downloader.aspx?trainingId={0}&personId={1}&docName={2}", TrainingId, PersonId, DocName); 
            }
        }
        public string Remarks { get; set; }
    }
}
