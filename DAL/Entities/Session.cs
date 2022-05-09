namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Session")]
    public partial class Session //класс сеанса
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Session()
        {
            Ticket = new HashSet<Ticket>();
        }
        public int SessionId { get; set; } //id сеанса
        public int FilmId { get; set; } //id фильма
        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; } //дата и время
        public int HallId { get; set; } //id зала
        public virtual Film Film { get; set; }
        public virtual Hall Hall { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
