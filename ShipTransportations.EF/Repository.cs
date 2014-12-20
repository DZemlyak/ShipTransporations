using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF
{
    public class Repository <T> where T : BaseEntity
    {
        private readonly DbSet<T> _entities;
        private readonly IValidator<T> _validator;
        private readonly Context _context;

        public Repository(IValidator<T> validator) {
            _context = Context.GetContext();
            _entities = _context.Set<T>();
            _validator = validator;
        }

        public void Add(T item)
        {
            try {
                if(!_validator.IsValid(item))
                    throw new Exception("Validation is not passed.");
                _entities.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Update(T item)
        {
            try {
                if (!_validator.IsValid(item))
                    throw new Exception("Validation is not passed.");
                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(T item)
        {
            try {
                _entities.Remove(item);
                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public T Read(int id)
        {
            var entity = _entities.Find(id);
            if (entity == null)
                throw new Exception("Entity is not found.");
            return entity;
        }

        public IEnumerable<T> ReadAll()
        {
            if (!_entities.Any())
                throw new Exception("No entities found..");
            return _entities;
        }

    }
}
