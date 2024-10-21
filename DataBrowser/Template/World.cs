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
    //	File header
    [StructLayout(LayoutKind.Explicit, Size = 0x74, CharSet = CharSet.Ansi)]
    public struct ECWDFILEHEADER
    {
        [FieldOffset(0x00)] public DWORD dwIdentify;       //	Identity, must be ECWDFILE_IDENTIFY
        [FieldOffset(0x04)] public DWORD dwVersion;        //	Version, must be ECWDFILE_VERSION
        [FieldOffset(0x08)] public float fWorldWid;        //	World width in meters
        [FieldOffset(0x0C)] public float fWorldLen;        //	World length in meters
        [FieldOffset(0x10)] public float fBlockSize;       //	Block size in meters
        [FieldOffset(0x14)] public int iBlockGrid;         //	Block grid row and column number, each block has (grid x grid) terrain grids
        [FieldOffset(0x18)] public int iNumBlock;          //	Number of block
        [FieldOffset(0x1C)] public int iWorldBlkRow;       //	Block row number in whole world
        [FieldOffset(0x20)] public int iWorldBlkCol;       //	Block column number in whole world
        [FieldOffset(0x24)] public DWORD dwTreeOff;        //	Tree type data offset
        [FieldOffset(0x28)] public DWORD dwGrassOff;       //	Grass type data offset
        [FieldOffset(0x2C)] public int iNumTreeType;       //	Number of tree type
        [FieldOffset(0x30)] public int iNumGrassType;      //	Number of grass type
        [FieldOffset(0x34)] public DWORD dwFlags;          //	World file flags
        [FieldOffset(0x38)] public BYTE[] aReserved;       //	Reserved
    };

    //	Block information when ECWDFILE_VERSION <= 3
    [StructLayout(LayoutKind.Explicit, Size = 0x18, CharSet = CharSet.Ansi)]
    struct ECWDFILEBLOCK
    {
        [FieldOffset(0x00)] public WORD iRowInWorld;   //	Row of this block in whole world
        [FieldOffset(0x02)] public WORD iColInWorld;   //	Column of this block in whole world
        [FieldOffset(0x04)] public int iNumTree;       //	Number of tree
        [FieldOffset(0x08)] public int iNumWater;      //	Number of water
        [FieldOffset(0x0C)] public int iNumGrass;      //	Number of grass type
        [FieldOffset(0x10)] public int iNumOrnament;   //	Number of ornament objects
        [FieldOffset(0x14)] public int iNumBoxArea;    //	Number of box area
    };

    //	Block information when 4 <= ECWDFILE_VERSION < 7
    [StructLayout(LayoutKind.Explicit, Size = 0x24, CharSet = CharSet.Ansi)]
    struct ECWDFILEBLOCK4
    {
        [FieldOffset(0x00)] public WORD iRowInWorld;   //	Row of this block in whole world
        [FieldOffset(0x02)] public WORD iColInWorld;   //	Column of this block in whole world
        [FieldOffset(0x04)] public int iNumTree;       //	Number of tree
        [FieldOffset(0x08)] public int iNumWater;      //	Number of water
        [FieldOffset(0x0C)] public int iNumGrass;      //	Number of grass type
        [FieldOffset(0x10)] public int iNumOrnament;   //	Number of ornament objects
        [FieldOffset(0x14)] public int iNumBoxArea;    //	Number of box area
        [FieldOffset(0x18)] public int iNumEffect;     //	Number of GFX effect
        [FieldOffset(0x1C)] public int iNumECModel;    //	Number of EC model
        [FieldOffset(0x20)] public int iNumCritter;    //	Number of Critter group
    };

    //	Block information when 7 <= ECWDFILE_VERSION < 9
    [StructLayout(LayoutKind.Explicit, Size = 0x28, CharSet = CharSet.Ansi)]
    struct ECWDFILEBLOCK7
    {
        [FieldOffset(0x00)] public WORD iRowInWorld;   //	Row of this block in whole world
        [FieldOffset(0x02)] public WORD iColInWorld;   //	Column of this block in whole world
        [FieldOffset(0x04)] public int iNumTree;       //	Number of tree
        [FieldOffset(0x08)] public int iNumWater;      //	Number of water
        [FieldOffset(0x0C)] public int iNumGrass;      //	Number of grass type
        [FieldOffset(0x10)] public int iNumOrnament;   //	Number of ornament objects
        [FieldOffset(0x14)] public int iNumBoxArea;    //	Number of box area
        [FieldOffset(0x18)] public int iNumEffect;     //	Number of GFX effect
        [FieldOffset(0x1C)] public int iNumECModel;    //	Number of EC model
        [FieldOffset(0x20)] public int iNumCritter;    //	Number of Critter group
        [FieldOffset(0x24)] public int iNumBezier;     //	Number of bezier route
    };

    //	Block information when ECWDFILE_VERSION >= 9
    [StructLayout(LayoutKind.Explicit, Size = 0x2C, CharSet = CharSet.Ansi)]
    struct ECWDFILEBLOCK9
    {
        [FieldOffset(0x00)] public WORD iRowInWorld;   //	Row of this block in whole world
        [FieldOffset(0x02)] public WORD iColInWorld;   //	Column of this block in whole world
        [FieldOffset(0x04)] public int iNumTree;       //	Number of tree
        [FieldOffset(0x08)] public int iNumWater;      //	Number of water
        [FieldOffset(0x0C)] public int iNumGrass;      //	Number of grass type
        [FieldOffset(0x10)] public int iNumOrnament;   //	Number of ornament objects
        [FieldOffset(0x14)] public int iNumBoxArea;    //	Number of box area
        [FieldOffset(0x18)] public int iNumEffect;     //	Number of GFX effect
        [FieldOffset(0x1C)] public int iNumECModel;    //	Number of EC model
        [FieldOffset(0x20)] public int iNumCritter;    //	Number of Critter group
        [FieldOffset(0x24)] public int iNumBezier;     //	Number of bezier route
        [FieldOffset(0x28)] public int iNumSound;      //	Number of sound object
    };

    //	Tree information when ECWDFILE_VERSION < 5
    [StructLayout(LayoutKind.Explicit, Size = 0x0C, CharSet = CharSet.Ansi)]
    struct ECWDFILETREE
    {
        [FieldOffset(0x00)] public DWORD dwType;           //	Tree type ID
        [FieldOffset(0x04)] public float vPos_x;      //	Tree position on x and z axis
        [FieldOffset(0x08)] public float vPos_z;
    };

    //	Tree information when ECWDFILE_VERSION >= 5
    [StructLayout(LayoutKind.Explicit, Size = 0x10, CharSet = CharSet.Ansi)]
    struct ECWDFILETREE5
    {
        [FieldOffset(0x00)] public DWORD dwType;           //	Tree type ID
        [FieldOffset(0x04)] public float vPos_x;      //	Tree position on x and z axis
        [FieldOffset(0x08)] public float vPos_y;
        [FieldOffset(0x0C)] public float vPos_z;
    };

    //	Reference to data in BSD file
    [StructLayout(LayoutKind.Explicit, Size = 0x08, CharSet = CharSet.Ansi)]
    struct ECWDFILEDATAREF
    {
        [FieldOffset(0x00)] public DWORD dwExportID;       //	Object export ID
        [FieldOffset(0x04)] public DWORD dwOffset;     //	Data offset in BSD file
    };

    //	Effect data in world file, when ECWDFILE_VERSION < 6
    [StructLayout(LayoutKind.Explicit, Size = 0x2C, CharSet = CharSet.Ansi)]
    struct ECWDFILEEFFECT
    {
        [FieldOffset(0x00)] public DWORD dwExportID;       //	Export ID
        [FieldOffset(0x04)] public float fScale;           //	GFX scale
        [FieldOffset(0x08)] public float vPos_x;      //	Position
        [FieldOffset(0x0C)] public float vPos_y;
        [FieldOffset(0x10)] public float vPos_z;
        [FieldOffset(0x14)] public float vDir_x;      //	Orientation
        [FieldOffset(0x18)] public float vDir_y;
        [FieldOffset(0x1C)] public float vDir_z;
        [FieldOffset(0x20)] public float vUp_x;           //	Up direction
        [FieldOffset(0x24)] public float vUp_y;
        [FieldOffset(0x28)] public float vUp_z;
    };

    //	Effect data in world file, when 6 <= ECWDFILE_VERSION < 8
    [StructLayout(LayoutKind.Explicit, Size = 0x30, CharSet = CharSet.Ansi)]
    struct ECWDFILEEFFECT6
    {
        [FieldOffset(0x00)] public DWORD dwExportID;       //	Export ID
        [FieldOffset(0x04)] public float fScale;           //	GFX scale
        [FieldOffset(0x08)] public float vPos_x;      //	Position
        [FieldOffset(0x0C)] public float vPos_y;
        [FieldOffset(0x10)] public float vPos_z;
        [FieldOffset(0x14)] public float vDir_x;      //	Orientation
        [FieldOffset(0x18)] public float vDir_y;
        [FieldOffset(0x1C)] public float vDir_z;
        [FieldOffset(0x20)] public float vUp_x;           //	Up direction
        [FieldOffset(0x24)] public float vUp_y;
        [FieldOffset(0x28)] public float vUp_z;
        [FieldOffset(0x2C)] public float fSpeed;           //	Play speed
    };

    //	Effect data in world file, when 8 <= ECWDFILE_VERSION < 12
    [StructLayout(LayoutKind.Explicit, Size = 0x34, CharSet = CharSet.Ansi)]
    struct ECWDFILEEFFECT8
    {
        [FieldOffset(0x00)] public DWORD dwExportID;       //	Export ID
        [FieldOffset(0x04)] public float fScale;           //	GFX scale
        [FieldOffset(0x08)] public float vPos_x;      //	Position
        [FieldOffset(0x0C)] public float vPos_y;
        [FieldOffset(0x10)] public float vPos_z;
        [FieldOffset(0x14)] public float vDir_x;      //	Orientation
        [FieldOffset(0x18)] public float vDir_y;
        [FieldOffset(0x1C)] public float vDir_z;
        [FieldOffset(0x20)] public float vUp_x;           //	Up direction
        [FieldOffset(0x24)] public float vUp_y;
        [FieldOffset(0x28)] public float vUp_z;
        [FieldOffset(0x2C)] public float fSpeed;           //	Play speed
        [FieldOffset(0x30)] public int iValidTime;     //	0-in daylight; 1-in night; 2: 24-hour
    };

    //	Effect data in world file, when ECWDFILE_VERSION >= 12
    [StructLayout(LayoutKind.Explicit, Size = 0x3C, CharSet = CharSet.Ansi)]
    struct ECWDFILEEFFECT12
    {
        [FieldOffset(0x00)] public DWORD dwExportID;       //	Export ID
        [FieldOffset(0x04)] public float fScale;           //	GFX scale
        [FieldOffset(0x08)] public float vPos_x;      //	Position
        [FieldOffset(0x0C)] public float vPos_y;
        [FieldOffset(0x10)] public float vPos_z;
        [FieldOffset(0x14)] public float vDir_x;      //	Orientation
        [FieldOffset(0x18)] public float vDir_y;
        [FieldOffset(0x1C)] public float vDir_z;
        [FieldOffset(0x20)] public float vUp_x;           //	Up direction
        [FieldOffset(0x24)] public float vUp_y;
        [FieldOffset(0x28)] public float vUp_z;
        [FieldOffset(0x2C)] public float fSpeed;           //	Play speed
        [FieldOffset(0x30)] public int iValidTime;     //	0-in daylight; 1-in night; 2: 24-hour
        [FieldOffset(0x34)] public float fAlpha;           //	Alpha value
        [FieldOffset(0x38)] public bool bAttenuation;  //	Attenuation flag
    };

    //	Static EC model data in world file
    [StructLayout(LayoutKind.Explicit, Size = 0x2C, CharSet = CharSet.Ansi)]
    struct ECWDFILEECMODEL
    {
        [FieldOffset(0x00)] public DWORD dwExportID;       //	Export ID
        [FieldOffset(0x04)] public float fScale;           //	GFX scale
        [FieldOffset(0x08)] public float vPos_x;      //	Position
        [FieldOffset(0x0C)] public float vPos_y;
        [FieldOffset(0x10)] public float vPos_z;
        [FieldOffset(0x14)] public float vDir_x;      //	Orientation
        [FieldOffset(0x18)] public float vDir_y;
        [FieldOffset(0x1C)] public float vDir_z;
        [FieldOffset(0x20)] public float vUp_x;           //	Up direction
        [FieldOffset(0x24)] public float vUp_y;
        [FieldOffset(0x28)] public float vUp_z;
    };

    //	Sound object data in world file, when ECWDFILE_VERSION < 10
    [StructLayout(LayoutKind.Explicit, Size = 0x1C, CharSet = CharSet.Ansi)]
    struct ECWDFILESOUND
    {
        [FieldOffset(0x00)] public DWORD dwExportID;       //	Export ID
        [FieldOffset(0x04)] public float vPos_x;      //	Tree position on x and z axis
        [FieldOffset(0x08)] public float vPos_y;
        [FieldOffset(0x0C)] public float vPos_z;	//Position
        [FieldOffset(0x10)] public float fMinDist;     //	Minimum and maximum distance
        [FieldOffset(0x14)] public float fMaxDist;
        [FieldOffset(0x18)] public int iGroup;         //	Sound group
    };

    //	Sound object data in world file, when ECWDFILE_VERSION >= 10
    [StructLayout(LayoutKind.Explicit, Size = 0x20, CharSet = CharSet.Ansi)]
    struct ECWDFILESOUND10
    {
        [FieldOffset(0x00)] public DWORD dwExportID;       //	Export ID
        [FieldOffset(0x04)] public float vPos_x;      //	Tree position on x and z axis
        [FieldOffset(0x08)] public float vPos_y;
        [FieldOffset(0x0C)] public float vPos_z;	//Position
        [FieldOffset(0x10)] public float fMinDist;     //	Minimum and maximum distance
        [FieldOffset(0x14)] public float fMaxDist;
        [FieldOffset(0x18)] public int iGroup;         //	Sound group
        [FieldOffset(0x1C)] public int iValidTime;     //	0-in daylight; 1-in night; 2: 24-hour
    };

    internal class World
    {
        public static DWORD ECWDFILE_IDENTIFY = (('E' << 24) | ('C' << 16) | ('W' << 8) | 'D');
        public static DWORD ECWDFILE_VERSION = 12;
    }
}
