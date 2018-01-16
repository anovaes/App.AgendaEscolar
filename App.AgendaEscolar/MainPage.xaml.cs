using App.AgendaEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App.AgendaEscolar.Services;
using App.AgendaEscolar.Pages;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App.AgendaEscolar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public AgendaViewModel Agenda { get; set; }

        public MainPage()
        {
            Agenda = new AgendaViewModel("Office");
            MainPage_Loaded();
            Agenda.CarregaLista();
            this.InitializeComponent();
        }

        public void Configuracoes_Click()
        {
            NavigationService.Navigate<AppSettingsPage>();
            //this.Frame.Navigate(typeof(AppSettingsPage));
        }

        private async void MainPage_Loaded()
        {
            await Agenda.Initialize();
        }

    }
}
