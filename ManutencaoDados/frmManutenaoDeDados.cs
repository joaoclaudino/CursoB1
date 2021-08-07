using HelperB1;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManutencaoDados
{
    class frmManutenaoDeDados
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbobsCOM.Company oCompany;

        private SAPbouiCOM.Form oForm;

        private SAPbouiCOM.Button oBtnNovoLCM;
        private SAPbouiCOM.Button oBtnNovoPN;
        private SAPbouiCOM.Button oBtnNovoItem;

        public frmManutenaoDeDados()
        {
            AppHelper.SetApplicationWithDI(ref oApplication, ref oCompany);

            this.oForm = UIHelper.CriarForm(
                this.oApplication
                , SAPbouiCOM.BoFormBorderStyle.fbs_Sizable
                , "frmAddNEW"
                , "frmAddNEW"
                , 200, 430
                , true
                , 0
                , "Inserir Objetos"
                , 0
                , 0
                , 0
                , 300);

            this.oBtnNovoLCM = UIHelper.AddBotaoAoFormulario(
                this.oForm,
                "btnNL",
                10, 100, 10, 0,
                "Novo LCM",
                false);

            this.oBtnNovoPN = UIHelper.AddBotaoAoFormulario(
                this.oForm,
                "btnNPN",
                120, 100, 10, 0,
                "Novo Parceiro",
                false);

            this.oBtnNovoItem = UIHelper.AddBotaoAoFormulario(
                this.oForm,
                "btnNI",
                230, 100, 10, 0,
                "Novo Item",
                false);


            this.oApplication.ItemEvent += OApplication_ItemEvent;

            this.oForm.Visible = true;

        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED
                & pVal.ItemUID.Equals(this.oBtnNovoLCM.Item.UniqueID)
                & pVal.BeforeAction)
            {
                SAPbobsCOM.JournalEntries oJournalEntries = (SAPbobsCOM.JournalEntries)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oJournalEntries);
                
                oJournalEntries.ReferenceDate = DateTime.Now;
                oJournalEntries.DueDate = DateTime.Now;
                oJournalEntries.TaxDate = DateTime.Now;
                oJournalEntries.Memo = "Novo LCM";

                oJournalEntries.Lines.BPLID = 1;
                oJournalEntries.Lines.AccountCode = "1.01.01.01.01";
                oJournalEntries.Lines.Debit = 0;
                oJournalEntries.Lines.Credit = 10.1;
                oJournalEntries.Lines.ReferenceDate1 = DateTime.Now;
                oJournalEntries.Lines.ReferenceDate2 = DateTime.Now;
                oJournalEntries.Lines.DueDate = DateTime.Now;
                oJournalEntries.Lines.TaxDate = DateTime.Now;
                oJournalEntries.Lines.LineMemo = "Novo LCM Linha Credito";
                oJournalEntries.Lines.Add();

                oJournalEntries.Lines.BPLID = 1;
                oJournalEntries.Lines.AccountCode = "4.02.01.01.09";
                oJournalEntries.Lines.Debit = 10.1;
                oJournalEntries.Lines.Credit = 0;
                oJournalEntries.Lines.ReferenceDate1 = DateTime.Now;
                oJournalEntries.Lines.ReferenceDate2 = DateTime.Now;
                oJournalEntries.Lines.DueDate = DateTime.Now;
                oJournalEntries.Lines.TaxDate = DateTime.Now;
                oJournalEntries.Lines.LineMemo = "Novo LCM Linha Debito";

                int lErrCode = oJournalEntries.Add();

                if (lErrCode != 0)
                {
                    int temp_int;
                    string temp_string;
                    this.oCompany.GetLastError(out temp_int, out temp_string);
                    
                    MessageBox.Show(string.Format("Erro Ao Gerar LCM: {0}, {1}", temp_int.ToString(), temp_string));
                }
                else
                {
                    string docEntry;
                    docEntry = this.oCompany.GetNewObjectKey();
                    MessageBox.Show(string.Format("LCM {0} Gerado com Sucesso!", docEntry), "LCM Adcionado");
                    if (oJournalEntries.GetByKey(Convert.ToInt32(docEntry)))
                    {
                        oJournalEntries.Memo = "Alterado Novo LCM";
                        for (int i = 0; i < oJournalEntries.Lines.Count; i++)
                        {
                            oJournalEntries.Lines.SetCurrentLine(i);
                            oJournalEntries.Lines.LineMemo = string.Format("Alterado Novo LCM Linha {0}", i);
                        }
                        if (oJournalEntries.Update() == 0)
                        {
                            MessageBox.Show(string.Format("LCM {0} Alterado com Sucesso!", docEntry), "LCM Alterado");
                        }
                        else
                        {
                            int temp_int;
                            string temp_string;
                            this.oCompany.GetLastError(out temp_int, out temp_string);
                            MessageBox.Show(string.Format("Erro Ao Alterar LCM: {0}, {1}", temp_int.ToString(), temp_string));
                        }
                    }
                }

                AppHelper.LimparObjeto(oJournalEntries);

            }
            else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED
                & pVal.ItemUID.Equals(this.oBtnNovoPN.Item.UniqueID)
                & pVal.BeforeAction)
            {
                BusinessPartners oBusinessPartner = (BusinessPartners)this.oCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners);
                
                oBusinessPartner.SalesPersonCode = 2;
                oBusinessPartner.CardName = "Nome";
                oBusinessPartner.CardForeignName = "Nome Fantasia";
                oBusinessPartner.CardType = SAPbobsCOM.BoCardTypes.cCustomer;
                oBusinessPartner.Series = 56;
                oBusinessPartner.EmailAddress = "email@email.com.br";
                oBusinessPartner.Phone1 = "123456789";
                oBusinessPartner.Phone2 = "41";
                oBusinessPartner.Fax = "91011121314";
                oBusinessPartner.Cellular = "15161718";
                oBusinessPartner.CompanyPrivate = BoCardCompanyTypes.cPrivate;
                oBusinessPartner.FreeText = "Observações";
                oBusinessPartner.Valid = BoYesNoEnum.tYES;



                if (oBusinessPartner.Addresses.Count == 0)
                {
                    oBusinessPartner.Addresses.Add();
                }
                oBusinessPartner.Addresses.SetCurrentLine(oBusinessPartner.Addresses.Count - 1);
                oBusinessPartner.Addresses.AddressType = BoAddressType.bo_BillTo;
                oBusinessPartner.Addresses.AddressName = "Cobrança";
                oBusinessPartner.Addresses.ZipCode = "82800-130";
                oBusinessPartner.Addresses.BuildingFloorRoom = "complemento";
                oBusinessPartner.Addresses.Street = "Rua";
                oBusinessPartner.Addresses.StreetNo = "s/n";
                oBusinessPartner.Addresses.TypeOfAddress = "Pau Brasil";
                oBusinessPartner.Addresses.Block = "Brasil";
                oBusinessPartner.Addresses.City = "Curitiba";
                oBusinessPartner.Addresses.State = "PR";
                oBusinessPartner.Addresses.County = "3283";

                oBusinessPartner.Addresses.Add();
                oBusinessPartner.Addresses.SetCurrentLine(oBusinessPartner.Addresses.Count - 1);
                oBusinessPartner.Addresses.AddressType = BoAddressType.bo_ShipTo;
                oBusinessPartner.Addresses.AddressName = "Entrega";
                oBusinessPartner.Addresses.ZipCode = "92800-130";
                oBusinessPartner.Addresses.BuildingFloorRoom = "complemento 1 ";
                oBusinessPartner.Addresses.Street = "Avenida";
                oBusinessPartner.Addresses.StreetNo = "1234";
                oBusinessPartner.Addresses.TypeOfAddress = "Pau Brasil";
                oBusinessPartner.Addresses.Block = "Brasil";
                oBusinessPartner.Addresses.City = "Curitiba";
                oBusinessPartner.Addresses.State = "PR";
                oBusinessPartner.Addresses.County = "3283";
                oBusinessPartner.Addresses.Add();

                if (oBusinessPartner.ContactEmployees.Count == 0)
                {
                    oBusinessPartner.ContactEmployees.Add();
                }
                oBusinessPartner.ContactEmployees.SetCurrentLine(oBusinessPartner.ContactEmployees.Count - 1);
                oBusinessPartner.ContactEmployees.Name = "Name";
                oBusinessPartner.ContactEmployees.FirstName = "FirstName";
                oBusinessPartner.ContactEmployees.DateOfBirth = DateTime.Now;
                oBusinessPartner.ContactEmployees.E_Mail = "E_Mail@E_Mail.com.br";
                oBusinessPartner.ContactEmployees.Gender = BoGenderTypes.gt_Male;

                oBusinessPartner.ContactEmployees.Position = "Position";
                oBusinessPartner.ContactEmployees.Profession = "Profession";
                oBusinessPartner.ContactEmployees.Title = "Title";
                oBusinessPartner.ContactEmployees.Phone1 = "1123654891";
                oBusinessPartner.ContactEmployees.Phone2 = "041";
                oBusinessPartner.ContactEmployees.MobilePhone = "556421589";

                oBusinessPartner.ContactEmployees.Add();
                oBusinessPartner.ContactEmployees.SetCurrentLine(oBusinessPartner.ContactEmployees.Count - 1);
                oBusinessPartner.ContactEmployees.Name = "Name1";
                oBusinessPartner.ContactEmployees.FirstName = "FirstName1";
                oBusinessPartner.ContactEmployees.DateOfBirth = DateTime.Now;
                oBusinessPartner.ContactEmployees.E_Mail = "E_Mail1@E_Mail.com.br";
                oBusinessPartner.ContactEmployees.Gender = BoGenderTypes.gt_Male;

                oBusinessPartner.ContactEmployees.Position = "Position1";
                oBusinessPartner.ContactEmployees.Profession = "Profession1";
                oBusinessPartner.ContactEmployees.Title = "Title1";
                oBusinessPartner.ContactEmployees.Phone1 = "1123654891";
                oBusinessPartner.ContactEmployees.Phone2 = "011";
                oBusinessPartner.ContactEmployees.MobilePhone = "556421589";

                if (oBusinessPartner.FiscalTaxID.Count == 0)
                {
                    oBusinessPartner.FiscalTaxID.Add();
                }

                oBusinessPartner.FiscalTaxID.SetCurrentLine(oBusinessPartner.FiscalTaxID.Count - 1);
                oBusinessPartner.FiscalTaxID.TaxId1 = "Isento";
                oBusinessPartner.FiscalTaxID.TaxId0 = "CNPJ";
                oBusinessPartner.FiscalTaxID.TaxId4 = "CPF";
                oBusinessPartner.FiscalTaxID.Add();

                oBusinessPartner.UserFields.Fields.Item("U_USERFIELD").Value = "valor qualquer";

                int lErrCode = oBusinessPartner.Add();
                if (lErrCode != 0)
                {
                    int temp_int;
                    string temp_string;
                    this.oCompany.GetLastError(out temp_int, out temp_string);                    
                    MessageBox.Show(string.Format("Erro Ao Gerar novo Cliente: {0}, {1}", temp_int.ToString(), temp_string));
                }
                else
                {
                    string docEntry;
                    docEntry = this.oCompany.GetNewObjectKey();
                    MessageBox.Show(string.Format("Cliente {0} Gerado com Sucesso!", docEntry), "Cliente Adcionado");
                    
                    
                    if (oBusinessPartner.GetByKey(docEntry))
                    {
                        oBusinessPartner.CardName = "Nome Alterado";
                        oBusinessPartner.CardForeignName = "Nome Fantasia Alterado";

                        oBusinessPartner.EmailAddress = "email Alterado@email.com.br";
                        oBusinessPartner.Phone1 = "987654321";
                        oBusinessPartner.Phone2 = "14";
                        oBusinessPartner.Fax = "0102030405";
                        oBusinessPartner.Cellular = "01020308";
                        oBusinessPartner.FreeText = "Observações  Alterado";

                        oBusinessPartner.CompanyPrivate = BoCardCompanyTypes.cCompany;

                        for (int i = 0; i < oBusinessPartner.Addresses.Count; i++)
                        {
                            oBusinessPartner.Addresses.SetCurrentLine(i);
                            oBusinessPartner.Addresses.BuildingFloorRoom = string.Format("{0} Alterado", oBusinessPartner.Addresses.BuildingFloorRoom);
                        }

                        for (int i = 0; i < oBusinessPartner.ContactEmployees.Count; i++)
                        {
                            oBusinessPartner.ContactEmployees.SetCurrentLine(i);
                            oBusinessPartner.ContactEmployees.E_Mail = "E_MailAlterado@E_Mail.com.br";
                        }

                        oBusinessPartner.UserFields.Fields.Item("U_USERFIELD").Value = "valor qualquer alterado";

                        if (oBusinessPartner.Update() == 0)
                        {
                            MessageBox.Show(string.Format("Cliente {0} Alterado com Sucesso!", docEntry), "Cliente Alterado");
                        }
                        else
                        {
                            int temp_int;
                            string temp_string;
                            this.oCompany.GetLastError(out temp_int, out temp_string);
                            MessageBox.Show(string.Format("Erro Ao Alterar Cliente: {0}, {1}", temp_int.ToString(), temp_string));
                        }


                    }


                }
                AppHelper.LimparObjeto(oBusinessPartner);

            }
            else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED
                & pVal.ItemUID.Equals(this.oBtnNovoItem.Item.UniqueID)
                & pVal.BeforeAction)
            {
                Items oItem = (Items)this.oCompany.GetBusinessObject(BoObjectTypes.oItems);
                oItem.ItemCode = "12345";
                oItem.ItemName = "Novo Item";
                oItem.ItemType = SAPbobsCOM.ItemTypeEnum.itItems;
                int lErrCode = oItem.Add();
                if (lErrCode != 0)
                {
                    int temp_int;
                    string temp_string;
                    this.oCompany.GetLastError(out temp_int, out temp_string);
                    MessageBox.Show(string.Format("Erro Ao Gerar novo Item: {0}, {1}", temp_int.ToString(), temp_string));
                }
                else
                {
                    string docEntry;
                    docEntry = this.oCompany.GetNewObjectKey();
                    MessageBox.Show(string.Format("Item {0} Gerado com Sucesso!", docEntry), "Item Adcionado");
                    if (oItem.GetByKey(docEntry))
                    {
                        oItem.ItemName = "Novo Item Alterado";
                        if (oItem.Update() == 0)
                        {
                            MessageBox.Show(string.Format("Item {0} Alterado com Sucesso!", docEntry), "Item Alterado");
                        }
                        else
                        {
                            int temp_int;
                            string temp_string;
                            this.oCompany.GetLastError(out temp_int, out temp_string);
                            MessageBox.Show(string.Format("Erro Ao Alterar Item: {0}, {1}", temp_int.ToString(), temp_string));
                        }
                    }


                }
                AppHelper.LimparObjeto(oItem);
            }
        }
    }
}
