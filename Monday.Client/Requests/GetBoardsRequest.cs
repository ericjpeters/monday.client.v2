﻿using Monday.Client.Models;
using Monday.Client.Options;
using System.Collections.Generic;

namespace Monday.Client.Requests
{
    public interface IGetBoardsRequest : IMondayRequest
    {
        int Limit { get; set; }

        IBoardOptions BoardOptions { get; set; }
    }

    public interface IGetBoardsResult : IMondayResult
    {
        List<Board> Data { get; }
    }

    internal class GetBoardsResult : MondayResult, IGetBoardsResult
    {
        public List<Board> Data { get; set; }
    }

    public class GetBoardsRequest : MondayRequest, IGetBoardsRequest
    {
        public int Limit { get; set; } = 100000;

        public IBoardOptions BoardOptions { get; set; }

        public GetBoardsRequest()
        {
            BoardOptions = new BoardOptions(RequestMode.Default);
            BoardOptions.IncludeColumns = false;
            BoardOptions.ColumnOptions = null;
        }

        public GetBoardsRequest(RequestMode mode)
            : this()
        {
            BoardOptions = new BoardOptions(mode);
        }
    }
}
