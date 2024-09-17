namespace ExamProject.Entities;

public class SoldTicket
{
    public int Id { get; set; }
    public Ticket Ticket { get; set; }
    public int TicketId { get; set; }
}