using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using M42.SPA.Sports;

namespace M42.API.Areas.Sports.Controllers
{
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ILogger<SportsController> _logger;
        private readonly IService<M42.Sports.Sport> _sportsService;

        public SportsController(ILogger<SportsController> logger, IService<M42.Sports.Sport> sportsService)
        {
            _logger = logger;
            _sportsService = sportsService;
        }
        [Route("api/[controller]")]
        [HttpGet]
        public IEnumerable<Sport> Get()
        {
            try
            {
                return SportsBuilder.GetSports(_sportsService);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Exception occurred in SportsService.Get() method.");

                throw ex;
            }
        }
        [Route("api/[controller]/{id}")]
        [HttpGet]
        public Sport Get(int id)
        {
            try
            {
                return SportsBuilder.GetSport(_sportsService, id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Exception occurred in SportsService.Get(id) method.");

                throw ex;
            }
        }
    }
}