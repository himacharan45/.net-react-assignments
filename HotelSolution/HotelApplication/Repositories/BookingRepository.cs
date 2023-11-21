using System;
using System.Collections.Generic;
using HotelApplication.Contexts;
using HotelApplication.Contexts.HotelApplication.Contexts;
using HotelApplication.Exceptions;
using HotelApplication.Interfaces;
using HotelApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApplication.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        HotelContext context;

        public BookingRepository(HotelContext bookingContext)
        {
            context = bookingContext;
        }

        public string AddNewBooking(Booking booking)
        {
            try
            {
                int count = context.Bookings.Count();
                context.Bookings.Add(booking);
                context.SaveChanges();
                int newCount = context.Bookings.Count();

                if (newCount > count)
                {
                    List<Booking> bookings = new List<Booking>();
                    bookings = context.Bookings.ToList();
                    Booking booking1 = bookings.Last();
                    int rid = booking1.RoomId;
                    Room room = context.Rooms.Find(rid);

                    if (room.AvalaibleRooms < 1)
                    {
                        throw new DatabaseException("Oops, something went wrong. No available rooms.");
                    }
                    else
                    {
                        if (room != null)
                        {
                            int a = room.AvalaibleRooms;
                            a = a - 1;
                            room.AvalaibleRooms = a;
                            context.SaveChanges();
                        }
                    }
                    return "Record inserted successfully";
                }
                else
                {
                    throw new DatabaseException("Oops, something went wrong.");
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Error adding booking: {ex.Message}");
            }
        }

        public string DeletBooking(int id)
        {
            try
            {
                Booking booking = context.Bookings.Find(id);

                if (booking != null)
                {
                    int rid = booking.RoomId;
                    Room room = context.Rooms.Find(rid);
                    if (room != null)
                    {
                        int a = room.AvalaibleRooms;
                        a = a + 1;
                        room.AvalaibleRooms = a;
                        context.SaveChanges();
                    }
                    context.Bookings.Remove(booking);
                    context.SaveChanges();
                    return "Booking is deleted";
                }
                else
                {
                    throw new NotFoundException("Booking is not available");
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Error deleting booking: {ex.Message}");
            }
        }

        public List<Booking> GetAllBookings()
        {
            try
            {
                return context.Bookings.ToList();
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Error getting all bookings: {ex.Message}");
            }
        }

        public string UpdateBooking(Booking newbooking)
        {
            try
            {
                Booking booking = context.Bookings.FirstOrDefault(d => d.BookingId == newbooking.BookingId);
                if (booking != null)
                {
                    booking.BookingId = newbooking.BookingId;
                    booking.HotelId = newbooking.HotelId;
                    booking.RoomId = newbooking.RoomId;
                    booking.CheckInDate = newbooking.CheckInDate;
                    booking.CheckOutDate = newbooking.CheckOutDate;
                    booking.NoOfPeople = newbooking.NoOfPeople;
                    context.SaveChanges();
                    return "Booking details are updated";
                }
                else
                {
                    throw new NotFoundException("Booking details are not available");
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Error updating booking: {ex.Message}");
            }
        }

        public List<Booking> GetBookingById(int id)
        {
            try
            {
                List<Booking> bookinglist = context.Bookings.Where(d => d.UserId == id).ToList();
                return bookinglist;
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Error getting bookings by user ID: {ex.Message}");
            }
        }
    }
}
