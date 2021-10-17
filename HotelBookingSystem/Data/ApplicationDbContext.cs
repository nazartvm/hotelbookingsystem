using HotelBookingSystem.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingSystem.Data
{
    public class ApplicationDbContext :IdentityDbContext<User,Role,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RoomBookingRelation> RoomBookingRelation { get; set; }
    }
}
