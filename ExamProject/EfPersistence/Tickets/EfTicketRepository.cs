using ExamProject.Dtos.Tickets;
using ExamProject.Entities;

namespace ExamProject.EfPersistence.Tickets;

public class EfTicketRepository(EfDataContext context)
{
    public void Add(Ticket ticket)
    {
        context.Set<Ticket>().Add(ticket);
    }
    public Ticket? GetById(int id)
    {
        return context.Set<Ticket>().FirstOrDefault(_ => _.Id == id);
    }

    public void Remove(Ticket ticket)
    {
        context.Set<Ticket>().Remove(ticket);
    }

    public List<GetAllTicketsDto> GetAll()
    {
        return context.Tickets.Select(_ => new GetAllTicketsDto
        {
            Id = _.Id,
            Price = _.Price
        }).ToList();
    }
}