using Monday.Client.Models;
using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetUserRequest : IMondayRequest
    {
        int UserId { get; set; }

        IUserOptions UserOptions { get; set; }
    }

    public interface IGetUserResult : IMondayResult
    {
        User Data { get; }
    }
    internal class GetUserResult : MondayResult, IGetUserResult
    {
        public User Data { get; set; }
    }

    public class GetUserRequest : MondayRequest, IGetUserRequest
    {
        public int UserId { get; set; }

        public IUserOptions UserOptions { get; set; }

        public GetUserRequest(int userId)
        {
            UserId = userId;

            UserOptions = new UserOptions(RequestMode.Default);
        }

        public GetUserRequest(int userId, RequestMode mode)
            : this(userId)
        {
            UserOptions = new UserOptions(mode);
        }
    }
}
