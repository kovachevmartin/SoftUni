﻿using P08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int workedHours)
        {
            this.PartName = partName;
            this.WorkedHours = workedHours;
        }

        public string PartName { get; private set; }

        public int WorkedHours { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.WorkedHours}";
        }
    }
}
