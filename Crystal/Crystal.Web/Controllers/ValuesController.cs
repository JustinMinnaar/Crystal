using System;
using System.Collections.Generic;
using System.Web.Http;
using Crystal.Profiler.Provider;
using Crystal.Profiler.Adapter;
using Crystal.Profiler.Data;
using Newtonsoft.Json;

namespace Crystal.Web.Controllers {
  [Authorize]
  public class ValuesController : ApiController {
    private static ICyProfileAdapter adapter;
    CProfileProvider CProfileProviderInstance = new CProfileProvider(adapter);

    // GET api/values
    public IList<CyProfileHeader> Get(string authToken) {
      return CProfileProviderInstance.ListProfiles(new Guid(authToken));
    }

    // GET api/values/5
    public CyProfile Get(string authToken, string profileName) {
      return CProfileProviderInstance.LoadProfiles(new Guid(authToken), profileName);
    }

    // POST api/values
    public void Post(string authToken, [FromBody]string jsonProfile) {
      CProfileProviderInstance.SaveProfiles(new Guid(authToken), JsonConvert.DeserializeObject<CyProfile>(jsonProfile));
    }
  }
}
