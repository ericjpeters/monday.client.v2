using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetUserRequest
    {
        int UserId { get; set; }

        IUserOptions UserOptions { get; set; }
    }

    public class GetUserRequest : IGetUserRequest
    {
        public int UserId { get; set; }

        public IUserOptions UserOptions { get; set; }

        public GetUserRequest(int userId)
            : this(userId, RequestMode.Default)
        { }

        public GetUserRequest(int userId, RequestMode mode)
        {
            UserId = userId;

            switch (mode)
            {
                case RequestMode.Minimum:
                    UserOptions = new UserOptions
                    {
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
