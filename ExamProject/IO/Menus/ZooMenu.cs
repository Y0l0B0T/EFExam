using ExamProject.EfPersistence;
using ExamProject.EfPersistence.Zoos;
using ExamProject.Entities;
using ExamProject.Exceptions;
using ExamProject.IO.Interfaces;

namespace ExamProject.IO.Menus;

public class ZooMenu(IUi ui, EfDataContext dbcontext) :MenuStructure(ui)
{
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
        var newZoo = new Zoo
        {
            Name = ui.GetStringFromUser("Enter Zoo Name :"),
            Address = ui.GetStringFromUser("Enter Zoo Address :")
        };
        _efZooRepository.Add(newZoo);
        dbcontext.SaveChanges();
    }
    private void ShowAll()
    {
        var Animals = _efZooRepository.GetAll();
        Animals.ForEach(_=> {ui.ShowMessage($"ID: {_.Id}\tName: {_.Name}");});
    }
    
    private void Edit()
    {
        int ZooId = ui.GetIntegerFromUser("Enter Zoo ID: ");
        var zoo = _efZooRepository.GetById(ZooId) ?? throw new NotFoundException(nameof(Zoo), ZooId);
        zoo.Name = ui.GetStringFromUser("Enter Zoo Name: ");
        zoo.Address = ui.GetStringFromUser("Enter Zoo Address: ");
        dbcontext.SaveChanges();
    }

    private void Remove()
    {
        int ZooId = ui.GetIntegerFromUser("Enter Zoo ID: ");
        var zoo = _efZooRepository.GetById(ZooId) ?? throw new NotFoundException(nameof(Zoo), ZooId);
        _efZooRepository.Remove(zoo);
        dbcontext.SaveChanges();
    }
}