using RideShare.Data;
using RideShareApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Service
{
    public interface IJourneyService
    {
        List<Journey> GetAvailableJourneys(string from, string to);
        void AddJourney(AddJourneyRequestModel journey);
        void UpdateJourneyStatus(string journeyId, int journeyStatus);
    }
}
