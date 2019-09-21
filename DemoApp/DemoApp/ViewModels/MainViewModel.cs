using System;
using DemoApp.Models;
using DemoApp.Services;
using MVVMCoffee.ViewModels;
using Xamarin.Forms;

namespace DemoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //Utilizar SetProperty na propriedade Retorno, se não a Lista não é atualizada após a consulta na API.
        private Retorno _retorno;
        public Retorno Retorno
        {
            get => _retorno;
            set => SetProperty(ref _retorno, value);
        }

        RestClient _client = new RestClient();

        public Command CarregaListaCommand { get; }

        public MainViewModel()
        {
            CarregaListaCommand = new Command(CarregaLista);
            Retorno = new Retorno();

        }

        public async void CarregaLista()
        {
            Retorno = await _client.Get<Retorno>("30");

        }

    }
}
