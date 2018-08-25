using Delegate.Models.LocalModels;

public class SecondViewModel : BaseViewModel<LocalModel>
{
    public SecondViewModel()
    {  
    }

    private LocalModel LocalModel;
    public override void InitializeViewModel()
    {
        LocalModel.Function.Invoke(LocalModel);
    }

    public override void Prepare(LocalModel parameter)
    {
        LocalModel = parameter;
        InitializeViewModel();
    }
}