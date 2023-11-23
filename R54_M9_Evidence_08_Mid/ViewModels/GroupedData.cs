using R54_M9_Evidence_08_Mid.Models;

namespace R54_M9_Evidence_08_Mid.ViewModels
{
    public class GroupedData
    {
        public string Key { get; set; } = default!;
        public IEnumerable<Sale> Data { get; set; } = default!;
    }
}
