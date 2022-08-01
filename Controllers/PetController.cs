using midterm_project.Repositories;
using midterm_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace midterm_project.Controllers;

public class PetController : Controller
{

    private readonly ILogger<PetController> _logger;

    private readonly IPetRepository _petRepository;

    public PetController(ILogger<PetController> logger, IPetRepository repository)
    {

        _logger = logger;
        _petRepository = repository;
    }

    // GET / view of all pets 
    public IActionResult List()
    {
        return View(_petRepository.GetAllPets());
    }

    // GET / view for details of pet by id
    public IActionResult Detail(int id)
    {
        var findPet = _petRepository.GetPetById(id);

        if (findPet == null)
        {
            return RedirectToAction("List");
        }

        return View(findPet);
    }

    // GET / view to edit pet by id
    public IActionResult Edit(int id)
    {
        var findPet = _petRepository.GetPetById(id);

        if (findPet == null)
        {
            return RedirectToAction("List");
        }

        return View(findPet);
    }

    // POST / UPDATE pet by id
    [HttpPost]
    public IActionResult Edit(Pet editPet)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _petRepository.UpdatePet(editPet);

        return RedirectToAction("Detail", new {id = editPet.PetId});
    }

    // GET / view to add a new pet
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    // POST / add new pet 
    [HttpPost]
    public IActionResult Add(Pet newPet)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _petRepository.CreatePet(newPet);

        return RedirectToAction("Detail", new {id = newPet.PetId});
    }

    // DELETE / pet by id
    public IActionResult Delete(int id)
    {
        _petRepository.DeletePetById(id);

        return RedirectToAction("List");
    }



}