using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTeamRequest
    {
        int TeamId { get; set; }

        ITeamOptions TeamOptions { get; set; } 
    }

    public class GetTeamRequest : IGetTeamRequest
    {
        public int TeamId { get; set; }

        public ITeamOptions TeamOptions { get; set; } 

        public GetTeamRequest(int teamId)
            : this(teamId, RequestMode.Default)
        { 
        }

        public GetTeamRequest(int teamId, RequestMode mode)
        {
            TeamId = teamId;

            switch (mode)
            {
                case RequestMode.Minimum:
                    TeamOptions = new TeamOptions
                    {
                        IncludeName = false,
                        IncludePhoto = false,
                        IncludeUsers = false
                    };
                    break;

                default:
                    TeamOptions = new TeamOptions
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
                    break;
            }
        }
    }
}
