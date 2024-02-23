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

                // Firm firm = new Firm{Name = "Tipatek A/S", FullAddress = "XYZ Address"};
                // Participant participant = new Participant{Name = "Luke", Firm = firm, Date = DateOnly.FromDateTime(DateTime.Now), Signature = "Testing signature"};
                // PlaceOfTesting placeOfTesting = new PlaceOfTesting{Firm = firm, TestType = TestType.FAT};
                // Test test = new Test();
                context.TestDocuments.AddRange
                (
                    new TestDocument() {Name = "Test1", Introduction = "This is testing off SPK1024", DefinitionAndAbbreviations = new Dictionary<string, string>(), 
                                        DocumentSupplied = "PartList.txt", PunchList = new List<Punch>(), Revisions = new List<Revision>(), 
                                        PlacesOfTesting = new List<PlaceOfTesting>(), Tests = new List<Test>()}, 

                    new TestDocument() {Name = "Test2", Introduction = "This is re-testing off the PU8012 pump", DefinitionAndAbbreviations = new Dictionary<string, string>(), 
                                        DocumentSupplied = "PartList.txt", PunchList = new List<Punch>(), Revisions = new List<Revision>(), 
                                        PlacesOfTesting = new List<PlaceOfTesting>(), Tests = new List<Test>()}
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