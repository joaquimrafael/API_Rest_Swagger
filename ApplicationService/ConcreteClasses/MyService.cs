using System.IO;
using System.Text.Json;
using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Hosting;


namespace ApplicationService
{
    public class MyService : IMyService // implento a interface para permitir a injeção
    {


        public void ProcessObject(MyObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj),"Objeto não pode ser nulo!");
            }
            //transformo os atributos do meu objeto para o formato json
            string jsonString = JsonSerializer.Serialize(obj);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos");
            // pego o caminho para o diretorio atual

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            // caso a pasta n exista eu a crio

            string fileName = Path.Combine(path, $"object_{obj.id}.json");
            // monto o arquivo json a partir do Id do objeto e o escrevo
            File.WriteAllText(fileName, jsonString);

        }

        public async Task DeleteAsync(int id)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos");
            string fileName = Path.Combine(path, $"object_{id}.json");

            if(File.Exists(fileName))
            {
                await Task.Run(() => File.Delete(fileName));
            }
            else
            {
                throw new FileNotFoundException($"Arquivo com o id{id} não foi encontrado");
            }


        }

        public async Task PutAsync(int id, MyObject obj)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos");
            string fileName = Path.Combine(path, $"object_{id}.json");

            if (File.Exists(fileName))
            {
                string jsonString = JsonSerializer.Serialize(obj);
                File.WriteAllText(fileName, jsonString);
            }
            else
            {
                throw new FileNotFoundException($"Arquivo com o id{id} não foi encontrado");
            }
        }

        public async Task<MyObject> GetAsync(int id)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos");
            string fileName = Path.Combine(path, $"object_{id}.json");

            if (File.Exists(fileName))
            {
                string jsonContent = await File.ReadAllTextAsync(fileName);
                MyObject obj = JsonSerializer.Deserialize<MyObject>(jsonContent);
                return obj;

            }
            else
            {
                throw new FileNotFoundException($"Arquivo com o id{id} não foi encontrado");
            }


        }

        public async Task<List<MyObject>> GetAllObjectsAsync()
        {
            var _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos");
            var objects = new List<MyObject>();

            if (Directory.Exists(_directoryPath))
            {
                var files = Directory.GetFiles(_directoryPath, "object_*.json");

                foreach (var file in files)
                {
                    string jsonContent = await File.ReadAllTextAsync(file);
                    MyObject obj = JsonSerializer.Deserialize<MyObject>(jsonContent);
                    objects.Add(obj);
                }
            }

            return objects;
        }
    }

}

