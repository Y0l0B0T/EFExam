using ExamProject.Dtos.Reports;
using ExamProject.Dtos.Sections;
using ExamProject.Dtos.Zoos;
using ExamProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.EfPersistence.Zoos;

public class EfZooRepository(EfDataContext context)
{
    public void Add(Zoo zoo)
    {
        context.Set<Zoo>().Add(zoo);
    }

    public Zoo? GetById(int id)
    {
        return context.Set<Zoo>().FirstOrDefault(_ => _.Id == id);
    }

    public void Remove(Zoo zoo)
    {
        context.Set<Zoo>().Remove(zoo);
    }

    public List<GetAllZoosDto> GetAll()
    {
        return context.Zoos.Select(_ => new GetAllZoosDto
        {
            Name = _.Name,
            Address = _.Address
        }).ToList();
    }

    public List<ShowReport1Dto> Report1Dto()
    {
        return context.Set<Zoo>().Include(_ => _.Sections).ThenInclude(_ => _.Animal).Select(_ => new ShowReport1Dto
        {
            Id = _.Id,
            Name = _.Name,
            Address = _.Address,
            AnimalName = _.Sections.Select(s => s.Animal.Name).ToList()
        }).ToList();
    }

    public List<ShowReport2Dto> Report2Dto()
    {
        return context.Zoos.Include(_ => _.Sections).ThenInclude(_ => _.Ticket).Select(_ => new ShowReport2Dto
        {
            Name = _.Name,
            SectionCount = _.Sections.Count(),
            Sections = _.Sections.Select(s => new ShowSectionForReport2Dto()
            {
                TicketPrice = s.Ticket.Price,
                Area = s.Area
            }).ToList()
        }).ToList();
        
    }
}