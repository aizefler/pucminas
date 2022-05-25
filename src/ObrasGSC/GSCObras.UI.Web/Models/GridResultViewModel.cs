namespace GSCObras.Web.Models
{
    public class GridResultViewModel<T>
    {
        public List<T> Items { get; }
        public int Count { get; }

        public GridResultViewModel(List<T> items, int count)
        {
            Items = items;
            Count = count;
        }
    }
}
