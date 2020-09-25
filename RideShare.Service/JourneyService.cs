using RideShare.Data;
using RideShare.Service.Utilities.Mappers;
using RideShareApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.Service
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository;

        public JourneyService(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }

        public List<Journey> GetAvailableJourneys(string from, string to)
        {
            return _journeyRepository.Get().Result.Where(j => j.From == from && j.To == to && j.JourneyStatus == (int)JourneyStatus.Active).ToList();
        }

        public void AddJourney(AddJourneyRequestModel journey)
        {
            _journeyRepository.Create(JourneyMapper.ToEntity(journey));
        }

        public void UpdateJourneyStatus(string journeyId, int journeyStatus)
        {
            var selectedJourney = _journeyRepository.Get(journeyId).Result;
            selectedJourney.JourneyStatus = journeyStatus;
            _journeyRepository.Update(selectedJourney, selectedJourney.Id);
        }
    }
}
