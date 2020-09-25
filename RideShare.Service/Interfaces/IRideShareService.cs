using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Service.Interfaces
{
    public interface IRideShareService
    {

        bool ShareRide(string journeyId);

    }
}
