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