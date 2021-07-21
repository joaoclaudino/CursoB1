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

namespace Matrix_e_Grid
{
    public partial class Form1 : Form
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;

        private SAPbouiCOM.DBDataSource oDBDataSource;
        private SAPbouiCOM.DBDataSource oDBDataSource1;
        private SAPbouiCOM.DBDataSource oDBDataSource2;
        private SAPbouiCOM.DBDataSource oDBDataSource3;


        private SAPbouiCOM.IMatrix oMatrix;
        private SAPbouiCOM.IGrid oGrid;

        //private SAPbouiCOM.IColumn oColumn;

        private SAPbouiCOM.IDataTable oDataTable;



        public Form1()
        {
            InitializeComponent();
            radioButtonMatrixMetaEData.Checked = true;
            radioButtonGridMetaEData.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppHelper.SetApplication(ref this.oApplication);

            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Sizable, "MeuForm", "MeuForm", 600, 400, true, 0, "Exemplo de Matrix e Grid", 0, 0, 50, 0);
            this.oForm.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iColCount = 0;
            this.oMatrix = UIHelper.AddMatrixAoFormulario(this.oForm, "Matrix", 10, (this.oForm.ClientWidth -10), 5, ((this.oForm.ClientHeight / 2) - 10), SAPbouiCOM.BoMatrixSelect.ms_Auto);
            this.oMatrix.Layout = SAPbouiCOM.BoMatrixLayoutType.mlt_Normal;

            this.oDBDataSource = oForm.DataSources.DBDataSources.Add("OCRD");
            this.oDBDataSource1 = oForm.DataSources.DBDataSources.Add("OITM");
            this.oDBDataSource2 = oForm.DataSources.DBDataSources.Add("OINV");
            this.oDBDataSource3 = oForm.DataSources.DBDataSources.Add("INV1");

            MatrixHelper.addoColumn(this.oMatrix, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_EDIT,0
                ,"#","",false,false,"","",false,1);
            iColCount++;

            MatrixHelper.addoColumn(this.oMatrix, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_EDIT, 70
                , "CardCode", "", false, true, "OCRD", "CardCode", false, 0);
            iColCount++;

            MatrixHelper.addoColumn(this.oMatrix, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_EDIT, 100
                , "ItemCode - OITM", "ItemCode", false, true, "OITM", "ItemCode", false, 0);
            iColCount++;

            MatrixHelper.addoColumn(this.oMatrix, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_EDIT, 80
                , "DocDate", "DocDate", false, true, "OINV", "DocDate", false, 0);
            iColCount++;

            MatrixHelper.addoColumn(this.oMatrix, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_EDIT, 80
                , "Numero", "Numero", false, true, "INV1", "LineTotal", false, 0);
            iColCount++;

            this.oMatrix.Clear();
            this.oMatrix.AutoResizeColumns();
            this.oDBDataSource.Query(null);
            this.oDBDataSource1.Query(null);
            this.oDBDataSource2.Query(null);
            this.oDBDataSource3.Query(null);

