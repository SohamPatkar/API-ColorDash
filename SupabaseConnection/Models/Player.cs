using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SupabaseConnection.Models
{
    public class Player
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = "";
        [Column("passwordhash")]
        public string? PasswordHash { get; set; }
        [Column("passwordsalt")]
        public string? PasswordSalt { get; set; }
        [Column("score")]
        public int Score { get; set; }
    }
}
