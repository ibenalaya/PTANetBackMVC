using APINetBackMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINetBackMVC.Controllers
{
    public class FeesController : Controller
    {
        private readonly ApiService _apiService;
        private readonly FeesService _feesService;

        public FeesController(ApiService apiService, FeesService feesService)
        {
            _apiService = apiService;
            _feesService = feesService;
        }


        // POST: FeesController/Create
        [HttpPost("load-fees")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoadFees()
        {
            var fees = await _apiService.GetDataFromApi();
            await _feesService.SaveDataToDatabase(fees);
            return Ok("Fees loaded successfully");
        }


    }
}
