using Microsoft.EntityFrameworkCore;

using WowApp.Data;
using WowApp.EntityModels;

namespace WowApp.Services
{
    public class PortfolioService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
        public PortfolioService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<Portfolio>> GetPortfoliosAsync(CancellationToken ct = default)
        {
            await using var dbContext = _dbFactory.CreateDbContext();
            return await dbContext.Portfolios.ToListAsync(ct);
        }

        public async Task<Portfolio?> GetPortfolioByIdAsync(int id, CancellationToken ct = default)
        {
            await using var dbContext = _dbFactory.CreateDbContext();
            return await dbContext.Portfolios.FirstOrDefaultAsync(p => p.Id == id, ct);
        }

        public async Task SavePortfolioAsync(Portfolio portfolio, CancellationToken ct = default)
        {
            await using var dbContext = await _dbFactory.CreateDbContextAsync(ct);

            if (portfolio.Id == 0) 
            {
                await dbContext.Portfolios.AddAsync(portfolio, ct);
            }
            else
            {
                dbContext.Portfolios.Update(portfolio);
            }

            await dbContext.SaveChangesAsync(ct);
        }

        public async Task DeletePortfolioAsync(int id, CancellationToken ct = default)
        {
            await using var dbContext = await _dbFactory.CreateDbContextAsync(ct);
            var portfolio = await dbContext.Portfolios.FirstOrDefaultAsync(p => p.Id == id, ct);

            if (portfolio != null)
            {
                dbContext.Portfolios.Remove(portfolio);
                await dbContext.SaveChangesAsync(ct);
            }
        }
    }
}
