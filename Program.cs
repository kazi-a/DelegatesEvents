using System;

namespace DelegatesAndEvents
{
    // Create a delegate
    public delegate void RaceEventHandler(int winner);

    public class Race
    {
        // Create a delegate event object
        public event RaceEventHandler RaceEvent;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            // First to finish specified number of laps wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {
                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        break;
                    }
                }
            }
            // Invoke the delegate event object and pass champ to the method
            RaceEvent?.Invoke(champ);
        }
    }

    class Program
    {
        public static void Main()
        {
            // Create a class object
            Race round1 = new Race();

            // Register with the footRace event
            round1.RaceEvent += footRace;

            // Trigger the event
            round1.Racing(5, 10); // 5 contestants, 10 laps

            // Register with the carRace event
            round1.RaceEvent += carRace;

            // Trigger the event
            round1.Racing(5, 10); // 5 contestants, 10 laps

            // Register a bike race event using a lambda expression
            round1.RaceEvent += (winner) => Console.WriteLine($"Biker number {winner} is the winner.");

            // Trigger the event
            round1.Racing(5, 10); // 5 contestants, 10 laps
        }

        // Event handlers
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }

        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}
