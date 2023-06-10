using AnimalNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalNotebook.Services
{
    public class InMemoryAnimalData : IAnimalData
    {
        List<Animal> animals;

        public InMemoryAnimalData()
        {
            animals = new List<Animal>()
            {
                new Animal{Id = Guid.NewGuid(), Name = "Ziggy", Age = 10, Type = AnimalType.Dog, Breed = "Siberian Husky"},
                new Animal{Id = Guid.NewGuid(), Name = "Zelda", Age = 4, Type = AnimalType.Cat, Breed = "American Shorthair"},
                new Animal{Id = Guid.NewGuid(), Name = "Achilies", Age = 3, Type = AnimalType.Rodent, Breed = "Guinea Pig"},
                new Animal{Id = Guid.NewGuid(), Name = "Zetsu", Age = 2, Type = AnimalType.Rodent, Breed = "Guinea Pig"},
                new Animal{Id = Guid.NewGuid(), Name = "Ying", Age = 22, Type = AnimalType.Reptile, Breed = "Turtle"},
                new Animal{Id = Guid.NewGuid(), Name = "Yang", Age = 22, Type = AnimalType.Reptile, Breed = "Turtle"}
            };
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public void deleteAnimal(Animal animal)
        {
            animals.Remove(animal);
        }

        public void EditAnimal(Animal animal)
        {
            var index = animals.FindIndex(a => a.Id == animal.Id);
            if(index != -1)
            {
                animals[index] = animal;
            }
        }

        public Animal GetAnimal(Guid id)
        {
            return animals.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return animals.OrderBy(a => a.Type);
        }

        public IEnumerable<Animal> GetAnimals(AnimalType type)
        {
            return animals.Where(a => a.Type == type);
        }
    }
}
