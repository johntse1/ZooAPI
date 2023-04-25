using System;
using System.ComponentModel.DataAnnotations;
namespace ZooAPI.Models
{
    public class Animal
    {
        [Key]
        public int AnimalID { get; set; }
        public string? AnimalName { get; set; }
        public string? SubSpecies { get; set; }
    }
}
