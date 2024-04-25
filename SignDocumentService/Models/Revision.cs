using System.Text.Json.Serialization;

namespace SignDocumentService.Models
{
    public class Revision
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string PageAffected { get; set; }
        public string SectionAffected { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int SignedDocumentId { get; set; }
    }
}