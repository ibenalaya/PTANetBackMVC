using APINetBackMVC.Data;
using APINetBackMVC.Models.Entities;

namespace APINetBackMVC.Services
{
    public class BankService(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public async Task SaveDataToDatabase(List<Bank> bankList)
        {
            // Using a FeeList for save the fees in bbdd
            _context.Banks.AddRange(bankList);

            // Save the Changes
            await _context.SaveChangesAsync();
        }

    }
}
