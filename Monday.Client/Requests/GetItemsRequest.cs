using Monday.Client.Models;
using Monday.Client.Options;
using System.Collections.Generic;

namespace Monday.Client.Requests
{
    public interface IGetItemsRequest : IMondayRequest
    {
        int BoardId { get; set; }
        int Limit { get; set; }

        string FilterColumnName { get; set; }
        string FilterColumnValue { get; set; }
        StateFilter? FilterState { get; set; }

        IItemOptions ItemOptions { get; set; }
    }

    public interface IGetItemsResult : IMondayResult
    {
        List<Item> Data { get; }
    }
    internal class GetItemsResult : MondayResult, IGetItemsResult
    {
        public List<Item> Data { get; set; }
    }

    public enum StateFilter
    { 
        None,
        Active
    }

    public class GetItemsRequest : MondayRequest, IGetItemsRequest
    {
        public int BoardId { get; set; }

        public int Limit { get; set; } = 100000;
        public string FilterColumnName { get; set; } = null;
        public string FilterColumnValue { get; set; } = null;
        public StateFilter? FilterState { get; set; } = null;

        public IItemOptions ItemOptions { get; set; }

        public GetItemsRequest(int boardId)
        {
            BoardId = boardId;

            ItemOptions = new ItemOptions(RequestMode.Default);
            ItemOptions.BoardOptions.IncludeBoardStateType = false;
            ItemOptions.BoardOptions.IncludeBoardFolderId = false;
            ItemOptions.GroupOptions.IncludeColor = false;
            ItemOptions.IncludeSubscribers = false;
            ItemOptions.SubscriberOptions = null;
            ItemOptions.IncludeColumnValues = false;
            ItemOptions.ColumnValueOptions = null;
        }

        public GetItemsRequest(int boardId, RequestMode mode)
            : this(boardId)
        {
            ItemOptions = new ItemOptions(mode);
        }
    }
}
