using TestDocumentService.Data.Context;
using TestDocumentService.Models;

namespace TestDocumentService.Data.DatabaseSeed
{
    public static class PrepDb
    {
        public static void PrepPopulation (IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (context != null)
                {
                    SeedData(context);
                }
                else
                {
                    throw new ArgumentNullException(nameof(context));
                }
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.TestDocuments.Any())
            {
                Console.WriteLine("--> Seeding data...");

                Firm firm = new Firm{Name = "Tipatek A/S", FullAddress = "XYZ Address"};
                Participant participant = new Participant{Name = "Luke", Firm = firm, Date = DateOnly.FromDateTime(DateTime.Now).ToString(), Signature = "Testing signature"};
                Dictionary<string, string> tempDictionary = new Dictionary<string, string>
                {
                    { "Key1", "Value1" },
                    { "Key2", "Value2" }
                    
                };
                
                List<Participant> tempParcicipantList = new List<Participant>
                {
                    participant
                };

                context.TestDocuments.AddRange(
                 new TestDocument()
                {
                    Name = "Test1",
                    Introduction = "This is testing off SPK1024",
                    DefinitionAndAbbreviations = tempDictionary,
                    DocumentSupplied = "PartList.txt",
                    PunchList = new List<Punch>(),
                    Revisions = new List<Revision>(),
                    PlaceOfTestings = new List<PlaceOfTesting>(),
                    Tests = new List<Test>(),
                    Participants = tempParcicipantList  // Assuming Participants is the navigation property in TestDocument
                },
                new TestDocument()
                {
                    Name = "Test2",
                    Introduction = "This is re-testing off the PU8012 pump",
                    DefinitionAndAbbreviations = tempDictionary,
                    DocumentSupplied = "PartList.txt",
                    PunchList = new List<Punch>(),
                    Revisions = new List<Revision>(),
                    PlaceOfTestings = new List<PlaceOfTesting>(),
                    Tests = new List<Test>(),
                    Participants = tempParcicipantList
                }
            );
                

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}