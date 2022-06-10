﻿using System;
using System.Text;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        private bool available;
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available { get; set; }

        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append($"Drone: {Name}");
            sb.Append(Environment.NewLine);
            sb.Append($"Manufactured by: {Brand}");
            sb.Append(Environment.NewLine);
            sb.Append($"Range: {Range} kilometers");

            return sb.ToString();
        }
    }
}
