using Monday.Client.Models;
using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetItemRequest : IMondayRequest
    {
        int ItemId { get; set; }

        IItemOptions ItemOptions { get; set; }
    }

    public interface IGetItemResult : IMondayResult
    {
        Item Data { get; }
    }

    internal class GetItemResult : MondayResult, IGetItemResult
    {
        public Item Data { get; set; }
    }

    public class GetItemRequest : MondayRequest, IGetItemRequest
    {
        public int ItemId { get; set; }

        public IItemOptions ItemOptions { get; set; }

        public GetItemRequest(int itemId)
        {
            ItemId = itemId;
        }

        public GetItemRequest(int itemId, RequestMode mode)
            : this(itemId)
        {
            ItemOptions = new ItemOptions(mode);
        }
    }
}
