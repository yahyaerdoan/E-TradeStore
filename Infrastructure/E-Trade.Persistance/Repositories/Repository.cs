using E_Trade.Persistence.Context;
using E_TradeStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Trade.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ETradeDbContext _eTradeDbContext;

        public Repository(ETradeDbContext eTradeDbContext)
        {
            _eTradeDbContext = eTradeDbContext;
        }

        public async Task CreateAsync(T entity)
        {
            _eTradeDbContext.Set<T>().Add(entity);
            await _eTradeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var values = _eTradeDbContext.Set<T>().Find(id);
            _eTradeDbContext.Set<T>().Remove(values);
            await _eTradeDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAsync()
        {
            return  await _eTradeDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _eTradeDbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _eTradeDbContext.Set<T>().Update(entity);
            await _eTradeDbContext.SaveChangesAsync();
        }
    }
}
