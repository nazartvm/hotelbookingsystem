using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.DomainModels
{
    public class RoomBookingRelation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Rooms Rooms { get; set; }
        public int RoomBookedUserId { get; set; }
        [ForeignKey("RoomBookedUserId")]
        public User BookedUser { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
