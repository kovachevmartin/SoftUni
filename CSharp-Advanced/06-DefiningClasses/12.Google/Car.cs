﻿public class Car
{
    public string Model { get; set; }
    public int Speed { get; set; }

    public Car()
    {

    }

    public Car(string model, int speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}
