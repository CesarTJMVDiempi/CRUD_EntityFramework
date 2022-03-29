internal class Program {
    private static void Main(string[] args) {
        ConsoleKey action;

        do {
            action = Menu();

            switch (action) {
                case ConsoleKey.C:
                    Crear();
                    break;
                case ConsoleKey.L:
                    Leer();
                    break;
                case ConsoleKey.M:
                    Mostrar();
                    break;
                case ConsoleKey.A:
                    Actualizar();
                    break;
                case ConsoleKey.B:
                    Borrar();
                    break;
                case ConsoleKey.S:
                    Console.WriteLine("Cerrando programa.");
                    break;
                default:
                    Console.Error.WriteLine("Comando no registrado. Por favor, intentelo de nuevo.");
                    break;
            }
        } while (action != ConsoleKey.S);

    }

    static void Crear() {
        string nombre = ObtenerDato("Escriba el nombre del departamento: ", "Nombre no puede estar vacio");
        string grupo = ObtenerDato("Escriba el grupo del departamento: ", "Grupo no puede estar vacio");

        using (var db = new TestProyecto.RRHHDepartment()) {
            try {
                db.Departments.Add(new TestProyecto.Department { Name = nombre, GroupName = grupo, ModifiedDate = DateTime.Now });
                db.SaveChanges();
                Console.WriteLine("Insertado correctamente");
            } catch (Microsoft.EntityFrameworkCore.DbUpdateException e) {
                Console.Error.WriteLine("A ocurrido un error al insertar el departamento, intentelo de nuevo mas tarde.");
                Console.Error.WriteLine(e.Message);
            }
        }

        ConsolaEspera();
    }

    static void Leer() {
        using (var db = new TestProyecto.RRHHDepartment()) {
            int id = ObtenerNum("Escriba el id del departamento: ", "Error eso no es un número", "Id no puede estar vacio");

            try {
                var departamento = db.Departments.AsEnumerable().ElementAt(id - 1);
                Console.WriteLine(departamento.ToString());
            } catch (ArgumentOutOfRangeException) {
                Console.Error.WriteLine($"Error! Departamento no encontrado. Asegurese de que el id esta entre 0 y {db.Departments.Count()}");
            }
        }

        ConsolaEspera();
    }

    static void Mostrar() {
        using (var db = new TestProyecto.RRHHDepartment()) {
            Console.WriteLine("Listado de departamentos:");

            db.Departments.ToList().ForEach(dep => Console.WriteLine("\t" + dep.ToString()));
            ConsolaEspera();
        }
    }

    static void Actualizar() {
        using (var db = new TestProyecto.RRHHDepartment()) {
            int id = ObtenerNum("Escriba el id del departamento: ", "Error eso no es un número", "Id no puede estar vacio");
            var departamento = db.Departments.AsEnumerable().ElementAt(id - 1);

            Console.WriteLine("Departamento a modificar:");
            Console.WriteLine(departamento.ToString() + "\n");

            string nombre = ObtenerDato("Inserte el nuevo nombre del departamento: ");
            if (nombre != string.Empty) departamento.Name = nombre;

            string grupo = ObtenerDato("Inserte el nuevo grupo del departamento: ");
            if (grupo != string.Empty) departamento.GroupName = grupo;

            departamento.ModifiedDate = DateTime.Now;


            db.SaveChanges();

            Console.WriteLine("\nDepartamento actualizado.");
            Console.WriteLine("Datos del departamento:");
            Console.WriteLine(departamento.ToString());
        }

        ConsolaEspera();
    }

    static void Borrar() {
        Console.WriteLine("Borrar");
    }

    static ConsoleKey Menu() {
        Console.WriteLine("+-----------------------+");
        Console.WriteLine("| CRUD ENTITY FRAMEWORK |");
        Console.WriteLine("+-----------------------+");
        Console.WriteLine("| [C]rear registro      |");
        Console.WriteLine("| [L]eer registro       |");
        Console.WriteLine("| [M]ostrar listado     |");
        Console.WriteLine("| [A]ctualizar registro |");
        Console.WriteLine("| [B]orrar registro     |");
        Console.WriteLine("| [S]alir del programa  |");
        Console.WriteLine("+-----------------------+");

        Console.Write("\n Accion a realizar (C, L, M, A, B, S): ");
        ConsoleKeyInfo action = Console.ReadKey();

        Console.Clear();
        return action.Key;
    }

    static string ObtenerDato(string info, string error) {
        string dato = string.Empty;

        Console.Write(info);
        while ((dato = Console.ReadLine()) == string.Empty) {
            Console.Clear();
            Console.Error.WriteLine(error);

            Console.Write(info);
        }

        return dato;
    }

    static string ObtenerDato(string info) {
        string dato = string.Empty;

        Console.WriteLine("*Dejar vacio si no se quiere cambiar*");
        Console.Write(info);
        dato = Console.ReadLine();

        return dato;
    }

    static int ObtenerNum(string info, string errorParse, string errorEmpty) {
        string dato = string.Empty;
        int num = 0;

        Console.Write(info);
        while ((dato = Console.ReadLine()) == string.Empty || !int.TryParse(dato, out num)) {
            Console.Clear();

            if (dato == string.Empty) Console.Error.WriteLine(errorEmpty);
            else Console.Error.WriteLine(errorParse);

            Console.Write(info);
        }

        return num;
    }

    static void ConsolaEspera() {
        Console.Write("\nPulsa una tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}