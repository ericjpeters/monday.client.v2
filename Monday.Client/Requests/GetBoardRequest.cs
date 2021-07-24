using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetBoardRequest
    {
        int BoardId { get; set; }

        IBoardOptions BoardOptions { get; set; }
    }

    public class GetBoardRequest  : IGetBoardRequest
    {
        public int BoardId { get; set; }

        public IBoardOptions BoardOptions { get; set; } = new BoardOptions { 
            IncludeBoardStateType = true,
            IncludeBoardFolderId = true,
            IncludePermissions = true,
            IncludeColumns = true
        };

        public GetBoardRequest(int boardId)
        {
            BoardId = boardId;
        }
    }
}
