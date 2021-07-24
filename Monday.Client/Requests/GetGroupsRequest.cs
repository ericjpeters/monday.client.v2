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

        public IGroupOptions GroupOptions { get; set; }

        public GetGroupsRequest(int boardId)
            : this(boardId, RequestMode.Default)
        {
        }

        public GetGroupsRequest(int boardId, RequestMode mode)
        {
            BoardId = boardId;

            switch(mode)
            {
                case RequestMode.Minimum:
                    GroupOptions = new GroupOptions
                    {
                        IncludeTitle = false,
                        IncludeColor = false,
                        IncludeIsArchived = false,
                        IncludeIsDeleted = false
                    };
                    break;

                case RequestMode.Maximum:
                    GroupOptions = new GroupOptions
                    {
                        IncludeTitle = true,
                        IncludeColor = true,
                        IncludeIsArchived = true,
                        IncludeIsDeleted = true
                    };
                    break;

                default:
                    GroupOptions = new GroupOptions
                    {
                        IncludeColor = true
                    };
                    break;
            }
        }
    }
}
