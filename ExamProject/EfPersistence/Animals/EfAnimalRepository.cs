using ExamProject.Dtos.Animals;
using ExamProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.EfPersistence.Animals;

public class EfAnimalRepository(EfDataContext context)
{
    public void Add(Animal animal)
    {
        context.Set<Animal>().Add(animal);
    }
    public Animal? GetById(int id)
    {
        return context.Set<Animal>().FirstOrDefault(_ => _.Id == id);
    }

    public void Remove(Animal animal)
    {
        context.Set<Animal>().Remove(animal);
    }

    public List<GetAllAnimalsDto> GetAll()
    {
        return context.Animals.Select(_ => new GetAllAnimalsDto
        {
            Id = _.Id,
            Name = _.Name
        }).ToList();
    }
}