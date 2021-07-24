﻿using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTeamRequest
    {
        int TeamId { get; set; }

        TeamOptions TeamOptions { get; set; } 
        UserOptions UserOptions { get; set; } 
    }

    public class GetTeamRequest : IGetTeamRequest
    {
        public int TeamId { get; set; }

        public TeamOptions TeamOptions { get; set; } = new TeamOptions();
        public UserOptions UserOptions { get; set; } = new UserOptions
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
        };

        public GetTeamRequest(int teamId)
        {
            TeamId = teamId;
        }
    }
}
