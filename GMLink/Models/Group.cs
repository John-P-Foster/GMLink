using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GMLink.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string? Member1 { get; set; } = null;
        public string? Member2 { get; set; } = null;
        public string? Member3 { get; set; } = null;
        public string? Member4 { get; set; } = null;
        public string? Member5 { get; set; } = null;
        public string? Member6 { get; set; } = null;

    }
}
