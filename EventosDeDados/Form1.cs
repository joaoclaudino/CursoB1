using HelperB1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventosDeDados
{
    public partial class Form1 : Form
    {
        private SAPbouiCOM.Application oApplication;

        public Form1()
        {
            InitializeComponent();

            AppHelper.SetApplication(ref this.oApplication);

            this.GridDataEvent.DataSource = EventData.Tables[0];

            this.oApplication.FormDataEvent += OApplication_FormDataEvent;
        }

        private void OApplication_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            DataRow NewRow;
            int i;

            NewRow = EventData.Tables[0].NewRow();
            i = EventData.Tables[0].Rows.Count;

            NewRow[0] = BusinessObjectInfo.ActionSuccess.ToString();
            NewRow[1] = BusinessObjectInfo.BeforeAction.ToString();
            NewRow[2] = BusinessObjectInfo.EventType.ToString();
            NewRow[3] = BusinessObjectInfo.FormTypeEx.ToString();
            NewRow[4] = BusinessObjectInfo.FormUID.ToString();
            NewRow[5] = BusinessObjectInfo.ObjectKey.ToString();
            NewRow[6] = BusinessObjectInfo.Type.ToString();

            EventData.Tables[0].Rows.Add(NewRow);



        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            GridDataEvent.Width = this.Width - 20;
            GridDataEvent.Height = this.ClientSize.Height - 5 - GridDataEvent.Top;
        }
    }
}
