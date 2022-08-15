using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using System;

namespace Schedule.Data
{
    public class ScheduleDbContext:IdentityDbContext
    {
        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) :base(options)
        {

        }
        DbSet<Scheduling> Schedulings { get; set; }
    }
}
