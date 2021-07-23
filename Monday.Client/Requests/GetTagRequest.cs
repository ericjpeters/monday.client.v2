using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTagRequest
    {
        int TagId { get; set; }

        TagOptions TagOptions { get; set; }
    }

    public class GetTagRequest : IGetTagRequest
    {
        public int TagId { get; set; }

        public TagOptions TagOptions { get; set; } = new TagOptions();

        public GetTagRequest (int tagId)
        {
            TagId = tagId;
        }
    }
}
