using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml.Linq;

namespace Ежедневник_2._0
{
    internal class CRUD
    {
        public static void Create(Event new_event)
        {
            List<Event> events = Files.Deserialize<List<Event>>();
            if (events == null)
            {
                events = new List<Event> { };
            }
            events.Add(new_event);
            Files.Serialize(events);
        }
        public static List<Event> Read(DateOnly current_date)
        {
            List<Event> events = Files.Deserialize<List<Event>>();
            List<Event> current_events = new List<Event>();
            if (events == null)
            {
                events = new List<Event> { };
            }
            foreach (var item in events)
            {
                if (DateOnly.Parse(item.EventDate) == current_date)
                {
                    current_events.Add(item);
                }
            }
            return current_events;
        }
        public static void Update(int current, string text, string name, string description)
        {
            int index = 0;
            int default_index = 0;
            List<Event> events = Files.Deserialize<List<Event>>();
            foreach (var item in events)
            {
                if (item.EventDate == text)
                {
                    if (index++ == current)
                    {
                        events[default_index].Name = name;
                        events[default_index].Description = description;
                        Files.Serialize(events);
                        return;
                    }
                }
                default_index++;
            }
        }
        public static void Delete(int current, string text)
        {
            int index = 0;
            int default_index = 0;
            List<Event> events = Files.Deserialize<List<Event>>();
            foreach (var item in events)
            {
                if (item.EventDate == text)
                {
                    if (index++ == current)
                    {
                        events.RemoveAt(default_index);
                        Files.Serialize(events);
                        return;
                    }
                }
                default_index++;
            }
        }
    }
}
