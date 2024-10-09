﻿using System.ComponentModel.DataAnnotations;

namespace EmpCRUDUsingApiForDBFirstDB.Models
{
    public class Employee
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string designation { get; set; }
        [Required]
        public int salary { get; set; }
    }
}
