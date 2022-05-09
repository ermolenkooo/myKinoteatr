namespace DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Film")]
    public partial class Film //����� ������
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Session = new HashSet<Session>();
        }
        public int FilmId { get; set; } //id ������
        [Required]
        public string Name { get; set; } //��������
        public int GenreId { get; set; } //id �����
        public int CountryId { get; set; } //id ������
        public int Timing { get; set; } //�����������
        public string Description { get; set; } //��������
        public string Poster { get; set; } //������

        public virtual Country Country { get; set; }
        public virtual Genre Genre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Session> Session { get; set; }
    }
}
