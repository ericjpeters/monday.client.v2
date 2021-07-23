using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTeamsRequest
    {
        TeamOptions TeamOptions { get; set; }
        UserOptions UserOptions { get; set; }
    }

    public class GetTeamsRequest : IGetTeamsRequest
    {
        public TeamOptions TeamOptions { get; set; } = new TeamOptions();
        public UserOptions UserOptions { get; set; } = new UserOptions
        {
            IncludeUrl = false,
            IncludePhotoOriginal = false,
            IncludeTitle = false,
            IncludeBirthday = false,
            IncludeCountryCode = false,
            IncludeLocation = false,
            IncludeTimeZoneIdentifier = false,
            IncludePhone = false,
            IncludeMobilePhone = false,
            IncludeMetadata = false
        };
    }
}
