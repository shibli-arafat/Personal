using System;

namespace ArmyTraining.Model.Trainings
{
    public class TrainingFlow
    {
        public int Id { get; set; }
        public DateTime? OfferLetterDate { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public DateTime? NominationDate { get; set; }
        public DateTime? DraftGoDate { get; set; }
        public DateTime? GoDate { get; set; }
        public DateTime? SelectionLetterDate { get; set; }
        public DateTime? LetterToAllConcernDate { get; set; }
        public DateTime? AttachmentDate { get; set; }
        public DateTime? MedicalDate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime? FltItineraryDate { get; set; }
        public DateTime? EntitlementDate { get; set; }
    }
}
