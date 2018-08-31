using Delegate.Interfaces;

public abstract class BaseViewModel : IViewModel
{
    protected INavigationService navigationService;
    public BaseViewModel()
    {
        navigationService = new NavigationService();
        InitializeViewModel();
    }
    public virtual void InitializeViewModel()
    {

    }
}

public abstract class BaseViewModel<TParameter> : IViewModel
{
    protected INavigationService navigationService;
    public BaseViewModel()
    {
        navigationService = new NavigationService();
    }
    public virtual void InitializeViewModel()
    {

    }

    public virtual void Prepare(TParameter parameter)
    {
        InitializeViewModel();
    }
}