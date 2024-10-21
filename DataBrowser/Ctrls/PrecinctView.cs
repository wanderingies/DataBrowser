using DataBrowser.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWORD = System.UInt32;

namespace DataBrowser.Ctrls
{
    public partial class PrecinctView : UserControl
    {
        public string szFileName {  get; set; }

        public PrecinctView()
        {
            InitializeComponent();
        }

        public int iVersion;
        public int m_dwTimeStamp;
        private string Notes => "//  Element pricinct file (client version)";

        private StreamReader streamReader;
        private List<Precinct> GetPrecincts;        

        private string GetNextToken()
        {
            string token;
            while ((token = streamReader.ReadLine()) == string.Empty) { }

            return token;
        }

        public void FormLoad(object sender, EventArgs eventArgs)
        {
            GetPrecincts = new List<Precinct>();
            Precinct precinct = new Precinct();
            streamReader = new StreamReader(szFileName);

            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
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

                precinct.m_strName = token.Trim(new char[] { '\"' });

                var propertys = streamReader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int i = 0;
                int iNumPoint;
                if (iVersion < 2)
                {
                    precinct.m_dwID = 0;

                    //	Read point number
                    iNumPoint = int.Parse(propertys[i++]);
                }
                else    //	dwVersion >= 2
                {
                    //	Read precinct ID
                    precinct.m_dwID = uint.Parse(propertys[i++]);
                    //	Read point number
                    iNumPoint = int.Parse(propertys[i++]);
                }

                //	Read mark number
                int iNumMark = int.Parse(propertys[i++]);
                //	Read priority
                precinct.m_iPriority = int.Parse(propertys[i++]);
                //	Read destination instance ID
                precinct.m_idDstInst = int.Parse(propertys[i++]);
                //	Read music file number
                int iNumMusic = int.Parse(propertys[i++]);
                //	Read music interval
                precinct.m_iMusicInter = int.Parse(propertys[i++]);
                //	Read music loop type
                precinct.m_iMusicLoop = int.Parse(propertys[i++]);

                //	Source instance ID
                if (iVersion >= 4)
                    precinct.m_idSrcInst = int.Parse(propertys[i++]);
                else
                    precinct.m_idSrcInst = 1;

                //	ID of domain
                if (iVersion >= 6)
                    precinct.m_idDomain = int.Parse(propertys[i++]);
                else
                    precinct.m_idDomain = 0;

                //	pk protect
                if (iVersion >= 7)
                    precinct.m_bPKProtect = int.Parse(propertys[i++]) > 0 ? true : false;
                else
                    precinct.m_bPKProtect = false;

                //	Read city position
                precinct.m_vCityPos = new VECTOR3();
                var citypos = streamReader.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                precinct.m_vCityPos.x = float.Parse(citypos[0]);
                precinct.m_vCityPos.y = float.Parse(citypos[1]);
                precinct.m_vCityPos.z = float.Parse(citypos[2]);

                //	Read vertices ...
                precinct.m_aPoints = new List<VECTOR3>(iNumPoint);
                for (i = 0; i < iNumPoint; i++)
                {
                    //	Get position
                    VECTOR3 v = new VECTOR3();
                    var pos = streamReader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    v.x = float.Parse(pos[0]);
                    v.y = float.Parse(pos[1]);
                    v.z = float.Parse(pos[2]);

                    precinct.m_aPoints.Add(v);
                }

                //	Read mark ...
                precinct.m_aMarks = new List<MARK>(iNumMark);
                for (i = 0; i < iNumMark; i++)
                {
                    MARK pMark = new MARK();
                    var marks = GetNextToken();
                    int index = marks.LastIndexOf("\"") + 1;
                    pMark.strName = marks.Substring(0, index).Trim(new char[] { '\"' }); ;
                    var pos = marks.Substring(index).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    pMark.vPos.x = float.Parse(pos[0]);
                    pMark.vPos.y = float.Parse(pos[1]);
                    pMark.vPos.z = float.Parse(pos[2]);

                    precinct.m_aMarks.Add(pMark);
                }

                //	Read sound file
                precinct.m_strSound = "music\\" + GetNextToken();

                //	Read music files ...
                precinct.m_aMusicFiles = new List<string>(iNumMusic);
                for (i = 0; i < iNumMusic; i++)
                    precinct.m_aMusicFiles.Add(GetNextToken());

                //	Read sound file at night
                if (iVersion >= 3)
                    precinct.m_strSound_n = "music\\" + GetNextToken();

                GetPrecincts.Add(precinct);
            }

