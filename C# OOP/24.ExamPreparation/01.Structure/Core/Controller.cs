using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotels;

        private List<string> roomTypes = new List<string>() { "Apartment", "DoubleBed", "Studio" };
        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                hotels.AddNew(new Hotel(hotelName, category));
                return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
            }

            return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);

        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().FirstOrDefault(h => h.Category == category) == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            var orderedHotels = hotels.All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.FullName);
            foreach (var item in orderedHotels)
            {
                var room = item.Rooms
                    .All()
                    .Where(r => r.PricePerNight > 0)
                    .OrderBy(r => r.BedCapacity)
                    .FirstOrDefault(r => r.BedCapacity >= adults + children);

                if (room != null)
                {
                    int bookingNumber = item.Bookings.All().Count() + 1;
                    IBooking booking = new Booking(room, duration, adults, children, bookingNumber);
                    item.Bookings.AddNew(booking);
                    return String.Format(OutputMessages.BookingSuccessful, bookingNumber, item.FullName);
                }
            }

            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Hotel name: {hotel.FullName}");
            stringBuilder.AppendLine($"--{hotel.Category} star hotel");
            stringBuilder.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            stringBuilder.AppendLine($"--Bookings:");
            stringBuilder.AppendLine();
            if (hotel.Bookings.All().Count() == 0)
            {
                stringBuilder.AppendLine("none");
            }
            else
            {
                foreach (var item in hotel.Bookings.All())
                {
                    stringBuilder.AppendLine(item.BookingSummary());
                    stringBuilder.AppendLine();
                }
            }


            return stringBuilder.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            switch (roomTypeName)
            {
                case nameof(DoubleBed):
                    room = new DoubleBed();
                    break;
                case nameof(Studio):
                    room = new Studio();
                    break;
                case nameof(Apartment):
                    room = new Apartment();
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
