namespace LINQ_ADO;

internal class Category
{

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public override string ToString() => Name;
}
