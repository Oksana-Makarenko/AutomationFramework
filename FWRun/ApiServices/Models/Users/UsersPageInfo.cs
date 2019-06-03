using System.Collections.Generic;

namespace FWRun.ApiServices.Models.Users
{
    public class UsersPageInfo
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public IList<UsersData> data { get; set; }
    }
}
