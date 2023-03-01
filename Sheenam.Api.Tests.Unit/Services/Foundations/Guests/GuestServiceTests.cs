//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//==================================================

using FluentAssertions;
using Moq;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Services.Foundations.Guests;
using System.Net.Sockets;
using Tynamix.ObjectFiller;
using Xunit;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            
            this.guestService = 
                new GuestService(storageBroker: this.storageBrokerMock.Object);
        }

        private static Guest CreateRandomGuest() =>
             CreateGuestFiller(date: GetRandomDataTimeOffset()).Create();

        private static DateTimeOffset GetRandomDataTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();
        private static Filler<Guest> CreateGuestFiller(DateTimeOffset date)
        {
            var filler = new Filler<Guest>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);


            return filler;
        }

    }
}
