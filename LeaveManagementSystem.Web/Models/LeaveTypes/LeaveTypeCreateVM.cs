﻿using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;


namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Required]
        [Length(4,150,ErrorMessage ="You have violate the length requirments")]
        public string? Name { get; set; }
        [Required]
        [Range(1,90)]
        [Display(Name = "Maximum Allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
