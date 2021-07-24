using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetItemsRequest
    {
        int BoardId { get; set; }
        int Limit { get; set; }

        IItemOptions ItemOptions { get; set; }
    }

    public class GetItemsRequest : IGetItemsRequest
    {
        public int BoardId { get; set; }

        public int Limit { get; set; } = 100000;

        public IItemOptions ItemOptions { get; set; } = new ItemOptions
        {
            IncludeColumnValues = false,
            CreatorOptions = new UserOptions 
            { 
                BaseNameSingular = "creator",
                BaseNamePlural = "creators",
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
            },
            IncludeBoard = true,
            BoardOptions = new BoardOptions(),
            IncludeGroup = true,
            GroupOptions = new GroupOptions()
        };

        public GetItemsRequest(int boardId)
        {
            BoardId = boardId;
        }
    }
}
