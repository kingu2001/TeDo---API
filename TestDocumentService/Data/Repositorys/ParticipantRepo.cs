using TestDocumentService.Data.Context;
using TestDocumentService.Data.Interfaces;
using TestDocumentService.Models;

namespace TestDocumentService.Data.Repositorys
{
    public class ParticipantRepo : IParticipant
    {
        private readonly AppDbContext _context;

        public ParticipantRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateFirm(Participant participant)
        {
            if(participant == null)
            {
                throw new ArgumentNullException(nameof(participant));
            }

            _context.Participants.Add(participant);
        }

        public IEnumerable<Participant> GetAllParticipant()
        {
            return _context.Participants.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}