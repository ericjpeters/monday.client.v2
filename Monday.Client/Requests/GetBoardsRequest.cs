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

        public IBoardOptions BoardOptions { get; set; } = new BoardOptions
        {
            IncludeBoardStateType = true,
            IncludeBoardFolderId = true,
            IncludePermissions = true
        };
    }
}
