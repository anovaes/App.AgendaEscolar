using App.AgendaEscolar.Interface;
using App.AgendaEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AgendaEscolar.Repository
{
    public abstract class Repository<T> : NotificationBase, IRepository<T> where T : class
    {
        private ObservableCollection<T> _items = new ObservableCollection<T>();
        public ObservableCollection<T> Items
        {
            protected set { SetProperty(ref _items, value); }
            get { return _items; }
        }

        public abstract Task LoadAll();
        public abstract Task Create(T entity);
        public abstract Task Update(T entity);
        public abstract Task Delete(T entity);
    }
}
