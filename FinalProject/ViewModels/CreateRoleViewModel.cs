using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Role_Name { get; set; }
    }
}
