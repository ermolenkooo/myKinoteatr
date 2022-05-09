namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Film")]
    public partial class Film //класс фильма
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Session = new HashSet<Session>();
        }
        public int FilmId { get; set; } //id фильма
        [Required]
        public string Name { get; set; } //название
        public int GenreId { get; set; } //id жанра
        public int CountryId { get; set; } //id страны
        public int Timing { get; set; } //хронометраж
        public string Description { get; set; } //описание
        public string Poster { get; set; } //постер

        public virtual Country Country { get; set; }
        public virtual Genre Genre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Session> Session { get; set; }
    }
}
