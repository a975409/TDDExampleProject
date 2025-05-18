using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uqs.AppointmentBooking.Domain.Database;

namespace Uqs.AppointmentBooking.Domain.Tests.Unit.Fakes
{
    public class ApplicationContextFake : ApplicationContext
    {
        public ApplicationContextFake() : base(new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: $"AppointmentBookingTest-{Guid.NewGuid()}")
            .Options)
        { }
    }
}
