using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Delegate.Interfaces;
using Delegate.Models;
using Delegate.Models.LocalModels;
using Monad;
using ResultExtension;

namespace Delegate.ViewModels
{
    public class FirstViewModel : BaseViewModel, IMapper
    {
        public delegate long BinaryOp(int multiply);
        private INavigationService _navigationService;
        public FirstViewModel()
        {
            
        }
       

        public override void InitializeViewModel()
        {
            base.InitializeViewModel();
            _navigationService = navigationService;
            var mapped = new Result<Model>(new Model
            {
                Property = "test",
                IntProperty = 1
            })
            .Map(x => new LocalModel
            {
                Property = x.Property,
                IntProperty = x.IntProperty,
                ViewModel = this
            });
            LocalModels = new List<LocalModel>();
            mapped.Value.ViewModel.MapSucced();
            for (int i = 0; i < 10; i++)
            {
                LocalModels.Add(new LocalModel
                {
                    ID = i.ToString(),
                    ViewModel = this,
                    Function = (LocalModel item)=>
                    {
                       return LocalModels.Remove(item);
                    }

                });
            }
            navigationService.NavigateTo<SecondViewModel,LocalModel>(LocalModels[5]);
            Task.Run(()=>
            {
                while (true)
                {
                    
                }
            });
        }

        private List<LocalModel> _localModels;
        public List<LocalModel> LocalModels
        {
            get=> _localModels;
            set => _localModels = value;
        }

        public void MapSucced()
        {
            Console.WriteLine("Done");
        }

    }
}
