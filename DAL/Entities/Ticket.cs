namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ticket")]
    public partial class Ticket //����� ������
    {
        public int TicketId { get; set; } //id ������ 
        public int SessionId { get; set; } //id ������
        public string ViewerId { get; set; } //id �������, ���������������� �����
        public int Row { get; set; } //���
        public int Place { get; set; } //�����
        public decimal Price { get; set; } //����
        public int Status { get; set; } //������

        public virtual Session Session { get; set; }
    }
}
