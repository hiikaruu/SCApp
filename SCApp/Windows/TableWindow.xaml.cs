using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OfficeOpenXml;
using SCApp.Data;
using SCApp.Tables;

namespace SCApp.Windows
{
    public partial class TableWindow : Window
    {
        public ObservableCollection<Enrollee> Enrollees { get; set; }
        public MyDbContext Db { get; set; }
        public TableWindow()
        {
            Enrollees = new ObservableCollection<Enrollee>();
            Db = new MyDbContext();
            Db.Enrollees.ToList().ForEach(e => Enrollees.Add(e));
            InitializeComponent();
        }

        public Enrollee SelectedEnrolle { get; set; }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            if (SelectedEnrolle is null)
            {
                return;
            }
            else
            {
                Db.Enrollees.Remove(SelectedEnrolle);
                Enrollees.Remove(SelectedEnrolle);
                Db.SaveChanges();
            }
        }
        public class DB
        {
            public List<Enrollee> GetTable()
            {
                return new MyDbContext().Enrollees.ToList();
            }


        }
        private void Button_SaveExcel(object sender, RoutedEventArgs e)
        {
            new Excel().createFile();
        }
        public class Excel
        {

            public void createFile()
            {
                List<Enrollee> list = new DB().GetTable();
                createFile(list);
            }

            public void createFile(List<Enrollee> list)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var path = @"" + fbd.SelectedPath + "\\Приемная комиссия.xlsx";
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;


                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        var table = pck.Workbook.Worksheets.Add("Enrolles");
                        table.Cells[2, 1].LoadFromCollection(list, false);
                        table.Column(19).Style.Numberformat.Format = "dd-MM-yyyy";
                        table.Cells["A1"].Value = "Имя";
                        table.Cells["B1"].Value = "Фамилия";
                        table.Cells["C1"].Value = "Отчество";
                        table.Cells["D1"].Value = "Дата рождения";
                        table.Cells["E1"].Value = "Возраст";
                        table.Cells["F1"].Value = "Пол";
                        table.Cells["G1"].Value = "Гражданство";
                        table.Cells["H1"].Value = "Субъект";
                        table.Cells["I1"].Value = "Регион";
                        table.Cells["J1"].Value = "Закончил классов";
                        table.Cells["K1"].Value = "Средний балл аттестата";
                        table.Cells["L1"].Value = "СНИЛС";
                        table.Cells["M1"].Value = "Форма обучения";
                        table.Cells["N1"].Value = "Специальность";
                        table.Cells["O1"].Value = "Зачисление";
                        table.Cells["P1"].Value = "Год поступления";
                        table.Cells["Q1"].Value = "Инвалидность";
                        table.Cells["R1"].Value = "Сиротство";
                        table.Cells["S1"].Value = "Аттестат";

                        try
                        {
                            pck.SaveAs(new FileInfo(path));
                        }
                        catch (System.InvalidOperationException e)
                        {
                            System.Windows.MessageBox.Show("Ошибка выбора пути. Выберетие другой путь сохранения", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
            }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
