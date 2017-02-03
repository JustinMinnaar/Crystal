using Crystal.Profiler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crystal.Web.Models {
  public class PostProfile {
    public string authToken { get; set; }
    public string jsonProfile { get; set; }
  }
}