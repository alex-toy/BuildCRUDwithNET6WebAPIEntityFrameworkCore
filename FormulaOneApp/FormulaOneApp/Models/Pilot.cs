﻿namespace FormulaOneApp.Models
{
    public class Pilot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pilot> Pilots { get; set; }
    }
}