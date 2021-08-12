using Monday.Client.Models;
using Monday.Client.Options;
using System.Collections.Generic;

namespace Monday.Client.Requests
{
    public interface IGetTeamsRequest : IMondayRequest
    {
        ITeamOptions TeamOptions { get; set; }
    }

    public interface IGetTeamsResult : IMondayResult
    {
        List<Team> Data { get; }
    }
    internal class GetTeamsResult : MondayResult, IGetTeamsResult
    {
        public List<Team> Data { get; set; }
    }

    public class GetTeamsRequest : MondayRequest, IGetTeamsRequest
    {
        public ITeamOptions TeamOptions { get; set; }

        public GetTeamsRequest()
        {
            TeamOptions = new TeamOptions(RequestMode.Default);
        }

        public GetTeamsRequest(RequestMode mode)
            : this()
        {
            TeamOptions = new TeamOptions(mode);
        }
    }
}