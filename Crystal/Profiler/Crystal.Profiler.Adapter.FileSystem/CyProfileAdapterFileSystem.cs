using Crystal.Profiler.Adapter;
using Crystal.Profiler.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crystal.Provider.Adapter.FileSystem
{
    public class CyProfileAdapterFileSystem : ICyProfileAdapter
    {
        protected string folder;
        private string ext = ".crystalprofile";

        /// <summary>Stores the profiles in a specific folder using their names.</summary>
        /// <param name="folder"></param>
        public CyProfileAdapterFileSystem(string folder)
        {
            this.folder = folder;
        }

        public IList<CyProfileHeader> ListProfiles()
        {
            var profiles = new List<CyProfileHeader>();
            var filePaths = Directory.GetFiles(folder, "*." + ext, SearchOption.TopDirectoryOnly);
            foreach (var filePath in filePaths)
            {
                var profile = LoadProfile(filePath);
                profiles.Add(profile.Header);
            }
            return profiles;
        }

        public CyProfile LoadProfile(string name)
        {
            var fileNameOnly = Path.GetFileNameWithoutExtension(name);
            var filePath = Path.Combine(folder, fileNameOnly + ext);
            if (!File.Exists(filePath))
                throw new FileNotFoundException(fileNameOnly);

            var xmlSerializer = new XmlSerializer(typeof(CyProfile));
            using (var stream = File.OpenRead(filePath))
                return (CyProfile)xmlSerializer.Deserialize(stream);
        }

        public void SaveProfile(CyProfile profile)
        {
            var fileNameOnly = Path.GetFileNameWithoutExtension(profile.Header.Name);
            var filePath = Path.Combine(folder, fileNameOnly + ext);

            if (!File.Exists(filePath))
                File.Delete(filePath);

            var xmlSerializer = new XmlSerializer(typeof(CyProfile));
            using (var stream = File.OpenWrite(filePath))
                xmlSerializer.Serialize(stream, profile);
        }
    }
}
