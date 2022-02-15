string fileName = GetFileName();
fileName += ".txt";
List<string> data = GetTestData();
File.WriteAllLines(fileName, data);
char symbolToSearch = GetSymbolToSearch();
WriteFilteredLines(fileName, symbolToSearch);
void WriteFilteredLines(string sourceFile, char symbolToSearch)
{
    var newFileName = "new" + sourceFile;
    FileStreamOptions readOptions = new() { Access = FileAccess.Read };
    FileStreamOptions writeOptions = new() { Access = FileAccess.Write };
    using StreamReader reader = new(sourceFile, readOptions);
    using StreamWriter writer = new(newFileName);

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        var filteredWords = line?.Split(" ").Where(x => x.StartsWith(symbolToSearch));
        string newLine = string.Join(" ", filteredWords);
        writer.WriteLine(newLine);
    }

    Console.WriteLine("Data was successfully written!");
}

char GetSymbolToSearch()
{
    Console.WriteLine("\n Enter a symbol you want to search: ");
    char symbol = (char)Console.Read();
    return symbol;
}

List<string> GetTestData()
{
    Console.WriteLine("Enter the content of the initial file: ");
    var content = new List<string>();
    while (true)
    {
        var info = Console.ReadKey();
        if (info.Modifiers == ConsoleModifiers.Control)
        {
            break;
        }

        string valueFromConsole = info.KeyChar + Console.ReadLine();
        content.Add(valueFromConsole);
    }

    return content;
}

string GetFileName()
{
    do
    {
        Console.WriteLine("Enter the name of a file: ");
        string valueFromConsole = Console.ReadLine();
        if (!string.IsNullOrEmpty(valueFromConsole))
        {
            return valueFromConsole;
        }
        else
        {
            Console.WriteLine("File name cannot be empty!Try again\n");
        }
    } 
    while (true);

}