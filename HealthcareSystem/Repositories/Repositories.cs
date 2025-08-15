using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareSystem.Repositories
{
    // Generic repository for entity storage & retrieval
    public class Repository<T>
    {
        private readonly List<T> items = new();

        public void Add(T item) => items.Add(item);

        public List<T> GetAll() => new(items);

        public T? GetById(Func<T, bool> predicate) =>
            items.FirstOrDefault(predicate);

        public bool Remove(Func<T, bool> predicate)
        {
            var entity = items.FirstOrDefault(predicate);
            if (entity != null)
            {
                items.Remove(entity);
                return true;
            }
            return false;
        }
    }
}
