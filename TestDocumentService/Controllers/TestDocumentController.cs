using AutoMapper;
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
        public ActionResult<IEnumerable<TestDocumentReadDto>> GetAllPlatforms()
        {
            var testDocumentItems =  _repo.GetAllPTestDocument();

            return Ok(_mapper.Map<IEnumerable<TestDocumentReadDto>>(testDocumentItems));
        }

    }
}