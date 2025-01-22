﻿using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tenisu.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Shortname { get; set; }
        public string Sex { get; set; }
        public Country Country { get; set; }
        public string Picture { get; set; }
        public Data Data { get; set; }

        public int GetRatio()
        {

            return this.Data.Last.Sum() / this.Data.Last.Count();
        }

        public int GetBMI()
        {
            return Data.Weight / (Data.Height * Data.Height);
        }
    }
}