using flight_data_server.Database;
using flight_data_server.Interface;
using flight_data_server.Models.Airliner;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace flight_data_server.Services.DBFunctions
    {
    public class DatabaseFunctions<T> : IDatabaseFunctions<T> where T : class
        {
        private readonly AirlinerDBContext _db;

        internal DbSet<T> dbSet;

        public DatabaseFunctions(AirlinerDBContext db)
            {
            this._db = db;
            this.dbSet = _db.Set<T>();
            }

        public async Task CreateAsync(T entitiy)
            {
            try
                {
                await dbSet.AddAsync(entitiy);
                await SaveAsync();
                }
            catch (Exception)
                {
                throw new NotImplementedException();
                }
            }

        public async Task<List<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            bool tracked = true
        )
            {
            IQueryable<T> query = dbSet;
            try
                {
                if (filter != null)
                    {
                    query = query.Where(filter);
                    }
                }
            catch
                {
                throw new NotImplementedException();
                }
            return await query.ToListAsync();
            }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
            {
            try
                {
                IQueryable<T> query = dbSet;

                if (filter != null)
                    {
                    query = query.Where(filter);
                    }
                return await query.ToListAsync();
                }
            catch (Exception)
                {
                throw new NotImplementedException();
                }
            }

        public async Task RemoveAsync(T entity)
            {
            try
                {
                dbSet.Remove(entity);
                await SaveAsync();
                }
            catch (Exception)
                {
                throw new NotImplementedException();
                }
            }

        public async Task SaveAsync()
            {
            try
                {
                await _db.SaveChangesAsync();
                }
            catch (Exception)
                {
                throw new NotImplementedException();
                }
            }
        }
    }
