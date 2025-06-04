namespace EmployeeTaskManagement.Models
{
    public class TaskItem
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
