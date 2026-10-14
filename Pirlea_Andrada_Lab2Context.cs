using Microsoft.EntityFrameworkCore;

public class Pirlea_Andrada_Lab2Context(DbContextOptions<Pirlea_Andrada_Lab2Context> options) : DbContext(options)
{
    public DbSet<Pirlea_Andrada_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Pirlea_Andrada_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Pirlea_Andrada_Lab2.Models.Author> Author { get; set; } = default!;
}