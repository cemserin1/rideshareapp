using MongoDB.Bson.IO;
using Newtonsoft.Json;
using RideShare.Data.Interfaces;
using RideShare.Data.Models;
using RideShare.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RideShare.Service
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;
        private readonly IRouteRepository _routeRepository;

        public MapService(IMapRepository mapRepository, IRouteRepository routeRepository)
        {
            _mapRepository = mapRepository;
            _routeRepository = routeRepository;
        }

        //This is only executed once just to create a map.
        public void GenerateCityMap()
        {
            List<Map> mapList = new List<Map>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Map map = new Map()
                    {
                        CoordinateX = i,
                        CoordinateY = j,
                        CityName = RandomString(5)
                    };
                    mapList.Add(map);
                }
            }
            _mapRepository.CreateMany(mapList);
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public List<string> GetCityNames()
        {
            return _mapRepository.Get().Result.Select(c => c.CityName).ToList();
        }
        public void CreateRoute(string from, string to)
        {
            var mapList = _mapRepository.Get().Result;
            var fromCity = mapList.Single(c => c.CityName == from);
            var toCity = mapList.Single(c => c.CityName == to);
            List<Map> citiesPassedBy = new List<Map>();
            #region set x coordinates as equal
            if (fromCity.CoordinateX > toCity.CoordinateX)
            {
                for (int i = 0; i < (fromCity.CoordinateX - toCity.CoordinateX); i++)
                {
                    var cityPassedByCoordinateX = fromCity.CoordinateX - i - 1;
                    var cityPassedBy = mapList.Single(c => c.CoordinateX == cityPassedByCoordinateX && c.CoordinateY == fromCity.CoordinateY);
                    citiesPassedBy.Add(cityPassedBy);
                }
            }
            else if (fromCity.CoordinateX < toCity.CoordinateX)
            {
                for (int i = 0; i < (toCity.CoordinateX - fromCity.CoordinateX); i++)
                {
                    var cityPassedByCoordinateX = fromCity.CoordinateX + i + 1;
                    var cityPassedBy = mapList.Single(c => c.CoordinateX == cityPassedByCoordinateX && c.CoordinateY == fromCity.CoordinateY);
                    citiesPassedBy.Add(cityPassedBy);
                }
            }
            #endregion

            #region set y coordinates as equal
            if (fromCity.CoordinateY > toCity.CoordinateY)
            {
                for (int i = 0; i < (fromCity.CoordinateY - toCity.CoordinateY); i++)
                {
                    var cityPassedByCoordinateY = fromCity.CoordinateY - i - 1;
                    var lastCityPassed = citiesPassedBy.Last();
                    int fromCityX = fromCity.CoordinateX;
                    if (lastCityPassed != null)
                    {
                        fromCityX = lastCityPassed.CoordinateX;
                    }

                    var cityPassedBy = mapList.Single(c => c.CoordinateY == cityPassedByCoordinateY && c.CoordinateX == fromCityX);
                    citiesPassedBy.Add(cityPassedBy);
                }
            }
            else if (fromCity.CoordinateY < toCity.CoordinateY)
            {
                for (int i = 0; i < (toCity.CoordinateY - fromCity.CoordinateY); i++)
                {
                    var cityPassedByCoordinateY = fromCity.CoordinateY + i + 1;
                    var lastCityPassed = citiesPassedBy.Last();
                    int fromCityX = fromCity.CoordinateX;
                    if (lastCityPassed != null)
                    {
                        fromCityX = lastCityPassed.CoordinateX;
                    }
                    var cityPassedBy = mapList.Single(c => c.CoordinateY == cityPassedByCoordinateY && c.CoordinateX == fromCityX);
                    citiesPassedBy.Add(cityPassedBy);
                }
            }
            //var numberOfCities = citiesPassedBy.Count;

            Route route = new Route();
            route.StartCity = fromCity;
            route.EndCity = toCity;
            route.RoutesPassedBy = citiesPassedBy;
            _routeRepository.Create(route);

            #endregion
        }

        public List<Route> GetAvailableRoutes(string from, string to)
        {
            var routes = _routeRepository.Get().Result.ToList();
            var availableRoutes = new List<Route>();
            foreach (var route in routes)
            {
                if (route.RoutesPassedBy.Any(c => c.CityName == from) && route.RoutesPassedBy.Any(c => c.CityName == to))
                {
                    var cityFrom = route.RoutesPassedBy.Single(c => c.CityName == from);
                    var cityTo = route.RoutesPassedBy.Single(c => c.CityName == to);
                    //a last minute fix to check whether the route is reverse or not. If reverse, should not be listed.                   
                    if (route.RoutesPassedBy.IndexOf(cityFrom) < route.RoutesPassedBy.IndexOf(cityTo))
                    {
                        availableRoutes.Add(route);
                    }
                }
            }
            return availableRoutes;
        }
    }
}
