﻿using System.IO;
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

    }
}
