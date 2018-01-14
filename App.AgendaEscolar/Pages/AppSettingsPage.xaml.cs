using App.AgendaEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace App.AgendaEscolar.Pages
{
    public sealed partial class AppSettingsPage : Page
    {
        public AppSettingsViewModel ViewModel { get; } = new AppSettingsViewModel();

        public AppSettingsPage()
        {
           // this.InitializeComponent();
        }
    }
}