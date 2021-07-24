using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetUserRequest
    {
        int UserId { get; set; }

        IUserOptions UserOptions { get; set; }
    }

    public class GetUserRequest : IGetUserRequest
    {
        public int UserId { get; set; }

        public IUserOptions UserOptions { get; set; } = new UserOptions();

        public GetUserRequest(int userId)
        {
            UserId = userId;
        }
    }
}
