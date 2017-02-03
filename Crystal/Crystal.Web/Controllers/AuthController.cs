using System;
using System.Web.Http;
using Crystal.Profiler.Provider;
using Crystal.Profiler.Adapter;
using Crystal.Web.Models;
using Crystal.Provider.Adapter.FileSystem;

namespace Crystal.Web.Controllers {

  public class AuthController : ApiController {
    private static ICyProfileAdapter adapter = new CyProfileAdapterFileSystem("C:/storage/", FileFormat.Xml);
    static CProfileProvider CProfileProviderInstance = new CProfileProvider(adapter);

    // POST api/auth
    public Guid Post([FromBody] AuthApiModel Auth) {
      return CProfileProviderInstance.LogIn(Auth.applicationName, Auth.applicationKey);
    }

  }
}
