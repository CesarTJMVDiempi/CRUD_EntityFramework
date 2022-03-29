ConsoleKeyInfo action;

do {
    Menu();

    switch (action.Key) {
        case ConsoleKey.C:
            Crear();
            break;
        case ConsoleKey.L:
            Leer();
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
} while (action.Key != ConsoleKey.S);


void Crear() {
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
}

void Leer() {

}

void Actualizar() {
    Console.WriteLine("Actualizar");
}

void Borrar() {
    Console.WriteLine("Borrar");
}

void Menu() {
    Console.WriteLine("+-----------------------+");
    Console.WriteLine("| CRUD ENTITY FRAMEWORK |");
    Console.WriteLine("+-----------------------+");
    Console.WriteLine("| [C]rear registro      |");
    Console.WriteLine("| [L]eer registro       |");
    Console.WriteLine("| [A]ctualizar registro |");
    Console.WriteLine("| [B]orrar registro     |");
    Console.WriteLine("| [S]alir del programa  |");
    Console.WriteLine("+-----------------------+");

    Console.Write("\n Accion a realizar (C, L, A, B, S): ");
    action = Console.ReadKey();

    Console.Clear();
}

string ObtenerDato(string info, string error) {
    string dato = string.Empty;

    Console.Write(info);
    while ((dato = Console.ReadLine()) == string.Empty) {
        Console.Clear();
        Console.Error.WriteLine(error);

        Console.Write(info);
    }

    return dato;
}