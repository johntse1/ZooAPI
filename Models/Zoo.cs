using System;
using System.ComponentModel.DataAnnotations;
namespace ZooAPI.Models
{
    public class Zoo
    {
        [Key]

        public int ZooID { get; set; }
        public string? ZooName { get; set; }

        public string? Location { get; set; }
    }
}
