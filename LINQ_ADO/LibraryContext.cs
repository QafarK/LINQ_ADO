using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LINQ_ADO;

internal class LibraryContext : DbContext
{
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Theme> Themes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=COMPUTER01\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=SSPI;TrustServerCertificate=True");


}
