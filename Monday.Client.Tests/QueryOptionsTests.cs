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
            _mondayClient = A.Fake<MondayClient>(_ => _.WithArgumentsForConstructor(new object[] { _graphQlClient }));

            // setup fake graphql client responses:
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

            A.CallTo(() => _graphQlClient.SendQueryAsync<GetUsersResponse>(A<GraphQLRequest>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(async (_) =>
                {
                    _latestGraphQlRequest = _.Arguments[0] as GraphQLRequest;
                    return await Task.FromResult(new GraphQLResponse<GetUsersResponse>()
                    {
                        Data = new GetUsersResponse
                        {
                            Users = new List<User> {
                              new User()
                            }
                        }
                    });
                });

            A.CallTo(() => _graphQlClient.SendQueryAsync<GetBoardsResponse>(A<GraphQLRequest>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(async (_) =>
                {
                    _latestGraphQlRequest = _.Arguments[0] as GraphQLRequest;
                    return await Task.FromResult(new GraphQLResponse<GetBoardsResponse>()
                    {
                        Data = new GetBoardsResponse
                        {
                            Boards = new List<Board> {
                                new Board()
                            }
                        }
                    });
                });

            A.CallTo(() => _graphQlClient.SendMutationAsync<GetGroupsResponse>(A<GraphQLRequest>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(async (_) =>
                {
                    _latestGraphQlRequest = _.Arguments[0] as GraphQLRequest;
                    return await Task.FromResult(new GraphQLResponse<GetGroupsResponse>()
                    {
                        Data = new GetGroupsResponse
                        {
                            Boards = new List<GetGroupsResponse.Board> {
                                new GetGroupsResponse.Board()
                            }
                        }
                    });
                });

            A.CallTo(() => _graphQlClient.SendMutationAsync<GetBoardTagsResponse>(A<GraphQLRequest>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(async (_) =>
                {
                    _latestGraphQlRequest = _.Arguments[0] as GraphQLRequest;
                    return await Task.FromResult(new GraphQLResponse<GetBoardTagsResponse>()
                    {
                        Data = new GetBoardTagsResponse
                        {
                            Boards = new List<GetBoardTagsResponse.Board> {
                                new GetBoardTagsResponse.Board()
                            }
                        }
                    });
                });

            A.CallTo(() => _graphQlClient.SendMutationAsync<GetTagsResponse>(A<GraphQLRequest>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(async (_) =>
                {
                    _latestGraphQlRequest = _.Arguments[0] as GraphQLRequest;
                    return await Task.FromResult(new GraphQLResponse<GetTagsResponse>()
                    {
                        Data = new GetTagsResponse
                        {
                            Tags = new List<Tag> {
                                new Tag()
                            }
                        }
                    });
                });

            A.CallTo(() => _graphQlClient.SendMutationAsync<GetTeamsResponse>(A<GraphQLRequest>.Ignored, A<CancellationToken>.Ignored))
                .ReturnsLazily(async (_) =>
                {
                    _latestGraphQlRequest = _.Arguments[0] as GraphQLRequest;
                    return await Task.FromResult(new GraphQLResponse<GetTeamsResponse>()
                    {
                        Data = new GetTeamsResponse
                        {
                            Teams = new List<Team> {
                                new Team()
                            }
                        }
                    });
                });
        }

        private void DumbCheckQueryEquivalence(string query1, string query2)
        {
            // I need to find a graphql query parser or comparitor.  until then,
            // this is a fair approximately-equal check, but does nothing to
            // check for validity of the generated graphql query.  (spaces could
            // be missing between field names, etc.)
            var q1 = Regex.Replace(query1, @"\s+", String.Empty).ToCharArray().ToList();
            q1.Sort();
            var q2 = Regex.Replace(query2, @"\s+", String.Empty).ToCharArray().ToList();
            q2.Sort();

            q1.ShouldBeEquivalentTo(q2, $@">>> GraphQl querys do not match:
    * Expected: {Regex.Replace(query2, @"\s+", " ").Trim()}
    * Received: {Regex.Replace(query1, @"\s+", " ").Trim()}
");
        }

        [TestMethod]
        public async Task EnsureGetItemWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetItem(1234);

            // Original query included updates information, but the resulting model does not represent that
            // data.  Therefore, I am removing it from the query...
            // The query was: "query request($id:Int) { items(ids: [$id]) { id name board { id name description board_kind state board_folder_id } group { id title color archived deleted } column_values { id text title type value additional_info } subscribers { id name email } updates(limit: 100000) { id body text_body replies { id body text_body creator_id creator { id name email } created_at updated_at } creator_id creator { id name email } created_at updated_at } creator_id created_at updated_at creator { id name email } } }"
            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int) { items(ids: [$id]) { id name board { id name description board_kind state board_folder_id } group { id title color archived deleted } column_values { id text title type value additional_info } subscribers { id name email } creator_id created_at updated_at creator { id name email } } }");
        }

        [TestMethod]
        public async Task EnsureGetItemsWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetItems(1234);

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int) { boards(ids:[$id]) { items(limit: 100000) { id name board { id name description board_kind } group { id title archived deleted } creator_id created_at updated_at creator { id name email } } } } ");
        }

        [TestMethod]
        public async Task EnsureGetUsersWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetUsers();

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query { users { id name email url photo_original title birthday country_code location time_zone_identifier phone mobile_phone is_guest is_pending enabled created_at }}");
        }

        [TestMethod]
        public async Task EnsureGetUsersByAccessTypeWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetUsers(UserAccessTypes.All);

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($userKind:UserKind) { users(kind:$userKind) { id name email url photo_original title birthday country_code location time_zone_identifier phone mobile_phone is_guest is_pending enabled created_at }}");
        }

        [TestMethod]
        public async Task EnsureGetUserWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetUser(1234);

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int) { users(ids:[$id]) { id name email url photo_original title birthday country_code location time_zone_identifier phone mobile_phone is_guest is_pending enabled created_at }}");
        }

        [TestMethod]
        public async Task EnsureGetBoardsWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetBoards();

            // Original query included user and owner information, but the resulting model does not represent that
            // data.  Therefore, I am removing it from the query...
            // The query was: "query { boards(limit: 100000) { id name description board_kind state board_folder_id permissions owner { id name email }}}"
            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query { boards(limit: 100000) { id name description board_kind state board_folder_id permissions }}");
        }

        [TestMethod]
        public async Task EnsureGetBoardWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetBoard(1234);

            // Original query included user and owner information, but the resulting model does not represent that
            // data.  Therefore, I am removing it from the query...
            // The query was: "query request($id:Int) { boards(ids:[$id]) { id name description board_kind state board_folder_id permissions owner { id name email url photo_original title birthday country_code location time_zone_identifier phone mobile_phone is_guest is_pending enabled created_at } columns { id, title, type, archived settings_str } } }"
            // I also removed the unnecessary commas in the columns list.
            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int) { boards(ids:[$id]) { id name description board_kind state board_folder_id permissions columns { id title type archived settings_str } } }");
        }

        [TestMethod]
        public async Task EnsureGetGroupsWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetGroups(1234);

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int!) { boards(ids: [$id]) { groups { id title color archived deleted }}}");
        }

        [TestMethod]
        public async Task EnsureGetTagsWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetTags(1234);

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int!) { boards(ids: [$id]) { tags { id name color } } } ");
        }

        [TestMethod]
        public async Task EnsureGetTagWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetTag(1234);

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int!) { tags(ids: [$id]) { id name color } }");
        }

        [TestMethod]
        public async Task EnsureGetTeamsWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetTeams();

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request { teams { id name picture_url users { id name email } } }");
        }

        [TestMethod]
        public async Task EnsureGetTeamWithNewQueryOptionsDefaultsToSameAsOriginalQuery()
        {
            await _mondayClient.GetTeam(1234);

            DumbCheckQueryEquivalence(_latestGraphQlRequest.Query,
                "query request($id:Int!) { teams(ids: [$id]) { id name picture_url users { id name email } } }");
        }
    }
}
