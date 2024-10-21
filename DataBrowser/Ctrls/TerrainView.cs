using DataBrowser.Template;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DWORD = System.UInt32;

namespace DataBrowser.Ctrls
{
    public partial class TerrainView : UserControl
    {
        public string szFileName { get; set; }

        public TerrainView()
        {
            InitializeComponent();
        }

        private float[] Heights;

        private uint m_byBlockComp;		//	Block data flag
        private TRN2FILEIDVER IdVer;
        private List<T2BKFILEBLOCK6> BlockInfos = new List<T2BKFILEBLOCK6>();
        private List<Terrain> terrains = new List<Terrain>();

        private List<int> m_aDataOffs;

        private FileStream fileStream;

        public void FormLoad(object sender, EventArgs eventArgs)
        {
            int iNumBlock = 0;
            fileStream = new FileStream(szFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            IdVer = new TRN2FILEIDVER();
            byte[] buffer = new byte[Marshal.SizeOf(IdVer)];
            fileStream.Read(buffer, 0, buffer.Length);
            IdVer = Deserialize<TRN2FILEIDVER>(buffer);

            if (IdVer.dwVersion < 2)
            {
                T2BKFILEHEADER Header = new T2BKFILEHEADER();
                var bytes = new byte[Marshal.SizeOf(Header)];
                fileStream.Read(bytes, 0, bytes.Length);
                Header = Deserialize<T2BKFILEHEADER>(bytes);

                iNumBlock = Header.iNumBlock;
                m_byBlockComp = 0;
            }
            else if (IdVer.dwVersion < 5)
            {
                T2BKFILEHEADER2 Header = new T2BKFILEHEADER2();
                var bytes = new byte[Marshal.SizeOf(Header)];
                fileStream.Read(bytes, 0, bytes.Length);
                Header = Deserialize<T2BKFILEHEADER2>(bytes);

                iNumBlock = Header.iNumBlock;
                m_byBlockComp = (uint)(Header.bCompressed ? (T2BKCOMP.T2BKCOMP_COL_ZIP | T2BKCOMP.T2BKCOMP_HEI_ZIP | T2BKCOMP.T2BKCOMP_NOR_ZIP) : 0);
            }
            else
            {
                T2BKFILEHEADER5 Header = new T2BKFILEHEADER5();
                var bytes = new byte[Marshal.SizeOf(Header)];
                fileStream.Read(bytes, 0, bytes.Length);
                Header = Deserialize<T2BKFILEHEADER5>(bytes);

                iNumBlock = Header.iNumBlock;
                m_byBlockComp = Header.byCompressed;
            }

            m_aDataOffs = new List<int>(iNumBlock);
            for (int i = 0; i < iNumBlock; i++)
                m_aDataOffs.Add(binaryReader.ReadInt32());

            uint m_dwBlkFileVer = IdVer.dwVersion;
            
            for (int i = 0; i < iNumBlock; i++)
            {
                var terrain = new Terrain();
                var BlockInfo = new T2BKFILEBLOCK6();
                
                fileStream.Seek(m_aDataOffs[i], SeekOrigin.Begin);

                if (m_dwBlkFileVer < 2)
                {
                    T2BKFILEBLOCK Info = new T2BKFILEBLOCK();
                    var bytes = new byte[Marshal.SizeOf(Info)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    Info = Deserialize<T2BKFILEBLOCK>(bytes);

                    BlockInfo.dwHeiSize = 0;
                    BlockInfo.dwNormalSize = 0;
                    BlockInfo.dwDiffSize = 0;
                    BlockInfo.dwDiffSize1 = 0;
                }
                else if (m_dwBlkFileVer < 3)
                {
                    T2BKFILEBLOCK2 Info = new T2BKFILEBLOCK2();
                    var bytes = new byte[Marshal.SizeOf(Info)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    Info = Deserialize<T2BKFILEBLOCK2>(bytes);

                    BlockInfo.dwHeiSize = Info.dwHeiSize;
                    BlockInfo.dwNormalSize = Info.dwNormalSize;
                    BlockInfo.dwDiffSize = 0;
                    BlockInfo.dwDiffSize1 = 0;
                }
                else if (m_dwBlkFileVer < 4)
                {
                    T2BKFILEBLOCK3 Info = new T2BKFILEBLOCK3();
                    var bytes = new byte[Marshal.SizeOf(Info)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    Info = Deserialize<T2BKFILEBLOCK3>(bytes);

                    BlockInfo.dwHeiSize = Info.dwHeiSize;
                    BlockInfo.dwNormalSize = Info.dwNormalSize;
                    BlockInfo.dwDiffSize = Info.dwDiffSize;
                    BlockInfo.dwDiffSize1 = 0;
                }
                else if (m_dwBlkFileVer < 6)
                {
                    T2BKFILEBLOCK4 Info = new T2BKFILEBLOCK4();
                    var bytes = new byte[Marshal.SizeOf(Info)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    Info = Deserialize<T2BKFILEBLOCK4>(bytes);

                    BlockInfo.dwHeiSize = Info.dwHeiSize;
                    BlockInfo.dwNormalSize = Info.dwNormalSize;
                    BlockInfo.dwDiffSize = Info.dwDiffSize;
                    BlockInfo.dwDiffSize1 = Info.dwDiffSize1;
                }
                else
                {
                    var bytes = new byte[Marshal.SizeOf(BlockInfo)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    BlockInfo = Deserialize<T2BKFILEBLOCK6>(bytes);
                }

                BlockInfos.Add(BlockInfo);

                terrain.pHeiData = new byte[BlockInfo.dwHeiSize];
                terrain.pNormalData = new byte[BlockInfo.dwNormalSize];
                terrain.pHeiData2 = new byte[BlockInfo.dwDiffSize];
                terrain.pNormalData2 = new byte[BlockInfo.dwDiffSize1];

                fileStream.Read(terrain.pHeiData, 0, terrain.pHeiData.Length);
                fileStream.Read(terrain.pNormalData, 0, terrain.pNormalData.Length);
                fileStream.Read(terrain.pHeiData2, 0, terrain.pHeiData2.Length);
                fileStream.Read(terrain.pNormalData2, 0, terrain.pNormalData2.Length);

                terrain.pHeiData = Decompress(terrain.pHeiData);
                //terrain.pNormalData = Decompress(terrain.pHeiData);
                //terrain.pHeiData2 = Decompress(terrain.pHeiData);
                //terrain.pNormalData2 = Decompress(terrain.pHeiData);

                terrains.Add(terrain);
            }

            int pos;
            int x_offset;
            int y_offset;

            double lowValue = 0;
            double height_scale = 800;
            Heights = new float[513 * 513];

            for (int i = 0; i < terrains.Count; i++)
            {
                x_offset = i % 16 * (33 - 1);
                y_offset = (i / 16 * 513 * (33 - 1));

                for (int j = 0; j < terrains[i].pHeiData.Length / 4; j++)
                {
                    pos = y_offset + x_offset + j / 33 * 513 + j % 33;
                    Heights[pos] = (float)(BitConverter.ToSingle(terrains[i].pHeiData, 4 * j) / height_scale);
                }
            }

            byte[] FrameBytes = new byte[4 * 513 * 513];
            IntPtr pointer = Marshal.UnsafeAddrOfPinnedArrayElement(FrameBytes, 0);
            Bitmap bitmap = new Bitmap(513, 513, 4 * 513, PixelFormat.Format32bppArgb, pointer);

            var gray = new int[256];
            for (int i = 0; i < gray.Length; i++)
                gray[i] = i * (256 * 256 + 256 + 1);

            Color color;
            for (int i = 0; i < Heights.Length; i++)
            {
                var value = Convert.ToDouble(Heights[i] * 1000);
                if (value <= lowValue) color = Color.Black;
                else if (value >= height_scale) color = Color.White;
                else color = Color.FromArgb(gray[Convert.ToByte((gray.Length - 1) * (value - lowValue) / (height_scale - lowValue))]);

                FrameBytes[4 * i + 0] = color.B;
                FrameBytes[4 * i + 1] = color.G;
                FrameBytes[4 * i + 2] = color.R;
                FrameBytes[4 * i + 3] = 255; // No Alpha
            }

            GC.Collect();

            pictureBox.Image = bitmap;
        }

        private void ButtonExportClick(object sender, EventArgs eventArgs)
        {
            this.Enabled = false;
            var file = szFileName.Replace(".t2bk", ".hmap");
            var newfile = string.Empty;
            for (int i = 1; i < 100; i++)
            {
                if (!File.Exists(file)) break;
                newfile = string.Format("{0}.{1}", file, i.ToString().PadLeft(4, '0'));
                if (!File.Exists(newfile))
                {
                    File.Move(file, newfile);
                    break;
                }
            }

            using (FileStream fileStream = new FileStream(file, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    foreach (float f in Heights)
                        binaryWriter.Write(f);
                }
            }
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

        private byte[] Decompress(byte[] compressed)
        {
            List<byte> data = new List<byte>();
            using (MemoryStream memoryStream = new MemoryStream(compressed))
            {
                // Skip 2 Bytes from zlib
                memoryStream.ReadByte();
                memoryStream.ReadByte();
                
                DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress, true);

                int value;
                while ((value = deflateStream.ReadByte()) != -1)
                    data.Add((byte)value);                
            }

            return data.ToArray();
        }
    }
}
