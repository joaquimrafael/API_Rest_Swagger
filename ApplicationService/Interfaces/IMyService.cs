﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    // interface usada ao implementar a minha classe de serviço
    public interface IMyService
    {
        // metodo obrigatorio para processar o objeto
        void ProcessObject(MyObject obj);

        Task DeleteAsync(int id);

        Task PutAsync(int id,MyObject obj);

        Task<MyObject> GetAsync(int id);

        Task<List<MyObject>> GetAllObjectsAsync();
    }
}
