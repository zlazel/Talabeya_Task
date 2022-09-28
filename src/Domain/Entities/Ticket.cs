namespace Talabeya_Task.Domain.Entities;

public class Ticket : BaseAuditableEntity
{
    public string? Phone { get; set; }
    public bool IsHandeled { get; set; }
    public Goverenorate Goverenorate { get; set; }
    public City City { get; set; }
    public District District { get; set; }

}
