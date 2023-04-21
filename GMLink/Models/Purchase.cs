using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GMLink.Models
{
    public class Purchase
    {
        [BindNever]
        public int PurchaseID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        public string GroupName { get; set; }
 
    } 
}