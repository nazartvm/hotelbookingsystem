using HotelBookingSystem.Data;
using HotelBookingSystem.DomainModels;
using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;
        private UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext, UserManager<User> userManager)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult History()
        {
            int userId = Convert.ToInt32(_userManager.GetUserId(User));
            var data = _applicationDbContext.RoomBookingRelation.Where(x => x.RoomBookedUserId == userId).ToList();
            List<UserBookedRoomViewModel> userBooked = new List<UserBookedRoomViewModel>();
            foreach (var item in data)
            {
                var room = _applicationDbContext.Rooms.Where(x => x.Id == item.RoomId).FirstOrDefault();
                userBooked.Add(new UserBookedRoomViewModel
                {
                    RoomNo = room.RoomNo,
                    FromDate = item.FromDate.Date,
                    ToDate = item.ToDate.Date,
                    RoomType = room.RoomType.ToString()
                });
            }
            return View(userBooked);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult submitdate(RequestViewModel model)
        {
            var fromDate = DateTime.ParseExact(model.FromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var toDate = DateTime.ParseExact(model.ToDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var roomType = (RoomType)Convert.ToInt32(model.RoomType);
            var BookedRoomDetails = _applicationDbContext.RoomBookingRelation.Where(x => x.FromDate.Date >= fromDate.Date && x.ToDate.Date <= toDate.Date && x.Rooms.RoomType == roomType).Select(x => x).ToList();
            var availableRoomDetails = _applicationDbContext.Rooms.Where(x => x.RoomType == roomType).ToList();
            foreach (var avRooms in availableRoomDetails)
            {
                foreach (var bkRooms in BookedRoomDetails)
                {
                    if (bkRooms.RoomId == avRooms.Id)
                    {
                        avRooms.Id = 0;
                    }
                }
            }
            if (availableRoomDetails.Where(x => x.Id != 0).Select(x => x).Count() >= 1)
            {
                int roomId = availableRoomDetails.Where(x => x.Id != 0).Select(x => x.Id).FirstOrDefault();
                int roomNo = availableRoomDetails.Where(x => x.Id != 0).Select(x => x.RoomNo).FirstOrDefault();
                availableRoomDetails = null;
                CreateUserRoomBooking(roomId, fromDate, toDate);
                ViewBag.RoomBookingMessage = "Room  Booked Successfully.Your Room No is " + roomNo;
                return View("Index");
            }
            ViewBag.RoomBookingMessage = "Room is not available. Please check on some other date";
            return View("Index");
        }
        private void CreateUserRoomBooking(int roomId, DateTime fromDate, DateTime toDate)
        {
            int userId = Convert.ToInt32(_userManager.GetUserId(User));
            var roomBookingRelation = new RoomBookingRelation();
            roomBookingRelation.RoomBookedUserId = userId;
            roomBookingRelation.RoomId = roomId;
            roomBookingRelation.FromDate = fromDate;
            roomBookingRelation.ToDate = toDate;
            _applicationDbContext.RoomBookingRelation.Add(roomBookingRelation);
            _applicationDbContext.SaveChanges();

        }
    }
}
