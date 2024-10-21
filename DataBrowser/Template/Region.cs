using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBrowser.Template
{
    //	Data file header
    struct REGIONFILEHEADER1
    {
        public uint dwVersion;     //	File version
        public int iNumRegion;     //	Number of region
    };

    struct REGIONFILEHEADER2
    {
        public uint dwVersion;     //	File version
        public int iNumRegion;     //	Number of region
        public int iNumTrans;      //	Number of transport box
    };

    struct REGIONFILEHEADER4
    {
        public uint dwVersion;     //	File version
        public int iNumRegion;     //	Number of region
        public int iNumTrans;      //	Number of transport box
        public uint dwTimeStamp;   //	Time stamp of this data file
    };

    internal class Region
    {
        public string       m_strName;
        public int          m_iType;		//	Region type

        public List<VECTOR3> m_aPoints;

        public override string ToString()
        {
            return m_strName;
        }
    }

    internal class TransportBox
    {
        public int m_idInst;       //	Instance id
        public int m_idSrcInst;    //	Source instance id
        public int m_iLevelLmt;    //	Level limit
        public VECTOR3 m_vTarget;      //	Target position
        public VECTOR3 m_vPos;         //	Area position
        public VECTOR3 m_vExts;        //	Transport box area extents
    }
}
