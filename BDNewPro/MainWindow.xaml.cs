using BDNewPro.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLitePCL;
using System.Data.SqlClient;

namespace BDNewPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductDBContext dbContext;
        Product product = new Product();
        public MainWindow(ProductDBContext dBContext)
        {
           this.dbContext = dBContext;
            InitializeComponent();
            GetTab();
            
            gridAdd.DataContext = product;
        }

        private void GetTab()
        {
            tab.ItemsSource = dbContext.Products.ToList();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            GetTab();
            product = new Product();
            gridAdd.DataContext = product;

        }
        Product selectedProduct = new Product();
        private void UpdateClickForEdit(object sender, RoutedEventArgs e)
        {
            selectedProduct = (sender as FrameworkElement).DataContext as Product;
            gridUpd.DataContext = selectedProduct;
        }
        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            dbContext.Update(selectedProduct);
            dbContext.SaveChanges();
            GetTab();
        }

        private void DeleteClick (object sender, RoutedEventArgs e)
        {
            var prodForDel = (sender as FrameworkElement).DataContext as Product;
            dbContext.Products.Remove(prodForDel);
            dbContext.SaveChanges();
            GetTab() ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double p = Convert.ToDouble( selT.Text);
            tab.ItemsSource = dbContext.Products.Where(x => x.Price == p ).ToList();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tab.ItemsSource = dbContext.Products.Join(dbContext.Shops, p=> p.Id, s => s.Id ,(p,s) => new { p.Name, p.Description, p.Price, p.Uint, s.Id, s.Adress }).ToList();
        }
    }
}