using APINetBackMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINetBackMVC.Controllers
{
    public class FeesController : Controller
    {
        private readonly ApiService _apiService;
        private readonly FeesService _feesService;
        private readonly BankService _banksService;

        public FeesController(ApiService apiService, FeesService feesService, BankService banksService)
        {
            _apiService = apiService;
            _feesService = feesService;
            _banksService = banksService;
        }


        // POST: FeesController/Create
        [HttpPost("load-fees")]
        public async Task<IActionResult> LoadFees()
        {

            var feesList = await _apiService.GetFeesFromApi();
            await _feesService.SaveDataToDatabase(feesList);

            return Ok("Fees loaded successfully");
        }

        // POST: FeesController/Create
        [HttpPost("load-banks")]
        public async Task<IActionResult> LoadBanks()
        {

            var banksList = await _apiService.GetBanksFromApi();
            await _banksService.SaveDataToDatabase(banksList);

            return Ok("Fees loaded successfully");
        }


    }
}
