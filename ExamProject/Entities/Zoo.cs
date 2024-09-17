namespace ExamProject.Entities;

public class Zoo
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
    public List<Section> Sections { get; set; } = [];
    public List<Ticket> Tickets { get; set; } = [];
}