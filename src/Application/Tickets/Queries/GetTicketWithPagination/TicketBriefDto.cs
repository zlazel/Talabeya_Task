using AutoMapper;
using Talabeya_Task.Application.Common.Mappings;
using Talabeya_Task.Domain.Entities;

namespace Talabeya_Task.Application.Tickets.Queries.GetTicketsWithPagination;

public class TicketBriefDto : IMapFrom<Ticket>
{
    public int Id { get; set; }
    public string? Phone { get; set; }
    public int DistrictId { get; set; }
    public DateTime Created { get; set; }
    public bool IsHandeled { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? Goverenorate { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Ticket, TicketBriefDto>()
            .ForMember(x => x.Goverenorate, opt => opt.MapFrom(s => s.Goverenorate.ToString()))
            .ForMember(x => x.City, opt => opt.MapFrom(s => s.City.ToString()))
            .ForMember(x => x.District, opt => opt.MapFrom(s => s.District.ToString()))
            ;
    }
}
