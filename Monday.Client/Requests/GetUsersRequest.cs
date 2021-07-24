﻿using Monday.Client.Models;
using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetUsersRequest
    {
        UserAccessTypes? UserAccessType { get; set; }

        IUserOptions UserOptions { get; set; }
    }

    public class GetUsersRequest : IGetUsersRequest
    {
        public UserAccessTypes? UserAccessType { get; set; }

        public IUserOptions UserOptions { get; set; }

        public GetUsersRequest()
            : this(RequestMode.Default)
        { 
        }

        public GetUsersRequest(RequestMode mode)
        {
            switch (mode)
            {
                case RequestMode.Minimum:
                    UserOptions = new UserOptions { 
                        IncludeName = false,
                        IncludeEmail = false,
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
                    break;

                case RequestMode.Maximum:
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
                    };
                    break;

                default:
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
                    };
                    break;
            }
        }
    }
}
