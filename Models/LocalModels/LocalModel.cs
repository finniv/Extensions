using System;
using Delegate.Interfaces;

namespace Delegate.Models.LocalModels
{
    public class LocalModel : Model 
    {
        public Func<LocalModel,bool> Function{get;set;}

        public string ID{get;set;}
        public IMapper ViewModel{get;set;}
    }
}
