using Delegate.Interfaces;

public interface INavigationService
{
    void NavigateTo<TViewModel>() where TViewModel : IViewModel , new() ;
    void NavigateTo<TViewModel,TItem>(TItem item) where TViewModel :BaseViewModel<TItem>, IViewModel, new();
}