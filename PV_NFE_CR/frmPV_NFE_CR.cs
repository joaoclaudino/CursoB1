using HelperB1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV_NFE_CR
{
    class frmPV_NFE_CR
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbobsCOM.Company oCompany;

        private SAPbouiCOM.Form oForm;

        private SAPbouiCOM.EditText oEditCliente = null;
        private SAPbouiCOM.EditText oEditClientN = null;
        private SAPbouiCOM.StaticText oStaticCliente = null;

        private SAPbouiCOM.EditText oEditPostDate = null;
        private SAPbouiCOM.EditText oEditDeliveryDate = null;

        private SAPbouiCOM.StaticText oStaticPostDate = null;
        private SAPbouiCOM.StaticText oStaticDeliveryDate = null;

        private SAPbouiCOM.Button oBtnPV;
        private SAPbouiCOM.Button oBtnPVWithNFE;
        private SAPbouiCOM.Button oBtnPVWithNFEWhitCR;

        public frmPV_NFE_CR()
        {
            AppHelper.SetApplicationWithDI(ref oApplication, ref oCompany);

            this.oForm = UIHelper.CriarForm(
                this.oApplication
                , SAPbouiCOM.BoFormBorderStyle.fbs_Sizable
                , "frmAddPV"
                , "frmAddPV"
                , 200, 430
                , true
                , 0
                , "Exemplo de Adcionar Pedido de Venda Ligados a uma NFE"
                , 0
                , 0
                , 0
                , 300);

            this.oStaticCliente = UIHelper.AdcionarStaticTextAoFormulario(
                this.oForm, "stCliente", 10, 0, 10, 0, "Cliente");
            this.oEditCliente = UIHelper.AdcionarEditTextAoFormulario(
                this.oForm, "TxtCliente", 80, 0, 10, 0, "stCliente", false, 0, 0);
            this.oEditClientN = UIHelper.AdcionarEditTextAoFormulario(
                this.oForm, "TxtClientN", 180, 130, 10, 0, "TxtCliente", false, 0, 0);

            this.oStaticPostDate = UIHelper.AdcionarStaticTextAoFormulario(
                this.oForm, "stPostDt", 10, 0, 25, 0, "Post Date");
            this.oEditPostDate = UIHelper.AdcionarEditTextAoFormulario(
                this.oForm, "TxtPostDt", 80, 0, 25, 0, "stPostDt", false, 0, 0);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "PostDtDS", SAPbouiCOM.BoDataType.dt_DATE, 254);
            this.oEditPostDate.DataBind.SetBound(true, "", "PostDtDS");
            this.oEditPostDate.Value = DateTime.Now.ToString("yyyyMMdd");

            this.oStaticDeliveryDate = UIHelper.AdcionarStaticTextAoFormulario(
                this.oForm, "stDelDt", 10, 0, 40, 0, "Delivery Date");
            this.oEditDeliveryDate = UIHelper.AdcionarEditTextAoFormulario(
                this.oForm, "TxtDelDt", 80, 0, 40, 0, "stDelDt", false, 0, 0);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "DelDt", SAPbouiCOM.BoDataType.dt_DATE, 254);
            this.oEditDeliveryDate.DataBind.SetBound(true, "", "DelDt");
            this.oEditDeliveryDate.Value = DateTime.Now.ToString("yyyyMMdd");

            this.oBtnPV = UIHelper.AddBotaoAoFormulario(this.oForm, "btnPV", 10, 130, 110, 0, "Novo Pedido de Venda", false);
            this.oBtnPVWithNFE = UIHelper.AddBotaoAoFormulario(this.oForm, "btnPVNFE", 150, 130, 110, 0, "Novo PV com NFE", false);
            this.oBtnPVWithNFEWhitCR = UIHelper.AddBotaoAoFormulario(this.oForm, "btnPVNFEC", 290, 130, 110, 0, "PV com NFE com CR", false);

            AddChooseFromList();

            UserDataSourceHelper.AddUserDataSource(this.oForm, "EditDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "EditDSN", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);

            this.oEditCliente.DataBind.SetBound(true, "", "EditDS");
            this.oEditClientN.DataBind.SetBound(true, "", "EditDSN");
            this.oEditCliente.ChooseFromListUID = "CFL1";

            this.oApplication.ItemEvent += OApplication_ItemEvent;

            this.oForm.Visible = true;
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST /*& pVal.FormType.Equals("CFL1")*/ )
            {
                SAPbouiCOM.IChooseFromListEvent oCFLEvento = null;
                oCFLEvento = ((SAPbouiCOM.IChooseFromListEvent)(pVal));
                string sCFL_ID = null;
                sCFL_ID = oCFLEvento.ChooseFromListUID;

                SAPbouiCOM.ChooseFromList oCFL = null;
                oCFL = oForm.ChooseFromLists.Item(sCFL_ID);
                if (oCFLEvento.BeforeAction == false)
                {
                    SAPbouiCOM.DataTable oDataTable = null;
                    oDataTable = oCFLEvento.SelectedObjects;

                    string val = null;
                    string valN = null;

                    try
                    {
                        val = System.Convert.ToString(oDataTable.GetValue(0, 0));
                        valN = System.Convert.ToString(oDataTable.GetValue(1, 0));
                    }
                    catch
                    {

                    }
                    if (pVal.ItemUID.Equals("TxtCliente"))
                    {
                        oForm.DataSources.UserDataSources.Item("EditDS").ValueEx = val;
                        oForm.DataSources.UserDataSources.Item("EditDSN").ValueEx = valN;
                    }

                }
            }
            else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED & pVal.ItemUID.Equals(this.oBtnPV.Item.UniqueID) & pVal.BeforeAction)
            {
                SAPbobsCOM.Documents oOrder;
                oOrder = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
                oOrder.CardCode = this.oEditCliente.Value;
                oOrder.DocDate = DateTime.ParseExact(this.oEditPostDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                oOrder.DocDueDate = DateTime.ParseExact(this.oEditDeliveryDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                oOrder.TaxDate = DateTime.Now;

                oOrder.Lines.SetCurrentLine(0);
                oOrder.Lines.ItemCode = "A00001";
                oOrder.Lines.Quantity = 1;
                oOrder.Lines.UnitPrice = 1;
                oOrder.Lines.Price = 1;
                oOrder.Lines.Add();

                oOrder.Lines.SetCurrentLine(1);
                oOrder.Lines.ItemCode = "A00002";
                oOrder.Lines.Quantity = 1;
                oOrder.Lines.UnitPrice = 1;
                oOrder.Lines.Price = 1;
                oOrder.Lines.Add();

                int lErrCode = oOrder.Add();

                if (lErrCode != 0)
                {
                    int temp_int;
                    string temp_string;
                    this.oCompany.GetLastError(out temp_int, out temp_string);
                    MessageBox.Show(string.Format("Erro Ao Gerar Pedido de Venda: {0}, {1}", temp_int.ToString(), temp_string));
                }
                else
                {
                    string docEntry;
                    docEntry = this.oCompany.GetNewObjectKey();
                    MessageBox.Show(string.Format("Pedido de Venda {0} Gerado com Sucesso!", docEntry), "Order Added");
                }
            }
            else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED & pVal.ItemUID.Equals(this.oBtnPVWithNFE.Item.UniqueID) & pVal.BeforeAction)
            {
                try
                {
                    if (this.oCompany.InTransaction)
                    {
                        this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                    }
                    this.oCompany.StartTransaction();
                    SAPbobsCOM.Documents oOrder;
                    oOrder = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
                    oOrder.CardCode = this.oEditCliente.Value;
                    oOrder.DocDate = DateTime.ParseExact(this.oEditPostDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    oOrder.DocDueDate = DateTime.ParseExact(this.oEditDeliveryDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    oOrder.TaxDate = DateTime.Now;

                    oOrder.Lines.SetCurrentLine(0);
                    oOrder.Lines.ItemCode = "A00001";
                    oOrder.Lines.Quantity = 1;
                    oOrder.Lines.UnitPrice = 1;
                    oOrder.Lines.Price = 1;
                    oOrder.Lines.Usage = "10";
                    oOrder.Lines.Add();

                    oOrder.Lines.SetCurrentLine(1);
                    oOrder.Lines.ItemCode = "A00002";
                    oOrder.Lines.Quantity = 1;
                    oOrder.Lines.UnitPrice = 1;
                    oOrder.Lines.Price = 1;
                    oOrder.Lines.Usage = "10";
                    oOrder.Lines.Add();


                    int lErrCode = oOrder.Add();
                    if (lErrCode != 0)
                    {
                        int temp_int;
                        string temp_string;
                        this.oCompany.GetLastError(out temp_int, out temp_string);
                        this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                        MessageBox.Show(string.Format("Erro Ao Gerar Pedido de Venda: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
                    }
                    else
                    {
                        string docEntry;
                        string docType;
                        docEntry = this.oCompany.GetNewObjectKey();
                        docType = this.oCompany.GetNewObjectType();

                        MessageBox.Show(string.Format("Pedido de Venda {0} Gerado com Sucesso!", docEntry), "Pedido Adcionado");

                        if (oOrder.GetByKey(Convert.ToInt32(docEntry)))
                        {
                            SAPbobsCOM.Documents oInvoice;
                            oInvoice = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);

                            oInvoice.CardCode = oOrder.CardCode;
                            oInvoice.DocDate = oOrder.DocDate;
                            oInvoice.DocDueDate = oOrder.DocDueDate;
                            oInvoice.TaxDate = oOrder.TaxDate;

                            for (int i = 0; i < oOrder.Lines.Count; i++)
                            {
                                oOrder.Lines.SetCurrentLine(i);

                                oInvoice.Lines.SetCurrentLine(i);
                                oInvoice.Lines.BaseEntry = oOrder.DocEntry;
                                oInvoice.Lines.BaseType = Convert.ToInt32(docType);
                                oInvoice.Lines.BaseLine = i;

                                oInvoice.Lines.ItemCode = oOrder.Lines.ItemCode;
                                oInvoice.Lines.Quantity = oOrder.Lines.Quantity;
                                oInvoice.Lines.UnitPrice = oOrder.Lines.UnitPrice;
                                oInvoice.Lines.Price = oOrder.Lines.Price;
                                oInvoice.Lines.Usage = oOrder.Lines.Usage;
                                oInvoice.Lines.Add();
                            }

                            lErrCode = oInvoice.Add();
                            if (lErrCode != 0)
                            {
                                int temp_int;
                                string temp_string;
                                this.oCompany.GetLastError(out temp_int, out temp_string);
                                if (this.oCompany.InTransaction)
                                {
                                    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                }
                                MessageBox.Show(string.Format("Erro Ao Gerar NFE do Pedido de Venda: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
                            }
                            else
                            {
                                docEntry = this.oCompany.GetNewObjectKey();
                                docType = this.oCompany.GetNewObjectType();
                                if (this.oCompany.InTransaction)
                                {
                                    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                }
                                MessageBox.Show(string.Format("NFE {0} Gerado com Sucesso!", docEntry), "NFE Adcionada");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                if (this.oCompany.InTransaction)
                {
                    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                }
            }
            else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED & pVal.ItemUID.Equals(this.oBtnPVWithNFEWhitCR.Item.UniqueID) & pVal.BeforeAction)
            {
                try
                {
                    if (this.oCompany.InTransaction)
                    {
                        this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                    }
                    this.oCompany.StartTransaction();
                    SAPbobsCOM.Documents oOrder;
                    oOrder = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
                    oOrder.CardCode = this.oEditCliente.Value;
                    oOrder.DocDate = DateTime.ParseExact(this.oEditPostDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    oOrder.DocDueDate = DateTime.ParseExact(this.oEditDeliveryDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    oOrder.TaxDate = DateTime.Now;

                    oOrder.Lines.SetCurrentLine(0);
                    oOrder.Lines.ItemCode = "A00001";
                    oOrder.Lines.Quantity = 1;
                    oOrder.Lines.UnitPrice = 1;
                    oOrder.Lines.Price = 1;
                    oOrder.Lines.Usage = "10";
                    oOrder.Lines.Add();

                    oOrder.Lines.SetCurrentLine(1);
                    oOrder.Lines.ItemCode = "A00002";
                    oOrder.Lines.Quantity = 1;
                    oOrder.Lines.UnitPrice = 1;
                    oOrder.Lines.Price = 1;
                    oOrder.Lines.Usage = "10";
                    oOrder.Lines.Add();


                    int lErrCode = oOrder.Add();
                    if (lErrCode != 0)
                    {
                        int temp_int;
                        string temp_string;
                        this.oCompany.GetLastError(out temp_int, out temp_string);
                        this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                        MessageBox.Show(string.Format("Erro Ao Gerar Pedido de Venda: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
                    }
                    else
                    {
                        string docEntry;
                        string docType;
                        docEntry = this.oCompany.GetNewObjectKey();
                        docType = this.oCompany.GetNewObjectType();

                        MessageBox.Show(string.Format("Pedido de Venda {0} Gerado com Sucesso!", docEntry), "Pedido Adcionado");

                        if (oOrder.GetByKey(Convert.ToInt32(docEntry)))
                        {
                            SAPbobsCOM.Documents oInvoice;
                            oInvoice = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);

                            oInvoice.CardCode = oOrder.CardCode;
                            oInvoice.DocDate = oOrder.DocDate;
                            oInvoice.DocDueDate = oOrder.DocDueDate;
                            oInvoice.TaxDate = oOrder.TaxDate;

                            for (int i = 0; i < oOrder.Lines.Count; i++)
                            {
                                oOrder.Lines.SetCurrentLine(i);

                                oInvoice.Lines.SetCurrentLine(i);
                                oInvoice.Lines.BaseEntry = oOrder.DocEntry;
                                oInvoice.Lines.BaseType = Convert.ToInt32(docType);
                                oInvoice.Lines.BaseLine = i;

                                oInvoice.Lines.ItemCode = oOrder.Lines.ItemCode;
                                oInvoice.Lines.Quantity = oOrder.Lines.Quantity;
                                oInvoice.Lines.UnitPrice = oOrder.Lines.UnitPrice;
                                oInvoice.Lines.Price = oOrder.Lines.Price;
                                oInvoice.Lines.Usage = oOrder.Lines.Usage;
                                oInvoice.Lines.Add();
                            }

                            lErrCode = oInvoice.Add();
                            if (lErrCode != 0)
                            {
                                int temp_int;
                                string temp_string;
                                this.oCompany.GetLastError(out temp_int, out temp_string);
                                if (this.oCompany.InTransaction)
                                {
                                    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                }
                                MessageBox.Show(string.Format("Erro Ao Gerar NFE do Pedido de Venda: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
                            }
                            else
                            {
                                docEntry = this.oCompany.GetNewObjectKey();
                                docType = this.oCompany.GetNewObjectType();
                                //if (this.oCompany.InTransaction)
                                //{
                                //    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                //}
                                MessageBox.Show(string.Format("NFE {0} Gerado com Sucesso!", docEntry), "NFE Adcionada");
                                if (oInvoice.GetByKey(Convert.ToInt32(docEntry)))
                                {
                                    SAPbobsCOM.Payments _documentPGTO = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oIncomingPayments);

                                    _documentPGTO.CardCode = oInvoice.CardCode;
                                    _documentPGTO.BPLID = oInvoice.BPL_IDAssignedToInvoice;
                                    _documentPGTO.DueDate = oInvoice.DocDueDate;
                                    _documentPGTO.DocDate = oInvoice.DocDate;
                                    _documentPGTO.TaxDate = oInvoice.TaxDate;

                                    _documentPGTO.Invoices.DocEntry = Convert.ToInt32(docEntry);
                                    _documentPGTO.Invoices.InvoiceType = SAPbobsCOM.BoRcptInvTypes.it_Invoice;
                                    _documentPGTO.Invoices.SumApplied = oInvoice.DocTotal;

                                    _documentPGTO.CashSum = oInvoice.DocTotal;
                                    _documentPGTO.CashAccount = "1.01.01.01.01";
                                    if (_documentPGTO.Add() == 0)
                                    {
                                        if (this.oCompany.InTransaction)
                                        {
                                            this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                        }
                                        MessageBox.Show(string.Format("Contas a Receber NFE {0} Gerado com Sucesso!", docEntry), "Contas a Receber Adcionada");
                                    }
                                    else
                                    {
                                        int temp_int;
                                        string temp_string;
                                        this.oCompany.GetLastError(out temp_int, out temp_string);
                                        if (this.oCompany.InTransaction)
                                        {
                                            this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                        }
                                        MessageBox.Show(string.Format("Erro Ao Gerar Contas a Receber da NFE: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
                                    }
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                if (this.oCompany.InTransaction)
                {
                    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                }
            }
        }

        private void AddChooseFromList()
        {
            SAPbouiCOM.ChooseFromListCollection oCFLs = null;
            SAPbouiCOM.Conditions oCons = null;
            SAPbouiCOM.Condition oCon = null;

            oCFLs = oForm.ChooseFromLists;

            SAPbouiCOM.ChooseFromList oCFL = null;

            SAPbouiCOM.ChooseFromListCreationParams oCFLCreationParams = null;
            oCFLCreationParams = ((SAPbouiCOM.ChooseFromListCreationParams)(oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams)));

            oCFLCreationParams.MultiSelection = false;
            oCFLCreationParams.ObjectType = "2";
            oCFLCreationParams.UniqueID = "CFL1";

            oCFL = oCFLs.Add(oCFLCreationParams);

            oCons = oCFL.GetConditions();

            oCon = oCons.Add();
            oCon.Alias = "CardType";
            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            oCon.CondVal = "C";

            oCFL.SetConditions(oCons);

        }
    }
}
