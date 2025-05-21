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


            //comboTipoOrdenamiento.ItemsSource = gestor.ObtenerListaProductos();
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

        /*private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string criterio = comboTipoBusqueda.SelectedItem.ToString();
            string valor = txtBusqueda.Text;

            switch (criterio)
            {
                case "ID":
                    if (int.TryParse(valor, out int id))
                    {
                        var (producto, iteraciones) = BusquedaSimplificado.BusquedaSecuencialNombre(gestor.ObtenerListaProductos(), valor);
                    }
                break;

                case "Nombre":
                    var (productoNombre, iteracionesNombre) = BusquedaSimplificado.BusquedaSecuencialNombre(gestor.ObtenerListaProductos(), valor);
                    MostrarResultadoBusqueda(productoNombre, iteracionesNombre);
                break;

                case "Codigo de Barras":
                    Producto productoCodigo = gestor.BuscarPorCodigo(valor);
                    MostrarResultadoBusqueda(productoCodigo, 1);
                break;
            }
        }*/

        private void MostrarResultadoBusqueda(Producto producto, int iteraciones)
        {
            txtResultadoBusqueda.Text = producto.ToString() ?? "Producto no encontrado";
            progressIteraciones.Value = iteraciones*5;
        }


        private void DibujarGraficoBarras(List<Producto> productos)
        {
            canvasGrafico.Children.Clear();
            double maxPrecio = productos.Max(x => x.Precio);
            double escala = canvasGrafico.ActualHeight/maxPrecio;

            for (int i = 0; i < productos.Count; i++)
            {
                Rectangle barra = new Rectangle
                {
                    Width = 30,
                    Height = productos[i].Precio * escala,
                    Fill= Brushes.AliceBlue,
                    Margin = new Thickness(i*40, canvasGrafico.ActualHeight - (productos[i].Precio*escala), 0,0)
                };

                canvasGrafico.Children.Add(barra);

                //Etiqueta de producto

                TextBlock etiqueta = new TextBlock
                {
                    Text = productos[i].Nombre,
                    Margin = new Thickness(i * 40, canvasGrafico.ActualHeight - 20, 0, 0)
                };

                canvasGrafico.Children.Add(etiqueta);
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            var ventanaAgregar = new AgregarProductoWindow();

            if (ventanaAgregar.ShowDialog() ==true)
            {
                Producto nuevoProducto = ventanaAgregar.Producto;

                try
                {
                    gestor.AgregarProducto(nuevoProducto);
                    dataGridProductos.ItemsSource = null; //Refrescar la página
                    dataGridProductos.ItemsSource= gestor.ObtenerListaProductos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }


        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProductos.SelectedItem is Producto productoSeleccionado)
            {
                bool eliminado = gestor.EliminarProducto(productoSeleccionado.CodigoBarras);
                if (eliminado)
                {
                    dataGridProductos.ItemsSource = null;
                    dataGridProductos.ItemsSource = gestor.ObtenerListaProductos();
                    MessageBox.Show("Error", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Selecciona un producto", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void bnOrdenar_Click(object sender, RoutedEventArgs e) //Completar.
        {
            List<Producto> productos = new List<Producto>(gestor.ObtenerListaProductos());

            string criterio = comboTipoOrdenamiento.Text.ToString();

            switch (criterio)
            {
                case "ID":
                    OrdenadorSimplificado.QuickSortId(productos);
                    break;

                case "Nombre":
                    OrdenadorSimplificado.MergeSortPorNombre(productos);
                    break;

                case "Precio":
                    OrdenadorSimplificado.QuickSortPorPrecio(productos);
                    break;
            }
        }

        private void btnBuscar_Click_1(object sender, RoutedEventArgs e)
        {
            string criterio = comboTipoBusqueda.SelectedItem.ToString();
            string valor = txtBusqueda.Text;

            switch (criterio)
            {
                case "ID":
                    if (int.TryParse(valor, out int id))
                    {
                        var (producto, iteraciones) = BusquedaSimplificado.BusquedaSecuencialNombre(gestor.ObtenerListaProductos(), valor);
                    }
                    break;

                case "Nombre":
                    var (productoNombre, iteracionesNombre) = BusquedaSimplificado.BusquedaSecuencialNombre(gestor.ObtenerListaProductos(), valor);
                    MostrarResultadoBusqueda(productoNombre, iteracionesNombre);
                    break;

                case "Codigo de Barras":
                    Producto productoCodigo = gestor.BuscarPorCodigo(valor);
                    MostrarResultadoBusqueda(productoCodigo, 1);
                    break;
            }
        }
    }
}


