using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestDocumentService.Data.Interfaces;
using TestDocumentService.Models;

namespace TestDocumentService.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
    public class TestDocumentController : ControllerBase
    {
        private readonly ITestDocumentRepo _repo;
        private readonly IMapper _mapper;

        public TestDocumentController(ITestDocumentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TestDocumentReadDto>> GetAllTestDocument()
        {
            var testDocumentItems =  _repo.GetAllTestDocument();

            Console.WriteLine("--> Returning all entities");

            return Ok(_mapper.Map<IEnumerable<TestDocumentReadDto>>(testDocumentItems));
        }
        
        [HttpGet("{id}", Name = "GetTestDocumentById")]
        public ActionResult<TestDocument> GetTestDocumentById(int id)
        {
            //For debuging
            Console.WriteLine($"--> Getting test document for id: {id}");

            var testDocumentItem = _repo.GetTestDocumentById(id);

            if(testDocumentItem != null)
            {
                return Ok(_mapper.Map<TestDocumentReadDto>(testDocumentItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<TestDocument> CreateTestDocument(TestDocumentCreateDto testDocumentCreateDto)
        {
            var testDocumentModel = _mapper.Map<TestDocument>(testDocumentCreateDto);

            _repo.CreateTestDocument(testDocumentModel);

            if(_repo.SaveChanges() != false)
            {
                var testDocumentReadDto = _mapper.Map<TestDocumentReadDto>(testDocumentModel);

                Console.WriteLine($"--> Test document created: {testDocumentReadDto.Id}");

                return CreatedAtRoute(nameof(GetTestDocumentById), new {id = testDocumentReadDto.Id}, testDocumentReadDto);
            }

            return StatusCode(500);
        }

    }
}