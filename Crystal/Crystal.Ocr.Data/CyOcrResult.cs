using Crystal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crystal.Ocr.Data
{
    [Serializable]
    public class CyOcrResult
    {
        public List<CyOcrCharacter> Characters;
    }

    [Serializable]
    public class CyOcrCharacter
    {
        [XmlAttribute]
        public string Symbols;

        [XmlElement]
        public CyRect Rectangle;

        [XmlAttribute]
        public int GroupIndex;

        [XmlAttribute]
        public float Confidence;
    }

}
