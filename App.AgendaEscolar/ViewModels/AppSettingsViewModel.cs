using App.AgendaEscolar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.AgendaEscolar.Services;

using Windows.UI.Xaml.Controls;

namespace App.AgendaEscolar.ViewModels
{
    public class AppSettingsViewModel : NotificationBase
    {
 
        private int? _appThemeSetting;

        public int? AppThemeSetting
        {
            get
            {
                return StorageService.GetSetting(StorageService.Settings.AppTheme, _appThemeSetting);
            }
            set
            {
                StorageService.SaveSetting(StorageService.Settings.AppTheme, value);

                ShowAppResetMessage();
            }
        }

        private bool _dialogTriggered;

        private void ShowAppResetMessage()
        {
            if (_dialogTriggered)
            {
                return;
            }

            _dialogTriggered = true;

            var dialog = new ContentDialog
            {
                Title = "Aviso",
                Content = "Você precisa reiniciar o App para trocar o estilo.",
                PrimaryButtonText = "OK"
            };

            dialog.PrimaryButtonClick += (s, e) =>
            {
                _dialogTriggered = false;
            };

            dialog.ShowAsync();
        }
    }
}