            foreach (var item in GetPrecincts)
            {
                checkedListBox.Items.Add(item.ToString());
            }

            textBoxVersion.Text = iVersion.ToString();
        }

        private void ListBoxSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (!(sender is CheckedListBox checkedListBox)) return;
            if (checkedListBox.SelectedIndex < 0) return;

            dataGridViewPoints.Rows.Clear();
            dataGridViewMark.Rows.Clear();
            dataGridViewSound.Rows.Clear();

            var precinct = GetPrecincts[checkedListBox.SelectedIndex];
            textBoxId.Text = precinct.m_dwID.ToString();
            textBoxDomain.Text = precinct.m_idDomain.ToString();
            textBoxPriority.Text = precinct.m_iPriority.ToString();
            textBoxPKProtect.Text = precinct.m_bPKProtect.ToString();
            textBoxDstInst.Text = precinct.m_idDstInst.ToString();
            textBoxSrcInst.Text = precinct.m_idSrcInst.ToString();
            textBoxCityPosX.Text = precinct.m_vCityPos.x.ToString();
            textBoxCityPosZ.Text = precinct.m_vCityPos.z.ToString();
            textBoxCityPosY.Text = precinct.m_vCityPos.y.ToString();
            comboBoxMusicLoop.SelectedIndex = precinct.m_iMusicLoop;
            textBoxMusicInter.Text = precinct.m_iMusicInter.ToString();

            foreach (var item in precinct.m_aPoints)
                dataGridViewPoints.Rows.Add(new object[] { item.x, item.y, item.z });

            foreach (var item in precinct.m_aMarks)
                dataGridViewMark.Rows.Add(new object[] { item.strName, item.vPos.x, item.vPos.y, item.vPos.z });

            dataGridViewSound.Rows.Add(new object[] { "Sound", precinct.m_strSound });
            foreach (var item in precinct.m_aMusicFiles)
                dataGridViewSound.Rows.Add(new object[] { "Music", precinct.m_strSound });

            if (iVersion >= 3)
                dataGridViewSound.Rows.Add(new object[] { "Night", precinct.m_strSound_n });
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
                using(BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    if (iVersion < 5)
                    {
                        binaryWriter.Write(iVersion);
                        binaryWriter.Write(GetPrecincts.Count);
                    }
                    else
                    {
                        binaryWriter.Write(iVersion);
                        binaryWriter.Write(GetPrecincts.Count);
                        binaryWriter.Write(m_dwTimeStamp);
                    }

                    foreach (var item in GetPrecincts)
                    {
                        binaryWriter.Write(item.m_aPoints.Count);
                        binaryWriter.Write(item.m_iPriority);
                        binaryWriter.Write(item.m_idDstInst);

                        if (iVersion >= 4)
                            binaryWriter.Write(item.m_idSrcInst);

                        if (iVersion >= 6)
                            binaryWriter.Write(item.m_idDomain);

                        if (iVersion >= 7)
                            binaryWriter.Write(item.m_bPKProtect);

                        binaryWriter.Write(item.m_vCityPos.x);
                        binaryWriter.Write(item.m_vCityPos.y);
                        binaryWriter.Write(item.m_vCityPos.z);

                        for (int i = 0; i < item.m_aPoints.Count; i++)
                        {
                            binaryWriter.Write(item.m_aPoints[i].x);
                            binaryWriter.Write(item.m_aPoints[i].y);
                            binaryWriter.Write(item.m_aPoints[i].z);
                        }
                    }

                    binaryWriter.Flush();
                }
            }

            Enabled = true;
        }
    }
}
