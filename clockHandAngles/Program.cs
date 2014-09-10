using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockHandApp;

namespace ClockHandApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            talkToUser();
        }

        static void talkToUser() 
        {   
            Console.WriteLine("Please enter the time: ( hh:mm:ss ) ");
            string time =  Console.ReadLine();
            Console.WriteLine("\n\n\tThe time is {0}",time);

            Clock c = new Clock();
            displayAnglesApart(c, time);
            diplayHandAngles(c, time);
            Console.ReadLine(); 
        }

        static void displayAnglesApart(Clock c, string time) 
        {
            decimal hourMinutesAngle = 0, minutesSecondsAngle = 0,  hourSecondsAngle = 0;
            c.getAllAnglesApart(ref hourMinutesAngle, ref minutesSecondsAngle, ref hourSecondsAngle, time);            
            Console.WriteLine("\nThe Hour and Minute hands are {0} degrees apart.", hourMinutesAngle.ToString("F4"));
            Console.WriteLine("The Minute and Seconds hands are {0} degrees apart.", minutesSecondsAngle.ToString("F4"));
            Console.WriteLine("The Hour and Seconds hands are {0} degrees apart.\n", hourSecondsAngle.ToString("F4"));
        }

        static void diplayHandAngles(Clock c, string time) 
        { 
            decimal hourHandAngle=0, minutesHandAngle=0, secondsHandAngle=0;
            c.getAllHandAngles(ref hourHandAngle, ref minutesHandAngle, ref secondsHandAngle, time);
            Console.WriteLine("\nThe Hour hand is at {0} degrees from 12.", hourHandAngle.ToString("F4"));
            Console.WriteLine("The Minute hand is at {0} degrees from 12.", minutesHandAngle.ToString("F4"));
            Console.WriteLine("The Seconds hand is at {0} degrees from 12.\n", secondsHandAngle.ToString("F4"));
        }
    }
}
