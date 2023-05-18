using System.Reflection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestTask_Directum_1.Models
{
    public class UserModel
    {
        private static string pathToSave { get; } = "./UsersJSON";

        public static string getPathToSaveJSON()
        {
            return pathToSave;
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }

        public string BirthDate { get; set; }

        public string saveToJSON()
        {
            Random random = new Random();

            DateTime dateTime = DateTime.UtcNow;

            string name = dateTime.ToString("dd/MM/yyyy_HH/mm/ss") + "_" + random.Next(1000);
            string path = pathToSave + "/" + name + ".json";

            // Checks if file with that name already exists.
            while (File.Exists(path))
            {
                name = dateTime.ToString("dd/MM/yyyy_HH/mm/ss") + "-" + random.Next(1000);
                path = pathToSave + "/" + name + ".json";
            }

            string jsonString = JsonSerializer.Serialize(this);

            FileStream fileStream = File.Create(path);

            StreamWriter writer = new StreamWriter(fileStream);
            writer.Write(jsonString);

            writer.Close();
            fileStream.Close();

            return name;
        }
    }
}