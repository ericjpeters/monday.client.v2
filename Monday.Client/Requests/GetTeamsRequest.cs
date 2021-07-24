﻿using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTeamsRequest
    {
        ITeamOptions TeamOptions { get; set; }
    }

    public class GetTeamsRequest : IGetTeamsRequest
    {
        public ITeamOptions TeamOptions { get; set; }

        public GetTeamsRequest()
            : this(RequestMode.Default)
        {
        }

        public GetTeamsRequest(RequestMode mode)
        {
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

                case RequestMode.Maximum:
                    TeamOptions = new TeamOptions
                    {
                        IncludeName = true,
                        IncludePhoto = true,
                        IncludeUsers = true,
                        UserOptions = new UserOptions
                        {
                            IncludeName = true,
                            IncludeEmail = true,
                            IncludeUrl = true,
                            IncludePhoto = true,
                            IncludeTitle = true,
                            IncludeBirthday = true,
                            IncludeCountryCode = true,
                            IncludeLocation = true,
                            IncludeTimeZoneIdentifier = true,
                            IncludePhone = true,
                            IncludeMobilePhone = true,
                            IncludeIsGuest = true,
                            IncludeIsPending = true,
                            IncludeIsEnabled = true,
                            IncludeCreatedAt = true
                        }
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