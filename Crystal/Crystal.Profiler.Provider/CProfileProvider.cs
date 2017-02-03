using Crystal.Profiler.Adapter;
using Crystal.Profiler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Profiler.Provider
{
    public class CProfileProvider
    {
        private ICyProfileAdapter adapter;

        public CProfileProvider(ICyProfileAdapter adapter)
        {
            this.adapter = adapter;
        }

        public Guid LogIn(string applicationName, string applicationKey)
        {
            return Guid.NewGuid();
        }

        public IList<CyProfileHeader> ListProfiles(Guid sessionId)
        {
            if (sessionId == Guid.Empty) throw new InvalidSessionException();

            return adapter.ListProfiles();
        }

        public CyProfile LoadProfiles(Guid sessionId, string name)
        {
            if (sessionId == Guid.Empty) throw new InvalidSessionException();

            return adapter.LoadProfile(name);
        }

        public void SaveProfiles(Guid sessionId, CyProfile  profile)
        {
            if (sessionId == Guid.Empty) throw new InvalidSessionException();
            profile.Header.Status = CyProfileStatus.Design;
            adapter.SaveProfile(profile);
        }
    }
}
