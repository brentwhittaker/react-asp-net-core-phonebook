using Microsoft.AspNetCore.Mvc;
using Phonebook.Api.Models;
using Phonebook.Api.Repositories;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Phonebook.Api.Controllers
{
    [Route("")]
    public class EntriesController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IEntryRepository _repository;

        public EntriesController(IBusClient busClient, IEntryRepository repository)
        {
            _busClient = busClient;
            _repository = repository;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody] Contact model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Save failed" });
            }
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.PhoneNumber))
            {
                return BadRequest(new { message = "Save failed" });
            }
            var command = new Phonebook.Common.Commands.xEntry();
            command.Id = Guid.NewGuid();
            command.Name = model.Name;
            command.PhoneNumber = model.PhoneNumber;
            await _busClient.PublishAsync(command);
            return Accepted(new { message = "Save succeeded" });
        }

        [HttpGet("contacts")]
        public IActionResult Get(string searchTerm, int pageNo = 1, int pageSize = 10)
        {
            if (pageNo < 0 || pageSize < 0)
            {
                return BadRequest(new { message = "Cannot retrieve contacts" });
            }
            var totalEntries = string.IsNullOrEmpty(searchTerm) ?
                _repository.TotalCount() :
                _repository.SearchCount(searchTerm);

            var totalPages = Math.Ceiling((float)totalEntries / (float)pageSize);
            totalPages = totalPages == 0 ? totalPages = 1 : totalPages;

            if (pageNo > totalPages)
            {
                return BadRequest(new { message = "Cannot retrieve contacts" });
            }

            var entries = string.IsNullOrEmpty(searchTerm) ?
                _repository.GetCollection(pageNo, pageSize) :
                _repository.SearchCollection(pageNo, pageSize, searchTerm);

            return Json(new { entries, pageNo, totalPages });
        }
    }
}