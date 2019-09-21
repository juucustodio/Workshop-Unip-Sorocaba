using System;
using System.Collections.Generic;
using DemoApp.Models;
using DemoApp.Services;
using DemoApp.ViewModels;
using Xamarin.Forms;

namespace DemoApp.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel
            => BindingContext as MainViewModel;

        
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        /*
         -Exemplo sem utilizar o MVVM
        RestClient _client = new RestClient();
        public async void Button_Cliked(object sender, EventArgs e)
        {
            var retorno = await _client.Get<Retorno>("30");
            ListDogs.ItemsSource = retorno.Message;
        }*/
    }
}
