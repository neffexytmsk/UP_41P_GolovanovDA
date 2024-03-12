using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UP_41P_GolovanovDA.Model;

namespace UP_41P_GolovanovDA
{
    /// <summary>
    /// Логика взаимодействия для ProdList.xaml
    /// </summary>
    public partial class ProdList : Page
    {
        ProductListModel model = new ProductListModel();
        public ProdList()
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
