using HotelApplication.Contexts.HotelApplication.Contexts;
using HotelApplication.Interfaces;
using HotelApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelApplication.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext context;

        public RoomRepository(HotelContext roomContext)
        {
            context = roomContext;
        }

        public string AddNewRoom(Room room)
        {
            try
            {
                int count = context.Rooms.Count();
                context.Rooms.Add(room);
                context.SaveChanges();
                int newcount = context.Rooms.Count();

                return newcount > count
                    ? "Record inserted successfully"
                    : "Oops, something went wrong while inserting";
            }
            catch (Exception ex)
            {
                return $"Error adding room: {ex.Message}";
            }
        }

        public string DeleteRoom(int id)
        {
            Room room = context.Rooms.Find(id);
            if (room != null)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
                return "Room removed successfully";
            }

            return "Room not available";
        }

        public List<Room> GetAllRooms()
        {
            return context.Rooms.ToList();
        }

        public string UpdateRoom(Room newroom)
        {
            Room room = context.Rooms.FirstOrDefault(d => d.RoomId == newroom.RoomId);
            if (room != null)
            {
                context.Entry(room).CurrentValues.SetValues(newroom);
                context.SaveChanges();
                return "Room details updated successfully";
            }

            return "Room details not found";
        }

        public Room GetRoomById(int id)
        {
            return context.Rooms.Find(id);
        }

        public List<Room> GetAllRoomsByHotelId(int hid)
        {
            return context.Rooms.Where(d => d.HotelId == hid).ToList();
        }
    }
}
