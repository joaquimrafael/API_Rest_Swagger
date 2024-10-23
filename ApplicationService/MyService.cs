using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;


namespace ApplicationService
{
    public class MyService : IMyService
    {


        public void ProcessObject(MyObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj),"Objeto não pode ser nulo!");
            }

            string jsonString = JsonSerializer.Serialize(obj);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.Combine(path, $"object_{obj.id}.json");
            File.WriteAllText(fileName, jsonString);

        }
    }
}
