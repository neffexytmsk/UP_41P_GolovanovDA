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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UP_41P_GolovanovDA
{
    /// <summary>
    /// Логика взаимодействия для AuthDialog.xaml
    /// </summary>
    public partial class AuthDialog : Window
    {
        private readonly Random random = new Random();
        private DispatcherTimer timer;
        private string captcha;
        public AuthDialog()
        {
            InitializeComponent();
            BaseConnect.MyGlobalConnection = new UP_41P_GolovanovDAEntities();
            GenerateCaptcha();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string password = txtPassword.Password.ToString();
            User currentUser = BaseConnect.MyGlobalConnection.User.FirstOrDefault(x => x.UserLogin == txtLogin.Text && x.UserPassword == password);//находим в базе записть с такими характеристиками
            if (currentUser != null)//если такой пользователь существует
            {
                if (captchaInputTextBox.Text == captcha)
                {
                    MessageBox.Show("Правильно");
                    GenerateCaptcha();
                    StartTimer();// Генерация новой капчи после успешного ввода
                    MessageBox.Show("Здравствуйте, " + currentUser.Role.RoleName + " " + currentUser.UserSurname + " " + currentUser.UserName);
                    
                    new MainWindow().Show();
                }
                else
                {
                    MessageBox.Show("Не правильно! Доступ заблокирован на 10 секунд.");
                    StartTimer();
                }
            }
            else//если такой пользователь не существует
            {
                MessageBox.Show("Вы не зарегистрированы");
            }
            
        }
        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 10); // Устанавливаем интервал в 10 секунд
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            GenerateCaptcha(); // Генерация новой капчи после истечения времени
            StartTimer(); // Перезапустить таймер
        }

        private void GenerateCaptcha()
        {
            // Создание случайной строки для капчи
            captcha = GenerateRandomString(6);
            captchaTextBlock.Text = captcha;
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void BtnGhost_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
