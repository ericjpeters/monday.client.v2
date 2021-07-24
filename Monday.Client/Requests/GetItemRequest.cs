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

        public IItemOptions ItemOptions { get; set; }

        public GetItemRequest(int itemId)
            : this(itemId, RequestMode.Default)
        {
        }

        public GetItemRequest(int itemId, RequestMode mode)
        {
            ItemId = itemId;

            switch (mode)
            {
                case RequestMode.Minimum:
                    ItemOptions = new ItemOptions { 
                        IncludeBoard = false,
                        IncludeGroup = false,
                        IncludeColumnValues = false,
                        IncludeName = false,
                        IncludeCreatorId = false,
                        IncludeCreatedAt = false,
                        IncludeUpdatedAt = false,
                        IncludeCreator = false,
                        IncludeSubscribers = false
                    };
                    break;

                default:
                    ItemOptions = new ItemOptions
                    {
                        IncludeColumnValues = true,
                        CreatorOptions = new UserOptions
                        {
                            NameSingular = "creator",
                            NamePlural = "creators",
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
                            NamePlural = "subscribers",
                            NameSingular = "subscriber",
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
