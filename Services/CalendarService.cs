using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EtudiantOS.Models;
using Ical.Net;

namespace EtudiantOS.Services
{
    public class CalendarService
    {
        public List<CoursEvent> ParseIcsContent(string content)
        {
            try
            {
                var calendar = Calendar.Load(content);
                var events = new List<CoursEvent>();

                foreach (var evt in calendar.Events)
                {
                    if (evt.Start.AsSystemLocal >= DateTime.Now.Date) // Keep today's events too
                    {
                        events.Add(new CoursEvent
                        {
                            Start = evt.Start.AsSystemLocal,
                            End = evt.End.AsSystemLocal,
                            Summary = evt.Summary,
                            Location = evt.Location,
                            Description = evt.Description
                        });
                    }
                }

                return events.OrderBy(e => e.Start).ToList();
            }
            catch
            {
                return new List<CoursEvent>();
            }
        }

        public List<CoursEvent> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return new List<CoursEvent>();
            return ParseIcsContent(File.ReadAllText(filePath));
        }

        public async Task<List<CoursEvent>> LoadFromUrl(string url)
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync(url);
            return ParseIcsContent(content);
        }
    }
}
