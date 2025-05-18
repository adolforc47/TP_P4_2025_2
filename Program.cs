//Creamos un gestor

GestorProductos gestor = new GestorProductos();

//Actividad 1 implementar las estructuras de datos

Console.WriteLine("ACTIVIDAD 1 Estructuras de datos");

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

//Mostrar inventario

gestor.MostrarInventario();

//Mostrar por categoria

gestor.MostrarProductoPorCategoria("Electronica");

//Buscar por codigo de barras
Console.WriteLine("Buscando producto con el codigo:123456");
Producto productoEncontrado = gestor.BuscarPorCodigo("123456");
Console.WriteLine(productoEncontrado != null ? productoEncontrado.ToString():"No encontrado");

//Actividad 2

Console.WriteLine("ACTIVIDAD 2: Algoritmos de ordenamiento");

//Crear una copia de la lista para ordenar

var productoParaOrdenar = new List<Producto>(gestor.ObtenerListaProductos());

//Ordenamiento con QuickSort
Console.WriteLine("Ordenado por precio con QuickSort:");
OrdenadorSimplificado.QuickSortPorPrecio(productoParaOrdenar);
foreach (var p in productoParaOrdenar)
{
    Console.WriteLine(p);
}
var productoParaOrdenar2 = new List<Producto>(gestor.ObtenerListaProductos());
Console.WriteLine("Ordenado por nombre con MergeSort:");
OrdenadorSimplificado.MergeSortPorNombre(productoParaOrdenar2);
foreach (var p in productoParaOrdenar2)
{
    Console.WriteLine(p);
}



//Actividad 3

Console.WriteLine("ACTIVIDAD 3: Algoritmos de busqueda");

//Busqueda binaria por ID
Console.WriteLine("Buscando por ID 4");
BusquedaSimplificado buscador = new BusquedaSimplificado();
var (productoBin, iterBin) = BusquedaSimplificado.BusquedaBinaria(productoParaOrdenar, 4);

Console.WriteLine(productoBin != null ? productoBin.ToString() : "No encontrado");
Console.WriteLine($"Iteraciones binaria:{iterBin}");

var (productoSec, iterSec) = BusquedaSimplificado.BusquedaSecuencial(productoParaOrdenar, 4);
Console.WriteLine(productoSec != null ? productoSec.ToString() : "No encontrado");
Console.WriteLine($"Iteraciones secuencial:{iterSec}");