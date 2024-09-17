using ExamProject.Dtos.Reports;
using ExamProject.Dtos.Sections;
using ExamProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.EfPersistence.Sections;

public class EfSectionRepository(EfDataContext context)
{
    public void Add(Section section)
    {
        context.Set<Section>().Add(section);
    }
    public Section? GetById(int id)
    {
        return context.Set<Section>().FirstOrDefault(_ => _.Id == id);
    }

    public void Remove(Section section)
    {
        context.Set<Section>().Remove(section);
    }

    public List<GetAllSectionsDto> GetAll()
    {
        return context.Sections.Select(_ => new GetAllSectionsDto
        {
            Id = _.Id,
            Name = _.Name,
            Descriptsion = _.Description,
            Area = _.Area,
            AnimalCount = _.AnimalCount
        }).ToList();
    }

    public List<ShowReport3Dto> Report3Dto()
    {
        return context.Sections.Include(_ => _.Animal).Select(_ => new ShowReport3Dto
        {
            Id = _.Id,
            Description = _.Description,
            AnimalCount = _.AnimalCount,
            AnimalName = _.Animal.Name,
        }).ToList();
    }
    public List<ShowReport4Dto> Report4Dto()
    {
        return context.Sections.Include(_ => _.Ticket).ThenInclude(_ => _.SoldTickets).Select(_ => new ShowReport4Dto
            {
                SectionId = _.Id,
                SoldTicketCount = _.Ticket.SoldTickets.Count,
            }).OrderByDescending(_ => _.SoldTicketCount).ToList();
    }
    public List<ShowReport5Dto> Report5Dto()
    {
        return context.Sections.Include(_ => _.Ticket).ThenInclude(_ => _.SoldTickets).Select(_ => new ShowReport5Dto
            {
                SectionId = _.Id,
                TotalPrice = _.Ticket.Price * _.Ticket.SoldTickets.Count,
            }).OrderByDescending(_ => _.TotalPrice).ToList();
    }
}