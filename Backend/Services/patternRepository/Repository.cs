using Entities;
using Services.patternRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.PatternRepository


{
  
    public class Repository<T> : IRepository<T> where T : IHasId
    {
        private readonly List<T> _data = new();  

        public Task<T> Add(T entity)
        {
            entity.Id = _data.Count + 1;
            _data.Add(entity);
            return Task.FromResult(entity);
        }

        public void Delete(T entity)
        {
                _data.Remove(entity);
            
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return Task.FromResult(_data.AsEnumerable());
        }

        public Task<T> GetById(int id)
        {
            var elementToSearch = _data.Find(x => x.Id == id);

            return Task.FromResult(elementToSearch);
        }
    }
}
