using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Uqs.AppointmentBooking.Domain.Database;
using Uqs.AppointmentBooking.Domain.Report;
using Uqs.AppointmentBooking.Domain.Services;

namespace Uqs.AppointmentBooking.Domain
{
    public interface ISlotsService
    {
        Task<Slots> GetAvailableSlotsForEmployee(int serviceId);
    }

    public class SlotsService : ISlotsService
    {
        private ApplicationContext _context;
        private readonly ApplicationSettings _settings;
        private readonly DateTime _now;
        private readonly TimeSpan _roundingIntervalSpan;

        public SlotsService(ApplicationContext context, INowService nowService, IOptions<ApplicationSettings> settings)
        {
            _context = context;
            _settings = settings.Value;
            _roundingIntervalSpan = TimeSpan.FromMinutes(_settings.RoundUpInMin);
            _now = RoundUpToNearest(nowService.Now);
        }


        public async Task<Slots> GetAvailableSlotsForEmployee(int serviceId)
        {
            var service = await _context.Services!.SingleOrDefaultAsync(m => m.Id == serviceId);

            if (service is null)
            {
                throw new ArgumentException("Record not found", nameof(serviceId));
            }

            return null;
        }

        private DateTime RoundUpToNearest(DateTime dt)
        {
            var ticksInSpan = _roundingIntervalSpan.Ticks;
            return new DateTime((dt.Ticks + ticksInSpan - 1)
                / ticksInSpan * ticksInSpan, dt.Kind);
        }
    }
}