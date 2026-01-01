using Microsoft.EntityFrameworkCore;

using WowApp.Data;
using WowApp.EntityModels;

namespace WowApp.Services
{
    public class ReviewService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
        public ReviewService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<Review>> GetServiceAsync(CancellationToken ct = default)
        {
            await using var dbContext = _dbFactory.CreateDbContext();
            return await dbContext.Reviews.ToListAsync(ct);
        }

        public async Task<Review?> GetServiceByIdAsync(int id, CancellationToken ct = default)
        {
            await using var dbContext = _dbFactory.CreateDbContext();
            return await dbContext.Reviews.FirstOrDefaultAsync(p => p.Id == id, ct);
        }

        public async Task SaveServiceAsync(Review review, CancellationToken ct = default)
        {
            await using var dbContext = await _dbFactory.CreateDbContextAsync(ct);
            if (review.Id == 0)
            {
                await dbContext.Reviews.AddAsync(review, ct);
            }
            else
            {
                dbContext.Reviews.Update(review);
            }
            await dbContext.SaveChangesAsync(ct);
        }

        public async Task DeleteServiceAsync(int id, CancellationToken ct = default)
        {
            await using var dbContext = await _dbFactory.CreateDbContextAsync(ct);
            var review = await dbContext.Reviews.FirstOrDefaultAsync(p => p.Id == id, ct);
            if (review != null)
            {
                dbContext.Reviews.Remove(review);
                await dbContext.SaveChangesAsync(ct);
            }
        }
    }
}
