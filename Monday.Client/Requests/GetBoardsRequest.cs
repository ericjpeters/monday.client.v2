using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetBoardsRequest
    {
        int Limit { get; set; }

        IBoardOptions BoardOptions { get; set; }
        IUserOptions OwnerOptions { get; set; }
    }

    public class GetBoardsRequest : IGetBoardsRequest
    {
        public int Limit { get; set; } = 100000;

        public IBoardOptions BoardOptions { get; set; } = new BoardOptions { 
            IncludeBoardStateType = true,
            IncludeBoardFolderId = true,
            IncludePermissions = true
        };
        public IUserOptions OwnerOptions { get; set; } = new UserOptions {
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
    }
}
