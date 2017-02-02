using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Crystal.Profiler.Provider;
using Crystal.Profiler.Adapter;

namespace Crystal.Web.Controllers {
  public class AuthController : ApiController {
    private static ICyProfileAdapter adapter;
    private CProfileProvider CProfileProviderInstance = new CProfileProvider(adapter);

    // POST api/auth
    public Guid Post([FromBody]string applicationName, [FromBody]string applicationKey) {
      return CProfileProviderInstance.LogIn(applicationName, applicationKey);
    }

  }
}
