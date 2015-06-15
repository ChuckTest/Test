using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReflectionDemo
{
    class Car
    {
        public Car()
        {
            Color = "White";
            speed = 0;
        }

        public Car(string color,int speed)
        {
            Color = color;
            this.speed = speed;
        }

        public string Color;

        private int speed;
        public int Speed
        {
            get { return speed; }
        }

        public void Accelerate(int accelerateBy)
        {
            speed += accelerateBy;
        }

        public bool IsMoving()
        {
            if (speed == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 每加仑行驶的英里数（miles per gallon）
        /// </summary>
        /// <param name="startMiles"></param>
        /// <param name="endMiles"></param>
        /// <param name="gallons"></param>
        /// <returns></returns>
        public double CalculateMPG(int startMiles,int endMiles,double gallons)
        {
            return (endMiles - startMiles) / gallons;
        }
    }
}
