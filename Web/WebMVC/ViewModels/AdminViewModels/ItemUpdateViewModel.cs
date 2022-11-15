namespace WebMVC.ViewModels.AdminViewModels;

public class ItemUpdateViewModel<T>
{
    public T Item { get; set; } = default(T)!;
}