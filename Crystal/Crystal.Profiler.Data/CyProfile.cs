using Crystal.Core;
using Crystal.Ocr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crystal.Profiler.Data
{
    [Serializable]
    public class CyProfile
    {
        public CyProfileHeader Header { get; set; }
        public ListCyProfileImage Images { get; set; }
        public ListCyProfileTemplate Templates { get; set; }

        public CyProfile()
        {
            Images = new ListCyProfileImage();
            Templates = new ListCyProfileTemplate();
        }

        public bool Matches(CyProfile loadedProfile)
        {
            if (!this.Header.Matches(loadedProfile.Header)) return false;
            if (!this.Images.Matches(loadedProfile.Images)) return false;
            if (!this.Templates.Matches(loadedProfile.Templates)) return false;

            return true;
        }
    }

    public enum CyProfileStatus : byte { Design = (byte)'D', Active = (byte)'P' }

    [Serializable]
    public class CyProfileHeader
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool Deleted { get; set; }

        [XmlAttribute]
        public int Version { get; set; }

        [XmlAttribute]
        public string Group { get; set; }

        [XmlAttribute]
        public CyProfileStatus Status { get; set; }

        [XmlAttribute]
        public string DestinationModule { get; set; }

        [XmlAttribute]
        public string DestinationEntity { get; set; }

        public bool Matches(CyProfileHeader header)
        {
            if (this.Deleted != header.Deleted) return false;
            if (this.DestinationEntity != header.DestinationEntity) return false;
            if (this.DestinationModule != header.DestinationModule) return false;
            if (this.Group != header.Group) return false;
            if (this.Name != header.Name) return false;
            if (this.Status != header.Status) return false;
            if (this.Version != header.Version) return false;

            return true;
        }
    }

    [Serializable]
    public class CyProfileImage : IMatches<CyProfileImage>
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public CySize SizePixels { get; set; }

        public CyOcrResult OcrResult { get; set; }

        public bool Matches(CyProfileImage other)
        {
            if (Name != other.Name) return false;
            if (SizePixels.Width != other.SizePixels.Width) return false;
            if (SizePixels.Height != other.SizePixels.Height) return false;
            return true;
        }
    }

    public enum CyProfileTemplateType { PageHeader, PageFooter, TableHeader, TableLine, TableFooter }

    [Serializable]
    public class CyProfileTemplate : IMatches<CyProfileTemplate>
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public CyProfileTemplateType Type { get; set; }

        [XmlAttribute]
        public string DestinationTable { get; set; }

        /// <summary>
        /// This is the area that the template covers. 
        /// Additional templates may follow under this template.
        /// </summary>
        public CyRect RectanglePixels { get; set; }

        public ListCyProfileExtractor Extractors { get; set; }

        public bool Matches(CyProfileTemplate other)
        {
            if (DestinationTable != other.DestinationTable) return false;
            if (Name != other.Name) return false;
            return true;
        }
    }
}
