using Monday.Client.Models;
using Monday.Client.Options;
using System.Collections.Generic;

namespace Monday.Client.Requests
{
    public interface IGetGroupsRequest : IMondayRequest
    {
        int BoardId { get; set; }

        IGroupOptions GroupOptions { get; set; }
    }

    public interface IGetGroupsResult : IMondayResult
    {
        List<Group> Data { get; }
    }

    internal class GetGroupsResult : MondayResult, IGetGroupsResult
    {
        public List<Group> Data { get; set; }
    }

    public class GetGroupsRequest : MondayRequest, IGetGroupsRequest
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
