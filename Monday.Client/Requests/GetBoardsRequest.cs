using Monday.Client.Models;
using Monday.Client.Options;
using System.Collections.Generic;

namespace Monday.Client.Requests
{
    public interface IGetBoardsRequest : IMondayRequest
    {
        int Limit { get; set; }

        IBoardOptions BoardOptions { get; set; }
    }

    public interface IGetBoardsResult : IMondayResult
    {
        List<Board> Data { get; }
    }

    internal class GetBoardsResult : MondayResult, IGetBoardsResult
    {
        public List<Board> Data { get; set; }
    }

    public class GetBoardsRequest : MondayRequest, IGetBoardsRequest
    {
        public int Limit { get; set; } = 100000;

        public IBoardOptions BoardOptions { get; set; }

        public GetBoardsRequest()
            : this(RequestMode.Default)
        { 
        }

        public GetBoardsRequest(RequestMode mode)
        {
            switch (mode)
            {
                case RequestMode.Minimum:
                    BoardOptions = new BoardOptions
                    {
                        IncludeName = false,
                        IncludeDescription = false,
                        IncludeBoardAccessType = false,
                        IncludeBoardStateType = false,
                        IncludeBoardFolderId = false,
                        IncludeColumns = false,
                        IncludePermissions = false,
                        IncludeActivityLogs = false,
                        IncludeCommunication = false,
                        IncludeGroups = false,
                        IncludeItems  = false,
                        IncludeOwner = false,
                        IncludePosition = false,
                        IncludeSubscribers = false,
                        IncludeTags = false,
                        IncludeTopGroup  = false,
                        IncludeUpdatedAt = false,
                        IncludeUpdates = false,
                        IncludeViews = false,
                        IncludeWorkspace = false,
                        IncludeWorkspaceId = false
                    };
                    break;

                case RequestMode.Maximum:
                    BoardOptions = new BoardOptions
                    {
                        IncludeName = true,
                        IncludeDescription = true,
                        IncludeBoardAccessType = true,
                        IncludeBoardStateType = true,
                        IncludeBoardFolderId = true,
                        IncludeColumns = true,
                        IncludePermissions = true,
                        IncludeActivityLogs = true,
                        IncludeCommunication = true,
                        IncludeGroups = true,
                        IncludeItems = true,
                        IncludeOwner = true,
                        IncludePosition = true,
                        IncludeSubscribers = true,
                        IncludeTags = true,
                        IncludeTopGroup = true,
                        IncludeUpdatedAt = true,
                        IncludeUpdates = true,
                        IncludeViews = true,
                        IncludeWorkspace = true,
                        IncludeWorkspaceId = true,

                        ColumnOptions = new ColumnOptions
                        { 
                            IncludeTitle = true,
                            IncludeType = true,
                            IncludeIsArchived = true,
                            IncludeSettings = true
                        },
                        ActivityLogOptions=new ActivityLogOptions
                        {
                            IncludeAccountId = true,
                            IncludeCreatedAt = true,
                            IncludeData = true,
                            IncludeEntity = true,
                            IncludeEvent = true,
                            IncludeUserId = true
                        },
                        GroupOptions = new GroupOptions
                        {
                            IncludeTitle = true,
                            IncludeColor = true,
                            IncludeIsArchived = true,
                            IncludeIsDeleted = true
                        },
                        ItemOptions =new ItemOptions
                        {
                            IncludeBoard = false,
                            IncludeGroup = false,
                            IncludeColumnValues = false,
                            IncludeName = true,
                            IncludeCreatorId = true,
                            IncludeCreatedAt = true,
                            IncludeUpdatedAt = true,
                            IncludeCreator = false,
                            IncludeSubscribers = false
                        },
                        OwnerOptions =new OwnerOptions
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
                        },
                        TagOptions = new TagOptions
                        {
                            IncludeName = true,
                            IncludeColor = true
                        },
                        TopGroupOptions = new TopGroupOptions
                        {
                            IncludeTitle = true,
                            IncludeColor = true,
                            IncludeIsArchived = true,
                            IncludeIsDeleted = true
                        },
                        UpdateOptions = new UpdateOptions
                        {
                            IncludeItemId = true,
                            IncludeCreatorId = true,
                            IncludeCreator = false,
                            IncludeBody = true,
                            IncludeBodyText = true,
                            IncludeReplies = false,
                            IncludeCreatedAt = true,
                            IncludeUpdatedAt = true
                        },
                        BoardViewOptions = new BoardViewOptions
                        {
                            IncludeName = true,
                            IncludeSettings = true,
                            IncludeType = true
                        },
                        WorkspaceOptions = new WorkspaceOptions
                        {
                        }
                    };
                    break;

                default:
                    BoardOptions = new BoardOptions
                    {
                        IncludeBoardStateType = true,
                        IncludeBoardFolderId = true,
                        IncludePermissions = true
                    };
                    break;
            }
        }
    }
}
