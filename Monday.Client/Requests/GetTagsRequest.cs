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

        public ITagOptions TagOptions { get; set; } 

        public GetTagsRequest(int boardId)
            : this(boardId, RequestMode.Default)
        {
        }

        public GetTagsRequest(int boardId, RequestMode mode)
        {
            BoardId = boardId;

            switch (mode)
            {
                case RequestMode.Minimum:
                    TagOptions = new TagOptions
                    {
                        IncludeName = false,
                        IncludeColor = false
                    };
                    break;

                case RequestMode.Maximum:
                    TagOptions = new TagOptions
                    {
                        IncludeName = true,
                        IncludeColor = true
                    };
                    break;

                default:
                    TagOptions = new TagOptions
                    {
                        IncludeName = true,
                        IncludeColor = true
                    };
                    break;
            }
        }
    }
}
