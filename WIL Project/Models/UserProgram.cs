using System;
using System.ComponentModel.DataAnnotations;

namespace WIL_Project.Models
{
    public class UserProgram
    {
        [Key]
        public string session_name { get; set; }
        public string date { get; set; }
    }
}

