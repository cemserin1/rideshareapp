using RideShare.Data;
using RideShareApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Service.Utilities.Mappers
{
    public static class JourneyMapper
    {
        public static Journey ToEntity(AddJourneyRequestModel model)
        {
            return new Journey()
            {
                AvailableSeats = model.AvailableSeats,
                DepartureDate = model.DepartureDate,
                From = model.From,
                JourneyStatus = model.JourneyStatus,
                To = model.To,
                UserId = model.UserId,
                VehicleId = model.VehicleId
            };
        }

        public static AddJourneyRequestModel ToModel(Journey entity)
        {
            return new AddJourneyRequestModel()
            {
                AvailableSeats = entity.AvailableSeats,
                DepartureDate = entity.DepartureDate,
                From = entity.From,
                JourneyStatus = entity.JourneyStatus,
                To = entity.To,
                UserId = entity.UserId,
                VehicleId = entity.VehicleId
            };
        }

    }
}
