using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_ADO;

internal class Theme
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public override string ToString()=> Name;
}
