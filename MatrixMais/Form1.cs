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

        private String oString;
        private SAPbouiCOM.IEditText oEditText;
        private SAPbouiCOM.Button oButton;
        private bool bIsMatrix = true;
        private int lRowNeedToMerge = 0;
        bool[] bSperateLine;/*= new bool[20] 
        { 
            true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true 
        };*/
        SAPbouiCOM.Cell oCell;

        public Form1()
        {
            InitializeComponent();
            AppHelper.SetApplication(ref this.oApplication);
            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Sizable, "Especial", "Especial", 600, 600, true, 0, "Exemplo de Matrix com Linhas Especiais", 0, 0, 0, 300);
            this.oForm.Visible = true;

            this.oApplication.ItemEvent += OApplication_ItemEvent;
            this.oApplication.FormDataEvent += OApplication_FormDataEvent;

        }

        private void OApplication_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            oString = BusinessObjectInfo.ObjectKey;
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.EventType==SAPbouiCOM.BoEventTypes.et_CLICK && pVal.FormUID== "longtext" && pVal.ItemUID == "1")
            {
                SAPbouiCOM.IForm otempForm;
                otempForm = this.oApplication.Forms.Item("longtext");
                oEditText = (SAPbouiCOM.EditText)otempForm.Items.Item("multiedit").Specific;
                oString = oEditText.Value;
                otempForm.Visible = false;
                if (bIsMatrix)
                {
                    oForm = this.oApplication.Forms.Item("Especial");
                    oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("matrix1").Specific;
                    oMatrix.CommonSetting.MergeCell(lRowNeedToMerge, 2, true);
                    oColumn = oMatrix.Columns.Item("mergecell");

                    oCell = oColumn.Cells.Item(lRowNeedToMerge);
                    oEditText = (SAPbouiCOM.EditText)oCell.Specific;
                    oEditText.Value = oString;
                    oMatrix.FlushToDataSource();
                }
                oForm.Update();
                otempForm.Close();
            }
            if (pVal.ItemUID == "matrix1")
            {
                oItem = oForm.Items.Item(pVal.ItemUID);
                if (oItem.Type == SAPbouiCOM.BoFormItemTypes.it_MATRIX)
                {
                    bIsMatrix = true;
                    oItem = oForm.Items.Item(pVal.ItemUID);
                    oMatrix = (SAPbouiCOM.Matrix)oItem.Specific;
                    oColumn = oMatrix.Columns.Item("Picture");

                    if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_COMBO_SELECT && pVal.BeforeAction == false)
                    {
                        oCombo = (SAPbouiCOM.ComboBox)oColumn.Cells.Item(pVal.Row).Specific;
                        oString = oCombo.Selected.Value;
                        if (oString == "T")
                        {
                            lRowNeedToMerge = pVal.Row;
                            SAPbouiCOM.EditText oTMPET = (SAPbouiCOM.EditText)oMatrix.Columns.Item("mergecell").Cells.Item(lRowNeedToMerge).Specific;
                            PopUp_Text_Form(oTMPET.String);
                        }
                        else if (oString == "S")
                        {
                            oMatrix.CommonSetting.SeparateLine(pVal.Row, 11111, SAPbouiCOM.BoSeparateLineType.slt_Top);
                            int GreyColor = 222 | (223 << 8) | (222 << 16);
                            oMatrix.CommonSetting.SetRowBackColor(pVal.Row, GreyColor);

                            bSperateLine[pVal.Row] = !bSperateLine[pVal.Row];
                            int value = MatrixCalculateTotal(pVal.Row);

                            oEditText = (SAPbouiCOM.EditText)oMatrix.Columns.Item("U_total").Cells.Item(pVal.Row).Specific;
                            oEditText.Value = Convert.ToString(value);

                        }

                        oForm.Update();
                    }

                }
            }
        }
        private int MatrixGetLastTotalRow(int row)
        {
            int last = 0;
            for (int i = 1; i < row; i++)
            {
                oColumn = oMatrix.Columns.Item("Picture");
                oCell = oColumn.Cells.Item(i);
                oCombo = (SAPbouiCOM.ComboBox)oCell.Specific;
                if (oCombo.Selected == null)
                    continue;
                oString = oCombo.Selected.Value;
                if (oString == "S")
                {
                    last = i;
                }
            }
            return last;
        }
        private int MatrixCalculateTotal(int row)
        {
            int total = 0;
            int tmp = 0;
            int last = MatrixGetLastTotalRow(row);

            for (int i = last + 1; i < row; i++)
            {
                oCombo = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item("Picture").Cells.Item(i).Specific;
                if (oCombo.Selected != null)
                {
                    oString = oCombo.Selected.Value;
                    if (oString == "T")
                        continue;
                }
                oColumn = oMatrix.Columns.Item("U_total");
                oCell = oColumn.Cells.Item(i);
                oEditText = (SAPbouiCOM.EditText)oCell.Specific;
                if (String.IsNullOrEmpty(oEditText.Value))
                {
                    oEditText.Value = "0";
                }
                oString = oEditText.Value;
                tmp = Convert.ToInt16(oString);
                total += tmp;

            }
            return total;
        }
        private void PopUp_Text_Form(string inital)
        {
            int oTop, oLeft, oHeight, oWidth;

            SAPbouiCOM.Form oMyForm;
            oMyForm = UIHelper.CriarForm(
                this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Sizable, "longtext", "longtext"
                , 376, 544, true, 0, "Texto Longo", 0, 0, 50, 0);
            oMyForm.Visible = true;

            oEditText = UIHelper.AdcionarEditExtendTextAoFormulario(oMyForm, "multiedit", 0, 526, 0, 298, "", false, 0, 0);
            oEditText.Active = true;
            oEditText.Value = inital;

            oTop = oEditText.Item.Top;
            oLeft = oEditText.Item.Left;
            oHeight = oEditText.Item.Height;
            oWidth = oEditText.Item.Width;

            oButton = UIHelper.AddBotaoAoFormulario(oMyForm, "1", oLeft + 3,70, oTop + oHeight + 50, 20, "Ok", false);
            oTop = oButton.Item.Top;
            oLeft = oButton.Item.Left;
            oHeight = oButton.Item.Height;
            oWidth = oButton.Item.Width;

            oButton = UIHelper.AddBotaoAoFormulario(oMyForm, "2", oLeft + oWidth+ 5, oWidth, oTop , oHeight, "Cancelar", false);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.oDBDataSource = this.oForm.DataSources.DBDataSources.Add("OITM");
            this.oUserDataSource = this.oForm.DataSources.UserDataSources.Add("user1", SAPbouiCOM.BoDataType.dt_LONG_TEXT, 100);

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

            bSperateLine = new bool[this.oMatrix.RowCount + 1];
            bSperateLine = Enumerable.Repeat(true, this.oMatrix.RowCount + 1).ToArray();

            this.oColumn = this.oMatrix.Columns.Item("Picture");
            this.oCombo = (SAPbouiCOM.ComboBox)this.oColumn.Cells.Item(1).Specific;



            string sPathImage = System.Windows.Forms.Application.StartupPath + @"\Smile.bmp";

            sPathImage = "E:\\CursoB1Source\\CursoB1GITWIN\\BMP\\Smile.bmp";

            this.oCombo.ValidValues.Add(sPathImage, "picture");
            this.oCombo.ValidValues.Add("T", "Text");
            this.oCombo.ValidValues.Add("A", "Alternative");
            this.oCombo.ValidValues.Add("S", "SubTotal");



        }
    }
}

