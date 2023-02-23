namespace Book.Events.Shared;

public class EventHeader
{
    public EventHeader(DateTime timeStamp, string userName, string identityName, int version)
    {
        TimeStamp = timeStamp;
        UserName = userName;
        IdentityName = identityName;
        Version = version;
    }
    
    public DateTime TimeStamp { get; set; }
    public string UserName { get; set; }
    public string IdentityName { get; set; }
    public int Version { get; set; }
}