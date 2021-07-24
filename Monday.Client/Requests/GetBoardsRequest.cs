using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetBoardsRequest
    {
        int Limit { get; set; }

        IBoardOptions BoardOptions { get; set; }
    }

    public class GetBoardsRequest : IGetBoardsRequest
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
                        IncludePermissions = false
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
