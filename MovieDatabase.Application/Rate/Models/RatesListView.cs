using System.Collections.Generic;

namespace MovieDatabase.Application.Rate.Models
{
    public class RatesListView
    {
        public IEnumerable<RateModel> Rates { get; set; }
    }
}
