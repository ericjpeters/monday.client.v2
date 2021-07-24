using Monday.Client.Models;
using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetUsersRequest
    {
        UserAccessTypes? UserAccessType { get; set; }

        IUserOptions UserOptions { get; set; }
    }

    public class GetUsersRequest : IGetUsersRequest
    {
        public UserAccessTypes? UserAccessType { get; set; }

        public IUserOptions UserOptions { get; set; } = new UserOptions();
    }
}
