using Book.Events.Abstract.Base;

namespace Book.Events.Abstract;

public interface IBookEvent : IEvent
{
    public string BookNumber { get; set; }
}