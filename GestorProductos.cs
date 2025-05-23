public class GestorProductos
{
    //Lista para mntener el orden de insercion y ordenar

    public List<Producto> listaProductos = new List<Producto>();

    //Diccionario para busquedas rapidas

    public Dictionary<string, Producto> diccionarioProductos = new Dictionary<string, Producto>();

    //Metodos

    public List<Producto> ObtenerListaProductos()
    {
        return new List<Producto>(listaProductos);
    }

    //Operaciones con lista

    public void AgregarProducto(Producto p)
    {
        // Validar codigo de barras

        if (diccionarioProductos.ContainsKey(p.CodigoBarras))
        {
            throw new Exception("El codigo de barras ya existe");
        }

        //Añadir producto a lista
        listaProductos.Add(p);
        //Añadir codigo de barras a diccionario
        diccionarioProductos[p.CodigoBarras] = p;
    }

    public bool EliminarProducto(string codigoBarras)
    {
        if (diccionarioProductos.TryGetValue(codigoBarras, out var producto))
        {
            listaProductos.Remove(producto);
            diccionarioProductos.Remove(codigoBarras);

            return true;
        }
        return false;
    }

    public void MostrarInventario()
    {
        Console.WriteLine("Inventario completo:");

        foreach (var p in listaProductos)
        {
            Console.WriteLine(p);
        }
    }

    //Operaciones con diccionario

    public Producto BuscarPorCodigo(string codigoBarras)
    {
        return diccionarioProductos.TryGetValue(codigoBarras, out var producto)? producto:null;
    }

    public void MostrarProductoPorCategoria(string categoria)
    {
        Console.WriteLine($"Productos en categoria: {categoria}-");

        foreach (var p in listaProductos)
        {
            if (p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(p);
            }
        }
    }

    public bool ExisteProducto(string codigoBarras)
    {
        return diccionarioProductos.ContainsKey(codigoBarras);
    }
}
