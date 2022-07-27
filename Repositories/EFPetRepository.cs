using midterm_project.Migrations;
using midterm_project.Models;

namespace midterm_project.Repositories;

public class EFPetRepository : IPetRepository
{
    
    private readonly PetDbContext _context;

    public EFPetRepository(PetDbContext context) {
        _context = context;
    }
    
    public Pet CreatePet(Pet newPet)
    {
        _context.Pet.Add(newPet);
        _context.SaveChanges();
        return newPet;
    }

    public void DeletePetById(int petId)
    {
        var deletePet = _context.Pet.Find(petId);

        if (deletePet != null) {
            _context.Pet.Remove(deletePet);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Pet> GetAllPets()
    {
        return _context.Pet.ToList();
    }

    public Pet? GetPetById(int petId)
    {
        return _context.Pet.SingleOrDefault(p => p.PetId == petId);
    }

    public Pet? UpdatePet(Pet newPet)
    {
        var originalPet = _context.Pet.Find(newPet.PetId);

        if (originalPet != null) {
            originalPet.PetName = newPet.PetName;
            originalPet.PetImgUrl = newPet.PetImgUrl;
            originalPet.PetDescription = newPet.PetDescription;
            originalPet.PetBreed = newPet.PetBreed;
            originalPet.PetAge = newPet.PetAge;
            originalPet.PetGender = newPet.PetGender;
        }

        return originalPet;
    }
}