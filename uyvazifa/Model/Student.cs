using System.ComponentModel.DataAnnotations;


namespace uyvazifa.Model
{
    public class Student
    {
        [Key]
        public int  StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }

    }
}
