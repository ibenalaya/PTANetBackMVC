using APINetBackMVC.Models.Dtos;
using APINetBackMVC.Models.Entities;
using APINetBackMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APINetBackMVC.Controllers
{
    public class ApiController : Controller
    {
        private readonly ApiService _apiService;
        private readonly FeesService _feesService;
        private readonly BankService _banksService;

        public ApiController(ApiService apiService, FeesService feesService, BankService banksService)
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
            var result = await _feesService.SaveDataToDatabase(feesList);

            if (result.Success)
            {
                return Ok("Banks loaded successfully");  //200 OK
            }

            if (result.StatusCode == 2627)
            {
                return Conflict(result.ErrorMessage); //409 Conflict
            }
            return StatusCode(500, result.ErrorMessage); //500 Internal Server Error

        }

        // POST: FeesController/Create
        [HttpPost("load-banks")]
        public async Task<IActionResult> LoadBanks()
        {
  
            var banksList = await _apiService.GetBanksFromApi();                
            var result = await _banksService.SaveDataToDatabase(banksList);

            if (result.Success){
                return Ok("Banks loaded successfully");  //200 OK
            }

            if (result.StatusCode== 2627)
            {
                return Conflict(result.ErrorMessage); //409 Conflict
            }
            return StatusCode(500, result.ErrorMessage); //500 Internal Server Error

        }

        // GET: api/Banks/SE
        [HttpGet("bank/{bic}")]
        public async Task<ActionResult<BankDto>> GetBank(string bic)
        {
            var bank = await _banksService.GetBankByIdAsync(bic);//Look for the registry by primary key    
            if (bank == null)
            {
                return NotFound();  //Return 404 if registry is not found
            }

            //return View(bank);
            return Ok(bank);  //Return the registry
        }

        // GET: api/Fees/5
        [HttpGet("Fees/{id}")]
        public async Task<ActionResult<FeeDto>> GetFees(int id)
        {
            var fee = await _feesService.GetFeeByIdAsync(id);  //Look for the registry by primary key

            if (fee == null)
            {
                return NotFound();  //Return 404 if registry is not found
            }

            //return View(fee);
            return Ok(fee);  //Return the registry
        }
    }
}
