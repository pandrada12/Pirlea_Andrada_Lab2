using System.Collections.Generic;

namespace Pirlea_Andrada_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Proprietate ajutătoare utilă pentru afișarea numelui complet în liste/tabele
        public string FullName => $"{FirstName} {LastName}";

        // Proprietate de navigare către cărți
        public ICollection<Book>? Books { get; set; }
    }
}