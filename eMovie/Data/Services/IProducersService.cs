using eMovie.Data.DTOs;
using eMovie.Models;

namespace eMovie.Data.Services
{
    public interface IProducersService
    {
        IEnumerable<Producer> GetAllProducers();

        Producer GetProducerById(int id);
        void AddProducer(ProducerDTO producer);
        Producer UpdateProducer(int id, ProducerDTO producer);
        void DeleteProducer(int id);
    }
}
