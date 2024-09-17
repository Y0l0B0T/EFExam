using ExamProject.Dtos.Reports;
using ExamProject.Dtos.Sections;
using ExamProject.EfPersistence;
using ExamProject.EfPersistence.Animals;
using ExamProject.EfPersistence.Sections;
using ExamProject.EfPersistence.Zoos;
using ExamProject.IO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.IO.Menus;

public class ReportMenu(EfDataContext context, IUi ui) : MenuStructure(ui)
{
    private readonly EfZooRepository _efZooRepository = new EfZooRepository(context);
    private readonly EfSectionRepository _efSectionRepository = new EfSectionRepository(context);
    
    protected override void AddMenuItems()
    {
        MenuItems.Add("Show All Zoos ", Report1);
        MenuItems.Add("Show Zoo and Section's Zoo & Details(Tick Price, Area)", Report2);
        MenuItems.Add("Show Sections & Details(Type, AnimalCount)", Report3);
        MenuItems.Add("Show Sold Tickets Section's Zoo (Order By SoldTickets Count)", Report4);
        MenuItems.Add("Show Sold Tickets Section's Zoo(Order By Sum Ticket Price)", Report5);
    }

    private void Report1()
    {
        _efZooRepository.Report1Dto();
    }

    private void Report2()
    {
        _efZooRepository.Report2Dto();
    }

    private void Report3()
    {
        _efSectionRepository.Report3Dto();
    }

    private void Report4()
    {
        _efSectionRepository.Report4Dto();
    }

    private void Report5()
    {
        _efSectionRepository.Report5Dto();
    }
}