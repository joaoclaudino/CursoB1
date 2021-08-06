using HelperB1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_NFC_CP
{
    class frmPC_NFC_CP
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbobsCOM.Company oCompany;

        private SAPbouiCOM.Form oForm;

        private SAPbouiCOM.EditText oEditFornecedor = null;
        private SAPbouiCOM.EditText oEditFornecedorN = null;
        private SAPbouiCOM.StaticText oStaticFornecedor = null;

        private SAPbouiCOM.EditText oEditPostDate = null;
        private SAPbouiCOM.EditText oEditDeliveryDate = null;

        private SAPbouiCOM.StaticText oStaticPostDate = null;
        private SAPbouiCOM.StaticText oStaticDeliveryDate = null;

        private SAPbouiCOM.Button oBtnPC;
        private SAPbouiCOM.Button oBtnPCWithNFC;
        private SAPbouiCOM.Button oBtnPCWithNFCWhitCP;

        public frmPC_NFC_CP()
        {
            AppHelper.SetApplicationWithDI(ref oApplication, ref oCompany);

            this.oForm = UIHelper.CriarForm(
                this.oApplication
                , SAPbouiCOM.BoFormBorderStyle.fbs_Sizable
                , "frmAddPC"
                , "frmAddPC"
                , 200, 430
                , true
                , 0
                , "Exemplo de Adcionar Pedido de Compra Ligado a uma NFC"
                , 0
                , 0
                , 0
                , 300);

            this.oStaticFornecedor = UIHelper.AdcionarStaticTextAoFormulario(
                this.oForm, "stCliente", 10, 0, 10, 0, "Fornecedor");
            this.oEditFornecedor = UIHelper.AdcionarEditTextAoFormulario(
                this.oForm, "TxtCliente", 80, 0, 10, 0, "stCliente", false, 0, 0);
            this.oEditFornecedorN = UIHelper.AdcionarEditTextAoFormulario(
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

            this.oBtnPC = UIHelper.AddBotaoAoFormulario(this.oForm, "btnPV", 10, 130, 110, 0, "Novo Pedido de Compra", false);
            this.oBtnPCWithNFC = UIHelper.AddBotaoAoFormulario(this.oForm, "btnPVNFE", 150, 130, 110, 0, "Novo PC com NFC", false);
            this.oBtnPCWithNFCWhitCP = UIHelper.AddBotaoAoFormulario(this.oForm, "btnPVNFEC", 290, 130, 110, 0, "PC com NFC com CP", false);

            AddChooseFromList();

            UserDataSourceHelper.AddUserDataSource(this.oForm, "EditDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);
            UserDataSourceHelper.AddUserDataSource(this.oForm, "EditDSN", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 254);

            this.oEditFornecedor.DataBind.SetBound(true, "", "EditDS");
            this.oEditFornecedorN.DataBind.SetBound(true, "", "EditDSN");
            this.oEditFornecedor.ChooseFromListUID = "CFL1";

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
            else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED & pVal.ItemUID.Equals(this.oBtnPC.Item.UniqueID) & pVal.BeforeAction)
            {
                SAPbobsCOM.Documents oPurchaseOrder;
                oPurchaseOrder = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
                oPurchaseOrder.CardCode = this.oEditFornecedor.Value;
                oPurchaseOrder.DocDate = DateTime.ParseExact(this.oEditPostDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                oPurchaseOrder.DocDueDate = DateTime.ParseExact(this.oEditDeliveryDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                oPurchaseOrder.TaxDate = DateTime.Now;

                oPurchaseOrder.Lines.SetCurrentLine(0);
                oPurchaseOrder.Lines.ItemCode = "A00001";
                oPurchaseOrder.Lines.Quantity = 1;
                oPurchaseOrder.Lines.UnitPrice = 1;
                oPurchaseOrder.Lines.Price = 1;
                oPurchaseOrder.Lines.Add();

                oPurchaseOrder.Lines.SetCurrentLine(1);
                oPurchaseOrder.Lines.ItemCode = "A00002";
                oPurchaseOrder.Lines.Quantity = 1;
                oPurchaseOrder.Lines.UnitPrice = 1;
                oPurchaseOrder.Lines.Price = 1;
                oPurchaseOrder.Lines.Add();

                int lErrCode = oPurchaseOrder.Add();

                if (lErrCode != 0)
                {
                    int temp_int;
                    string temp_string;
                    this.oCompany.GetLastError(out temp_int, out temp_string);
                    MessageBox.Show(string.Format("Erro Ao Gerar Compra de Venda: {0}, {1}", temp_int.ToString(), temp_string));
                }
                else
                {
                    string docEntry;
                    docEntry = this.oCompany.GetNewObjectKey();
                    MessageBox.Show(string.Format("Pedido de Compra {0} Gerado com Sucesso!", docEntry), "Order Added");
                }
            }
            else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED & pVal.ItemUID.Equals(this.oBtnPCWithNFC.Item.UniqueID) & pVal.BeforeAction)
            {
                try
                {
                    if (this.oCompany.InTransaction)
                    {
                        this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                    }
                    this.oCompany.StartTransaction();
                    SAPbobsCOM.Documents oPurchaseOrder;
                    oPurchaseOrder = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
                    oPurchaseOrder.CardCode = this.oEditFornecedor.Value;
                    oPurchaseOrder.DocDate = DateTime.ParseExact(this.oEditPostDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    oPurchaseOrder.DocDueDate = DateTime.ParseExact(this.oEditDeliveryDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    oPurchaseOrder.TaxDate = DateTime.Now;

                    oPurchaseOrder.Lines.SetCurrentLine(0);
                    oPurchaseOrder.Lines.ItemCode = "A00001";
                    oPurchaseOrder.Lines.Quantity = 1;
                    oPurchaseOrder.Lines.UnitPrice = 1;
                    oPurchaseOrder.Lines.Price = 1;
                    oPurchaseOrder.Lines.Usage = "10";
                    oPurchaseOrder.Lines.Add();

                    oPurchaseOrder.Lines.SetCurrentLine(1);
                    oPurchaseOrder.Lines.ItemCode = "A00002";
                    oPurchaseOrder.Lines.Quantity = 1;
                    oPurchaseOrder.Lines.UnitPrice = 1;
                    oPurchaseOrder.Lines.Price = 1;
                    oPurchaseOrder.Lines.Usage = "10";
                    oPurchaseOrder.Lines.Add();


                    int lErrCode = oPurchaseOrder.Add();
                    if (lErrCode != 0)
                    {
                        int temp_int;
                        string temp_string;
                        this.oCompany.GetLastError(out temp_int, out temp_string);
                        this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                        MessageBox.Show(string.Format("Erro Ao Gerar Compra de Venda: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
                    }
                    else
                    {
                        string docEntry;
                        string docType;
                        docEntry = this.oCompany.GetNewObjectKey();
                        docType = this.oCompany.GetNewObjectType();

                        MessageBox.Show(string.Format("Pedido de Compra {0} Gerado com Sucesso!", docEntry), "Pedido Adcionado");

                        if (oPurchaseOrder.GetByKey(Convert.ToInt32(docEntry)))
                        {
                            SAPbobsCOM.Documents oPurchaseInvoice;
                            oPurchaseInvoice = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseInvoices);

                            oPurchaseInvoice.CardCode = oPurchaseOrder.CardCode;
                            oPurchaseInvoice.DocDate = oPurchaseOrder.DocDate;
                            oPurchaseInvoice.DocDueDate = oPurchaseOrder.DocDueDate;
                            oPurchaseInvoice.TaxDate = oPurchaseOrder.TaxDate;

                            for (int i = 0; i < oPurchaseOrder.Lines.Count; i++)
                            {
                                oPurchaseOrder.Lines.SetCurrentLine(i);

                                oPurchaseInvoice.Lines.SetCurrentLine(i);
                                oPurchaseInvoice.Lines.BaseEntry = oPurchaseOrder.DocEntry;
                                oPurchaseInvoice.Lines.BaseType = Convert.ToInt32(docType);
                                oPurchaseInvoice.Lines.BaseLine = i;

                                oPurchaseInvoice.Lines.ItemCode = oPurchaseOrder.Lines.ItemCode;
                                oPurchaseInvoice.Lines.Quantity = oPurchaseOrder.Lines.Quantity;
                                oPurchaseInvoice.Lines.UnitPrice = oPurchaseOrder.Lines.UnitPrice;
                                oPurchaseInvoice.Lines.Price = oPurchaseOrder.Lines.Price;
                                oPurchaseInvoice.Lines.Usage = oPurchaseOrder.Lines.Usage;
                                oPurchaseInvoice.Lines.Add();
                            }

                            lErrCode = oPurchaseInvoice.Add();
                            if (lErrCode != 0)
                            {
                                int temp_int;
                                string temp_string;
                                this.oCompany.GetLastError(out temp_int, out temp_string);
                                if (this.oCompany.InTransaction)
                                {
                                    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                }
                                MessageBox.Show(string.Format("Erro Ao Gerar NFC do Pedido de Venda: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
                            }
                            else
                            {
                                docEntry = this.oCompany.GetNewObjectKey();
                                docType = this.oCompany.GetNewObjectType();
                                if (this.oCompany.InTransaction)
                                {
                                    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                }
                                MessageBox.Show(string.Format("NFC {0} Gerado com Sucesso!", docEntry), "NFC Adcionada");
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
            else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED & pVal.ItemUID.Equals(this.oBtnPCWithNFCWhitCP.Item.UniqueID) & pVal.BeforeAction)
            {
                try
                {
                    if (this.oCompany.InTransaction)
                    {
                        this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                    }
                    this.oCompany.StartTransaction();
                    SAPbobsCOM.Documents oPurchaseOrder;
                    oPurchaseOrder = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
                    oPurchaseOrder.CardCode = this.oEditFornecedor.Value;
                    oPurchaseOrder.DocDate = DateTime.ParseExact(this.oEditPostDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    oPurchaseOrder.DocDueDate = DateTime.ParseExact(this.oEditDeliveryDate.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
                    oPurchaseOrder.TaxDate = DateTime.Now;

                    oPurchaseOrder.Lines.SetCurrentLine(0);
                    oPurchaseOrder.Lines.ItemCode = "A00001";
                    oPurchaseOrder.Lines.Quantity = 1;
                    oPurchaseOrder.Lines.UnitPrice = 1;
                    oPurchaseOrder.Lines.Price = 1;
                    oPurchaseOrder.Lines.Usage = "10";
                    oPurchaseOrder.Lines.Add();

                    oPurchaseOrder.Lines.SetCurrentLine(1);
                    oPurchaseOrder.Lines.ItemCode = "A00002";
                    oPurchaseOrder.Lines.Quantity = 1;
                    oPurchaseOrder.Lines.UnitPrice = 1;
                    oPurchaseOrder.Lines.Price = 1;
                    oPurchaseOrder.Lines.Usage = "10";
                    oPurchaseOrder.Lines.Add();


                    int lErrCode = oPurchaseOrder.Add();
                    if (lErrCode != 0)
                    {
                        int temp_int;
                        string temp_string;
                        this.oCompany.GetLastError(out temp_int, out temp_string);
                        this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                        MessageBox.Show(string.Format("Erro Ao Gerar Pedido de Compra: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
                    }
                    else
                    {
                        string docEntry;
                        string docType;
                        docEntry = this.oCompany.GetNewObjectKey();
                        docType = this.oCompany.GetNewObjectType();

                        MessageBox.Show(string.Format("Pedido de Compra {0} Gerado com Sucesso!", docEntry), "Pedido Adcionado");

                        if (oPurchaseOrder.GetByKey(Convert.ToInt32(docEntry)))
                        {
                            SAPbobsCOM.Documents oPurchaseInvoice;
                            oPurchaseInvoice = this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseInvoices);

                            oPurchaseInvoice.CardCode = oPurchaseOrder.CardCode;
                            oPurchaseInvoice.DocDate = oPurchaseOrder.DocDate;
                            oPurchaseInvoice.DocDueDate = oPurchaseOrder.DocDueDate;
                            oPurchaseInvoice.TaxDate = oPurchaseOrder.TaxDate;

                            for (int i = 0; i < oPurchaseOrder.Lines.Count; i++)
                            {
                                oPurchaseOrder.Lines.SetCurrentLine(i);

                                oPurchaseInvoice.Lines.SetCurrentLine(i);
                                oPurchaseInvoice.Lines.BaseEntry = oPurchaseOrder.DocEntry;
                                oPurchaseInvoice.Lines.BaseType = Convert.ToInt32(docType);
                                oPurchaseInvoice.Lines.BaseLine = i;

                                oPurchaseInvoice.Lines.ItemCode = oPurchaseOrder.Lines.ItemCode;
                                oPurchaseInvoice.Lines.Quantity = oPurchaseOrder.Lines.Quantity;
                                oPurchaseInvoice.Lines.UnitPrice = oPurchaseOrder.Lines.UnitPrice;
                                oPurchaseInvoice.Lines.Price = oPurchaseOrder.Lines.Price;
                                oPurchaseInvoice.Lines.Usage = oPurchaseOrder.Lines.Usage;
                                oPurchaseInvoice.Lines.Add();
                            }

                            lErrCode = oPurchaseInvoice.Add();
                            if (lErrCode != 0)
                            {
                                int temp_int;
                                string temp_string;
                                this.oCompany.GetLastError(out temp_int, out temp_string);
                                if (this.oCompany.InTransaction)
                                {
                                    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                }
                                MessageBox.Show(string.Format("Erro Ao Gerar NFC do Pedido de Venda: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
                            }
                            else
                            {
                                docEntry = this.oCompany.GetNewObjectKey();
                                docType = this.oCompany.GetNewObjectType();
                                //if (this.oCompany.InTransaction)
                                //{
                                //    this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                //}
                                MessageBox.Show(string.Format("NFC {0} Gerado com Sucesso!", docEntry), "NFC Adcionada");
                                if (oPurchaseInvoice.GetByKey(Convert.ToInt32(docEntry)))
                                {
                                    SAPbobsCOM.Payments _documentPGTO = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oVendorPayments);

                                    _documentPGTO.CardCode = oPurchaseInvoice.CardCode;
                                    _documentPGTO.BPLID = oPurchaseInvoice.BPL_IDAssignedToInvoice;
                                    _documentPGTO.DueDate = oPurchaseInvoice.DocDueDate;
                                    _documentPGTO.DocDate = oPurchaseInvoice.DocDate;
                                    _documentPGTO.TaxDate = oPurchaseInvoice.TaxDate;

                                    _documentPGTO.Invoices.DocEntry = Convert.ToInt32(docEntry);
                                    _documentPGTO.Invoices.InvoiceType = SAPbobsCOM.BoRcptInvTypes.it_PurchaseInvoice;
                                    _documentPGTO.Invoices.SumApplied = oPurchaseInvoice.DocTotal;

                                    _documentPGTO.CashSum = oPurchaseInvoice.DocTotal;
                                    _documentPGTO.CashAccount = "1.01.01.01.01";
                                    if (_documentPGTO.Add() == 0)
                                    {
                                        if (this.oCompany.InTransaction)
                                        {
                                            this.oCompany.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                        }
                                        MessageBox.Show(string.Format("Contas a Receber NFC {0} Gerado com Sucesso!", docEntry), "Contas à Pagar Adcionada");
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
                                        MessageBox.Show(string.Format("Erro Ao Gerar Contas à Pagar da NFC: {0}, {1}", temp_int.ToString(), temp_string)); // Display error message
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
            oCon.CondVal = "S";

            oCFL.SetConditions(oCons);

        }
    }
}
