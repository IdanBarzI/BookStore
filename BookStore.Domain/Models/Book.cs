using BookStore.Domain.Models.IModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public enum BookGenre
    {
        Unknown,//Defult
        ComicBook,
        DetectiveAndMystery,
        Fantasy,
        Horror,
        Romance,
        ShortStories,
        BiographiesAndAutobiographies,
        Cookbooks,
        History,
        Poetry,
        TrueCrime
    }

    public class Book : BaseProduct
    {
        public BookGenre BookGenre { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string Edition { get; set; }

    }
}
