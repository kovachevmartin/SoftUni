﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P06.TrafficLights.TrafficLightModels
{
    public interface ITrafficLight
    {
        State State { get; set; }
        void ChangeState(int cycles);
    }
}
