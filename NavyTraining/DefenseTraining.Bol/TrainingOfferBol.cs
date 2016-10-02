using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class TrainingOfferBol
    {
        private TrainingOfferDal _Dal;

        public TrainingOfferBol()
        {
            _Dal = new TrainingOfferDal();
        }

        public List<TrainingOffer> GetTrainingOffers()
        {
            return _Dal.GetTrainingOffers();
        }

        public TrainingOffer GetTrainingOffer(int id)
        {
            return _Dal.GetTrainingOffer(id);
        }

        public void DeleteTrainingOffer(int id)
        {
            _Dal.DeleteTrainingOffer(id);
        }

        public TrainingOffer SaveTrainingOffer(TrainingOffer trainingOffer)
        {
            if (_Dal.TrainingOfferExists(trainingOffer.Id, trainingOffer.StartDate, trainingOffer.Name))
            {
                throw new Exception("Training Offer in the same year already exists. Please enter unique year.");
            }
            trainingOffer.Id = _Dal.SaveTrainingOffer(trainingOffer);
            return trainingOffer;
        }
    }
}
