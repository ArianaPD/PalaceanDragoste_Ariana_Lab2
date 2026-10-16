using System.ComponentModel.DataAnnotations;

namespace Nume_Pren_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName; //creez proprietatea FullName

        public ICollection<Book>? Books { get; set; } // navigation property

    }
}