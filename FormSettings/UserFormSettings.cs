using HelperB1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace FormSettings
{
    public partial class UserFormSettings : Form
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;

        private SAPbouiCOM.Button oButtonOK;
        private SAPbouiCOM.Button oButtonCancel;

        //private SAPbouiCOM.Item oItem;
        private SAPbouiCOM.Matrix oMatrix1;
        private SAPbouiCOM.Matrix oMatrix2;

        public UserFormSettings()
        {
            InitializeComponent();

            AppHelper.SetApplication(ref this.oApplication);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //criar um formulários com dois Matrix
            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Sizable, "TypeFrmMatrix", "UidFrmMatrix", 200, 600, true, 0, "Matrix e Celulas", 250, 740,44,366);
            this.oButtonOK = UIHelper.AddBotaoAoFormulario(this.oForm, "1", 5, 65, 170, 19, "Ok", false);
            this.oButtonCancel = UIHelper.AddBotaoAoFormulario(this.oForm, "2", 75, 65, 170, 19, "Cancelar", false);
            AddDataSources();

            this.oMatrix1 = UIHelper.AddMatrixAoFormulario(this.oForm, "Matrix1",360,361,5,150, SAPbouiCOM.BoMatrixSelect.ms_Auto);
            
            this.AddColunasMatrix1(this.oMatrix1);
            this.setMatrix(ref this.oMatrix1);

            this.oMatrix2 = UIHelper.AddMatrixAoFormulario(this.oForm, "Matrix2", 5, 361, 5, 150, SAPbouiCOM.BoMatrixSelect.ms_Auto);
            this.AddColunasMatrix1(this.oMatrix2);
            this.setMatrix(ref this.oMatrix2);

            this.oForm.Settings.Enabled = true;
            this.oForm.Visible = true;

            this.btnMudarGrid.Enabled = true;
            this.btnMatrix.Enabled = false;

        }
        private void setMatrix(ref SAPbouiCOM.Matrix pMatrix1)
        {
            pMatrix1.AddRow(5, -1);
        }
        private void AddColunasMatrix1(SAPbouiCOM.Matrix pMatrix1)
        {
            SAPbouiCOM.Column oColumn;
            SAPbouiCOM.LinkedButton oLinkedButton;

            //add primeira coluna de seleção
            oColumn = pMatrix1.Columns.Add("col0",SAPbouiCOM.BoFormItemTypes.it_EDIT);
            oColumn.TitleObject.Caption = "#";
            oColumn.Editable = false;

            //add coluna link
            oColumn = pMatrix1.Columns.Add("col1", SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON);
            oColumn.Width = 100;
            oColumn.TitleObject.Caption = "Seleção do Link";
            oColumn.BackColor = HelperB1.Colors.ColorToInt(Brushes.Green);
            oColumn.ForeColor = HelperB1.Colors.ColorToInt(Brushes.Purple);
            oColumn.TextStyle = 8;

            oLinkedButton = (SAPbouiCOM.LinkedButton)oColumn.ExtendedObject;
            oLinkedButton.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_BusinessPartner;

            //add coluna combo 
            oColumn = pMatrix1.Columns.Add("col2", SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX);
            oColumn.Width = 100;
            oColumn.DataBind.SetBound(true,"", "ComoboDS");
            oColumn.TitleObject.Caption = "Combo";
            oColumn.BackColor = HelperB1.Colors.ColorToInt(Brushes.Purple);
            oColumn.ForeColor = HelperB1.Colors.ColorToInt(Brushes.Green); 
            for (int i = 0; i <=3; i++)
            {
                oColumn.ValidValues.Add("val"+i.ToString(), "Descrição" + i.ToString());
            }
            oColumn.DisplayDesc = true;

            //add coluna checkbox
            oColumn = pMatrix1.Columns.Add("col3", SAPbouiCOM.BoFormItemTypes.it_CHECK_BOX);
            oColumn.Width = 50;
            oColumn.DataBind.SetBound(true, "", "CheckDS");
            if (pMatrix1.Item.UniqueID.Equals( "Matrix1"))
            {
                oColumn.TitleObject.Caption = "Check 1";
            }
            else if (pMatrix1.Item.UniqueID.Equals("Matrix2"))
            {
                oColumn.TitleObject.Caption = "Check 2";
            }
            oColumn.BackColor = HelperB1.Colors.ColorToInt(Brushes.Green);
            oColumn.ForeColor = HelperB1.Colors.ColorToInt(Brushes.Purple);

            //add Picture Box
            oColumn = pMatrix1.Columns.Add("col4", SAPbouiCOM.BoFormItemTypes.it_PICTURE);
            oColumn.Editable = false;
            oColumn.Width = 60;
            oColumn.DataBind.SetBound(true, "", "PicDS");
            oColumn.TitleObject.Caption = "Picture";
            oColumn.BackColor = HelperB1.Colors.ColorToInt(Brushes.Purple);
            oColumn.ForeColor = HelperB1.Colors.ColorToInt(Brushes.Green);

        }
        private void AddDataSources()
        {
            UserDataSourceHelper.AddUserDataSource(this.oForm, "TabDS1", SAPbouiCOM.BoDataType.dt_SHORT_NUMBER, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "EditDS1", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "EditDS2", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "EditDS3", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "CheckDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "ComoboDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "LinkDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "PicDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
        }

        private void btnMudarGrid_Click(object sender, EventArgs e)
        {            
            if (this.oForm.Settings.MatrixUID.Equals("Matrix1"))
            {
                this.oForm.Settings.MatrixUID = "Matrix2";                
            }
            else
            {
                this.oForm.Settings.MatrixUID = "Matrix1";
            }
        }
    }
}
