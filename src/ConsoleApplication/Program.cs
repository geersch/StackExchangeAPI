using System;
using Newtonsoft.Json;
using StackExchange.Api;

namespace ConsoleApplication
{
    class Program
    {
        static void Main()
        {
            var api = new StackExchangeApi("your api key");

            var user = api.GetUser(893099);

            Console.WriteLine(String.Format("Max rate limit: {0}", api.MaxRateLimit));
            Console.WriteLine(String.Format("Current rate limit: {0}", api.CurrentRateLimit));
            Console.WriteLine();

            Console.WriteLine(String.Format("User id: {0}", user.Id));
            Console.WriteLine(String.Format("Display name: {0}", user.DisplayName));
            Console.WriteLine(String.Format("Reputation: {0}", user.Reputation));
            Console.WriteLine(String.Format("Golden badges: {0}", user.BadgeCounts.Gold));
            Console.WriteLine(String.Format("Silver badges: {0}", user.BadgeCounts.Silver));
            Console.WriteLine(String.Format("Bronze badges: {0}", user.BadgeCounts.Bronze));
            Console.WriteLine();

            var reputation = api.GetReputationChanges(893099, DateTime.Now.AddDays(-14), DateTime.Now);
            foreach(var change in reputation)
            {
                Console.WriteLine(String.Format("{0}: {1} +{2} -{3}", change.OnDate, change.Title,
                                                change.PossitiveReputation, change.NegativeReputation));
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }

    public class Ruben
    {
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime BirthDay { get; set; }
    }
}
