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

        public IBoardOptions BoardOptions { get; set; } 

        public GetBoardRequest(int boardId)
            : this(boardId, RequestMode.Default)
        {
        }

        public GetBoardRequest(int boardId, RequestMode mode)
        {
            BoardId = boardId;

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
                        ColumnOptions = new ColumnOptions
                        {
                            IncludeTitle = true,
                            IncludeType = true,
                            IncludeIsArchived = true,
                            IncludeSettings = true
                        }
                    };
                    break;

                default:
                    BoardOptions = new BoardOptions
                    {
                        IncludeBoardStateType = true,
                        IncludeBoardFolderId = true,
                        IncludePermissions = true,
                        IncludeColumns = true
                    };
                    break;
            }
        }
    }
}
