using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UP_41P_GolovanovDA.Model
{
    internal class ProductListModel: INotifyPropertyChanged
    {
        List<Product> product;



        /// <summary>
        /// задаем в конструкторе значения по умолчанию
        /// </summary>
        public ProductListModel()
        {
            product = BaseConnect.MyGlobalConnection.Product.ToList();//список из базы

        }

        /// <summary>
        /// свойство для списка пользователей
        /// </summary>
        public List<Product> Product
        {
            get => product; set
            {
                product = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Product)));
            }
        }

        /// <summary>
        /// свойство для списка ролей. Его мы не изменяем, а только получаем (поэтому нет set)
        /// </summary>


        string zaglushkaPath;

        public string ZaglushkaPath { get { MessageBox.Show("ok"); return zaglushkaPath; } set => zaglushkaPath = "/Picture/shrek.jpg"; }






        public event PropertyChangedEventHandler PropertyChanged;
    }
}
