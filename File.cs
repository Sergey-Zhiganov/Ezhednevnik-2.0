using Newtonsoft.Json;
using System;
using System.IO;

namespace Ежедневник_2._0
{
    public static class Files
    {
        static string path = $"{Environment.CurrentDirectory}\\events.json";
        public static void Serialize<T>(T type)
        {
            string json = JsonConvert.SerializeObject(type);
            File.WriteAllText(path, json);
        }

        public static T Deserialize<T>()
        {
            if (File.Exists(path) == false)
            {
                File.Create(path).Close();
            }
            string json = File.ReadAllText(path);
            T type = JsonConvert.DeserializeObject<T>(json);
            return type;
        }
    }
}
