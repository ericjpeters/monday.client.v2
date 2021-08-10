using Monday.Client.Models;
using System.Collections.Generic;

namespace Monday.Client.Requests
{
    public interface ICreateItemRequest: IMondayRequest
    {
        string Name { get; set; }
        int BoardId { get; set; }
        string GroupId { get; set; }
        IMondayColumns ColumnValues { get; set; }
    }

    public class CreateItemRequest : MondayRequest, ICreateItemRequest
    {
        public string Name { get; set; }
        public int BoardId { get; set; }
        public string GroupId { get; set; }
        public IMondayColumns ColumnValues { get; set; }
    }

    public interface ICreateItemResult : IMondayResult
    {
        Item Data { get; }
    }

    public class CreateItemResult : MondayResult, ICreateItemResult
    {
        public Item Data { get; set;  }
    }
}
