using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using BYTE = System.Byte;
using WORD = System.UInt16;
using DWORD = System.UInt32;

namespace DataBrowser.Template
{
    //	Block data compress flags
    internal enum T2BKCOMP
    {
        T2BKCOMP_COL_ZIP = 0x01,        //	ZIP compression for color
                                        //	T2BKCOMP_COL_16B	= 0x02,		//	16-bit compression for color
        T2BKCOMP_HEI_ZIP = 0x04,        //	ZIP compression for vertex height
        T2BKCOMP_HEI_INC = 0x08,        //	Increamental compression for vertex height
        T2BKCOMP_NOR_ZIP = 0x10,        //	ZIP compression for normal
        T2BKCOMP_NOR_DEG = 0x20,        //	Degree compression for normal
    };

    //	Block flags & masks
    internal enum T2BKFLAG
    {
        T2BKFLAG_DEFAULT = 0x00,        //	The block flag default value
        T2BKFLAG_NORENDER = 0x01,       //	The whole block is not rendered
        T2BKFLAG_NOTRACE = 0x02,        //	The whole block is out of RayTrace
        T2BKFLAG_NOPOSHEIGHT = 0x04,        //	The whole block is unable to GetPosHeight
        T2BKFLAG_NORENDERWITHWATER = 0x08,      //	The whole block is not rendered with water
    };

    //	Terrain file ID and cersion
    [StructLayout(LayoutKind.Explicit, Size = 0x08, CharSet = CharSet.Ansi)]
    struct TRN2FILEIDVER
    {
        [FieldOffset(0x00)] public DWORD dwIdentify;       //	Identity, must be TRN2FILE_IDENTIFY
        [FieldOffset(0x04)] public DWORD dwVersion;        //	Version, must be TRN2FILE_VERSION
    };

    //	Block data file header, T2BKFILE_VERSION < 2
    [StructLayout(LayoutKind.Explicit, Size = 0x04, CharSet = CharSet.Ansi)]
    struct T2BKFILEHEADER
    {
        [FieldOffset(0x00)] public int iNumBlock;      //	Number of block
    };

    //	Block data file header, T2BKFILE_VERSION >= 2
    [StructLayout(LayoutKind.Explicit, Size = 0x08, CharSet = CharSet.Ansi)]
    struct T2BKFILEHEADER2
    {
        [FieldOffset(0x00)] public int iNumBlock;      //	Number of block
        [FieldOffset(0x04)] public bool bCompressed;   //	Data compression flag
    };

    //	Block data file header, T2BKFILE_VERSION >= 5
    [StructLayout(LayoutKind.Explicit, Size = 0x08, CharSet = CharSet.Ansi)]
    struct T2BKFILEHEADER5
    {
        [FieldOffset(0x00)] public int iNumBlock;      //	Number of block
        [FieldOffset(0x04)] public DWORD byCompressed;  //	Compression flag
    };

    //	Block information
    [StructLayout(LayoutKind.Explicit, Size = 0x10, CharSet = CharSet.Ansi)]
    struct T2BKFILEBLOCK
    {
        [FieldOffset(0x00)] public int iMaskArea;      //	Index of mask area this block blongs to
        [FieldOffset(0x04)] public WORD iRowInTrn;     //	Row of this block in whole terrain
        [FieldOffset(0x06)] public WORD iColInTrn;     //	Column of this block in whole terrain
        [FieldOffset(0x08)] public float fLODScale;        //	LOD scale factor
        [FieldOffset(0x0C)] public DWORD dwLayerFlags; //	Effect layer flags
    };

    //	Block information, T2BKFILE_VERSION >= 2
    [StructLayout(LayoutKind.Explicit, Size = 0x18, CharSet = CharSet.Ansi)]
    struct T2BKFILEBLOCK2
    {
        [FieldOffset(0x00)] public int iMaskArea;      //	Index of mask area this block blongs to
        [FieldOffset(0x04)] public WORD iRowInTrn;     //	Row of this block in whole terrain
        [FieldOffset(0x06)] public WORD iColInTrn;     //	Column of this block in whole terrain
        [FieldOffset(0x08)] public float fLODScale;        //	LOD scale factor
        [FieldOffset(0x0C)] public DWORD dwLayerFlags; //	Effect layer flags
        [FieldOffset(0x10)] public DWORD dwHeiSize;        //	Height data size
        [FieldOffset(0x14)] public DWORD dwNormalSize; //	Normal data size
    };

