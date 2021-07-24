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

                case RequestMode.Maximum:
                    ItemOptions = new ItemOptions
                    {
                        IncludeBoard = true,
                        IncludeGroup = true,
                        IncludeColumnValues = true,
                        IncludeName = true,
                        IncludeCreatorId = true,
                        IncludeCreatedAt = true,
                        IncludeUpdatedAt = true,
                        IncludeCreator = true,
                        IncludeSubscribers = true,
                        BoardOptions = new BoardOptions
                        {
                            IncludeName = true,
                            IncludeDescription = true,
                            IncludeBoardAccessType = true,
                            IncludeBoardStateType = true,
                            IncludeBoardFolderId = true,
                            IncludePermissions = true,
                            IncludeColumns = false
                        },
                        GroupOptions = new GroupOptions
                        {
                            IncludeTitle = true,
                            IncludeColor = true,
                            IncludeIsArchived = true,
                            IncludeIsDeleted = true,
                        },
                        ColumnValueOptions = new ColumnValueOptions
                        {
                            IncludeTitle = true,
                            IncludeValue = true,
                            IncludeType = true,
                            IncludeText = true,
                            IncludeAdditionalInfo = true
                        },
                        CreatorOptions = new CreatorOptions
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
                        },
                        SubscriberOptions = new SubscriberOptions
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
                    ItemOptions = new ItemOptions
                    {
                        IncludeColumnValues = true,
                        CreatorOptions = new CreatorOptions
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
                        SubscriberOptions = new SubscriberOptions
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
