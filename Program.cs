using System;
using System.IO;
using StackExchange.Redis;

namespace RedisPopulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read File
            // TODO: Change this to match the path of your data.csv file
            const string pathToData = @"C:\Users\emilv\OneDrive\Softwareudvikling\1. Semester\Database\Mini project 2\data.csv";
            var lines = File.ReadAllLines(pathToData);
            
            var muxer = ConnectionMultiplexer.Connect("localhost");
            // Get a connection to database 1. You can leave this parameter blank or select another db to connect to.
            var conn = muxer.GetDatabase(1);
            
            // Split the CSV line into a string array, and then select all indices but the first element.
            // The first element should be the Key you want in Redis.
            var headers = lines[0].Split(',');

            // Array which will contain the key value entries.
            var entries = new HashEntry[headers.Length - 2];
            
            var numberOfElements = (lines.Length - 1).ToString("N0");
            Console.WriteLine($"Writing {numberOfElements} elements to DB please wait...");
            for (var i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                // Assemble hash entries (Key, Values) to be inserted into the hash
                for (var j = 2; j < headers.Length; j++)
                {
                    entries[j - 2] = new HashEntry(headers[j], values[j]);
                }
                // Query the entries to the DB
                conn.HashSet($"{headers[0]}:{values[0]}.{values[1]}", entries);
            }

            Console.WriteLine("Finished!");
        }
    }
}