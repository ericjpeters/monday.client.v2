using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTagsRequest
    {
        int BoardId { get; set; }

        ITagOptions TagOptions { get; set; }
    }

    public class GetTagsRequest : IGetTagsRequest
    {
        public int BoardId { get; set; }

        public ITagOptions TagOptions { get; set; } = new TagOptions();

        public GetTagsRequest(int boardId)
        {
            BoardId = boardId;
        }
    }
}
