using MunicipalServicesAppPoe3.DataStructures;
using MunicipalServicesAppPoe3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace MunicipalServicesAppPoe3.Services
{
    public static class EventManager
    {
        private static readonly string FilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "events.json");

        public static List<EventModel> Events = new List<EventModel>();
        private static CustomQueue<EventModel> eventQueue = new CustomQueue<EventModel>();
        private static HashSet<string> eventTitles = new HashSet<string>();

        static EventManager()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            LoadEvents();
        }

        public static void AddEvent(EventModel ev)
        {
            if (eventTitles.Contains(ev.Title)) return;

            Events.Add(ev);
            eventQueue.Enqueue(ev);
            eventTitles.Add(ev.Title);

            if (Events.Count > 8)
                Events.RemoveAt(0); // keep 8 visible

            SaveEvents();
        }

        public static void ToggleAttendance(string title)
        {
            var ev = Events.Find(e => e.Title == title);
            if (ev != null)
            {
                ev.Attended = !ev.Attended;
                SaveEvents();
            }
        }

        public static void SaveEvents()
        {
            var json = JsonConvert.SerializeObject(Events, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static void LoadEvents()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                Events = JsonConvert.DeserializeObject<List<EventModel>>(json) ?? new List<EventModel>();

                foreach (var ev in Events)
                {
                    eventQueue.Enqueue(ev);
                    eventTitles.Add(ev.Title);
                }
            }
            else
            {
                // load 8 default events for first run
                for (int i = 1; i <= 8; i++)
                {
                    AddEvent(new EventModel
                    {
                        Title = $"Community Clean-Up #{i}",
                        Description = "Join us to help keep the area beautiful!",
                        Date = DateTime.Today.AddDays(i),
                        Attended = false
                    });
                }
                SaveEvents();
            }
        }
    }
}
