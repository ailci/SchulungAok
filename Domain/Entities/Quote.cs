namespace Domain.Entities
{
    public class Quote
    {
        public Guid Id { get; set; } // Id,Id, Klassenname + Id
        public required string QuoteText { get; set; }
        public Author? Author { get; set; }
        public Guid AuthorId { get; set; } // FK => Author + Id
    }
}