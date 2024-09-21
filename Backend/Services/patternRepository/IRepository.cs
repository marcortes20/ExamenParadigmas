using Entities;
using Services.PatternRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.patternRepository
{
    public interface IRepository<T> where T : IHasId
    {

        Task <IEnumerable<T>> GetAll();
        Task<T>  Add(T entity);
        void Delete(T entity);
        Task<T> GetById(int id);

    }
}
