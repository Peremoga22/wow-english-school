using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

using System.Globalization;

using WowApp.Data;
using WowApp.EntityModels;
using WowApp.ModelsDTOs;

namespace WowApp.Services
{
    public class TelegramBotService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public TelegramBotService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<int> SaveAppointmentClientAsync(Appointment appointmentUser, CancellationToken ct = default)
        {
            await using var db = await _dbFactory.CreateDbContextAsync(ct);

            if (appointmentUser.Id == 0)
            {
                await db.Appointments.AddAsync(appointmentUser, ct);
            }
            else
            {
                db.Appointments.Update(appointmentUser);
            }

            await db.SaveChangesAsync(ct);
            return appointmentUser.Id;
        }

        public async Task<int> CreateCallbackAsync(CallbackCreateDto dto, CancellationToken ct = default)
        {
            await using var db = await _dbFactory.CreateDbContextAsync(ct);
            var entity = new CallbackRequest
            {
                Id = dto.Id, 
                Name = dto.ClientName.Trim(),
                Phone = dto.ClientPhone.Trim(),
                Comment = dto.Message,
                IsCulture = CultureInfo.CurrentUICulture.Name.StartsWith("en")
            };

            db.CallbackRequests.Add(entity);
            await db.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<List<CallbackRequest>> GetAllCallbackAsync( CancellationToken ct = default)
        {
            await using var db = await _dbFactory.CreateDbContextAsync(ct);

            return await db.CallbackRequests.ToListAsync(ct);
        }

        public async Task DeleteServiceAsync(int id, CancellationToken ct = default)
        {
            await using var dbContext = await _dbFactory.CreateDbContextAsync(ct);
            var callback = await dbContext.CallbackRequests.FirstOrDefaultAsync(p => p.Id == id, ct);

            if (callback != null)
            {
                dbContext.CallbackRequests.Remove(callback);
                await dbContext.SaveChangesAsync(ct);
            }
        }
    }
}
