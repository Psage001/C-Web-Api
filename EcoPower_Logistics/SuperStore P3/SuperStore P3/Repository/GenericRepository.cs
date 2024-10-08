﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace EcoPower_Logistics.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SuperStoreContext _context;
        private readonly DbSet<T> _dbSet;



        public GenericRepository(SuperStoreContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }


        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task AddEntry(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateEntry(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteEntry(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }

        }


        public async Task<bool> Exists(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null;
        }
    }
}