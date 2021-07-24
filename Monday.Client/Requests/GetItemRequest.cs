using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetItemRequest
    {
        int ItemId { get; set; }

        IItemOptions ItemOptions { get; set; }
    }

    public class GetItemRequest : IGetItemRequest
    {
        public int ItemId { get; set; }

        public IItemOptions ItemOptions { get; set; } = new ItemOptions
        {
            IncludeColumnValues = true,
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
            BoardOptions = new BoardOptions
            { 
                IncludeBoardStateType = true,
                IncludeBoardFolderId = true
            },
            IncludeGroup = true,
            GroupOptions = new GroupOptions
            {
                IncludeColor = true
            },
            IncludeSubscribers = true,
            SubscriberOptions = new UserOptions
            { 
                BaseNamePlural = "subscribers",
                BaseNameSingular = "subscriber",
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

        public GetItemRequest(int itemId)
        {
            ItemId = itemId;
        }
    }
}
