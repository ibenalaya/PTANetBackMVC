﻿using APINetBackMVC.Data;
using APINetBackMVC.Models.Entities;

namespace APINetBackMVC.Services
{
    public class FeesService(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public async Task SaveDataToDatabase(List<Fees> feesList)
        {
            // Using a FeeList for save the fees in bbdd
            _context.Fees.AddRange(feesList);

            // Save the Changes
            await _context.SaveChangesAsync();
        }

    }
}
