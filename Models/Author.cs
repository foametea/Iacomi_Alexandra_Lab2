using System.ComponentModel.DataAnnotations;

namespace Iacomi_Alexandra_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return AuthorName + " " + AuthorLastName;
            }
        }
        public ICollection<Book>? Books { get; set; }
    }
}

