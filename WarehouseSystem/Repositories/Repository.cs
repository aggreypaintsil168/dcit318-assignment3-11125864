using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseSystem.Exceptions;

namespace WarehouseSystem.Repositories
{
    public class Repository<T> where T : class
    {
        private List<T> _items = new List<T>();

        public void Add(T item, Func<T, bool> duplicatePredicate)
        {
            if (_items.Any(duplicatePredicate))
                throw new DuplicateItemException("Item already exists in the repository.");
            
            _items.Add(item);
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public T GetById(Func<T, bool> predicate)
        {
            var found = _items.FirstOrDefault(predicate);
            if (found == null)
                throw new ItemNotFoundException("Item not found.");
            return found;
        }

        public void Remove(Func<T, bool> predicate)
        {
            var item = _items.FirstOrDefault(predicate);
            if (item == null)
                throw new ItemNotFoundException("Cannot remove: Item not found.");
            
            _items.Remove(item);
        }
    }
}
