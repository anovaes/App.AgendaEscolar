using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AgendaEscolar.Data
{
    public class Compromisso
    {
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
        public System.Nullable<DateTimeOffset> Data { get; set; }
        public TipoCompromisso Tipo { get; set; }
        public string Descricao { get; set; }
    }

    public enum TipoCompromisso
    {
        Prova, Trabalho, Tarefa, Exercício, Simulado, Outro
    }

    public class CompromissoService
    {
        public static string Name = "Fake Data Service.";

        public static List<Compromisso> ConsultaCompromissos()
        {
            return new List<Compromisso>()
                {
                    new Compromisso() { Nome="Prova de matemática", Data=DateTime.Now.AddDays(-10), Tipo=TipoCompromisso.Prova, Descricao="Prova de geometria. Estudar capítulos 25 e 26"},
                    new Compromisso() { Nome="Tarefa de português", Data=DateTime.Now.AddDays(20), Tipo=TipoCompromisso.Tarefa, Descricao="Responder questionário da página 56"},
                    new Compromisso() { Nome="Trabalho de geografia", Data=DateTime.Now.AddDays(5), Tipo=TipoCompromisso.Trabalho, Descricao="Desenhar o mapa do Brasil. Trabalho em dupla."},
                };
        }

        public static void Write(Compromisso compromisso)
        {
            Debug.WriteLine("INSERT person with name " + compromisso.Nome);
        }

        public static void Delete(Compromisso compromisso)
        {
            Debug.WriteLine("DELETE person with name " + compromisso.Nome);
        }
    }
}
