using SQLite;

namespace BiLink.Models
{
    [Table("Links")]
    public class Link
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nome{ get; set; } = string.Empty;
        [NotNull]
        public string URL { get; set; } = string.Empty;
        [Indexed]
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; } = string.Empty;
    }

    [Table("Categorias")]
    public class Categorias
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull, Unique]
        public string Nome { get; set; } = string.Empty;
    }

}
