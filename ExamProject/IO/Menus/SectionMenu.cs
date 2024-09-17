using ExamProject.EfPersistence;
using ExamProject.EfPersistence.Animals;
using ExamProject.EfPersistence.Sections;
using ExamProject.EfPersistence.Zoos;
using ExamProject.Entities;
using ExamProject.Exceptions;
using ExamProject.IO.Interfaces;

namespace ExamProject.IO.Menus;

public class SectionMenu(IUi ui, EfDataContext dbcontext) :MenuStructure(ui)
{
    private readonly EfSectionRepository _efSectionRepository = new EfSectionRepository(dbcontext);
    private readonly EfAnimalRepository _efAnimalRepository = new EfAnimalRepository(dbcontext);
    private readonly EfZooRepository _efZooRepository = new EfZooRepository(dbcontext);
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
        ShowAll();
        int AnimalId = ui.GetIntegerFromUser("Enter Animal ID :");
        var animal = _efAnimalRepository.GetById(AnimalId)
                      ?? throw new NotFoundException(nameof(Section), AnimalId);
        int ZooId = ui.GetIntegerFromUser("Enter Zoo ID :");
        var zoo = _efZooRepository.GetById(ZooId)
                     ?? throw new NotFoundException(nameof(Zoo), ZooId);
        var newSection = new Section
        {
            AnimalId = AnimalId,
            ZooId = ZooId,
            Name = ui.GetStringFromUser("Enter Section Name :"),
            Description = ui.GetStringFromUser("Enter Section Description :"),
            Area = ui.GetIntegerFromUser("Enter Section Area :"),
            AnimalCount = ui.GetIntegerFromUser("Enter Section Animal Count :"),
        };
        _efSectionRepository.Add(newSection);
        dbcontext.SaveChanges();
    }
    private void ShowAll()
    {
        var sections = _efSectionRepository.GetAll();
        sections.ForEach(_=> {ui.ShowMessage($"ID: {_.Id} Name: {_.Name} Description: {_.Descriptsion} Area= {_.Area}  Animal Count = {_.AnimalCount}");});
    }
    
    private void Edit()
    {
        int SectionId = ui.GetIntegerFromUser("Enter Section ID: ");
        var section = _efSectionRepository.GetById(SectionId) ?? throw new NotFoundException(nameof(Section), SectionId);
        section.AnimalId = ui.GetIntegerFromUser("Enter Animal ID: ");
        section.Name = ui.GetStringFromUser("Enter Section Name: ");
        section.Description = ui.GetStringFromUser("Enter Section Description: ");
        section.Area = ui.GetIntegerFromUser("Enter Section Area: ");
        section.AnimalCount = ui.GetIntegerFromUser("Enter Section AnimalCount: ");
        dbcontext.SaveChanges();
    }

    private void Remove()
    {
        int SectionId = ui.GetIntegerFromUser("Enter Section ID: ");
        var section = _efSectionRepository.GetById(SectionId) ?? throw new NotFoundException(nameof(Section), SectionId);
        _efSectionRepository.Remove(section);
        dbcontext.SaveChanges();
    }
}