using Market.DB;
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

namespace Market.Views
{

    public partial class ProductAndCategoryxaml : Window
    {
        public ProductAndCategoryxaml()
        {
            InitializeComponent();
            Items.ItemsSource = ShopEntities1.GetContext().Product.ToList();
            Categories.ItemsSource = ShopEntities1.GetContext().Category.ToList();
        }

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (Product)Items.SelectedItem;
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите элемент для редактирования!");
            }
            else
            {
                EditProductWindow editProductWindow = new EditProductWindow(selectedProduct);
                editProductWindow.ShowDialog();
            }
            Categories.ItemsSource = null;
            Items.ItemsSource = null;
            Categories.ItemsSource = ShopEntities1.GetContext().Category.ToList();
            Items.ItemsSource = ShopEntities1.GetContext().Product.ToList();

        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {

            Category selectedCategory = (Category)Categories.SelectedItem;
            if (selectedCategory == null)
            {
                MessageBox.Show("Выберите элемент для редактирования!");
            }
            else
            {
                EditCategoryWindow editCategoryWindow = new EditCategoryWindow(selectedCategory);
                editCategoryWindow.ShowDialog();
            }
            Categories.ItemsSource = null;
            Items.ItemsSource = null;
            Categories.ItemsSource = ShopEntities1.GetContext().Category.ToList();
            Items.ItemsSource = ShopEntities1.GetContext().Product.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            addCategoryWindow.ShowDialog();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Product> products = new List<Product>();
            Items.ItemsSource = null;
            Items.ItemsSource = ShopEntities1.GetContext().Product.ToList();
            if(SearchBox.Text == string.Empty || SearchBox.Text == "")
            {
                Items.ItemsSource = null;
                Items.ItemsSource = ShopEntities1.GetContext().Product.ToList();
            }
            else
            {
                foreach(Product product in Items.Items)
                {
                    if(product.nameProduct.Contains(SearchBox.Text) || product.description.Contains(SearchBox.Text))
                    {
                        products.Add(product);
                    }
                }
                Items.ItemsSource = null;
                Items.ItemsSource = products;
            }
        }
    }

}

