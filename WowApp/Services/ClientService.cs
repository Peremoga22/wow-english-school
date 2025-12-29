using Microsoft.EntityFrameworkCore;

using WowApp.Data;
using WowApp.EntityModels;

namespace WowApp.Services
{
    public class ClientService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
        public ClientService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<ServiceClient>> GetPortfoliosAsync(CancellationToken ct = default)
        {
            await using var dbContext = _dbFactory.CreateDbContext();
            return await dbContext.ServiceClients.ToListAsync(ct);
        }

        public async Task<ServiceClient?> GetPortfolioByIdAsync(int id, CancellationToken ct = default)
        {
            await using var dbContext = _dbFactory.CreateDbContext();
            return await dbContext.ServiceClients.FirstOrDefaultAsync(p => p.Id == id, ct);
        }

        public async Task SavePortfolioAsync(ServiceClient serviceClient, CancellationToken ct = default)
        {
            await using var dbContext = await _dbFactory.CreateDbContextAsync(ct);

            if (serviceClient.Id == 0)
            {
                await dbContext.ServiceClients.AddAsync(serviceClient, ct);
            }
            else
            {
                dbContext.ServiceClients.Update(serviceClient);
            }

            await dbContext.SaveChangesAsync(ct);
        }

        public async Task DeletePortfolioAsync(int id, CancellationToken ct = default)
        {
            await using var dbContext = await _dbFactory.CreateDbContextAsync(ct);
            var serviceClient = await dbContext.ServiceClients.FirstOrDefaultAsync(p => p.Id == id, ct);

            if (serviceClient != null)
            {
                dbContext.ServiceClients.Remove(serviceClient);
                await dbContext.SaveChangesAsync(ct);
            }
        }
    }
}
