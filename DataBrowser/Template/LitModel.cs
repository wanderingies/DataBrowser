using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CHAR = System.Byte;
using WORD = System.UInt16;
using FLOAT = System.Single;
using DWORD = System.UInt32;
using A3DCOLOR = System.UInt32;
using System.Runtime.InteropServices;

namespace DataBrowser.Template
{
    [StructLayout(LayoutKind.Explicit, Size = 0x0C, CharSet = CharSet.Ansi)]
    public struct A3DVECTOR3
    {
        [FieldOffset(0x00)] public FLOAT x, y, z;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30, CharSet = CharSet.Ansi)]
    public struct LITINFO
    {
        [FieldOffset(0x00)] public A3DVECTOR3 m_vecScale;
        [FieldOffset(0x0C)] public A3DVECTOR3 m_vecDir;
        [FieldOffset(0x18)] public A3DVECTOR3 m_vecUp;
        [FieldOffset(0x24)] public A3DVECTOR3 m_vecPos;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x1C, CharSet = CharSet.Ansi)]
    public struct A3DLVERTEX
    {
        [FieldOffset(0x00)] public FLOAT x, y, z;
        [FieldOffset(0x0C)] public DWORD diffuse;
        [FieldOffset(0x10)] public DWORD specular;
        [FieldOffset(0x14)] public FLOAT tu, tv;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18, CharSet = CharSet.Ansi)]
    public struct A3DLMVERTEX_WITHOUTNORMAL
    {
        [FieldOffset(0x00)] public A3DVECTOR3 pos;
        [FieldOffset(0x0C)] public A3DCOLOR diffuse;

        [FieldOffset(0x10)] public float u;
        [FieldOffset(0x14)] public float v;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x30, CharSet = CharSet.Ansi)]
    public struct A3DAABB
    {
        [FieldOffset(0x00)] public A3DVECTOR3 Center;
        [FieldOffset(0x0C)] public A3DVECTOR3 Extents;
        [FieldOffset(0x18)] public A3DVECTOR3 Mins;
        [FieldOffset(0x24)] public A3DVECTOR3 Maxs;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10, CharSet = CharSet.Ansi)]
    struct A3DCOLORVALUE
    {
        [FieldOffset(0x00)] public FLOAT r, g, b, a;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x44, CharSet = CharSet.Ansi)]
    struct A3DMATERIALPARAM
    {
        [FieldOffset(0x00)] public A3DCOLORVALUE Diffuse;
        [FieldOffset(0x10)] public A3DCOLORVALUE Ambient;
        [FieldOffset(0x20)] public A3DCOLORVALUE Specular;
        [FieldOffset(0x30)] public A3DCOLORVALUE Emissive;
        [FieldOffset(0x40)] public FLOAT Power;
    };

    struct A3DMaterial
    {
        public CHAR[] szLineBuffer;
        public A3DMATERIALPARAM m_MaterialParam;
        public CHAR szResult;
    };

    struct A3DLIGHTMAPCOORD
    {
        public FLOAT u, v;
    };

    internal class LitMesh
    {
        public byte[] szName;
        public byte[] szTextureMap;

        public bool _hasExtraColors = false;

        public A3DLVERTEX[] pVerts = null;
        public A3DLMVERTEX_WITHOUTNORMAL[] pVerts_with = null;

        public WORD[] m_pIndices;
        public A3DVECTOR3[] m_pNormals;

        public A3DCOLOR[] m_pDayColors;
        public A3DCOLOR[] m_pNightColors;

        public A3DCOLOR[] m_pDayColorsExtra;
        public A3DCOLOR[] m_pNightColorsExtra;

        public A3DAABB m_aabb;

        public A3DMaterial m_Material;
        public A3DLIGHTMAPCOORD[] m_pLMCoords;
    }

    internal class LitModel
    {
        public uint dwIdentify;
        public uint version;
        public bool bCollideOnly = false;

        public byte[] m_szLightMap;
        public byte[] m_szNightLightMap;

        public LITINFO LitInfo;
        public List<LitMesh> MeshList;
    }
}
