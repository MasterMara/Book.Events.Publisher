using Book.Events.Common;
using Book.Events.V1.Book;
using Book.Events.V1.Book.Props;

namespace Book.Events.Publisher.SeedData;

public static class BookEventPublisher
{

    public static Created PublishCreatedEvent()
    {
        var bookCreated = new Created
        {
            Id = "1",
            Version = 1,
            BookNumber = "123456",
            BookName = "Outliers",
            Writer = new Writer
            {
                Id = "10",
                Name = "Mustafa KARACABEY"
            },
            TotalAmount = new Money
            {
                CurrencyCode = 949,
                Value = 100
            }
        };
        return bookCreated;
    }

    public static Placed PublishPlacedEvent()
    {
        var bookPlaced= new Placed
        {
            Id = "1",
            Version =2,
            BookNumber = "123456",
          
        };
        return bookPlaced;
    }
    
    public static Printed PublishPrintedEvent()
    {
        var bookPrinted= new Printed()
        {
            Id = "1",
            Version = 3,
            BookNumber = "123456",
            PrintedBy = "Kadir"
          
        };
        return bookPrinted;
    }
    
    public static Deleted PublishDeletedEvent()
    {
        var bookDeleted= new Deleted()
        {
            Id = "1",
            Version = 4,
            BookNumber = "123456",
          
        };
        return bookDeleted;
    }
    
    public static Published PublishPublishedEvent()
    {
        var bookDeleted= new Published()
        {
            Id = "1",
            Version = 5,
            BookNumber = "123456",
            PublishedBy = "Muhammed"
          
        };
        return bookDeleted;
    }
}