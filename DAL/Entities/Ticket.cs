namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ticket")]
    public partial class Ticket //класс билета
    {
        public int TicketId { get; set; } //id билета 
        public int SessionId { get; set; } //id сеанса
        public string ViewerId { get; set; } //id зрителя, забронировавшего билет
        public int Row { get; set; } //ряд
        public int Place { get; set; } //место
        public decimal Price { get; set; } //цена
        public int Status { get; set; } //статус

        public virtual Session Session { get; set; }
    }
}
