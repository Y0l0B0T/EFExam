namespace ExamProject.Entities;

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Area { get; set; }
    public int AnimalCount { get; set; }
    public Animal Animal { get; set; }
    public int AnimalId { get; set; }
    public Zoo Zoo { get; set; }
    public int ZooId { get; set; }
    public Ticket Ticket { get; set; }
}