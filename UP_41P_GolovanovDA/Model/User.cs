using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_41P_GolovanovDA.Model
{
    internal class User:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        User user;
        public User(User user_Import)
        {
            this.user = user_Import;

        }
        public User()
        {
            user = new User();
        }
        public User Users { get {; return user; } set => user = value; }
    }
}
