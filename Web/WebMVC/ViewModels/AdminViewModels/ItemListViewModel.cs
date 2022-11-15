namespace WebMVC.ViewModels.AdminViewModels;

public class ItemListViewModel<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
}