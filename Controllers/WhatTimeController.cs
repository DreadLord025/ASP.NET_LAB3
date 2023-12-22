using lab3.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhatTimeController : Controller
    {
        private readonly TimeOfDayService _timeOfDayService;

        public WhatTimeController(TimeOfDayService timeOfDayService)
        {
            _timeOfDayService = timeOfDayService;
        }

        [HttpGet]
        public IActionResult GetWhatTime()
        {
            string timeOfDay = _timeOfDayService.GetTimeOfDay();
            return Ok($"Доброго времени суток. {timeOfDay}!");
        }
    }
}
