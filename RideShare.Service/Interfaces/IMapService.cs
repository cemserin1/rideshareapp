using RideShare.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Service.Interfaces
{
    public interface IMapService
    {
        void GenerateCityMap();

        List<string> GetCityNames();

        void CreateRoute(string from, string to);

        List<Route> GetAvailableRoutes(string from, string to);
    }
}
