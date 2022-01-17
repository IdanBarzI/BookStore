using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public enum JournalGenre
    {
        Unknown,
        NewsArticles,
        Features,
        Portraits,
        Reportages,
        Interviews,
        Editorials,
        Columns,
        Reviews,
        Essays
    }

    public class Journal : BaseProduct
    {
        public JournalGenre JournalGenres { get; set; }

    }
}
