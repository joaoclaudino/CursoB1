using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GridExemplo
{
    public class MeuFormGrid
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Item oItem;
        private SAPbouiCOM.Grid oGrid;

        private SAPbouiCOM.StaticText oStatHeader;
        private SAPbouiCOM.StaticText oStatHead;
        private SAPbouiCOM.StaticText oStatGroup;
        private SAPbouiCOM.Button oBtnCol;
        private SAPbouiCOM.Button oBtnExp;


        private SAPbouiCOM.OptionBtn oOptNoGroup;
        private SAPbouiCOM.OptionBtn oOptCardCode;
        private SAPbouiCOM.OptionBtn oOptDocDate;
        private SAPbouiCOM.OptionBtn oOptDocStatus;


        private SAPbouiCOM.UserDataSource userDS;

        public MeuFormGrid()
        {
            AppHelper.SetApplication(ref this.oApplication);

            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Sizable, "SAMPLE", "frmGrid", 0, 0, true, 0, "Exemplo de Grid UIAPI", 305, 650);
            this.oForm.Freeze(true);


            this.oStatHeader = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "StatHeader"
                , 20, 500, 20, 0, "Em um novo Grid você pode definir que os dados sejam agrupados e tenham uma árvore de colapso...");

            this.oStatHead = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "StatHead"
                , 20, 500, 40, 0, "Neste Grid você poderá ver todas as Notas Fiscais de Venda Cadastradas...");

            this.oBtnCol = UIHelper.AddBotaoAoFormulario(this.oForm, "btnCol", 480, 0, 80, 0, "Collapse", false);
            this.oBtnExp = UIHelper.AddBotaoAoFormulario(this.oForm, "btnExp", 480, 0, 110, 0, "Expand", false);


            this.oStatGroup = UIHelper.AdcionarStaticTextAoFormulario(this.oForm, "StatGroup"
                , 470, 80, 140, 0, "Agrupado");

            userDS = UserDataSourceHelper.AddUserDataSource(this.oForm, "OpBtnDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1);


            this.oOptNoGroup = UIHelper.AddOptionButtonAoFormulario(
                this.oForm
                , "optNo"
                , 480
                , 120
                , 160
                , 0
                , "Sem Agrupamento"
                , ""
                , true
                , 0
                , 0
                );

            this.oOptNoGroup.DataBind.SetBound(true, "", "OpBtnDS");

            this.oOptCardCode = UIHelper.AddOptionButtonAoFormulario(
                this.oForm
                , "optCode"
                , 480
                , 120
                , 180
                , 0
                , "Código do Cliente"
                , "optNo"
                , true
                , 0
                , 0
                );

            this.oOptCardCode.DataBind.SetBound(true, "", "OpBtnDS");

            this.oOptDocDate = UIHelper.AddOptionButtonAoFormulario(
                this.oForm
                , "optDate"
                , 480
                , 120
                , 200
                , 0
                , "Data do Documento"
                , "optNo"
                , true
                , 0
                , 0
                );

            this.oOptDocDate.DataBind.SetBound(true, "", "OpBtnDS");


            this.oOptDocStatus = UIHelper.AddOptionButtonAoFormulario(
                this.oForm
                , "optStatus"
                , 480
                , 120
                , 220
                , 0
                , "Status do Documento"
                , "optNo"
                , true
                , 0
                , 0
                );

            this.oOptDocStatus.DataBind.SetBound(true, "", "OpBtnDS");



            oItem = oForm.Items.Add("MyGrid", SAPbouiCOM.BoFormItemTypes.it_GRID);
            oItem.Left = 20;
            oItem.Top = 60;
            oItem.Width = 430;
            oItem.Height = 200;

            oGrid = ((SAPbouiCOM.Grid)(oItem.Specific));

            oForm.DataSources.DataTables.Add("MyDataTable");
            oForm.DataSources.DataTables.Item(0).ExecuteQuery("select CardCode, CardName, DocDate, DocNum, format(DocTotal, 'c', 'pt-br')DocTotal, DocStatus from OINV");
            oGrid.DataTable = oForm.DataSources.DataTables.Item("MyDataTable");

            oGrid.Columns.Item(0).Width = 50;
            oGrid.Columns.Item(1).Width = 60;
            oGrid.Columns.Item(2).Width = 130;
            for (int i = 0; i < oGrid.Columns.Count; i++)
            {
                oGrid.Columns.Item(i).Editable = false;
            }

            AtualizarTipoColunas();

            ColorirLinhas();

            this.oForm.Visible = true;

            this.oApplication.ItemEvent += OApplication_ItemEvent;
            this.oForm.Freeze(false);
        }

        private void ColorirLinhas()
        {
            for (int i = 0; i < oGrid.Rows.Count; i++)
            {

                oGrid.CommonSetting.SetRowFontStyle(i + 1, SAPbouiCOM.BoFontStyle.fs_Italic);
                if ((i + 1) % 2 == 0)
                {
                    //verde
                    oGrid.CommonSetting.SetRowBackColor(i + 1, HelperB1.Colors.ColorToInt(Brushes.Green));
                }
                else
                {
                    //azul
                    oGrid.CommonSetting.SetRowBackColor(i + 1,HelperB1.Colors.ColorToInt(Brushes.Blue));
                }
                //for (int x = 0; x < oGrid.Columns.Count; x++)
                //{
                //    oGrid.CommonSetting.SetRowFontStyle(i + 1, SAPbouiCOM.BoFontStyle.fs_Italic);
                //    if ((i + 1) % 2 == 0)
                //    {
                //        //verde
                //        oGrid.CommonSetting.SetCellBackColor(i + 1, x + 1, HelperB1.Colors.ColorToInt(Brushes.Green));
                //    }
                //    else
                //    {
                //        //azul
                //        oGrid.CommonSetting.SetCellBackColor(i + 1, x + 1, HelperB1.Colors.ColorToInt(Brushes.Blue));
                //    }
                //}
            }
        }
       
        private void AtualizarTipoColunas()
        {
            SAPbouiCOM.EditTextColumn oEditCol = ((SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item("CardCode")));
            oEditCol.LinkedObjectType = "2";

            oEditCol = ((SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item("DocNum")));
            oEditCol.LinkedObjectType = "13";

            oGrid.Columns.Item("DocStatus").Type = SAPbouiCOM.BoGridColumnType.gct_ComboBox;
            SAPbouiCOM.ComboBoxColumn oComboBoxCol;
            oComboBoxCol = ((SAPbouiCOM.ComboBoxColumn)(oGrid.Columns.Item("DocStatus")));
            oComboBoxCol.ValidValues.Add("C", "Fechado");
            oComboBoxCol.ValidValues.Add("O", "Aberto");
            oComboBoxCol.DisplayType = SAPbouiCOM.BoComboDisplayType.cdt_Description;
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (FormUID.Equals("frmGrid"))
            {
                if (pVal.ItemUID.Equals("optNo") | pVal.ItemUID.Equals("optCode") | pVal.ItemUID.Equals("optDate") | pVal.ItemUID.Equals("optStatus"))
                {
                    if (userDS.Value.Equals("1"))
                    {
                        oForm.Freeze(true);
                        oForm.DataSources.DataTables.Item(0).ExecuteQuery("select CardCode, CardName, DocDate, DocNum, format(DocTotal, 'c', 'pt-br')DocTotal, DocStatus from OINV");
                        oGrid.CollapseLevel = 0;
                        AtualizarTipoColunas();
                        ColorirLinhas();
                        oForm.Freeze(false);
                    }
                    else if (userDS.Value.Equals("2"))
                    {
                        oForm.Freeze(true);
                        oForm.DataSources.DataTables.Item(0).ExecuteQuery("select CardCode, CardName, DocDate, DocNum, format(DocTotal, 'c', 'pt-br')DocTotal, DocStatus from OINV");
                        oGrid.CollapseLevel = 1;
                        AtualizarTipoColunas();
                        ColorirLinhas();
                        oForm.Freeze(false);
                    }
                    else if (userDS.Value.Equals("3"))
                    {

                        oForm.Freeze(true);
                        oForm.DataSources.DataTables.Item(0).ExecuteQuery("select DocDate,CardCode, CardName,  DocNum, format(DocTotal, 'c', 'pt-br')DocTotal, DocStatus from OINV");
                        oGrid.CollapseLevel = 1;
                        AtualizarTipoColunas();
                        ColorirLinhas();
                        oForm.Freeze(false);
                    }
                    else if (userDS.Value.Equals("4"))
                    {
                        oForm.Freeze(true);
                        oForm.DataSources.DataTables.Item(0).ExecuteQuery("select DocStatus,CardCode, CardName, DocDate, DocNum, format(DocTotal, 'c', 'pt-br')DocTotal from OINV");
                        oGrid.CollapseLevel = 1;
                        AtualizarTipoColunas();
                        ColorirLinhas();
                        oForm.Freeze(false);
                    }
                }else if ((pVal.ItemUID.Equals("btnCol") | pVal.ItemUID.Equals("btnExp") ) & ((!pVal.BeforeAction) & (pVal.EventType==SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED)  ))
                {
                    if (pVal.ItemUID.Equals("btnCol"))
                    {
                        this.oGrid.Rows.CollapseAll();
                    }
                    else if (pVal.ItemUID.Equals("btnExp"))
                    {
                        this.oGrid.Rows.ExpandAll();
                    }
                }
                else if (pVal.EventType==SAPbouiCOM.BoEventTypes.et_FORM_CLOSE)
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
        }
    }
}
