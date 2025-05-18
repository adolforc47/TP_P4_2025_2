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

namespace GestorProductosWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GestorProductos gestor = new GestorProductos();

        public MainWindow()
        {
            InitializeComponent();
            CargarDatosInicales();

            dataGridProductos.ItemsSource = gestor.ObtenerListaProductos();
            comboTipoBusqueda.Items.Add("ID");
            comboTipoBusqueda.Items.Add("Nombre");
            comboTipoBusqueda.Items.Add("Codigo de barras");

            comboTipoBusqueda.SelectedIndex = 0;


            comboTipoOrdenamiento.ItemsSource = gestor.ObtenerListaProductos();
            comboTipoOrdenamiento.Items.Add("Id");
            comboTipoOrdenamiento.Items.Add("Nombre");
            comboTipoOrdenamiento.Items.Add("Precio");

            comboTipoOrdenamiento.SelectedIndex = 0;
        }
        private void CargarDatosInicales()
        {
            gestor.AgregarProducto(new Producto
            {
                Id = 3,
                CodigoBarras = "789123",
                Nombre = "Teclado",
                Categoria = "Electronica",
                Precio = 300,
                Stock = 20
            });
            gestor.AgregarProducto(new Producto
            {
                Id = 1,
                CodigoBarras = "123456",
                Nombre = "Mouse",
                Categoria = "Electronica",
                Precio = 10,
                Stock = 5
            });
            gestor.AgregarProducto(new Producto
            {
                Id = 4,
                CodigoBarras = "456789",
                Nombre = "Monitor",
                Categoria = "Electronica",
                Precio = 600,
                Stock = 10
            });
            gestor.AgregarProducto(new Producto
            {
                Id = 2,
                CodigoBarras = "321654",
                Nombre = "USB",
                Categoria = "Electronica",
                Precio = 15,
                Stock = 5
            });
        }
    }
}