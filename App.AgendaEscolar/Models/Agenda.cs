using App.AgendaEscolar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AgendaEscolar.Models
{
    public class Agenda
    {
        public List<Compromisso> Compromissos { get; set; }
        public string Nome { get; set; }

        public Agenda(string databaseName)
        {
            Nome = databaseName;
            Compromissos = CompromissoService.ConsultaCompromissos();
        }

        public void Add(Compromisso compromisso)
        {
            if (!Compromissos.Contains(compromisso))
            {
                Compromissos.Add(compromisso);
                CompromissoService.Write(compromisso);
            }
        }

        public void Delete(Compromisso compromisso)
        {
            if (Compromissos.Contains(compromisso))
            {
                Compromissos.Remove(compromisso);
                CompromissoService.Delete(compromisso);
            }
        }

        public void Update(Compromisso compromisso)
        {
            CompromissoService.Write(compromisso);
        }
    }
}
