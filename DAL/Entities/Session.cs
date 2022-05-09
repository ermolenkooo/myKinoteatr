namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Session")]
    public partial class Session //����� ������
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Session()
        {
            Ticket = new HashSet<Ticket>();
        }
        public int SessionId { get; set; } //id ������
        public int FilmId { get; set; } //id ������
        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; } //���� � �����
        public int HallId { get; set; } //id ����
        public virtual Film Film { get; set; }
        public virtual Hall Hall { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
