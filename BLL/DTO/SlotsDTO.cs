﻿using DAL.Models;

namespace BLL.DTO
{
    public class SlotsDTO
    {
        public int Id { get; set; }

        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public int DayOfTheWeek { get; set; }

        public List<SlotsSchedules> Schedules { get; set; }
    }
}
