using Book.Events.Abstract;

namespace Book.Events.V1.Book;

public class Published : IBookEvent
{
    public string Id { get; set; }
    public string BookNumber { get; set; }
    public int Version { get; set; }
    public string PublishedBy { get; set; }
}