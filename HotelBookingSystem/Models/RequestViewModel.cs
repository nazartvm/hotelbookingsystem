using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Models
{
    public class RequestViewModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string RoomType { get; set; }
    }
}
