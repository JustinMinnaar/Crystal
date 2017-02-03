using System;
using System.Collections.Generic;
using System.Web.Http;
using Crystal.Profiler.Provider;
using Crystal.Profiler.Adapter;
using Crystal.Profiler.Data;
using Crystal.Web.Models;
using Crystal.Provider.Adapter.FileSystem;

namespace Crystal.Web.Controllers {
  public class ValuesController : ApiController {
    private static ICyProfileAdapter adapter = new CyProfileAdapterFileSystem("C:/storage/", FileFormat.Xml);
    static CProfileProvider CProfileProviderInstance = new CProfileProvider(adapter);

    // GET api/values
    public IList<CyProfileHeader> Get(string authToken) {
      return CProfileProviderInstance.ListProfiles(new Guid(authToken));
    }

    // GET api/values/5
    public CyProfile Get(string authToken, string profileName) {
      return CProfileProviderInstance.LoadProfiles(new Guid(authToken), profileName);
    }

    // POST api/values
    public void Post([FromBody] PostProfile profile) {
      CProfileProviderInstance.SaveProfiles(new Guid(profile.authToken), profile.Profile);
    }

  }
}
