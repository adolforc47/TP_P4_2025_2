public class OrdenadorSimplificado
{
    //Quick Sort ordena por ID

    public static void QuickSortId(List<Producto> productos)
    {
        //Caso lista con un elemento
        if (productos.Count <= 1)
        {
            return;
        }

        //Elegir un pivote
        Producto pivote = productos[productos.Count - 1];
        //Sublistas
        var menores = new List<Producto>();
        var mayores = new List<Producto>();

        for (int i = 0; i < productos.Count - 1; i++)
        {
            if (productos[i].Id < pivote.Id)
            {
                menores.Add(productos[i]);
            }
            else
            {
                mayores.Add(productos[i]);
            }
        }

        //Recursivo
        QuickSortId(menores);
        QuickSortId(mayores);

        //Ordenamiento de lista
        productos.Clear();

        productos.AddRange(menores);
        productos.Add(pivote);
        productos.AddRange(mayores);
    }


    //Quicksort por precio

    public static void QuickSortPorPrecio(List<Producto> productos)
    {
        //Caso lista con un elemento
        if (productos.Count <= 1)
        {
            return;
        }

        //Elegir un pivote
        Producto pivote = productos[productos.Count - 1];
        //Sublistas
        var menores = new List<Producto>();
        var mayores = new List<Producto>();

        for (int i = 0; i < productos.Count - 1; i++)
        {
            if (productos[i].Precio < pivote.Precio)
            {
                menores.Add(productos[i]);
            }
            else
            {
                mayores.Add(productos[i]);
            }
        }

        //Recursivo
        QuickSortPorPrecio(menores);
        QuickSortPorPrecio(mayores);

        //Ordenamiento de lista
        productos.Clear();

        productos.AddRange(menores);
        productos.Add(pivote);
        productos.AddRange(mayores);
    }

    // Merge Sort ordena por nombre

    public static List<Producto> MergeSortPorNombre(List<Producto> productos)
    {
        if (productos.Count <= 1)
        {
            return productos;
        }

        //Dividir lista por la mitad

        int mitad = productos.Count / 2;

        var izquierda = productos.GetRange(0, mitad);
        var derecha = productos.GetRange(mitad, productos.Count - mitad);

        //Recursividad

        izquierda = MergeSortPorNombre(izquierda);
        derecha = MergeSortPorNombre(derecha);

        //Comparacion para mezcla
        return Mezclar(izquierda, derecha);

    }

    public static List<Producto> Mezclar(List<Producto> izquierda, List<Producto> derecha)
    {
        var resultado = new List<Producto>();

        int i = 0, j = 0;

        //Comparamos y ordenamos

        while (i < izquierda.Count && j < derecha.Count)
        {
            if (string.Compare(izquierda[i].Nombre, derecha[j].Nombre) < 0)
            {
                resultado.Add(izquierda[i++]);
            }
            else
            {
                resultado.Add(derecha[j++]);
            }
        }

        //Agregar elementos restantes

        while (i < izquierda.Count)
        {
            resultado.Add(izquierda[i++]);
        }
        while (j < derecha.Count)
        {
            resultado.Add(derecha[j++]);
        }

        return resultado;
    }

}
