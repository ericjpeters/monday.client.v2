using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monday.Client.Models;
using Monday.Client.Responses;
using Shouldly;

namespace Monday.Client.Tests
{
    [TestClass]
    public class QueryOptionsTests
    {
        private string _fakeKey = Guid.NewGuid().ToString();
        private MondayClient _mondayClient;
        private IGraphQLClient _graphQlClient;
        private GraphQLRequest _latestGraphQlRequest;

        [TestInitialize]
        public void SetupClient()
        {
            _graphQlClient = A.Fake<IGraphQLClient>();
            A.CallTo(() => _graphQlClient.SendQueryAsync<GetBoardItemsResponse>(A<GraphQLRequest>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(async (_) =>
                {
                    _latestGraphQlRequest = _.Arguments[0] as GraphQLRequest;
                    return await Task.FromResult(new GraphQLResponse<GetBoardItemsResponse>()
                    {
                        Data = new GetBoardItemsResponse
                        { 
                            Boards = new List<GetBoardItemsResponse.Board> {
                                new GetBoardItemsResponse.Board()
                            }
                        }
                    });
                });
            A.CallTo(() => _graphQlClient.SendQueryAsync<GetItemsResponse>(A<GraphQLRequest>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(async (_) =>
                {
                    _latestGraphQlRequest = _.Arguments[0] as GraphQLRequest;
                    return await Task.FromResult(new GraphQLResponse<GetItemsResponse>()
                    {
                        Data = new GetItemsResponse
                        {
                            Items = new List<Item> { 
                                new Item()
                            }
                        }
                    });
                });

            _mondayClient = A.Fake<MondayClient>(_ => _.WithArgumentsForConstructor(new object[] { _fakeKey, _graphQlClient }));
        }

        private void DumbCheckQueryEquivalence(string query1, string query2)
        {
            var q1 = Regex.Replace(query1, @"\s+", String.Empty).ToCharArray().ToList();
            q1.Sort();
            var q2 = Regex.Replace(query2, @"\s+", String.Empty).ToCharArray().ToList();
            q2.Sort();

            q1.ShouldBeEquivalentTo(q2, "query's do not match");
        }

        [TestMethod]
        public async Task EnsureGetItemWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetItem(1234);

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int) { items(ids: [$id]) { id name board { id name description board_kind state board_folder_id } group { id title color archived deleted } column_values { id text title type value additional_info } subscribers { id name email } updates(limit: 100000) { id body text_body replies { id body text_body creator_id creator { id name email } created_at updated_at } creator_id creator { id name email } created_at updated_at } creator_id created_at updated_at creator { id name email } } }");
        }

        [TestMethod]
        public async Task EnsureGetItemsWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetItems(1234);

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int) { boards(ids:[$id]) { items(limit: 100000) { id name board { id name description board_kind } group { id title archived deleted } creator_id created_at updated_at creator { id name email } } } } ");
        }
    }
}