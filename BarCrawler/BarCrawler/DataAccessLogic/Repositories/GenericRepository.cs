﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using BarCrawler.DataAccessLogic.Repositories.Interface;
using BarCrawler.Models;
using DataAccessLogic.Repositories;

namespace BarCrawler.DataAccessLogic.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;

        public GenericRepository()
        {
            
        }

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public TEntity GetByID(int? id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        protected void MarkAsDirty(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}