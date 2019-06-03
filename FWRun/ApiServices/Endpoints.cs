using RestSharp;

namespace FWRun.ApiEndpoints
{
    public static class Endpoints
    {
        private const string ListUsersEndpoint = "/api/users";

        public static RestRequest GetListUsers(int pageNumber)
            => new RestRequest($"/{ListUsersEndpoint}?page={pageNumber}", Method.GET);

        public static RestRequest GetUser(int userId)
            => new RestRequest($"/{ListUsersEndpoint}/{userId}", Method.GET);
    }
}
