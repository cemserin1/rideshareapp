using RideShare.Data;
using RideShare.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Service
{
    public class RideShareService : IRideShareService
    {

        private readonly IJourneyRepository _journeyRepository;

        public RideShareService(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }

        private bool CheckForAvailableSeats(string journeyId)
        {
            return _journeyRepository.Get(journeyId).Result.AvailableSeats == 0 ? false : true;
        }

        public bool ShareRide(string journeyId)
        {
            if (!CheckForAvailableSeats(journeyId))
                return false;

            var selectedJourney = _journeyRepository.Get(journeyId).Result;
            selectedJourney.AvailableSeats--;
            _journeyRepository.Update(selectedJourney, selectedJourney.Id);
            return true;
        }
    }
}
