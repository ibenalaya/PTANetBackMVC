using APINetBackMVC.Data;
using APINetBackMVC.Models;
using APINetBackMVC.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APINetBackMVC.Services
{
    public class BankService(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<OperationResult> SaveDataToDatabase(List<Bank> bankList)
        {
            try { 
            // Using a FeeList for save the fees in bbdd
            _context.Banks.AddRange(bankList);
            // Save the Changes
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true };
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Registry duplicated", StatusCode = 2627 };
                }
            return new OperationResult { Success = false, ErrorMessage = "There was an error saving the data", StatusCode = -1 };
            }
        }

        public async Task<Bank> GetBankByIdAsync(string country)
        {
            var bank = await _context.Banks.FindAsync(country);
            return bank; // return the registry
        }

    }
}
