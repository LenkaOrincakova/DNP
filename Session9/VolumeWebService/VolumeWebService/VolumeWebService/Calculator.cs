using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolumeWebService
{
    public class Calculator
    {

        public double CalculateVolumeCylinder(double radius, double height)
        {
            return Math.Pi * radius * radius * height;
        }

        public double CalculateVolumeCone(double radius, double height)
        {
            return CalculateVolumeCylinder(radius, height) / 3;
        }
    }
}
