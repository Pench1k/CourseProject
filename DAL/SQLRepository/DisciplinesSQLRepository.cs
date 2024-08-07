﻿using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DAL.SQLRepository
{
    public class DisciplinesSQLRepository : IDisciplinesRepository
    {
        private readonly ApplicationDbContext _context;

        public DisciplinesSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Disciplines entity)
        {
            _context.Disciplines.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteDisciplines = _context.Disciplines.Find(id);
            if (deleteDisciplines != null)
            {
                _context.Disciplines.Remove(deleteDisciplines); 
                _context.SaveChanges();
            }
        }

        public Disciplines? Get(int id) => _context.Disciplines.Find(id);   

        public List<Disciplines> GetAll() => _context.Disciplines.ToList();

        public void Update(Disciplines discipline)
        {
            // Получаем сущность из базы данных
            var disciplines = _context.Disciplines.Find(discipline.Id);

            if (disciplines != null)
            {
                // Обновляем свойства сущности
                disciplines.DisciplineName = discipline.DisciplineName;

                // Сохраняем изменения
                _context.SaveChanges();
            }
        }
    }
}
