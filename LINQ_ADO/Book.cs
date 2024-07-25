using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LINQ_ADO;

internal class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Pages { get; set; }

    public int YearPress { get; set; }

    public int Id_Author { get; set; }
    public int Id_Themes { get; set; }
    public int Id_Category { get; set; }

    public override string ToString()=> Name;
}