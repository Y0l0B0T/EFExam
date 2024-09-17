using ExamProject.EfPersistence;
using ExamProject.EfPersistence.Tickets;
using ExamProject.Entities;
using ExamProject.Exceptions;
using ExamProject.IO.Interfaces;

namespace ExamProject.IO.Menus;

public class TicketMenu(IUi ui, EfDataContext dbcontext) :MenuStructure(ui)
{
    private readonly EfTicketRepository _efTicketRepository = new EfTicketRepository(dbcontext);
    protected override void AddMenuItems()
    {
        MenuItems.Add("Add", Add);
        MenuItems.Add("Show All", ShowAll);
        MenuItems.Add("Edit", Edit);
        MenuItems.Add("Remove", Remove);
    }
    protected override string ExitMessageMenu { get; } = "Back To Main Menu";
    private void Add()
    {
        var newTicket = new Ticket
        {
            SectionId = ui.GetIntegerFromUser("Enter Section ID:"),
            Price = ui.GetDecimalFromUser("Enter Ticket Price :")
        };
        _efTicketRepository.Add(newTicket);
        dbcontext.SaveChanges();
    }
    private void ShowAll()
    {
        var Tickets = _efTicketRepository.GetAll();
        Tickets.ForEach(_=> {ui.ShowMessage($"ID: {_.Id}Price: {_.Price} Section: ?? ");});
    }
    
    private void Edit()
    {
        int TicketId = ui.GetIntegerFromUser("Enter Ticket ID: ");
        var ticket = _efTicketRepository.GetById(TicketId) ?? throw new NotFoundException(nameof(Ticket), TicketId);
        ticket.Price = ui.GetDecimalFromUser("Enter Ticket Price: ");
        dbcontext.SaveChanges();
    }

    private void Remove()
    {
        int TicketId = ui.GetIntegerFromUser("Enter Ticket ID: ");
        var ticket = _efTicketRepository.GetById(TicketId) ?? throw new NotFoundException(nameof(Ticket), TicketId);
        _efTicketRepository.Remove(ticket);
        dbcontext.SaveChanges();
    }
}