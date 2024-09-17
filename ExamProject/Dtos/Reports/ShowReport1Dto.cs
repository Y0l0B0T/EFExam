using ExamProject.Entities;

namespace ExamProject.Dtos.Reports;

public class ShowReport1Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<string> AnimalName { get; set; }
}