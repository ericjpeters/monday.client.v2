using Monday.Client.Models;
using Monday.Client.Options;
using System.Collections.Generic;

namespace Monday.Client.Requests
{
    public interface IGetTagsRequest : IMondayRequest
    {
        int BoardId { get; set; }

        ITagOptions TagOptions { get; set; }
    }

    public interface IGetTagsResult : IMondayResult
    {
        List<Tag> Data { get; }
    }
    internal class GetTagsResult : MondayResult, IGetTagsResult
    {
        public List<Tag> Data { get; set; }
    }

    public class GetTagsRequest : MondayRequest, IGetTagsRequest
    {
        public int BoardId { get; set; }

        public ITagOptions TagOptions { get; set; } 

        public GetTagsRequest(int boardId)
        {
            BoardId = boardId;

            TagOptions = new TagOptions(RequestMode.Default);
        }

        public GetTagsRequest(int boardId, RequestMode mode)
            : this(boardId)
        {
            TagOptions = new TagOptions(mode);
        }
    }
}
