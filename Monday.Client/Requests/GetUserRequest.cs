using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetUserRequest
    {
        int UserId { get; set; }

        UserOptions UserOptions { get; set; }
    }

    public class GetUserRequest : IGetUserRequest
    {
        public int UserId { get; set; }

        public UserOptions UserOptions { get; set; } = new UserOptions();

        public GetUserRequest(int userId)
        {
            UserId = userId;
        }
    }
}
