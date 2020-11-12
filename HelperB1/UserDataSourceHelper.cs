using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperB1
{
    public static class UserDataSourceHelper
    {
        public static SAPbouiCOM.UserDataSource AddUserDataSource(
            SAPbouiCOM.Form pForm
            , string pUID
            , BoDataType pDataType
            , int pLength = 254
        )
        {
           return  pForm.DataSources.UserDataSources.Add(pUID, pDataType, pLength);
        }
    }
}
