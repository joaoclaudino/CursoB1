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

namespace MatrixMais
{
    public partial class Form1 : Form
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;

        private SAPbouiCOM.Item oItem;

        private SAPbouiCOM.Matrix oMatrix;
        private SAPbouiCOM.Column oColumn;

        private SAPbouiCOM.DBDataSource oDBDataSource;
        private SAPbouiCOM.UserDataSource oUserDataSource;


        private SAPbouiCOM.IComboBox oCombo;

        public Form1()
        {
            InitializeComponent();
            AppHelper.SetApplication(ref this.oApplication);
            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Sizable, "Especial", "Especial", 600, 600, true, 0, "Exemplo de Matrix com Linhas Especiais", 0, 0, 0, 300);
            this.oForm.Visible = true;

            this.oApplication.ItemEvent += OApplication_ItemEvent;

        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.EventType==SAPbouiCOM.BoEventTypes.et_CLICK)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.oDBDataSource = this.oForm.DataSources.DBDataSources.Add("OITM");
            this.oUserDataSource = this.oForm.DataSources.UserDataSources.Add("user1", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 20);

            this.oItem = this.oForm.Items.Add("matrix1", SAPbouiCOM.BoFormItemTypes.it_MATRIX);
            this.oItem.Height = Convert.ToInt32(this.oForm.Height * 0.7);
            this.oItem.Width = Convert.ToInt32(this.oForm.Width * 0.9);
            this.oItem.Top = 10;

            this.oMatrix = (SAPbouiCOM.Matrix)oItem.Specific;
            this.oMatrix.Layout = SAPbouiCOM.BoMatrixLayoutType.mlt_Normal;
            this.oMatrix.SelectionMode = SAPbouiCOM.BoMatrixSelect.ms_Auto;

            //col1
            this.oColumn = this.oMatrix.Columns.Add("col0", SAPbouiCOM.BoFormItemTypes.it_EDIT);
            this.oColumn.Editable = false;
            this.oColumn.TitleObject.Caption = "#";


            //col2
            this.oColumn = this.oMatrix.Columns.Add("Picture", SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX);
            this.oColumn.Width = 60;
            this.oColumn.Description = "Col1";
            this.oColumn.TitleObject.Caption = "Picture";
            this.oColumn.DisplayDesc = false;
            this.oColumn.DataBind.SetBound(true, "", "user1");

            SAPbouiCOM.ColumnSetting cs = this.oColumn.ColumnSetting;
            SAPbouiCOM.BoColumnDisplayType dt = cs.DisplayType;
            cs.DisplayType = SAPbouiCOM.BoColumnDisplayType.cdt_Picture;
            dt = cs.DisplayType;


            //col3
            this.oColumn = this.oMatrix.Columns.Add("mergecell", SAPbouiCOM.BoFormItemTypes.it_EDIT);
            this.oColumn.Width = 60;
            this.oColumn.Description = "Mer";
            this.oColumn.TitleObject.Caption = "MergeCell";
            this.oColumn.DataBind.SetBound(true, "OITM", "U_string");
            this.oColumn.Editable = false;

            //col4
            this.oColumn = this.oMatrix.Columns.Add("ItemName", SAPbouiCOM.BoFormItemTypes.it_EDIT);
            this.oColumn.Width = 60;
            this.oColumn.Description = "col2";
            this.oColumn.TitleObject.Caption = "OITM - ItemName";
            this.oColumn.DataBind.SetBound(true, "OITM", "ItemName");
            this.oColumn.Editable = false;

            //col5
            this.oColumn = this.oMatrix.Columns.Add("ItemCode", SAPbouiCOM.BoFormItemTypes.it_EDIT);
            this.oColumn.Width = 60;
            this.oColumn.Description = "col3";
            this.oColumn.TitleObject.Caption = "OITM - ItemCode";
            this.oColumn.DisplayDesc = false;
            this.oColumn.DataBind.SetBound(true, "OITM", "ItemCode");
            this.oColumn.Editable = false;

            //col6
            this.oColumn = this.oMatrix.Columns.Add("U_total", SAPbouiCOM.BoFormItemTypes.it_EDIT);
            this.oColumn.Width = 60;
            this.oColumn.Description = "col4";
            this.oColumn.TitleObject.Caption = "Total";
            this.oColumn.DataBind.SetBound(true, "OITM", "U_total");
            this.oColumn.Editable = false;


            this.oMatrix.Clear();
            this.oMatrix.AutoResizeColumns();
            this.oDBDataSource.Query(null);
            this.oMatrix.LoadFromDataSource();

            this.oColumn = this.oMatrix.Columns.Item("Picture");
            this.oCombo = (SAPbouiCOM.ComboBox)this.oColumn.Cells.Item(1).Specific;
            string sPathImage = "C:\\BitMap\\Smile.bmp";
            
            this.oCombo.ValidValues.Add(sPathImage, "picture");
            this.oCombo.ValidValues.Add("T", "Text");
            this.oCombo.ValidValues.Add("A", "Alternative");
            this.oCombo.ValidValues.Add("S", "SubTotal");



        }
    }
}

