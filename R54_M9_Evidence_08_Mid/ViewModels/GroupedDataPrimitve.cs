using R54_M9_Evidence_08_Mid.Models;

namespace R54_M9_Evidence_08_Mid.ViewModels
{
    public class GroupedDataPrimitve<T>
    {
        public string Key { get; set; } = default!;
        public T Data { get; set; } = default!;
    }
}
