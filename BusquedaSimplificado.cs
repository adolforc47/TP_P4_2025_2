
public class BusquedaSimplificado
{
    //Busqueda Binaria
    public static (Producto,int) BusquedaBinaria(List<Producto>productos, int idBuscado)
    {
        int inicio = 0;
        int fin = productos.Count - 1;
        int iteraciones = 0;

        //Ciclo de busqueda

        while (inicio<=fin)
        {
            iteraciones++;

            //Obtener el producto de la mitad

            int mitad = (inicio +fin)/2;

            //Comparar con el ID buscado
            if (productos[mitad].Id == idBuscado)
            {
                return (productos[mitad], iteraciones);
            }

            //Ajustar los limites de busqueda

            if (productos[mitad].Id<idBuscado)
            {
                inicio = mitad + 1;
            }
            else
            {
                fin = mitad - 1;
            }

        }

        return (null, iteraciones); //No se encontro
    }

    //Busqueda secuencial

    public static (Producto, int) BusquedaSecuencial(List<Producto> productos, int idBuscado)
    {
        int iteraciones = 0;

        //Recorrer la lista uno por uno

        foreach (Producto producto in productos)
        {
            iteraciones++;

            //Comparar el elemento actual con el buscado
            if (producto.Id == idBuscado)
            { 
                return (producto, iteraciones);
            }
        }

        return (null, iteraciones);
    }

    public static (Producto, int) BusquedaSecuencialNombre(List<Producto> productos, string nombre)
    {
        int iteraciones = 0;

        //Recorrer la lista uno por uno

        foreach (Producto producto in productos)
        {
            iteraciones++;

            //Comparar el elemento actual con el buscado
            if (producto.Nombre.Equals(nombre,StringComparison.OrdinalIgnoreCase))
            {
                return (producto, iteraciones);
            }
        }

        return (null, iteraciones);
    }
}
