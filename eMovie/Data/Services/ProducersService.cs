using eMovie.Data.DTOs;
using eMovie.Models;

namespace eMovie.Data.Services
{
    public class ProducersService:IProducersService
    {
        private readonly AppDbContext _context;

        public ProducersService(AppDbContext context)
        {
                _context = context;
        }

        public void AddProducer(ProducerDTO producer)
        {
            Producer producerToAdd = new Producer()
            {
                FullName = producer.FullName,
                Bio = producer.Bio,
                ProfilePictureURL = producer.ProfilePictureURL
            };
            _context.Producers.Add(producerToAdd);
            _context.SaveChanges();
        }

        public void DeleteProducer(int id)
        {
            var producerToDelete = _context.Producers.FirstOrDefault(i=> i.Id==id);
            if (producerToDelete != null)
            {
                _context.Producers.Remove(producerToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Producer> GetAllProducers()
        {
            var producers = _context.Producers.ToList();
            return producers;
        }

        public Producer GetProducerById(int id)
        {
            var producer = _context.Producers.FirstOrDefault(i => i.Id == id);
                return producer;

        }

        public Producer UpdateProducer(int id, ProducerDTO producer)
        {
           var pr = _context.Producers.FirstOrDefault(i => i.Id == id);
            if (pr != null)
            {
                pr.FullName = producer.FullName;
                pr.Bio = producer.Bio;
                pr.ProfilePictureURL = producer.ProfilePictureURL;
                _context.SaveChanges();
            }
            return pr;
        }
    }
}
