using App.AgendaEscolar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AgendaEscolar.ViewModels
{
    public class MainPageViewModel : NotificationBase
    {
        public void AppSettingsButton_Click()
        {
            NavigationService.Navigate<AppSettingsPage>();
        }
    }
}
