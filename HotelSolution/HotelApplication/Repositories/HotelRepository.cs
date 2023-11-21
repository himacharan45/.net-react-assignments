using System;
using System.Collections.Generic;
using HotelApplication.Contexts.HotelApplication.Contexts;
using HotelApplication.Exceptions;
using HotelApplication.Interfaces;
using HotelApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApplication.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext context;

        public HotelRepository(HotelContext hotelContext)
        {
            context = hotelContext;
        }

        public List<Hotel> GetAllHotels()
        {
            return context.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            Hotel hotel = context.Hotels.Find(id);
            if (hotel == null)
            {
                throw new NotFoundException($"Hotel with ID {id} not found");
            }
            return hotel;
        }

        public string AddHotel(Hotel hotel)
        {
            try
            {
                int count = context.Hotels.Count();
                context.Hotels.Add(hotel);
                context.SaveChanges();
                int newcount = context.Hotels.Count();

                if (newcount > count)
                {
                    return "Record inserted successfully";
                }
                else
                {
                    throw new DatabaseException("Oops, something went wrong while inserting");
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Error adding hotel: {ex.Message}");
            }
        }

        public string UpdateHotel(Hotel newhotel)
        {
            try
            {
                Hotel hotel = context.Hotels.FirstOrDefault(d => d.HotelId == newhotel.HotelId);
                if (hotel == null)
                {
                    throw new NotFoundException($"Hotel with ID {newhotel.HotelId} not found");
                }

                hotel.HotelName = newhotel.HotelName;
                hotel.Location = newhotel.Location;
                hotel.AvailableRooms = newhotel.AvailableRooms;
                context.SaveChanges();
                return "Hotel details updated successfully";
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Error updating hotel: {ex.Message}");
            }
        }

        public string DeleteHotel(int id)
        {
            try
            {
                Hotel hotel = context.Hotels.Find(id);
                if (hotel == null)
                {
                    throw new NotFoundException($"Hotel with ID {id} not found");
                }

                context.Hotels.Remove(hotel);
                context.SaveChanges();
                return "Hotel removed from database";
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Error deleting hotel: {ex.Message}");
            }
        }
    }
}
