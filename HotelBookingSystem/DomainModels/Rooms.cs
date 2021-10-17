using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.DomainModels
{
    public class Rooms
    {
        public int Id { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomNo { get; set; }
        public string AboutRoom { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
    }
    public enum RoomType
    {
        Single,
        Double
    }
}
