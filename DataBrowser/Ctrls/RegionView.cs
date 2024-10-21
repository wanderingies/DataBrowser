using DataBrowser.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBrowser.Ctrls
{
    public partial class RegionView : UserControl
    {
        public string szFileName { get; set; }

        public RegionView()
        {
            InitializeComponent();
        }

        public int iVersion;
        public int m_dwTimeStamp;

        private List<Template.Region> regions;
        private List<Template.TransportBox> transports;

        private StreamReader streamReader;

        private string Notes => "//  Element pricinct file (client version)";

        public void FormLoad(object sender, EventArgs eventArgs)
        {
            regions = new List<Template.Region>();
            transports = new List<Template.TransportBox>();

            streamReader = new StreamReader(szFileName);                        

            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                Template.Region region = new Template.Region();
                Template.TransportBox transportBox = new Template.TransportBox();

                string token;
                while ((token = streamReader.ReadLine()) == string.Empty) { }
                if (token == null) continue;

                if (token.Contains("version"))
                {
                    iVersion = int.Parse(token.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                    if (iVersion >= 5)
                        m_dwTimeStamp = int.Parse(streamReader.ReadLine());
                    else m_dwTimeStamp = 0;

                    continue;
                }

                if (token == "[region]")
                {
                    region.m_strName = streamReader.ReadLine();
                    var types = streamReader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    region.m_iType = int.Parse(types[0]);
                    int iNumPoint = int.Parse(types[1]);

                    region.m_aPoints = new List<Template.VECTOR3>(iNumPoint);
                    for (int i = 0; i < iNumPoint; i++)
                    {
                        VECTOR3 v = new VECTOR3();
                        var points = streamReader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        //	Get position
                        v.x = float.Parse(points[0]);
                        v.y = float.Parse(points[1]);
                        v.z = float.Parse(points[2]);

                        region.m_aPoints.Add(v);
                    }

                    regions.Add(region);
                }
                else if (token == "[trans]")
                {
                    var value = streamReader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    transportBox.m_idInst = int.Parse(value[0]);

                    if (iVersion >= 3)
                        transportBox.m_idSrcInst = int.Parse(value[1]);
                    else transportBox.m_idSrcInst = 1;

                    if (iVersion >= 5)
                        transportBox.m_iLevelLmt = int.Parse(value[2]);
                    else transportBox.m_iLevelLmt = 1;                    

                    var pos = streamReader.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    transportBox.m_vPos = new VECTOR3()
                    {
                        x = float.Parse(pos[0]),
                        y = float.Parse(pos[1]),
                        z = float.Parse(pos[2]),
                    };

                    var exts = streamReader.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    transportBox.m_vExts = new VECTOR3()
                    {
                        x = float.Parse(exts[0]),
                        y = float.Parse(exts[1]),
                        z = float.Parse(exts[2]),
                    };

                    var target = streamReader.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    transportBox.m_vTarget = new VECTOR3()
                    {
                        x = float.Parse(target[0]),
                        y = float.Parse(target[1]),
                        z = float.Parse(target[2]),
                    };

                    transports.Add(transportBox);
                }
            }

            foreach (var item in regions)
                checkedListBoxRegion.Items.Add(item.ToString());

            for (var i = 0; i < regions.Count; i++)
                checkedListBoxTrans.Items.Add(string.Format("trans-{0}", i.ToString().PadLeft(2, '0')));
        }

        private void CheckedListBoxTransSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            CheckedListBox checkedListBox = sender as CheckedListBox;
            if (checkedListBox == null && checkedListBox.SelectedIndex < 0) return;

            dataGridView.Rows.Clear();
            Template.TransportBox transport = transports[checkedListBox.SelectedIndex];
            dataGridView.Rows.Add(new object[] { "Area", transport.m_vPos.x, transport.m_vPos.y, transport.m_vPos.z });
            dataGridView.Rows.Add(new object[] { "Target", transport.m_vTarget.x, transport.m_vTarget.y, transport.m_vTarget.z });
            dataGridView.Rows.Add(new object[] { "Extents", transport.m_vExts.x, transport.m_vExts.y, transport.m_vExts.z });

            textBoxInst.Text = transport.m_idInst.ToString();
            textBoxSrcInst.Text = transport.m_idSrcInst.ToString();
            textBoxLevelLmt.Text = transport.m_iLevelLmt.ToString();
        }

        private void CheckedListBoxRegionSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            CheckedListBox checkedListBox = sender as CheckedListBox;
            if (checkedListBox == null && checkedListBox.SelectedIndex < 0) return;

            dataGridView.Rows.Clear();
            Template.Region region = regions[checkedListBox.SelectedIndex];
            foreach (var item in region.m_aPoints)
                dataGridView.Rows.Add(new object[] { "region", item.x, item.y, item.z });

            textBoxInst.Text = string.Empty;
            textBoxSrcInst.Text = string.Empty;
            textBoxLevelLmt.Text = string.Empty;
        }

        private void ButtonExportClick(object sender, EventArgs eventArgs)
        {
            if (comboBoxVersion.SelectedIndex < 0) return;

            this.Enabled = false;
            var file = szFileName.Replace(".clt", ".sev");
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

            iVersion = int.Parse(comboBoxVersion.SelectedItem.ToString());
            using (FileStream fileStream = new FileStream(file, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    if (iVersion == 1)
                    {
                        binaryWriter.Write(iVersion);
                        binaryWriter.Write(regions.Count);
                    }
                    else if (iVersion < 4)
                    {
                        binaryWriter.Write(iVersion);
                        binaryWriter.Write(regions.Count);
                        binaryWriter.Write(transports.Count);
                    }
                    else
                    {
                        binaryWriter.Write(iVersion);
                        binaryWriter.Write(regions.Count);
                        binaryWriter.Write(transports.Count);
                        binaryWriter.Write(m_dwTimeStamp);
                    }

                    foreach (var item in regions)
                    {
                        binaryWriter.Write(item.m_iType);
                        binaryWriter.Write(item.m_aPoints.Count);

                        foreach (var point in item.m_aPoints)
                        {
                            binaryWriter.Write(point.x);
                            binaryWriter.Write(point.y);
                            binaryWriter.Write(point.z);
                        }
                    }

                    if (iVersion > 1)
                    {
                        foreach (var item in transports)
                        {
                            binaryWriter.Write(0);
                            binaryWriter.Write(item.m_idInst);

                            if (iVersion >= 3)
                                binaryWriter.Write(item.m_idSrcInst);

                            if (iVersion >= 5)
                                binaryWriter.Write(item.m_iLevelLmt);

                            binaryWriter.Write(item.m_vPos.x);
                            binaryWriter.Write(item.m_vPos.y);
                            binaryWriter.Write(item.m_vPos.z);

                            binaryWriter.Write(item.m_vExts.x);
                            binaryWriter.Write(item.m_vExts.y);
                            binaryWriter.Write(item.m_vExts.z);

                            binaryWriter.Write(item.m_vTarget.x);
                            binaryWriter.Write(item.m_vTarget.y);
                            binaryWriter.Write(item.m_vTarget.z);
                        }
                    }
                }
            }

            Enabled = true;
        }
    }
}
