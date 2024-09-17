using ExamProject.Dtos.Animals;
using ExamProject.Dtos.SoldTickets;
using ExamProject.Entities;

namespace ExamProject.EfPersistence.SoldTickets;

public class EfSoldTicketRepository(EfDataContext context)
{
    public void Add(SoldTicket soldTicket)
    {
        context.Set<SoldTicket>().Add(soldTicket);
    }
    public SoldTicket? GetById(int id)
    {
        return context.Set<SoldTicket>().FirstOrDefault(_ => _.Id == id);
    }

    public void Remove(SoldTicket soldTicket)
    {
        context.Set<SoldTicket>().Remove(soldTicket);
    }

    public List<GetAllSoldTicketsDto> GetAll()
    {
        return context.Tickets.Select(_ => new GetAllSoldTicketsDto
        {
            Id = _.Id,
            Price = _.Price,
        }).ToList();
    }
}