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
        {
            BoardId = boardId;

            GroupOptions = new GroupOptions(RequestMode.Default);
        }

        public GetGroupsRequest(int boardId, RequestMode mode)
        {
            GroupOptions = new GroupOptions(mode);
        }
    }
}
