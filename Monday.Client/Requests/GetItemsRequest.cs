using Monday.Client.Models;
using Monday.Client.Options;
using System.Collections.Generic;

namespace Monday.Client.Requests
{
    public interface IGetItemsRequest : IMondayRequest
    {
        int BoardId { get; set; }
        int Limit { get; set; }

        IItemOptions ItemOptions { get; set; }
    }

    public interface IGetItemsResult : IMondayResult
    {
        List<Item> Data { get; }
    }
    internal class GetItemsResult : MondayResult, IGetItemsResult
    {
        public List<Item> Data { get; set; }
    }

    public class GetItemsRequest : MondayRequest, IGetItemsRequest
    {
        public int BoardId { get; set; }

        public int Limit { get; set; } = 100000;

        public IItemOptions ItemOptions { get; set; }

        public GetItemsRequest(int boardId)
            : this(boardId, RequestMode.Default)
        { 
        }
        
        public GetItemsRequest(int boardId, RequestMode mode)
        {
            BoardId = boardId;

            switch(mode)
            {
                case RequestMode.Minimum:
                    ItemOptions = new ItemOptions
                    {
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
                        IncludeColumnValues = false,
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
                        BoardOptions = new BoardOptions(),
                        IncludeGroup = true,
                        GroupOptions = new GroupOptions()
                    };
                    break;
            }
        }
    }
}
