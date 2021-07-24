using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTeamsRequest
    {
        ITeamOptions TeamOptions { get; set; }
    }

    public class GetTeamsRequest : IGetTeamsRequest
    {
        public ITeamOptions TeamOptions { get; set; } = new TeamOptions
        {
            IncludeUsers = true,
            UserOptions = new UserOptions
            {
                IncludeUrl = false,
                IncludePhoto = false,
                IncludeTitle = false,
                IncludeBirthday = false,
                IncludeCountryCode = false,
                IncludeLocation = false,
                IncludeTimeZoneIdentifier = false,
                IncludePhone = false,
                IncludeMobilePhone = false,
                IncludeIsGuest = false,
                IncludeIsPending = false,
                IncludeIsEnabled = false,
                IncludeCreatedAt = false
            }
        };
    }
}