            this.oMatrix.LoadFromDataSource();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            HabilitarOrdenacaoColunasMAtrix(true);
        }

        private void HabilitarOrdenacaoColunasMAtrix(bool bOrdenar)
        {
            this.oMatrix.Columns.Item(1).TitleObject.Sortable = bOrdenar;
            this.oMatrix.Columns.Item(2).TitleObject.Sortable = bOrdenar;
            this.oMatrix.Columns.Item(3).TitleObject.Sortable = bOrdenar;
            this.oMatrix.Columns.Item(4).TitleObject.Sortable = bOrdenar;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.oMatrix.Columns.Item(1).TitleObject.Sortable = true;
            this.oMatrix.Columns.Item(1).TitleObject.Sort(SAPbouiCOM.BoGridSortType.gst_Descending);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HabilitarOrdenacaoColunasMAtrix(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.oMatrix.Columns.Item(1).TitleObject.Sortable = true;
            this.oMatrix.Columns.Item(1).TitleObject.Sort(SAPbouiCOM.BoGridSortType.gst_Ascending);
        }

        private void btnSerXMLMatrix_Click(object sender, EventArgs e)
        {
            string sXML = string.Empty;
            if (radioButtonMatrixMetaEData.Checked)
            {
                sXML = this.oMatrix.SerializeAsXML(SAPbouiCOM.BoMatrixXmlSelect.mxs_All);
            }
            else if (radioButtonMatrixMetaData.Checked)
            {
                sXML = this.oMatrix.SerializeAsXML(SAPbouiCOM.BoMatrixXmlSelect.mxs_MetaData);
            }
            this.txtMatrixXML.Text = sXML;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            this.oDataTable = oForm.DataSources.DataTables.Add("MyDataTable");
            this.oDataTable.ExecuteQuery("select CardCode,CardName,DocDate,ExcRefDate from OINV");

            this.oGrid = UIHelper.AddGridAoFormulario(
                this.oForm, "MyGrid", 10, oForm.ClientWidth - 10, oForm.ClientHeight / 2
                , (oForm.ClientHeight / 2) - 10
                , SAPbouiCOM.BoMatrixSelect.ms_None
                , (SAPbouiCOM.DataTable)(this.oDataTable)
                );
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HabilitarOrdenacaoColunasDoGrud(true);
        }

        private void HabilitarOrdenacaoColunasDoGrud(bool pSortable)
        {
            this.oGrid.Columns.Item(0).TitleObject.Sortable = pSortable;
            this.oGrid.Columns.Item(1).TitleObject.Sortable = pSortable;
            this.oGrid.Columns.Item(2).TitleObject.Sortable = pSortable;
            this.oGrid.Columns.Item(3).TitleObject.Sortable = pSortable;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HabilitarOrdenacaoColunasDoGrud(false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.oGrid.Columns.Item(0).TitleObject.Sortable = true;
                this.oGrid.Columns.Item(0).TitleObject.Sort(SAPbouiCOM.BoGridSortType.gst_Ascending);
            }
            catch (Exception ex)
            {
                this.oApplication.MessageBox(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.oGrid.Columns.Item(0).TitleObject.Sortable = true;
                this.oGrid.Columns.Item(0).TitleObject.Sort(SAPbouiCOM.BoGridSortType.gst_Descending);
            }
            catch (Exception ex)
            {
                this.oApplication.MessageBox(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.oGrid.CollapseLevel = 1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.oGrid.CollapseLevel = 0;
        }

        private void btnSerXMLGrid_Click(object sender, EventArgs e)
        {
            string sXML = string.Empty;

            if (radioButtonGridMetaEData.Checked)
            {
                sXML = this.oGrid.DataTable.SerializeAsXML(SAPbouiCOM.BoDataTableXmlSelect.dxs_All);
            }
            else if (radioButtonGridMetaData.Checked)
            {
                sXML = this.oGrid.DataTable.SerializeAsXML(SAPbouiCOM.BoDataTableXmlSelect.dxs_MetaData);
            }
            else if (radioButtonGridData.Checked)
            {
                sXML = this.oGrid.DataTable.SerializeAsXML(SAPbouiCOM.BoDataTableXmlSelect.dxs_DataOnly);
            }
            this.txtGridXML.Text = sXML;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton3.Checked)
                {
                    this.oDataTable.LoadSerializedXML(SAPbouiCOM.BoDataTableXmlSelect.dxs_All, this.txtGridXML.Text);
                }
                else if (radioButton2.Checked)
                {
                    this.oDataTable.LoadSerializedXML(SAPbouiCOM.BoDataTableXmlSelect.dxs_MetaData, this.txtGridXML.Text);
                }
                else if (radioButton1.Checked)
                {
                    this.oDataTable.LoadSerializedXML(SAPbouiCOM.BoDataTableXmlSelect.dxs_DataOnly, this.txtGridXML.Text);
                }
            }
            catch (Exception ex)
            {

                this.oApplication.MessageBox(ex.Message);
            }

        }
    }
}
