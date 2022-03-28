Console.WriteLine("Inserte un número");
string? ts = Console.In.ReadLine();
int n;
;


if (ts == string.Empty) Console.WriteLine("No has escrito nada");
else if (int.TryParse(ts, out n)) {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(n);
} else {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ts + " NO ES UN NÚMERO!");
}