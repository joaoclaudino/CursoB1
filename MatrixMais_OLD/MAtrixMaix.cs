using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMais
{
    public class MAtrixMaix
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Matrix oMatrix1;
        private SAPbouiCOM.Column oColumn;

        private SAPbouiCOM.UserDataSource oUsrDS;
        private SAPbouiCOM.DBDataSource oDBDS;

        private string sObjectKey;
        private SAPbouiCOM.IComboBox oCombo;
        private SAPbouiCOM.Cell oCell;
        private bool bIsMatrix=false;
        public MAtrixMaix()
        {
            int iColCount = 0;
            AppHelper.SetApplication(ref this.oApplication);


            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Sizable
                , "MaisMatrix", "MaisMatrix", 600, 600, true, 0, "Mais de Matrix",0,0,0,300);
            this.oForm.Visible = true;
            //this.oForm.Freeze(true);


            this.oMatrix1 = UIHelper.AddMatrixAoFormulario(this.oForm, "Matrix1", 10, Convert.ToInt32( this.oForm.Width *0.9)
                , 10, /*Convert.ToInt32(this.oForm.Height * 0.7)*/300, SAPbouiCOM.BoMatrixSelect.ms_Auto);
            this.oMatrix1.Layout = SAPbouiCOM.BoMatrixLayoutType.mlt_Normal;

            this.oDBDS = oForm.DataSources.DBDataSources.Add("OITM");
            this.oUsrDS= UserDataSourceHelper.AddUserDataSource(this.oForm, "UsrDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 20);


            MatrixHelper.addoColumn(this.oMatrix1, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_EDIT, 0
                , "#", "", false, false, "", "", false, 1);
            iColCount++;

            this.oColumn=MatrixHelper.addoColumn(this.oMatrix1, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX, 60
                , "Imagem", "Imagem", false, true, "", "UsrDS", true, 1);

            SAPbouiCOM.ColumnSetting cs = this.oColumn.ColumnSetting;
            SAPbouiCOM.BoColumnDisplayType dt = cs.DisplayType;
            cs.DisplayType = SAPbouiCOM.BoColumnDisplayType.cdt_Picture;
            dt = cs.DisplayType;
            this.oColumn.Editable = true;
            iColCount++;


            this.oColumn = MatrixHelper.addoColumn(this.oMatrix1, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_EXTEDIT, 60
                , "Merge", "Merge", false, true, "OITM", "U_string", false, 1);
            iColCount++;

            this.oColumn = MatrixHelper.addoColumn(this.oMatrix1, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_EXTEDIT, 60
            , "ItemName", "ItemName", false, true, "OITM", "ItemName", false, 1);
            this.oColumn.Editable = false;
            iColCount++;

            this.oColumn = MatrixHelper.addoColumn(this.oMatrix1, "Col" + iColCount.ToString(), SAPbouiCOM.BoFormItemTypes.it_EXTEDIT, 60
            , "Total", "Total", false, true, "OITM", "U_Total", false, 1);
            this.oColumn.Editable = false;
            iColCount++;

            this.oMatrix1.Clear();
            this.oMatrix1.AutoResizeColumns();
            this.oDBDS.Query(null);

            this.oMatrix1.LoadFromDataSource();

            //this.oColumn = this.oMatrix1.Columns.Item("Col1");
            //this.oCombo = (SAPbouiCOM.ComboBox)this.oColumn.Cells.Item(1).Specific;
            //string sString = "C:\\BitMap\\Smile.bmp";
            //this.oCombo.ValidValues.Add(sString, "Imagem");
            //this.oCombo.ValidValues.Add("T", "Texto");
            //this.oCombo.ValidValues.Add("A", "Alternativo");
            //this.oCombo.ValidValues.Add("S", "SubTotal");


            //this.oApplication.ItemEvent += OApplication_ItemEvent;
            //this.oApplication.FormDataEvent += OApplication_FormDataEvent;

            //this.oForm.Freeze(false);
        }

        private void OApplication_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            sObjectKey = BusinessObjectInfo.ObjectKey;
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (FormUID.Equals(this.oForm.UniqueID))
            {
                if (pVal.ItemUID.Equals("MaisMatrix"))
                {
                    bIsMatrix = true;
                }
            }
        }
    }
}
