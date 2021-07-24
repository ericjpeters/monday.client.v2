using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetBoardRequest
    {
        int BoardId { get; set; }

        IBoardOptions BoardOptions { get; set; }
        IUserOptions OwnerOptions { get; set; }
        IColumnOptions ColumnOptions { get; set; }
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
        public IUserOptions OwnerOptions { get; set; } = new UserOptions();
        public IColumnOptions ColumnOptions { get; set; } = new ColumnOptions();

        public GetBoardRequest(int boardId)
        {
            BoardId = boardId;
        }
    }
}
