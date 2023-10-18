using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIL_Project.Models
{
    public class UserProgram
    {
        [Key]
        [ForeignKey("SessionInformation")]
        public int SessionID { get; set; }
        [ForeignKey("UserInfo")]
        public string Id { get; set; }
        public string date { get; set; }
    }
}

