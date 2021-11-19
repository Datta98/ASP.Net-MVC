using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCPractice.Models
{
    public class Department
    {
        [Required(AllowEmptyStrings =false , ErrorMessage ="Department ID Required")]
        public int DeptId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Department Name Required")]        
        public string DeptName { get; set;}
    }
}