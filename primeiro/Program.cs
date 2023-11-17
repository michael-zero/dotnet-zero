﻿namespace Payments {
class Program
    {
    static void Main(string[] args)
    {
        var room = new Room(3);
        room.RoomSoldOutEvent += OnRoomSoldOut;
        room.ReserveSeat();
        room.ReserveSeat();
        room.ReserveSeat();
        room.ReserveSeat();
    }

    static void OnRoomSoldOut(object seat, EventArgs e){
        Console.WriteLine("Sala lotada!");
    }

    public class Room {
        private int seatsInUse = 0;
        public int Seats { get; set; }
        public Room(int seats)
        {
            Seats = seats;
            seatsInUse = 0;
        }

        public void ReserveSeat(){
            seatsInUse++;
            if(seatsInUse > Seats){
             //Evento fechado
             OnRoomSoldOut(EventArgs.Empty);

            }else{
                Console.WriteLine("Assento reservado!");
            }
        }
        public event EventHandler RoomSoldOutEvent;
        protected virtual void OnRoomSoldOut(EventArgs e){
            EventHandler handler = RoomSoldOutEvent;
            handler?.Invoke(this, e);
        }
    }
    }
}