using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Models
{
    public class UserBookedRoomViewModel
    {
        public int RoomNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string RoomOwnerName { get; set; }
        public string RoomType { get; set; }

        public string BookedUserName { get; set; }
    }
}
