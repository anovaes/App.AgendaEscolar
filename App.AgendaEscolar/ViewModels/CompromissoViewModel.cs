using App.AgendaEscolar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AgendaEscolar.ViewModels
{
    public class CompromissoViewModel : NotificationBase<Compromisso>
    {
        public CompromissoViewModel(Compromisso compromisso = null) : base(compromisso) { }

        public string Nome
        {
            get { return This.Nome; }
            set { SetProperty(This.Nome, value, () => This.Nome = value); }
        }

        public DateTime Data
        {
            get { return This.Data; }
            set { SetProperty(This.Data, value, () => This.Data = value); }
        }

        public TipoCompromisso Tipo
        {
            get { return This.Tipo; }
            set { SetProperty(This.Tipo, value, () => This.Tipo = value); }
        }

        public string Descricao
        {
            get { return This.Descricao; }
            set { SetProperty(This.Descricao, value, () => This.Descricao = value); }
        }
    }
}
