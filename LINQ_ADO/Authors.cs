using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_ADO;

internal class Author
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public override string ToString() {
        if (FirstName != null && LastName != null)
            return FirstName + LastName;
        else
            return "";
    }
}
