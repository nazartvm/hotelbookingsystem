using HotelBookingSystem.CustomAttribute;
using HotelBookingSystem.Data;
using HotelBookingSystem.DomainModels;
using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Controllers.APIController
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RoomAPIController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #region HotelOwnerAPI
        [Route("GetRooms"),HttpGet]
        public async Task<IActionResult> GetRoomsListByDate(string pickedDate)
        {
            List<RoomResponseModel> responsemodel = new List<RoomResponseModel>();
            var convertedDate=DateTime.ParseExact(pickedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var rooms = await _applicationDbContext.Rooms.ToListAsync();
            foreach(var item in rooms)
            {
                var roomBooking = await _applicationDbContext.RoomBookingRelation.Where(x => x.FromDate.Date == convertedDate.Date && x.RoomId==item.Id).Select(x => x).FirstOrDefaultAsync();
                responsemodel.Add(new RoomResponseModel()
                {
                    Id = item.Id,
                    RoomNumber = item.RoomNo,
                    RoomType = item.RoomType,
                    RoomStatus = roomBooking != null ? true : false
                }); 
            }
            return Ok(responsemodel);
        }
        [HttpPost,Route("CreateRoom")]
        public IActionResult CreateRoom([FromBody]Rooms room)
        {
            var existingRoomNo = _applicationDbContext.Rooms.Where(x => x.RoomNo == room.RoomNo).Select(x => x).FirstOrDefault();
            if (existingRoomNo != null)
            {
                return Ok(new Response()
                {
                    Message="Room No Should be unique",
                    Status="InComplete"
                });
            }
            room.OwnerId= (int)Request.HttpContext.Items["User"];
            _applicationDbContext.Rooms.Add(room);
            _applicationDbContext.SaveChanges();
            return Ok(new Response() { 
               Message="Success",
               Status="Done"
            });
        }

        [HttpGet,Route("GetUserRoomDetails")]
        public IActionResult GetUserRoomDetails(int userId)
        {
            return Ok(_applicationDbContext.RoomBookingRelation.Where(x => x.RoomBookedUserId == userId).Select(x => x).ToList());
        }


        #endregion
    }
}
