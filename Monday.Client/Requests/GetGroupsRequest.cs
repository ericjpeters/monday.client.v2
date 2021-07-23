using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetGroupsRequest
    {
        int BoardId { get; set; }

        IGroupOptions GroupOptions { get; set; }
    }

    public class GetGroupsRequest : IGetGroupsRequest
    {
        public int BoardId { get; set; }

        public IGroupOptions GroupOptions { get; set; } = new GroupOptions
        {
            IncludeColor = true
        };

        public GetGroupsRequest(int boardId)
        {
            BoardId = boardId;
        }
    }
}
