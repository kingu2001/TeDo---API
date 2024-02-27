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

                //Adding new firm and participants
                Firm firm = new Firm{Name = "Tipatek A/S", FullAddress = "XYZ Address"};
                Participant participant = new Participant{Name = "Luke",Firm = firm, Date = DateOnly.FromDateTime(DateTime.Now).ToString(), Signature = "Testing signature"};
                
                
                //Creating new definitionAndAbbrevation
                DefinitionAndAbbrevation definitionAndAbbrevation1 = new DefinitionAndAbbrevation(){Definition = "Key1", Abbrevation = "Value1"};
                DefinitionAndAbbrevation definitionAndAbbrevation2 = new DefinitionAndAbbrevation(){Definition = "Key2", Abbrevation = "Value2"};

                //Creating new tesdocument
                TestDocument testDocument1 = new TestDocument()
                {
                    Name = "Test1",
                    Introduction = "This is testing off SPK1024",
                    DocumentSupplied = "PartList.txt",
                    Punches = new List<Punch>(),
                    Revisions = new List<Revision>(),
                    Firms = new List<Firm>(),
                    Tests = new List<Test>(),
                    Participants = new List<Participant>(),
                    DefinitionAndAbbrevations = new List<DefinitionAndAbbrevation>()
                };

                //Adding definitionAndAbbrevation1 to testDocument1 
                testDocument1.DefinitionAndAbbrevations.Add(definitionAndAbbrevation1);
                testDocument1.Participants.Add(participant);

                //Adding definitionAndAbbrevation2 to testDocument2
                TestDocument testDocument2 = new TestDocument()
                {
                    Name = "Test2",
                    Introduction = "This is re-testing off the PU8012 pump",
                    DocumentSupplied = "PartList.txt",
                    Punches = new List<Punch>(),
                    Revisions = new List<Revision>(),
                    Firms = new List<Firm>(),
                    Tests = new List<Test>(),
                    Participants = new List<Participant>(),
                    DefinitionAndAbbrevations = new List<DefinitionAndAbbrevation>()
                };

                context.TestDocuments.AddRange(testDocument2, testDocument1);
                

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}