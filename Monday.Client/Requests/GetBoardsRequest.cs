using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetBoardsRequest
    {
        int Limit { get; set; }

        IBoardOptions BoardOptions { get; set; }
        IOwnerOptions OwnerOptions { get; set; }
    }

    public class GetBoardsRequest : IGetBoardsRequest
    {
        public int Limit { get; set; } = 100000;

        public IBoardOptions BoardOptions { get; set; } = new BoardOptions { 
            IncludeBoardStateType = true,
            IncludeBoardFolderId = true,
            IncludePermissions = true
        };
        public IOwnerOptions OwnerOptions { get; set; } = new OwnerOptions {
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
