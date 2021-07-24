using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTagRequest
    {
        int TagId { get; set; }

        ITagOptions TagOptions { get; set; }
    }

    public class GetTagRequest : IGetTagRequest
    {
        public int TagId { get; set; }

        public ITagOptions TagOptions { get; set; } 

        public GetTagRequest(int tagId)
            : this(tagId, RequestMode.Default)
        {
        }

        public GetTagRequest(int tagId, RequestMode mode)
        {
            TagId = tagId;

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
