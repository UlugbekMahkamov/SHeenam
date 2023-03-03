using Xeptions;

namespace Sheenam.Api.Services.Foundations.Guests.Exceptions
{
    public class GuestValidationsException: Xeption
    {
        public GuestValidationsException(Xeption innerException)
           : base(message: "Guest validation error occurred, fix the errors and try again",
                 innerException)
        { }
    }
}
