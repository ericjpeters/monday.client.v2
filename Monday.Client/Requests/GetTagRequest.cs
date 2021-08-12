using Monday.Client.Models;
using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTagRequest : IMondayRequest
    {
        int TagId { get; set; }

        ITagOptions TagOptions { get; set; }
    }

    public interface IGetTagResult : IMondayResult
    {
        Tag Data { get; }
    }
    internal class GetTagResult : MondayResult, IGetTagResult
    {
        public Tag Data { get; set; }
    }

    public class GetTagRequest : MondayRequest, IGetTagRequest
    {
        public int TagId { get; set; }

        public ITagOptions TagOptions { get; set; } 

        public GetTagRequest(int tagId)
        {
            TagId = tagId;

            TagOptions = new TagOptions(RequestMode.Default);
        }

        public GetTagRequest(int tagId, RequestMode mode)
            : this(tagId)
        {
            TagOptions = new TagOptions(mode);
        }
    }
}
