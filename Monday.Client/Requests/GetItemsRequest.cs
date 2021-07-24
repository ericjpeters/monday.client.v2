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
                        IncludeColumnValues = false,
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
                        BoardOptions = new BoardOptions(),
                        IncludeGroup = true,
                        GroupOptions = new GroupOptions()
                    };
                    break;
            }
        }
    }
}
