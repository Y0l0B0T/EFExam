using ExamProject.Dtos.Sections;
using ExamProject.Entities;

namespace ExamProject.Dtos.Reports;

public class ShowReport2Dto
{
    public string Name { get; set; }
    public int SectionCount { get; set; }
    
    public decimal Price { get; set; }
    public int Area { get; set; }
    public List<ShowSectionForReport2Dto> Sections { get; set; }
}