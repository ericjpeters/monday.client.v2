using Monday.Client.Models;
using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetUsersRequest
    {
        UserAccessTypes? UserAccessType { get; set; }

        UserOptions UserOptions { get; set; }
    }

    public class GetUsersRequest : IGetUsersRequest
    {
        public UserAccessTypes? UserAccessType { get; set; }

        public UserOptions UserOptions { get; set; } = new UserOptions();
    }
}
