using APINetBackMVC.Data;
using APINetBackMVC.Models.Entities;

namespace APINetBackMVC.Services
{
    public class FeesService
    {
        private readonly ApplicationDbContext _context;

        public FeesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveDataToDatabase(Fees entity)
        {

            _context.YourEntities.Add(entity);
            await _context.SaveChangesAsync();
        }

    }
}
