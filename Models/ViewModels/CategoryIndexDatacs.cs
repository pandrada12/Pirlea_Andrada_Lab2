using Pirlea_Andrada_Lab2.Models;

namespace Pirlea_Andrada_Lab2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}