using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uqs.AppointmentBooking.Domain.Database;
using Uqs.AppointmentBooking.Domain.DomainObjects;

namespace Uqs.AppointmentBooking.Domain.Services
{
    public class ServicesService
    {
        private readonly ApplicationContext _context;

        public ServicesService(ApplicationContext context) { _context = context; }

        public async Task<IEnumerable<Service>> GetActiveServices()
        {
            return await _context.Services!.Where(m => m.IsActive).ToArrayAsync();
        }

        
    }
}
