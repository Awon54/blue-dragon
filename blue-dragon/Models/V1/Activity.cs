﻿using System;

namespace blue_dragon.Models.V1
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Double Amount { get; set; }
    }
}
