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

namespace CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> DatabaseUsers;

        private List<Address> DatabaseAddress;

        public MainWindow()
        {
            InitializeComponent();

            Read();
            using (DataContext context = new DataContext())
            {
                User user = context.Users.Find(1);
                var address = user.Address.ToList();

                foreach (var adres in address)
                {
                    MessageBox.Show(adres.Street);
                    Console.WriteLine(adres);
                }

                // Address address = new Address() { Street = "Calle 1", Number = 1, PostalCode = "47007", User = user };


                // context.Address.Add(address);
                //    context.SaveChanges();    
                
            }
        }

        /// <summary>
        /// Añade un nuevo dato a la BBDD
        /// </summary>
        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var name = tb_nombre.Text;
                var lastName = tb_LastName.Text;

                if (name != null && lastName != null)
                {
                    context.Users.Add(new User() { Name = name, LastName = lastName });
                    context.SaveChanges();
                    Read();
                }

            }
        }
        /// <summary>
        /// Lee todos los datos de la BBDD
        /// </summary>
        public void Read()
        {
            using (DataContext context = new DataContext())
            {

                DatabaseUsers = context.Users.ToList();
                ItemList.ItemsSource = DatabaseUsers;

            }

        }
        /// <summary>
        /// Para modificar un dato
        /// </summary>
        public void Update()
        {
            using (DataContext context = new DataContext())
            {
                User selectedUser = ItemList.SelectedItem as User;


                var name = tb_nombre.Text;
                var lastName = tb_LastName.Text;


                if (name != null && lastName != null)
                {
                    User user = context.Users.Find(selectedUser.Id);

                    user.Name = name;
                    user.LastName = lastName;

                    context.SaveChanges();

                    Read();
                }

            }

        }
        /// <summary>
        /// Borra un dato seleccionado con el ratón de la BBDD
        /// </summary>
        public void Delete()
        {

            using (DataContext context = new DataContext())
            {
                User selectedUser = ItemList.SelectedItem as User;

                if (selectedUser != null)
                {
                    User user = context.Users.Single(x => x.Id == selectedUser.Id);

                    context.Remove(user);
                    context.SaveChanges();
                    Read();

                }

            }

        }

        private void ButtonCrear_click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ButtonLeer_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void ItemList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                User selectedUser = ItemList.SelectedItem as User;

                DatabaseAddress = context.Address.Where(x => x.UserId == selectedUser.Id).ToList();
                ItemList2.ItemsSource = DatabaseAddress;

            }
        }
    }
}
