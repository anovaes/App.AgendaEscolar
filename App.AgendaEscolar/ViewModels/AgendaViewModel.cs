using App.AgendaEscolar.Data;
using App.AgendaEscolar.Models;
using App.AgendaEscolar.Repository;
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
        public CompromissoRepository CompromissoRepository { get; private set; } = CompromissoRepository.Instance;

        public AgendaViewModel(string name)
        {
            agenda = new Agenda(name);
            _SelectedIndex = -1;
        }

        public void CarregaLista()
        {
            var itens = CompromissoRepository.Items;

            foreach (var compromisso in itens)
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

        public IEnumerable<TipoCompromisso> ListaDeTipos
        {
            get { return Enum.GetValues(typeof(TipoCompromisso)).Cast<TipoCompromisso>();  }
        }

        public async Task Initialize()
        {
            await CompromissoRepository.LoadAll();
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

        private bool _isSplitViewOpen;
        public bool IsSplitViewOpen
        {
            get { return _isSplitViewOpen; }
            set { SetProperty(ref _isSplitViewOpen, value); }
        }

        //public void Add()
        //{
        //    var compromisso = new CompromissoViewModel();
        //    compromisso.PropertyChanged += Person_OnNotifyPropertyChanged;
        //    Compromissos.Add(compromisso);
        //    agenda.Add(compromisso);
        //    SelectedIndex = Compromissos.IndexOf(compromisso);
        //}

        public async void Add()
        {
            var compromisso = new CompromissoViewModel();
            compromisso.PropertyChanged += Person_OnNotifyPropertyChanged;
            Compromissos.Add(compromisso);
            await CompromissoRepository.Create(compromisso);
            SelectedIndex = Compromissos.IndexOf(compromisso);
        }

        public async void Delete()
        {
            if (SelectedIndex != -1)
            {
                var compromisso = Compromissos[SelectedIndex];
                Compromissos.RemoveAt(SelectedIndex);
                await CompromissoRepository.Delete(compromisso);
                //agenda.Delete(compromisso);
            }
        }

        async void Person_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            var compromisso = (CompromissoViewModel)sender;
            await CompromissoRepository.Update(compromisso);
            //agenda.Update((CompromissoViewModel)sender);
        }

        public void HamburguerButton_Click()
        {
            IsSplitViewOpen = !IsSplitViewOpen;
        }

        
    }
}
