using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Project21WPF
{
    public static class Ext
    {
        public static ObservableCollection<Contact> ToObservableCollection(this IEnumerable<Contact> e)
        {
            ObservableCollection<Contact> t = new ObservableCollection<Contact>();
            foreach (var item in e)
            {
                t.Add(item);
            }
            return t;
        }
        public static ObservableCollection<Contact> ToObservableCollection(this Contact e)
        {
            ObservableCollection<Contact> t = new ObservableCollection<Contact>();
            t.Add(e);
            return t;
        }
    }
}
