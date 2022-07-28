using System.ComponentModel.DataAnnotations;

namespace midterm_project.Models;

// Creating enum options for Gender to use a drop down in the View (https://www.c-sharpcorner.com/UploadFile/4b0136/getting-started-with-enum-support-in-mvc-5-view/)
public enum Gender {
    Male,
    Female
}

public class Pet {

    public int PetId { get; set; }

    [Required]
    [Display(Name = "Pet Name")]
    public string PetName { get; set; }

    [Required]
    [Display(Name = "Pet Image URL")]
    public string PetImgUrl { get; set; }

    [Required]
    [Display(Name = "Pet Description")]
    public string PetDescription { get; set; }

    [Required]
    [Display(Name = "Pet Breed")]
    public string PetBreed { get; set; }

    [Required, Range(0, 30)]
    [Display(Name = "Pet Age")]
    public float PetAge { get; set; }

    [Required]
    [Display(Name = "Pet Gender")]
    public Gender PetGender { get; set; }

}