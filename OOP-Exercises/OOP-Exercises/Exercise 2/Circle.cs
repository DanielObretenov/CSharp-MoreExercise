using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exercises.Exercise_3
{
    public class Circle:Point
    {
        public double Radius { get; set; }


        public Circle(double x, double y, double radius) : base( x , y)
        {
            Radius = radius;
            X = x;
            Y = y;

        }

        public double CalculateDistanceBetweenPoints(Point a, Point b)
        {
            double powA = Math.Pow((a.X - b.X), 2);
            double powB = Math.Pow((a.Y - b.Y), 2);
            double distanceBetweenPoints = Math.Sqrt(powA + powB);
            return distanceBetweenPoints;
        }

        public bool AreIntersecting(Circle a, Circle b)
        {
            Point pointA = new Point(a.X, a.Y);
            Point pointB = new Point(a.X, a.Y);
            double totalRadius = a.Radius + b.Radius;
            double distanceBetweenPoints = CalculateDistanceBetweenPoints(pointA, pointB);
            bool isIntersection = totalRadius >= distanceBetweenPoints ? true : false;
            return isIntersection;
        }
        
    }
}
