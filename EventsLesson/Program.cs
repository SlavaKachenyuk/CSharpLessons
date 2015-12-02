using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDemo
{
    delegate void EventHandler(EventSender sender);
    class Program
    {
        static void Main(string[] args)
        {
            EventSender senderVasya = new EventSender("Vasya");
            senderVasya.EventHandlers += new EventHandler(EventHandlerA);
            senderVasya.EventHandlers += new EventHandler(EventHandlerB);

            EventSender senderPetya = new EventSender("Petya");
            senderPetya.EventHandlers += EventHandlerA;

            senderVasya.SendEvent();
            senderPetya.SendEvent();

            Console.ReadKey();
        }
        static void EventHandlerA(EventSender sender)
        {
            Console.WriteLine("EventHandlerA: Sender " + sender.Name);
        }
        static void EventHandlerB(EventSender sender)
        {
            Console.WriteLine("EventHandlerB: Sender " + sender.Name);
        }
    }
    class EventSender
    {
        public string Name;
        public event EventHandler EventHandlers;
        public EventSender(string name)
        {
            Name = name;
        }
        public void SendEvent()
        {
            if (EventHandlers != null)
            {
                EventHandlers(this);
            }
        }
    }
}