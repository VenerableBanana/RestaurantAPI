using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public enum ResourceOpreration
    {
        Create,
        Read,
        Update,
        Delete
    }

    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOpreration ResourceOpreration { get; }

        public ResourceOperationRequirement(ResourceOpreration resourceOpreration)
        {
            ResourceOpreration = resourceOpreration;
        }
    }
}
