﻿namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
