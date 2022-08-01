using midterm_project.Models;

namespace midterm_project.Repositories;

public interface IPetRepository {

    IEnumerable<Pet> GetAllPets();

    Pet? GetPetById(int petId);

    Pet CreatePet(Pet newPet);

    Pet? UpdatePet(Pet newPet);

    void DeletePetById(int petId);
}