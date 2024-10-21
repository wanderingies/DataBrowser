using System;
using System.Collections.Generic;
using System.IO;
using DWORD = System.UInt32;

namespace DataBrowser.Template
{
    public struct VECTOR3
    {
        public float x, y, z;
    };

    struct MARK
    {
        public string strName;
        public VECTOR3 vPos;
    };

    //	Music loop type
    public enum LoopType
    {
        LOOP_NONE = 0,
        LOOP_WHOLE,
        LOOP_SKIPFIRST,
    };

    internal struct Precinct
    {        
        public string m_strName;

        public DWORD m_dwID;

        public int m_iMusicInter;      //	Music interval
        public int m_iMusicLoop;       //	Music loop

        bool m_bNightSFX;		//	flag indicates current night sfx is activated
        public int m_idDstInst;         //	ID of instance m_vCityPos belongs to
        public int m_idSrcInst;         //	ID of source instance
        public int m_iPriority;         //	Precinct priority
        public VECTOR3 m_vCityPos;      //	City position
        public int m_idDomain;          //	ID of domain
        public bool m_bPKProtect;       //  是否是PK保护区
        public string m_strSound;
        public string m_strSound_n;

        public List<VECTOR3> m_aPoints;	//	Precinct points;
        public List<MARK> m_aMarks;
        public List<string> m_aMusicFiles;    

        public override string ToString()
        {
            return m_strName;
        }
    }

    #region Server

    //	Data file header
    public struct PRECINCTFILEHEADER
    {
        public uint dwVersion;     //	File version
        public int iNumPrecinct;   //	Number of NPC generator
    };

    struct PRECINCTFILEHEADER5
    {
        public uint dwVersion;     //	File version
        public int iNumPrecinct;   //	Number of NPC generator
        public uint dwTimeStamp;   //	Time stamp of this data file
    };
    #endregion
}
