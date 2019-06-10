namespace Restaurant.Domain.DTO
﻿using System;
{
    public class DiningTableDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int AvailableChairs { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
