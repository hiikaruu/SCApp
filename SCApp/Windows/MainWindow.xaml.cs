using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using SCApp.Tables;
using SCApp.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace SCApp
{
    public partial class MainWindow : Window
    {
        public byte[] WardDoc { get; set; }
        public byte[] DisabilityDoc { get; set; }
        public byte[] CertificateDoc { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            сitizenshipСheck.Checked += CheckBoxCitizenship_Checked;
            сitizenshipСheck.Unchecked += CheckBoxCitizenship_Unchecked;
        }
        private void loadDisDocButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG файлы (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                DisabilityDoc = File.ReadAllBytes(openFileDialog.FileName);
            }

        }
        private void loadOrhDocButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG файлы (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                WardDoc = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
        private void loadCerButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG файлы (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                CertificateDoc = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void CheckBoxCitizenship_Checked(object sender, RoutedEventArgs e)
        {
            foreignСitizen.Visibility = Visibility.Visible;
            subject.Visibility = Visibility.Collapsed;
        }

        private void CheckBoxCitizenship_Unchecked(object sender, RoutedEventArgs e)
        {
            foreignСitizen.Visibility = Visibility.Collapsed;
            subject.Visibility = Visibility.Visible;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (subject.Text == "Костромская область")
            {
                regionKostroma.Visibility = Visibility.Visible;
            }
            else
            {
                regionKostroma.Visibility = Visibility.Collapsed;
            }
        }
        const int reqfild = 11, nonreqfild = 1;
        String[] namereqfild = new String[reqfild] { "Фамилия", "Имя", "Дата Рождения", "Возраст","Пол","Гражданство","Закончил классов", "Средний балл","СНИЛС", "Форма обучения", "Специальность", };

        private void surname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^А-Яа-яЁё]");
        }
        private void name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^А-Яа-яЁё]");
        }
        private void patronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^А-Яа-яЁё]");
        }
        private void dtBirth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9/.] ");
        }

        private void ButtonEn_Click(object sender, RoutedEventArgs e)
        {
            String[] infreqfild = new String[reqfild] {surname.Text, name.Text, dtBirth.Text, fullYear.Text, gender.Text, citizenship.Text, education.Text, classend.Text, certificateScore.Text, snils.Text, speciality.Text};
            String[] infnonreqfild = new String[nonreqfild] { patronymic.Text };
            if (!firstValidations(infreqfild))
                return;


            infreqfild[3] = infreqfild[3].Replace('.', '-');
            DateTime date;
            if ((DateTime.TryParse(infreqfild[3], out date)))
            {
                dtBirth.ToolTip = "\"Дата рождения\" указан не верно. Данное поле заполняется по шаблону День.Месяц.Год или День-Месяц-Год";
                dtBirth.Background = Brushes.LightPink;
            }


            using (var db = new Data.MyDbContext())
            {
                var enrolle = new Enrollee
                {
                    Name = name.Text,
                    Surname = surname.Text,
                    Patronymic = patronymic.Text,
                    DtBirth = dtBirth.Text,
                    Gender = gender.Text,
                    Class = classend.Text,
                    Education = education.Text,
                    Snils = snils.Text,
                    Score = certificateScore.Text,
                    FullYear = fullYear.Text,
                    Сitizenship = citizenship.Text,
                    Subject = subject.Text,
                    Region = regionKostroma.Text,
                    Speciality = speciality.Text,
                    Certificate = certi.Text,
                    Year = year.Text,
                    DisabilityDoc = DisabilityDoc,
                    WardDoc = WardDoc,
                    CertificateDoc = CertificateDoc,
                    Enrollment = enrollment.Text
                };
                db.Enrollees.Add(enrolle);
                db.SaveChanges();

            }
        }

        private bool firstValidations(String[] infreqfild)
        {
            for (int i = 0; i < reqfild; i++)
                if (infreqfild[i] == "")
                {
                    ToolTip = ("Значение в поле \"" + namereqfild[i] + "\" должно быть заполнено");
                    Background = Brushes.LightPink;
                    return false;
                }
            return true;


        }
        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            TableWindow tableWindow = new TableWindow();
            this.Close();
            tableWindow.Show();
        }
    }
}
