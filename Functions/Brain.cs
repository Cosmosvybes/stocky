using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Inventory.Functions
{
    public class Brain
    {


        public static void SaveData()
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Stocky.stores, options);// converted the store data to strings
            File.WriteAllText(Stocky.FileName, jsonString);// write strigified data to the memory(harddrive)
            Console.WriteLine("File data saved");
        }

        public static void ReadData()
        {
            if (File.Exists(Stocky.FileName))
            {
                string JsonStrings = File.ReadAllText(Stocky.FileName);// read strigified data from the memory(harddrive)
                List<Store> jsonStores = JsonSerializer.Deserialize<List<Store>>(JsonStrings);// convert the strigified data back to objects
                Stocky.stores.Clear();
                Stocky.stores.AddRange(jsonStores);
            }
        }
    }
}