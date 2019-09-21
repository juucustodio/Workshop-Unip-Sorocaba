using System;
using System.Collections.Generic;
using MVVMCoffee.Models;

namespace DemoApp.Models
{
    public class Retorno : BaseModel
    {

        #region Message
        private List<string> _message;
        public List<string> Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        #endregion
    }
}
