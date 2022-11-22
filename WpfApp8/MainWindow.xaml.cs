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

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PageChange pc = new PageChange();  // создаем объект класса для отображения страниц
        List<CatTable> CatsFilter = new List<CatTable>();
        public MainWindow()
        {
            InitializeComponent();
            ClassBase.TB = new testBaseEntities();
            CatsFilter = ClassBase.TB.CatTable.ToList();
            LVCats.ItemsSource = ClassBase.TB.CatTable.ToList();
            pc.CountPage = ClassBase.TB.CatTable.ToList().Count;
            DataContext = pc;  // добавляем объект для отображения страниц в ресурсы страницы
        }
        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                pc.CountPage = CatsFilter.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            pc.Countlist = CatsFilter.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            LVCats.ItemsSource = CatsFilter.Skip(0).Take(pc.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
            pc.CurrentPage = 1; // текущая страница - это страница 1
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)  // обработка нажатия на один из Textblock в меню с номерами страниц
        {
            TextBlock tb = (TextBlock)sender;
            
            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            LVCats.ItemsSource = CatsFilter.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();  // оображение записей постранично с определенным количеством на каждой странице
            // Skip(pc.CurrentPage* pc.CountPage - pc.CountPage) - сколько пропускаем записей
            // Take(pc.CountPage) - сколько записей отображаем на странице
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            pc.CurrentPage=1;
            
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                pc.CountPage = CatsFilter.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            pc.Countlist = CatsFilter.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            LVCats.ItemsSource = CatsFilter.Skip(0).Take(pc.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
        }
    }
}
