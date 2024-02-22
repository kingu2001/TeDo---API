using AutoMapper;
using TestDocumentService.Models;

namespace TestDocumentService.Profiles
{
    public class TestDocumentProfile : Profile
    {
        public TestDocumentProfile()
        {
            //Her mapper vi vores Dto'er med vores model klasse
            // source -> target
            //Fordi vores Dto'er og model klasses prop hedder det samme
            //skal vi ikke configuere yderligere (det hedder jo AutoMapper >_>)
            CreateMap<TestDocument, TestDocumentReadDto>();
            CreateMap<TestDocumentCreateDto, TestDocument>();
        }
    }

}