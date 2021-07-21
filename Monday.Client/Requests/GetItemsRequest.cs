using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetItemsRequest
    {
        int BoardId { get; set; }
        int Limit { get; set; }

        IBoardOptions BoardOptions { get; set; }
        IGroupOptions GroupOptions { get; set; }
        IItemOptions ItemOptions { get; set; }
    }

    public class GetItemsRequest : IGetItemsRequest
    {
        public int BoardId { get; set; }

        public int Limit { get; set; } = 100000;
        public IBoardOptions BoardOptions { get; set; } = new BoardOptions();
        public IGroupOptions GroupOptions { get; set; } = new GroupOptions();
        public IItemOptions ItemOptions { get; set; } = new ItemOptions();

        public GetItemsRequest(int boardId)
        {
            BoardId = boardId;
        }
    }
}
