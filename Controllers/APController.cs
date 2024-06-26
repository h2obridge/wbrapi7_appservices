﻿using Microsoft.AspNetCore.Mvc;
using wbrapi7_appservices.Repositories;

namespace wbrapi7_appservices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APController : Controller
    {
        IWBRDataRepository _repository;
        public APController(IWBRDataRepository repository)
        {
            _repository = repository;

        }


        [HttpGet("STImport/{ticketNo}")]
        public IActionResult APStatementImport(string ticketNo)
        {
            //var dataFromRepo = _repository.apStatementImport(ticketNo);

            //return Ok(dataFromRepo);
            var dataFromRepo = new { Message = "Success", Data = (object)null };
            return Ok(dataFromRepo);


        }

        [HttpGet("GetSafIncHeadStatus/")]
        public IActionResult GetSafIncHeadStatus()
        {
            var dataFromRepo = _repository.GetvciSafIncHeadStatus();
            if (dataFromRepo == null)
            {
                return NotFound();
            }

            return Ok(dataFromRepo);
        }


        [HttpGet("JIBReadFolder/")]
        public IActionResult JIBReadFolder()
        {
            try
            {
                var dataFromRepo2 = _repository.JIBReadFolder();
                //JIBExceltoPDF();
                if (dataFromRepo2.Equals("ok", StringComparison.OrdinalIgnoreCase))
                {
                    return Ok(dataFromRepo2);
                }
                else
                {
                    // If the message is anything else, assume it's an error message
                    return BadRequest(dataFromRepo2);
                }

            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }



        }


    }
}

