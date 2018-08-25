using Delegate.Interfaces;

public class NavigationService : INavigationService
{
    public void NavigateTo<TViewModel>() where TViewModel : IViewModel, new()
    {
        new TViewModel();
    }

    public void NavigateTo<TViewModel, TItem>(TItem item) where TViewModel :BaseViewModel<TItem>, IViewModel, new()
    {
        new TViewModel().Prepare(item);
    }
}