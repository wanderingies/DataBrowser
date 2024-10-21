using DataBrowser.Ctrls;
using DataBrowser.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBrowser.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            #region Bonding Events

            comboBoxMaplist.SelectedIndexChanged += ComboBoxMaplistSelectedIndexChanged;
            comboBoxBlock.SelectedIndexChanged += ComboBoxBlockSelectedIndexChanged;
            comboBoxCondition.SelectedIndexChanged += ComboBoxConditionSelectedIndexChanged;
            comboBoxShowmodel.SelectedIndexChanged += ComboBoxShowmodelSelectedIndexChanged;
            treeViewFilelist.NodeMouseClick += TreeViewFilelistNodeMouseClick;
            #endregion

            string[] lines = File.ReadLines("configure.ini").ToArray();
            Dictionary<string, Ini.Category> result = Ini.Parser.Parse(lines);

            Ini.Category user = result["Global"];
            Folder = user.GetEntryByKey("w2i").Value;

            string maps = Path.Combine(Folder, "maps\\");
            var dirs = Directory.GetDirectories(maps, "*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < dirs.Length; i++)
                dirs[i] = dirs[i].Replace(maps, "");

            comboBoxMaplist.DataSource = dirs;
            comboBoxShowmodel.DataSource = new string[] { "Tile", "List", "Details", "SmallIcon", "LargeIcon" };
            comboBoxCondition.DataSource = new string[] { "手动", "全部", "树木", "水域", "静模", "盒子", "植被", "效果", "动模", "动物", "贝塞尔", "声音" };            
        }

        private string Folder;
        private FileStream fileStream;
        private ViewForm viewForm;        

        private List<int> m_aDataOffs;
        private ECWDFILEBLOCK9 m_Info;
        private ECWDFILEHEADER pHeader;

        private List<string> skins => new List<string>() { ".t2bk", ".clt", ".bmd" };

        #region Control Events

        private void ComboBoxMaplistSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null || comboBox.SelectedIndex < 0) return;

            string maps = Path.Combine(Folder, "maps");
            string file = Path.Combine(maps, comboBox.SelectedItem.ToString(), string.Format("{0}.ecwld", comboBox.SelectedItem));
            if (!File.Exists(file)) return;

            fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            pHeader = new ECWDFILEHEADER();
            byte[] buffer = new byte[Marshal.SizeOf(pHeader)];
            fileStream.Read(buffer, 0, buffer.Length);
            pHeader = Deserialize<ECWDFILEHEADER>(buffer);

            m_aDataOffs = new List<int>();
            for (int i = 0; i < pHeader.iNumBlock; i++)
                m_aDataOffs.Add(binaryReader.ReadInt32());

            comboBoxBlock.DataSource = m_aDataOffs;

            treeViewFilelist.Nodes.Clear();
            string mapsPath = Path.Combine(maps, comboBox.SelectedItem.ToString());
            TreeNode map = treeViewFilelist.Nodes.Add("maps");
            SetTreeViewNode(mapsPath, map);

            string litmodelPath = Path.Combine(maps.Replace("maps", "litmodels"), comboBox.SelectedItem.ToString());
            TreeNode litmodel = treeViewFilelist.Nodes.Add("litmodels");
            SetTreeViewNode(litmodelPath, litmodel);
        }

        private void ComboBoxBlockSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null || comboBox.SelectedIndex < 0) return;

            m_Info = new ECWDFILEBLOCK9();
            var offset = m_aDataOffs[comboBox.SelectedIndex];
            
            BinaryReader binaryReader = new BinaryReader(fileStream);
            fileStream.Seek(offset, SeekOrigin.Begin);

            if (pHeader.dwVersion < 4)
            {
                ECWDFILEBLOCK Info = new ECWDFILEBLOCK();
                var bytes = new byte[Marshal.SizeOf(Info)];
                fileStream.Read(bytes, 0, bytes.Length);
                Info = Deserialize<ECWDFILEBLOCK>(bytes);

                m_Info.iNumTree = Info.iNumTree;
                m_Info.iNumWater = Info.iNumWater;
                m_Info.iNumOrnament = Info.iNumOrnament;
                m_Info.iNumBoxArea = Info.iNumBoxArea;
                m_Info.iNumGrass = Info.iNumGrass;
                m_Info.iRowInWorld = Info.iRowInWorld;
                m_Info.iColInWorld = Info.iColInWorld;
            }
            else if (pHeader.dwVersion < 7)
            {
                ECWDFILEBLOCK4 Info = new ECWDFILEBLOCK4();
                var bytes = new byte[Marshal.SizeOf(Info)];
                fileStream.Read(bytes, 0, bytes.Length);
                Info = Deserialize<ECWDFILEBLOCK4>(bytes);

                m_Info.iNumTree = Info.iNumTree;
                m_Info.iNumWater = Info.iNumWater;
                m_Info.iNumOrnament = Info.iNumOrnament;
                m_Info.iNumBoxArea = Info.iNumBoxArea;
                m_Info.iNumGrass = Info.iNumGrass;
                m_Info.iNumEffect = Info.iNumEffect;
                m_Info.iNumECModel = Info.iNumECModel;
                m_Info.iNumCritter = Info.iNumCritter;
                m_Info.iRowInWorld = Info.iRowInWorld;
                m_Info.iColInWorld = Info.iColInWorld;
            }
            else if (pHeader.dwVersion < 9)
            {
                ECWDFILEBLOCK7 Info = new ECWDFILEBLOCK7();
                var bytes = new byte[Marshal.SizeOf(Info)];
                fileStream.Read(bytes, 0, bytes.Length);
                Info = Deserialize<ECWDFILEBLOCK7>(bytes);

                m_Info.iNumTree = Info.iNumTree;
                m_Info.iNumWater = Info.iNumWater;
                m_Info.iNumOrnament = Info.iNumOrnament;
                m_Info.iNumBoxArea = Info.iNumBoxArea;
                m_Info.iNumGrass = Info.iNumGrass;
                m_Info.iNumEffect = Info.iNumEffect;
                m_Info.iNumECModel = Info.iNumECModel;
                m_Info.iNumCritter = Info.iNumCritter;
                m_Info.iNumBezier = Info.iNumBezier;
                m_Info.iRowInWorld = Info.iRowInWorld;
                m_Info.iColInWorld = Info.iColInWorld;
            }
            else
            {
                ECWDFILEBLOCK9 Info = new ECWDFILEBLOCK9();
                var bytes = new byte[Marshal.SizeOf(Info)];
                fileStream.Read(bytes, 0, bytes.Length);
                Info = Deserialize<ECWDFILEBLOCK9>(bytes);

                m_Info.iNumTree = Info.iNumTree;
                m_Info.iNumWater = Info.iNumWater;
                m_Info.iNumOrnament = Info.iNumOrnament;
                m_Info.iNumBoxArea = Info.iNumBoxArea;
                m_Info.iNumGrass = Info.iNumGrass;
                m_Info.iNumEffect = Info.iNumEffect;
                m_Info.iNumECModel = Info.iNumECModel;
                m_Info.iNumCritter = Info.iNumCritter;
                m_Info.iNumBezier = Info.iNumBezier;
                m_Info.iNumSound = Info.iNumSound;
                m_Info.iRowInWorld = Info.iRowInWorld;
                m_Info.iColInWorld = Info.iColInWorld;
            }

            for (int i = 0; i < m_Info.iNumTree; i++)
            {
                if (pHeader.dwVersion < 5)
                {
                    ECWDFILETREE TreeInfo = new ECWDFILETREE();
                    var bytes = new byte[Marshal.SizeOf(TreeInfo)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    TreeInfo = Deserialize<ECWDFILETREE>(bytes);
                }
                else
                {
                    ECWDFILETREE5 TreeInfo = new ECWDFILETREE5();
                    var bytes = new byte[Marshal.SizeOf(TreeInfo)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    TreeInfo = Deserialize<ECWDFILETREE5>(bytes);
                }
            }

            for (int i = 0; i < m_Info.iNumGrass; i++)
            {
                ECWDFILEDATAREF SrcInfo = new ECWDFILEDATAREF();
                var bytes = new byte[Marshal.SizeOf(SrcInfo)];
                fileStream.Read(bytes, 0, bytes.Length);
                SrcInfo = Deserialize<ECWDFILEDATAREF>(bytes);
            }

            for (int i = 0; i < m_Info.iNumWater; i++)
            {
                ECWDFILEDATAREF SrcInfo = new ECWDFILEDATAREF();
                var bytes = new byte[Marshal.SizeOf(SrcInfo)];
                fileStream.Read(bytes, 0, bytes.Length);
                SrcInfo = Deserialize<ECWDFILEDATAREF>(bytes);
            }

            for (int i = 0; i < m_Info.iNumOrnament; i++)
            {
                if (pHeader.dwVersion >= 4)
                {
                    ECWDFILEDATAREF SrcInfo = new ECWDFILEDATAREF();
                    var bytes = new byte[Marshal.SizeOf(SrcInfo)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    SrcInfo = Deserialize<ECWDFILEDATAREF>(bytes);
                }
                else //	Version <= 3
                {

                }
            }

            for (int i = 0; i < m_Info.iNumBoxArea; i++)
            {
                ECWDFILEDATAREF SrcInfo = new ECWDFILEDATAREF();
                var bytes = new byte[Marshal.SizeOf(SrcInfo)];
                fileStream.Read(bytes, 0, bytes.Length);
                SrcInfo = Deserialize<ECWDFILEDATAREF>(bytes);
            }

            for (int i = 0; i < m_Info.iNumEffect; i++)
            {
                if (pHeader.dwVersion < 6)
                {
                    ECWDFILEEFFECT effect = new ECWDFILEEFFECT();
                    var bytes = new byte[Marshal.SizeOf(effect)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    effect = Deserialize<ECWDFILEEFFECT>(bytes);

                    int len = binaryReader.ReadInt32();
                    var str = binaryReader.ReadString();
                }
                else if (pHeader.dwVersion < 8)
                {
                    ECWDFILEEFFECT6 effect = new ECWDFILEEFFECT6();
                    var bytes = new byte[Marshal.SizeOf(effect)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    effect = Deserialize<ECWDFILEEFFECT6>(bytes);

                    int len = binaryReader.ReadInt32();
                    var str = binaryReader.ReadString();
                }
                else if (pHeader.dwVersion < 12)
                {
                    ECWDFILEEFFECT8 effect = new ECWDFILEEFFECT8();
                    var bytes = new byte[Marshal.SizeOf(effect)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    effect = Deserialize<ECWDFILEEFFECT8>(bytes);

                    int len = binaryReader.ReadInt32();
                    var str = binaryReader.ReadString();
                }
                else
                {
                    ECWDFILEEFFECT12 effect = new ECWDFILEEFFECT12();
                    var bytes = new byte[Marshal.SizeOf(effect)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    effect = Deserialize<ECWDFILEEFFECT12>(bytes);

                    int len = binaryReader.ReadInt32();
                    var str = binaryReader.ReadString();
                }
            }

            for (int i = 0; i < m_Info.iNumECModel; i++)
            {
                ECWDFILEECMODEL SrcInfo = new ECWDFILEECMODEL();
                var bytes = new byte[Marshal.SizeOf(SrcInfo)];
                fileStream.Read(bytes, 0, bytes.Length);
                SrcInfo = Deserialize<ECWDFILEECMODEL>(bytes);
            }

            for (int i = 0; i < m_Info.iNumCritter; i++)
            {
                ECWDFILEDATAREF SrcInfo = new ECWDFILEDATAREF();
                var bytes = new byte[Marshal.SizeOf(SrcInfo)];
                fileStream.Read(bytes, 0, bytes.Length);
                SrcInfo = Deserialize<ECWDFILEDATAREF>(bytes);
            }

            for (int i = 0; i < m_Info.iNumBezier; i++)
            {
                ECWDFILEDATAREF SrcInfo = new ECWDFILEDATAREF();
                var bytes = new byte[Marshal.SizeOf(SrcInfo)];
                fileStream.Read(bytes, 0, bytes.Length);
                SrcInfo = Deserialize<ECWDFILEDATAREF>(bytes);
            }

            for (int i = 0; i < m_Info.iNumSound; i++)
            {
                if (pHeader.dwVersion < 10)
                {
                    ECWDFILESOUND SrcInfo = new ECWDFILESOUND();
                    var bytes = new byte[Marshal.SizeOf(SrcInfo)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    SrcInfo = Deserialize<ECWDFILESOUND>(bytes);
                }
                else
                {
                    ECWDFILESOUND10 SrcInfo = new ECWDFILESOUND10();
                    var bytes = new byte[Marshal.SizeOf(SrcInfo)];
                    fileStream.Read(bytes, 0, bytes.Length);
                    SrcInfo = Deserialize<ECWDFILESOUND10>(bytes);
                }
            }
        }

        private void ComboBoxConditionSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null || comboBox.SelectedIndex < 0) return;

            switch (comboBox.SelectedIndex)
            {
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        
                        break;
                    }
                case 4:
                    {
                        
                        break;
                    }
                case 5:
                    {
                        
                        break;
                    }
                case 6:
                    {
                        
                        break;
                    }
                case 7:
                    {
                        
                        break;
                    }
                case 8:
                    {
                        
                        break;
                    }
                case 9:
                    {
                        
                        break;
                    }
                case 10:
                    {
                        
                        break;
                    }
                case 11:
                    {
                        
                        break;
                    }
            }
        }

        private void ComboBoxShowmodelSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null || comboBox.SelectedIndex < 0) return;

            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        listView.View = View.Tile;
                        break;
                    }
                case 1:
                    {
                        listView.View = View.List;
                        break;
                    }
                    case 2:
                    {
                        listView.View = View.Details;
                        break;
                    }
                case 3:
                    {
                        listView.View = View.SmallIcon;
                        break;
                    }
                case 4:
                    {
                        listView.View = View.LargeIcon;
                        break;
                    }
            }
        }

        private void TreeViewFilelistNodeMouseClick(object sender, TreeNodeMouseClickEventArgs eventArgs)
        {
            if (!(sender is TreeView treeView)) return;

            if (eventArgs.Button == MouseButtons.Left)
            {
                if (eventArgs.Node.Text.Contains(".bmd"))
                {

                }
                else if (eventArgs.Node.Text.Contains(".ski"))
                {

                }
            }
            else if (eventArgs.Button == MouseButtons.Right)
            {
                if (eventArgs.Node.Text == "region.clt")
                {
                    
                    RegionView regionView = new RegionView();
                    regionView.Dock = DockStyle.Fill;
                    string mapPath = Path.Combine(Folder, "maps");
                    regionView.szFileName = Path.Combine(mapPath, comboBoxMaplist.SelectedItem.ToString(), "region.clt");

                    viewForm = new ViewForm();
                    viewForm.Size = new Size(1060, 450);
                    viewForm.Controls.Add(regionView);
                    viewForm.Show();
                }
                if (eventArgs.Node.Text == "precinct.clt")
                {                    
                    PrecinctView precinctView = new PrecinctView();
                    precinctView.Dock = DockStyle.Fill;
                    string mapPath = Path.Combine(Folder, "maps");
                    precinctView.szFileName = Path.Combine(mapPath, comboBoxMaplist.SelectedItem.ToString(), "precinct.clt");

                    viewForm = new ViewForm();
                    viewForm.Size = new Size(1060, 450);
                    viewForm.Controls.Add(precinctView);
                    viewForm.Show();
                }
                else if (eventArgs.Node.Text.Contains(".bmd"))
                {
                    LitModelView modelView = new LitModelView();
                    modelView.Dock = DockStyle.Fill;
                    string litPath = Path.Combine(Folder, "litmodels", comboBoxMaplist.SelectedItem.ToString());
                    modelView.szFileName = Path.Combine(litPath, (comboBoxBlock.SelectedIndex + 1).ToString(),eventArgs.Node.Text);

                    viewForm = new ViewForm();
                    viewForm.Size = new Size(1060, 450);
                    viewForm.Controls.Add(modelView);
                    viewForm.Show();
                }
                else if (eventArgs.Node.Text.Contains(".ski"))
                {

                }
                else if (eventArgs.Node.Text.Contains(".t2bk"))
                {
                    TerrainView terrainView = new TerrainView();
                    terrainView.Dock = DockStyle.Fill;
                    string mapPath = Path.Combine(Folder, "maps");
                    terrainView.szFileName = Path.Combine(mapPath, comboBoxMaplist.SelectedItem.ToString(), eventArgs.Node.Text);

                    viewForm = new ViewForm();
                    viewForm.Size = new Size(534, 587);
                    viewForm.Controls.Add(terrainView);
                    viewForm.Show();
                }
            }
        }
        #endregion

        #region Utility

        private void SetTreeViewNode(string path, TreeNode node)
        {
            var directories = Directory.GetDirectories(path);
            if (directories != null)
            {
                foreach (var item in directories)
                {
                    var childrenNode = node.Nodes.Add(item.Substring(item.LastIndexOf('\\') + 1));
                    SetTreeViewNode(item, childrenNode);
                }
            }

            var files = Directory.GetFiles(path);
            if (files != null)
            {
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (!skins.Contains(fileInfo.Extension)) continue;
                    node.Nodes.Add(file.Substring(file.LastIndexOf('\\') + 1));
                }
            }
        }

        public static byte[] Serialize<T>(T obj)
        {
            int rawsize = Marshal.SizeOf(obj);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(obj, buffer, false);
            byte[] rawdatas = new byte[rawsize];
            Marshal.Copy(buffer, rawdatas, 0, rawsize);
            Marshal.FreeHGlobal(buffer);
            return rawdatas;
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
        #endregion
    }
}