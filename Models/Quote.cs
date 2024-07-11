namespace LOTR.SDK.Models;

public class Quote
{
    public string Id { get; set; }
    public string Dialog { get; set; }
    
    // TODO: Extend in the future to support fetching related entities like Movie and Character
    // TODO: Extend in the future to have separate models for Movie and Character that can conditionally be included
    public string Movie { get; set; }
    public string Character { get; set; }
}