﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T:class
    {
        private CareerCloudContext _context;

        public EFGenericRepository(bool createProxy=true)
        {
            _context = new CareerCloudContext(createProxy);
        }


        public void Add(params T[] items)
        {
            if (items != null)
            {
                foreach (T item in items)
                {
                    _context.Entry(item).State =
                        EntityState.Added;
                }
            }

            Debug.WriteLine("OK before savechanges");

            //_context.SaveChanges();

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach(Expression<Func<T, object>> navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);
            }
            return dbQuery.ToList();
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (Expression<Func<T, object>> navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);
            }

            return dbQuery.Where(where).ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (Expression<Func<T, object>> navProp in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navProp);
            }

            return dbQuery.FirstOrDefault(where);
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State =
                    EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State =
                    EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
