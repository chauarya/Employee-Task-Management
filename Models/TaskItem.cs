//namespace EmployeeTaskManagement.Models
//{
//    public class TaskItem
//    {

//        public int Id { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public DateTime DueDate { get; set; }
//        public int EmployeeId { get; set; }
//        public Employee Employee { get; set; }
//    }
//}
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagement.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Employee selection is required")]
        public int EmployeeId { get; set; }

        [ValidateNever]
        public Employee Employee { get; set; }
    }
}
