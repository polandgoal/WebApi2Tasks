﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Routing;

namespace WebApi2Book.Web.Common.Routing
{
    public class ApiVersionConstraint : IHttpRouteConstraint
    {
        #region Members
        #endregion

        #region Property
        public string AllowedVersion { get; private set; }
        #endregion

        #region Constructor
        public ApiVersionConstraint(string allowedVersion)
        {
            AllowedVersion = allowedVersion;
        }
        #endregion

        #region Methods
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return AllowedVersion.Equals(value.ToString().ToLowerInvariant());
            }
            return false;
        }
        #endregion
    }
}
