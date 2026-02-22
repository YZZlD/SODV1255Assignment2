using Microsoft.AspNetCore.Mvc;
using SODV1255Assignment2.Models;
using SODV1255Assignment2.Repositories;

namespace SODV1255Assignment2.Controllers
{
    //Reader controller is simply get, get{id}, post, put, delete routes for basic object manipulation
    [ApiController]
    [Route("/readers")]
    public class ReaderController : Controller
    {
        private readonly ReaderRepository _readerRepository;

        public ReaderController(ReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        [HttpGet]
        public IActionResult GetAllReaders()
        {
            return Ok(_readerRepository.GetAllReaders());
        }

        [HttpGet("{id}")]
        public IActionResult GetReaderById(int id)
        {
            try
            {
                return Ok(_readerRepository.GetReaderById(id));
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Reader #{id} not found.");
            } catch (FormatException)
            {
                return NotFound("Query formatted incorrectly.");
            }

        }

        [HttpPost]
        public IActionResult AddReader([FromBody] ReaderDTO readerDTO)
        {
            Reader reader = new Reader(readerDTO.Name);
            return Ok(_readerRepository.AddReader(reader));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReader([FromBody] ReaderDTO readerDTO, int id)
        {
            try
            {
                return Ok(_readerRepository.UpdateReader(readerDTO.Name, id - 1));
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Reader #{id} not found.");
            } catch (FormatException)
            {
                return NotFound("Query formatted incorrectly.");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReader(int id)
        {
            try
            {
                _readerRepository.DeleteReader(id - 1);
                return NoContent();
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Reader #{id} not found.");
            } catch (FormatException)
            {
                return NotFound("Query formatted incorrectly.");
            }

        }
    }
}
