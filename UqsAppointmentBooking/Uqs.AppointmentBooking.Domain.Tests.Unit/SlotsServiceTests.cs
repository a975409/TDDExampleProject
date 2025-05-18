using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uqs.AppointmentBooking.Domain.Services;
using Uqs.AppointmentBooking.Domain.Tests.Unit.Fakes;

namespace Uqs.AppointmentBooking.Domain.Tests.Unit
{
    public class SlotsServiceTests
    {
        private readonly ApplicationContextFakeBuilder _ctxBldr = new ApplicationContextFakeBuilder();
        private readonly INowService _nowService = Substitute.For<INowService>();
        private readonly ApplicationSettings _applicationSettings =
            new()
            {
                OpenAppointmentInDays = 7,
                RoundUpInMin = 5,
                RestInMin = 5
            };
        private readonly IOptions<ApplicationSettings> _settings =
            Substitute.For<IOptions<ApplicationSettings>>();
        private SlotsService? _sut;

        public SlotsServiceTests()
        {
            _settings.Value.Returns(_applicationSettings);
        }

        [Fact]
        public async Task GetAvailableSlotsForEmployee_ServiceIdNoFound_ArgumentException()
        {
            // Arrange
            var ctx = _ctxBldr.Build();
            _sut = new SlotsService(ctx, _nowService, _settings);

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetAvailableSlotsForEmployee(-1));

            // Assert
            Assert.IsType<ArgumentException>(exception);
        }
    }
}
