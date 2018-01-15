using App.AgendaEscolar.Data;
using App.AgendaEscolar.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AgendaEscolar.Repository
{
    public class CompromissoRepository : Repository<Compromisso>
    {
        //public CompromissoRepository()
        //{
        //    var context = new AgendaDbContext();
        //    context.Database.Migrate();
        //}

        private static readonly Lazy<CompromissoRepository> _instance =
                new Lazy<CompromissoRepository>(() => new CompromissoRepository());

        public static CompromissoRepository Instance { get { return _instance.Value; } }

        public override async Task Create(Compromisso entity)
        {
            using (var context = new AgendaDbContext())
            {
                entity.Id = Guid.NewGuid().ToString();
                Items.Add(entity);

                context.Compromisso.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public override async Task Delete(Compromisso entity)
        {
            var category = Items.SingleOrDefault(c => c.Id == entity.Id);

            if (category != null)
            {
                using (var context = new AgendaDbContext())
                {
                    Items.Remove(category);

                    context.Compromisso.Remove(category);
                    await context.SaveChangesAsync();
                }
            }
        }

        public override async Task LoadAll()
        {
            if (Items.Count > 0)
            {
                return;
            }

            using (var context = new AgendaDbContext())
            {
                var compromissos = context.Compromisso.ToList();

                foreach (var compromisso in compromissos)
                {
                    Items.Add(compromisso);
                }
            }
        }

        public override async Task Update(Compromisso entity)
        {
            using (var context = new AgendaDbContext())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

                var collectionIndex = Items.Select((value, index) => new { value, index })
                    .Where(c => c.value.Id == entity.Id)
                    .Select(x => x.index)
                    .First();

                Items[collectionIndex] = entity;
            }
        }
    }
}
