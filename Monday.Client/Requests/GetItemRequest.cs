using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetItemRequest
    {
        int ItemId { get; set; }

        IItemOptions ItemOptions { get; set; }
        IBoardOptions BoardOptions { get; set; }
        IGroupOptions GroupOptions { get; set; }
        IColumnValuesOptions ColumnValuesOptions { get; set; }
        ISubscribersOptions SubscribersOptions { get; set; }
        IUpdatesOptions UpdatesOptions { get; set; }
    }

    public class GetItemRequest : IGetItemRequest
    {
        public int ItemId { get; set; }
        public IItemOptions ItemOptions { get; set; } = new ItemOptions();
        public IBoardOptions BoardOptions { get; set; } = new BoardOptions
        {
            IncludeBoardStateType = true,
            IncludeBoardFolderId = true
        };
        public IGroupOptions GroupOptions { get; set; } = new GroupOptions
        {
            IncludeColor = true
        };
        public IColumnValuesOptions ColumnValuesOptions { get; set; } = new ColumnValuesOptions();
        public ISubscribersOptions SubscribersOptions { get; set; } = new SubscribersOptions();
        public IUpdatesOptions UpdatesOptions { get; set; } = new UpdatesOptions();

        public GetItemRequest(int itemId)
        {
            ItemId = itemId;
        }
    }
}
