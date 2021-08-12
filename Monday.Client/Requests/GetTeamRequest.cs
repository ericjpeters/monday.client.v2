using Monday.Client.Models;
using Monday.Client.Options;

namespace Monday.Client.Requests
{
    public interface IGetTeamRequest : IMondayRequest
    {
        int TeamId { get; set; }

        ITeamOptions TeamOptions { get; set; } 
    }

    public interface IGetTeamResult : IMondayResult
    {
        Team Data { get; }
    }
    internal class GetTeamResult : MondayResult, IGetTeamResult
    {
        public Team Data { get; set; }
    }

    public class GetTeamRequest : MondayRequest, IGetTeamRequest
    {
        public int TeamId { get; set; }

        public ITeamOptions TeamOptions { get; set; } 

        public GetTeamRequest(int teamId)
        {
            TeamId = teamId;

            TeamOptions = new TeamOptions(RequestMode.Default);
        }

        public GetTeamRequest(int teamId, RequestMode mode)
            : this(teamId)
        {
            TeamOptions = new TeamOptions(mode);
        }
    }
}
