using ExamProject.EfPersistence;
using ExamProject.EfPersistence.Animals;
using ExamProject.EfPersistence.Sections;
using ExamProject.Entities;
using ExamProject.Exceptions;
using ExamProject.IO.Interfaces;

namespace ExamProject.IO.Menus;

public class AnimalMenu(IUi ui, EfDataContext dbcontext) :MenuStructure(ui)
{
    private readonly EfAnimalRepository _efanimalRepository = new EfAnimalRepository(dbcontext);
    private readonly EfSectionRepository _efSectionRepository = new EfSectionRepository(dbcontext);
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
        var newAnimal = new Animal
        {
            Name = ui.GetStringFromUser("Enter Animal Name :")
        };
        _efanimalRepository.Add(newAnimal);
        dbcontext.SaveChanges();
    }
    private void ShowAll()
    {
        var Animals = _efanimalRepository.GetAll();
        Animals.ForEach(_=> {ui.ShowMessage($"ID: {_.Id}\tName: {_.Name}");});
    }
    
    private void Edit()
    {
        int AnimalId = ui.GetIntegerFromUser("Enter Animal ID: ");
        var animal = _efanimalRepository.GetById(AnimalId) ?? throw new NotFoundException(nameof(Animal), AnimalId);
        animal.Name = ui.GetStringFromUser("Enter Animal Name: ");
        
        dbcontext.SaveChanges();
    }

    private void Remove()
    {
        int AnimalId = ui.GetIntegerFromUser("Enter Animal ID: ");
        var animal = _efanimalRepository.GetById(AnimalId) ?? throw new NotFoundException(nameof(Animal), AnimalId);
        _efanimalRepository.Remove(animal);
        dbcontext.SaveChanges();
    }
}
