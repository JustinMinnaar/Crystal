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

        /// <summary>The classification for this profile is used to organise the profiles. 
        /// For example, all profiles relating to 'warehousing' or 'suppliers'.</summary>
        public string Classification { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid CreatedByGuid { get; set; }

        public List<CyProfileExtractor> Extractors { get; set; }

        /// <summary>The image that was used to define this template.</summary>
        public string ImageName { get; set; }

        /// <summary>
        /// This becomes true when the user publishes the profile.
        /// This allows the profiler to use the profile in the system.
        /// It is false while the profile is being developed.
        /// </summary>
        public bool IsActive { get; set; }

        [XmlAttribute]
        public CyProfileTemplateType Type { get; set; }

        [XmlAttribute]
        public string DestinationTable { get; set; }
        
        /// <summary>The characters required to uniquely identify the section, which are usually ignored by the extractors.</summary>
        public List<CyOcrCharacter> IdentifyCharacters { get; set; }

        /// <summary>For optimisation, the identification characters required to uniquely identify that the section is up-side-down.</summary>
        public List<CyOcrCharacter> IdentifyCharactersUpSideDown { get; set; }

        /// <summary>
        /// This is the area that the template covers. 
        /// Additional templates may follow under this template.
        /// </summary>
        public CyRect RectanglePixels { get; set; }

        /// <summary>
        ///   The maximum number of times that this section can repeat on a page. 
        ///   For each occurrence, the ID characters and extractors are tested.
        /// </summary>
        public int RepeatMaximum { get; set; }

        public bool Matches(CyProfileTemplate other)
        {
            if (this.Classification != other.Classification) return false;
            if (this.CreatedByGuid != other.CreatedByGuid) return false;
            if (this.CreatedOn != other.CreatedOn) return false;
            if (this.DestinationTable != other.DestinationTable) return false;
            if (!this.Extractors.Matches(other.Extractors)) return false;
            if (!this.IdentifyCharacters.Matches(other.IdentifyCharacters)) return false;
            if (!this.IdentifyCharactersUpSideDown.Matches(other.IdentifyCharactersUpSideDown)) return false;
            if (this.ImageName != other.ImageName) return false;
            if (this.Name != other.Name) return false;
            if (!this.RectanglePixels.Matches(other.RectanglePixels)) return false;
            if (this.Type != other.Type) return false;
            if (this.RepeatMaximum != other.RepeatMaximum) return false;

            return true;
        }
    }
}
