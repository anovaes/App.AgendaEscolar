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
    public class AgendaViewModel : NotificationBase
    {
        Agenda agenda;

        public AgendaViewModel(string name)
        {
            agenda = new Agenda(name);
            _SelectedIndex = -1;

            foreach (var compromisso in agenda.Compromissos)
            {
                var np = new CompromissoViewModel(compromisso);
                np.PropertyChanged += Person_OnNotifyPropertyChanged;
                _Compromisso.Add(np);

            }
        }

        ObservableCollection<CompromissoViewModel> _Compromisso = new ObservableCollection<CompromissoViewModel>();

        public ObservableCollection<CompromissoViewModel> Compromissos
        {
            get { return _Compromisso; }
            set { SetProperty(ref _Compromisso, value); }
        }

        string _Nome;
        public string Nome
        {
            get { return agenda.Nome; }
        }

        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                {
                    RaisePropertyChanged(nameof(SelecionadoCompromisso));
                }
            }
        }

        public CompromissoViewModel SelecionadoCompromisso
        {
            get { return (_SelectedIndex >= 0) ? _Compromisso[_SelectedIndex] : null; }
        }

        public void Add()
        {
            var compromisso = new CompromissoViewModel();
            compromisso.PropertyChanged += Person_OnNotifyPropertyChanged;
            Compromissos.Add(compromisso);
            agenda.Add(compromisso);
            SelectedIndex = Compromissos.IndexOf(compromisso);
        }

        public void Delete()
        {
            if (SelectedIndex != -1)
            {
                var compromisso = Compromissos[SelectedIndex];
                Compromissos.RemoveAt(SelectedIndex);
                agenda.Delete(compromisso);
            }
        }

        void Person_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            agenda.Update((CompromissoViewModel)sender);
        }
    }
}
