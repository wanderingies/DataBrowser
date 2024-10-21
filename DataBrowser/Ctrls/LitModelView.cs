using DataBrowser.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBrowser.Ctrls
{
    public partial class LitModelView : UserControl
    {
        public string szFileName { get; set; }

        public LitModelView()
        {
            InitializeComponent();
        }

        public uint dwVersion;

        private LitModel model;
        private FileStream fileStream;

        public void FormLoad(object sender, EventArgs eventArgs)
        {
            model = new LitModel();
            fileStream = new FileStream(szFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            model.dwIdentify = binaryReader.ReadUInt32();
            model.version = binaryReader.ReadUInt32();
            if (model.version == 0x80000001)
                model.bCollideOnly = binaryReader.ReadBoolean();
            else binaryReader.BaseStream.Seek(-4, SeekOrigin.Current);

            dwVersion = binaryReader.ReadUInt32();

            model.LitInfo = new LITINFO();
            byte[] buffer = new byte[Marshal.SizeOf(model.LitInfo)];
            fileStream.Read(buffer, 0, buffer.Length);
            model.LitInfo = Deserialize<LITINFO>(buffer);

            int nNumMeshes = binaryReader.ReadInt32();
            model.MeshList = new List<LitMesh>(nNumMeshes);
            for (int i = 0;i< nNumMeshes; i++)
                model.MeshList.Add(ModelLoad(fileStream));

            //if(dwVersion == 0x10000001)
            //if(dwVersion <= 0x10000002)
            if (dwVersion == 0x10000100)
            {
                model.m_szLightMap = binaryReader.ReadBytes(256);
            }
            else if (dwVersion == 0x10000101)
            {
                model.m_szLightMap = binaryReader.ReadBytes(260);
                model.m_szNightLightMap = binaryReader.ReadBytes(260);
            }

            int m_nNumHull = binaryReader.ReadInt32();
            for (int i = 0; i < m_nNumHull; i++)
            {
                int nNumMesh = binaryReader.ReadInt32();

            }
        }

        private LitMesh ModelLoad(FileStream fileStream)
        {
            LitMesh mesh = new LitMesh();
            BinaryReader binaryReader = new BinaryReader(fileStream);

            // 骨骼名称
            mesh.szName = new byte[64];
            fileStream.Read(mesh.szName, 0, mesh.szName.Length);

            // 贴图地址
            mesh.szTextureMap = new byte[256];
            fileStream.Read(mesh.szTextureMap, 0, mesh.szTextureMap.Length);

            // 线与面数量
            int nVertCount = binaryReader.ReadInt32();
            int nFaceCount = binaryReader.ReadInt32();

            if (dwVersion == 0x10000006)
                mesh._hasExtraColors = binaryReader.ReadBoolean();

            if (dwVersion > 0x10000003)
            {
                mesh.pVerts_with = new A3DLMVERTEX_WITHOUTNORMAL[nVertCount];
                for (int i = 0; i < nVertCount; i++)
                {
                    A3DLMVERTEX_WITHOUTNORMAL vertex = new A3DLMVERTEX_WITHOUTNORMAL();
                    byte[] buffer = new byte[Marshal.SizeOf(vertex)];
                    fileStream.Read(buffer, 0, buffer.Length);
                    vertex = Deserialize<A3DLMVERTEX_WITHOUTNORMAL>(buffer);
                    mesh.pVerts_with[i] = vertex;
                }
            }
            else
            {
                mesh.pVerts = new A3DLVERTEX[nVertCount];
                for (int i = 0; i < nVertCount; i++)
                {
                    A3DLVERTEX vertex = new A3DLVERTEX();
                    byte[] buffer = new byte[Marshal.SizeOf(vertex)];
                    fileStream.Read(buffer, 0, buffer.Length);
                    vertex = Deserialize<A3DLVERTEX>(buffer);
                    mesh.pVerts[i] = vertex;
                }
            }

            {
                mesh.m_pIndices = new UInt16[nFaceCount * 3];
                for (int i = 0; i < nFaceCount * 3; i++)
                    mesh.m_pIndices[i] = binaryReader.ReadUInt16();

                mesh.m_pNormals = new A3DVECTOR3[nVertCount];
                for (int i = 0; i < nVertCount; i++)
                {
                    mesh.m_pNormals[i] = new A3DVECTOR3()
                    {
                        x = binaryReader.ReadSingle(),
                        y = binaryReader.ReadSingle(),
                        z = binaryReader.ReadSingle(),
                    };
                }
            }

            if (dwVersion > 0x10000002)
            {
                mesh.m_pDayColors = new uint[nVertCount];
                for (int i = 0; i < nVertCount; i++)
                    mesh.m_pDayColors[i] = binaryReader.ReadUInt32();

                mesh.m_pNightColors = new uint[nVertCount];
                for (int i = 0; i < nVertCount; i++)
                    mesh.m_pNightColors[i] = binaryReader.ReadUInt32();
            }

            if (mesh._hasExtraColors)
            {
                mesh.m_pDayColorsExtra = new uint[nVertCount];
                for (int i = 0; i < nVertCount; i++)
                    mesh.m_pDayColorsExtra[i] = binaryReader.ReadUInt32();

                mesh.m_pNightColorsExtra = new uint[nVertCount];
                for (int i = 0; i < nVertCount; i++)
                    mesh.m_pNightColorsExtra[i] = binaryReader.ReadUInt32();
            }

            {
                mesh.m_aabb = new A3DAABB();
                byte[] buffer = new byte[Marshal.SizeOf(mesh.m_aabb)];
                fileStream.Read(buffer, 0, buffer.Length);
                mesh.m_aabb = Deserialize<A3DAABB>(buffer);
            }

            if (dwVersion > 0x10000004)
            {
                mesh.m_Material = new A3DMaterial();
                mesh.m_Material.szLineBuffer = binaryReader.ReadBytes(11);

                A3DMATERIALPARAM param = new A3DMATERIALPARAM();
                byte[] buffer = new byte[Marshal.SizeOf(param)];
                fileStream.Read(buffer, 0, buffer.Length);
                mesh.m_Material.m_MaterialParam = Deserialize<A3DMATERIALPARAM>(buffer);

                mesh.m_Material.szResult = binaryReader.ReadByte();
            }

            if (dwVersion >= 0x10000100)
            {
                mesh.m_pLMCoords = new A3DLIGHTMAPCOORD[nVertCount];
                for (int i = 0; i < nVertCount; i++)
                {
                    mesh.m_pLMCoords[i] = new A3DLIGHTMAPCOORD()
                    {
                        u = binaryReader.ReadSingle(),
                        v = binaryReader.ReadSingle(),
                    };
                }
            }

            return mesh;
        }

        public static T Deserialize<T>(byte[] rawdatas)
        {
            Type anytype = typeof(T);
            int rawsize = Marshal.SizeOf(anytype);
            if (rawsize > rawdatas.Length) return default(T);

            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.Copy(rawdatas, 0, buffer, rawsize);
            object retobj = Marshal.PtrToStructure(buffer, anytype);
            Marshal.FreeHGlobal(buffer);

            return (T)retobj;
        }
    }
}
