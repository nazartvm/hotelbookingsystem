using HotelBookingSystem.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Models
{
    public class RoomResponseModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public bool RoomStatus { get; set; }
    }
}
