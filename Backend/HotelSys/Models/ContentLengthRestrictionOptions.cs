using HotelSys.Interfaces;

namespace HotelSys.Models
{
    public class ContentLengthRestrictionOptions : IContentLengthRestrictionOptions
    {
        public int ContentLengthLimit { get; set; }
    }
}
