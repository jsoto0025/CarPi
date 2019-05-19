using System;
using System.Collections.Generic;

namespace DataAccess.Database
{
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public int RouteId { get; set; }
    }
}
