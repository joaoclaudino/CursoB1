using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperB1
{
    public static class MatrixHelper
    {
        public static SAPbouiCOM.Column addoColumn(
            SAPbouiCOM.IMatrix pMatrix
            , string pUID, BoFormItemTypes pType
            , int pWidth
            , string pCaption
            , string pDescriptiom
            , bool pDisplayDesc

            , bool pBound
            , string pTableName
            , string pAlias

            ,bool pEditable
            ,int pForeColor
            )
        {
            SAPbouiCOM.Column oColumn;
            oColumn = pMatrix.Columns.Add(pUID, pType);
            if (pWidth>0)
            {
                oColumn.Width = pWidth;
            }
            if (!string.IsNullOrEmpty(pCaption))
            {
                oColumn.TitleObject.Caption = pCaption;
            }
            if (!string.IsNullOrEmpty(pDescriptiom))
            {
                oColumn.Description = pDescriptiom;
            }
            oColumn.DisplayDesc = pDisplayDesc;
            if (pBound)
            {
                oColumn.DataBind.SetBound(pBound, pTableName, pAlias);
            }
            oColumn.Editable = pEditable;
            if (pForeColor>0)
            {
                oColumn.ForeColor = pForeColor;
            }

            return oColumn;

        }
    }
}
