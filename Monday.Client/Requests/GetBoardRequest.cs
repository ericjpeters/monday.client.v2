using Monday.Client.Models;
using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetBoardRequest : IMondayRequest
    {
        int BoardId { get; set; }

        IBoardOptions BoardOptions { get; set; }
    }

    public interface IGetBoardResult : IMondayResult
    {
        Board Data { get; }
    }

    internal class GetBoardResult : MondayResult, IGetBoardResult
    {
        public Board Data { get; set; }
    }

    public class GetBoardRequest  : MondayRequest, IGetBoardRequest
    {
        public int BoardId { get; set; }

        public IBoardOptions BoardOptions { get; set; } 

        public GetBoardRequest(int boardId)
        {
            BoardId = boardId;

            BoardOptions = new BoardOptions(RequestMode.Default);
        }

        public GetBoardRequest(int boardId, RequestMode mode)
            : this(boardId)
        {
            BoardOptions = new BoardOptions(mode);
        }
    }
}
