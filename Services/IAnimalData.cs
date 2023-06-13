using AnimalNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalNotebook.Services
{
    public interface IAnimalData
    {
        IEnumerable<Animal> GetAnimals();

        IEnumerable<Animal> GetAnimals(AnimalType Breed);

        Animal GetAnimal(Guid id);

        void AddAnimal(Animal animal);

        void EditAnimal(Animal animal);

        void DeleteAnimal(Animal animal);

        void Dispose();
    }
}