    //	Block information, T2BKFILE_VERSION >= 3
    [StructLayout(LayoutKind.Explicit, Size = 0x1C, CharSet = CharSet.Ansi)]
    struct T2BKFILEBLOCK3
    {
        [FieldOffset(0x00)] public int iMaskArea;      //	Index of mask area this block blongs to
        [FieldOffset(0x04)] public WORD iRowInTrn;     //	Row of this block in whole terrain
        [FieldOffset(0x06)] public WORD iColInTrn;     //	Column of this block in whole terrain
        [FieldOffset(0x08)] public float fLODScale;        //	LOD scale factor
        [FieldOffset(0x0C)] public DWORD dwLayerFlags; //	Effect layer flags
        [FieldOffset(0x10)] public DWORD dwHeiSize;        //	Height data size
        [FieldOffset(0x14)] public DWORD dwNormalSize; //	Normal data size
        [FieldOffset(0x18)] public DWORD dwDiffSize;       //	Diffuse data size
    };

    //	Block information, T2BKFILE_VERSION >= 4
    [StructLayout(LayoutKind.Explicit, Size = 0x20, CharSet = CharSet.Ansi)]
    struct T2BKFILEBLOCK4
    {
        [FieldOffset(0x00)] public int iMaskArea;      //	Index of mask area this block blongs to
        [FieldOffset(0x04)] public WORD iRowInTrn;     //	Row of this block in whole terrain
        [FieldOffset(0x06)] public WORD iColInTrn;     //	Column of this block in whole terrain
        [FieldOffset(0x08)] public float fLODScale;        //	LOD scale factor
        [FieldOffset(0x0C)] public DWORD dwLayerFlags; //	Effect layer flags
        [FieldOffset(0x10)] public DWORD dwHeiSize;        //	Height data size
        [FieldOffset(0x14)] public DWORD dwNormalSize; //	Normal data size
        [FieldOffset(0x18)] public DWORD dwDiffSize;       //	Diffuse (day light) data size
        [FieldOffset(0x1C)] public DWORD dwDiffSize1;  //	Diffuse (night light) data size
    };

    //	Block information, T2BKFILE_VERSION >= 6
    [StructLayout(LayoutKind.Explicit, Size = 0x24, CharSet = CharSet.Ansi)]
    struct T2BKFILEBLOCK6
    {
        [FieldOffset(0x00)] public int iMaskArea;      //	Index of mask area this block blongs to
        [FieldOffset(0x04)] public WORD iRowInTrn;     //	Row of this block in whole terrain
        [FieldOffset(0x06)] public WORD iColInTrn;     //	Column of this block in whole terrain
        [FieldOffset(0x08)] public float fLODScale;        //	LOD scale factor
        [FieldOffset(0x0C)] public DWORD dwLayerFlags; //	Effect layer flags
        [FieldOffset(0x10)] public DWORD dwHeiSize;        //	Height data size
        [FieldOffset(0x14)] public DWORD dwNormalSize; //	Normal data size
        [FieldOffset(0x18)] public DWORD dwDiffSize;       //	Diffuse (day light) data size
        [FieldOffset(0x1C)] public DWORD dwDiffSize1;  //	Diffuse (night light) data size
        [FieldOffset(0x20)] public DWORD dwBlkFlags;       /*  
								                            dwBlkFlags & T2BKFLAG_NORENDER		The whole block is not rendered
								                            dwBlkFlags & T2BKFLAG_NOTRACE		The whole block is out of RayTrace
								                            dwBlkFlags & T2BKFLAG_NOPOSHEIGHT	The whole block is unable to GetPosHeight
							                                */
    };

    internal struct Terrain
    {
        public const DWORD T2BKFILE_IDENTIFY = (('T' << 24) | ('B' << 16) | ('K' << 8) | 'B');
        public const DWORD T2BKFILE_VERSION = 6;

        public byte[] pHeiData;
        public byte[] pNormalData;
        public byte[] pHeiData2;
        public byte[] pNormalData2;
    }
}
