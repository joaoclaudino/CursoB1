//  SAP MANAGE UI API 2007 SDK Sample
//****************************************************************************
//
//  File:      AddingMenuItems.cs
//
//  Copyright (c) SAP MANAGE
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
//****************************************************************************
// BEFORE STARTING:
// 1. Add reference to the "SAP Business One UI API"
// 2. Insert the development connection string to the "Command line argument"
//-----------------------------------------------------------------
// 1.
//    a. Project->Add Reference...
//    b. select the "SAP Business One UI API 2007" From the COM folder
//
// 2.
//     a. Project->Properties...
//     b. choose Configuration Properties folder (place the arrow on Debugging)
//     c. place the following connection string in the 'Command line arguments' field
// 0030002C0030002C00530041005000420044005F00440061007400650076002C0050004C006F006D0056004900490056
//
//**************************************************************************************************


using System;
using System.Windows.Forms;
class UseMatrix  { 
    
    //**********************************************************
    // This parameter will use us to manipulate the
    // SAP Business One Application
    //**********************************************************
    
    private SAPbouiCOM.Application SBO_Application; 
    private SAPbouiCOM.Form oForm; 
    
    private SAPbouiCOM.Matrix oMatrix; 
    private SAPbouiCOM.Columns oColumns; 
    private SAPbouiCOM.Column oColumn; 
    
    // declareing a DB data source for all the Data binded columns
    
    private SAPbouiCOM.DBDataSource oDBDataSource; 
    
    // declaring a User data source for the "Remarks" Column
    private SAPbouiCOM.UserDataSource oUserDataSource; 
    
    // *****************************************************************
    //  This Function is called automatically when an instance
    //  of the class is created.
    //  Indise this function
    // *****************************************************************
    public UseMatrix() { 
        
        
        //*************************************************************
        // set SBO_Application with an initialized application object
        //*************************************************************
        
        SetApplication(); 
        
        // Create the UI 
        CreateFormWithMatrix(); 
        
        // Add Data Sources to the Form
        AddDataSourceToForm(); 
        
        // Bind the Form's items with the desired data source
        BindDataToForm(); 
        
        // Load date to matrix
        GetDataFromDataSource(); 
        
        // Make the form visible
        oForm.Visible = true; 
        
        // events handled by SBO_Application_AppEvent
        SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler( SBO_Application_AppEvent ); 
        // events handled by SBO_Application_ItemEvent
        SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler( SBO_Application_ItemEvent ); 
    } 
    
    
    private void SetApplication() { 
        
        // *******************************************************************
        // Use an SboGuiApi object to establish connection
        // with the SAP Business One application and return an
        // initialized appliction object
        // *******************************************************************
        
        SAPbouiCOM.SboGuiApi SboGuiApi = null; 
        string sConnectionString = null; 
        
        SboGuiApi = new SAPbouiCOM.SboGuiApi(); 
        
        // by following the steps specified above, the following
        // statment should be suficient for either development or run mode
        
        sConnectionString = System.Convert.ToString( Environment.GetCommandLineArgs().GetValue( 1 ) ); 
        
        // connect to a running SBO Application
        
        try { 
            //  If there's no active application the connection will fail
			SboGuiApi.Connect( sConnectionString ); 
        } 
        catch  { //  Connection failed
            System.Windows.Forms.MessageBox.Show( "No SAP Business One Application was found" ); 
            System.Environment.Exit( 0 ); 
        } 
        // get an initialized application object
        
        SBO_Application = SboGuiApi.GetApplication( 0); 
        // SBO_Application.MessageBox("Hello World")
        
    } 
    
    private void SBO_Application_AppEvent( SAPbouiCOM.BoAppEventTypes EventType ) { 
        
        switch ( EventType ) {
            case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                
                SBO_Application.MessageBox( "A Shut Down Event has been caught" + Environment.NewLine + "Terminating 'Add Menu Item' Add On...", 1, "Ok", "", "" ); 
                // terminating the Add On
                System.Windows.Forms.Application.Exit(); 
                break;
        }
        
    } 
    
    
    private void CreateFormWithMatrix() { 
        //*******************************************************
        // Don't Forget:
        // it is much more efficient to load a form from xml.
        // use code only to create your form.
        // once you have created it save it as XML.
        // see "WorkingWithXML" sample project
        //*******************************************************
        
        // we will use the following object to add items to our form
        SAPbouiCOM.Item oItem = null; 
        
        // *******************************************
        // we will use the following objects to set
        // the specific values of every item
        // we add.
        // this is the best way to do so
        //*********************************************
        
        SAPbouiCOM.Button oButton = null; 
        SAPbouiCOM.StaticText oStaticText = null; 
        SAPbouiCOM.EditText oEditText = null; 
        
        // The following object is needed to create our form
		SAPbouiCOM.FormCreationParams creationPackage;
        //object creationPackage = null;
		object tmp = null;
		SAPbouiCOM.FormCreationParams oCreationParams = null; 

		tmp = SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams );
		
		creationPackage = ( ( SAPbouiCOM.FormCreationParams )( SBO_Application.CreateObject( SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams ) ) ); 
	
		creationPackage.UniqueID = "UidFrmMatrix"; 
		creationPackage.FormType = "TypeFrmMatrix"; 
    
		// Add our form to the SBO application
		oForm = SBO_Application.Forms.AddEx( ( ( SAPbouiCOM.FormCreationParams )( creationPackage ) ) ); 
    
		// Set the form properties
		oForm.Title = "Matrix, Datasources and Linked Button"; 
		oForm.Left = 336; 
		oForm.ClientWidth = 520; 
		oForm.Top = 44; 
		oForm.ClientHeight = 200; 
    
		//*****************************************
		// Adding Items to the form
		// and setting their properties
		//*****************************************
    
		// /**********************
		// Adding an Ok button
		//*********************
    
		// We get automatic event handling for
		// the Ok and Cancel Buttons by setting
		// their UIDs to 1 and 2 respectively
    
		oItem = oForm.Items.Add( "1", SAPbouiCOM.BoFormItemTypes.it_BUTTON ); 
		oItem.Left = 5; 
		oItem.Width = 65; 
		oItem.Top = 170; 
		oItem.Height = 19; 
    
		oButton = ( ( SAPbouiCOM.Button )( oItem.Specific ) ); 
    
		oButton.Caption = "Ok"; 
    
		//************************
		// Adding a Cancel button
		//***********************
    
		oItem = oForm.Items.Add( "2", SAPbouiCOM.BoFormItemTypes.it_BUTTON ); 
		oItem.Left = 75; 
		oItem.Width = 65; 
		oItem.Top = 170; 
		oItem.Height = 19; 
    
		oButton = ( ( SAPbouiCOM.Button )( oItem.Specific ) ); 
    
		oButton.Caption = "Cancel"; 
    
    
		//*************************
		// Adding a Text Edit item
		//*************************
    
		oItem = oForm.Items.Add( "txtPhone", SAPbouiCOM.BoFormItemTypes.it_EDIT ); 
		oItem.Left = 265; 
		oItem.Width = 163; 
		oItem.Top = 172; 
		oItem.Height = 14; 
    
		//******************************************
		// Adding an Add Phone prefix column button
		//******************************************
		oItem = oForm.Items.Add( "BtnPhone", SAPbouiCOM.BoFormItemTypes.it_BUTTON ); 
		oItem.Left = 160; 
		oItem.Width = 100; 
		oItem.Top = 170; 
		oItem.Height = 19; 
    
		oButton = ( ( SAPbouiCOM.Button )( oItem.Specific ) ); 
    
		oButton.Caption = "Add Phone prefix"; 
    
		// Add the matrix to the form
		AddMatrixToForm(); 
        
	} 
    
    private void AddMatrixToForm() { 
        
        // we will use the following object to add items to our form
        SAPbouiCOM.Item oItem = null; 
        
        // we will use the following object to set a linked button
        SAPbouiCOM.LinkedButton oLink = null; 
        
        //***************************
        // Adding a Matrix item
        //***************************
        
        oItem = oForm.Items.Add( "Matrix1", SAPbouiCOM.BoFormItemTypes.it_MATRIX ); 
        oItem.Left = 5; 
        oItem.Width = 500; 
        oItem.Top = 5; 
        oItem.Height = 150; 
        
        oMatrix = ( ( SAPbouiCOM.Matrix )( oItem.Specific ) ); 
        oColumns = oMatrix.Columns; 
        
        //***********************************
        // Adding Culomn items to the matrix
        //***********************************
        
        oColumn = oColumns.Add( "#", SAPbouiCOM.BoFormItemTypes.it_EDIT ); 
        oColumn.TitleObject.Caption = "#"; 
        oColumn.Width = 30; 
        oColumn.Editable = false; 
        
        // Add a column for BP Card Code
        oColumn = oColumns.Add( "DSCardCode", SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON ); 
        oColumn.TitleObject.Caption = "Card Code"; 
        oColumn.Width = 40; 
        oColumn.Editable = true; 
        
        // Link the column to the BP master data system form
        oLink = ( ( SAPbouiCOM.LinkedButton )( oColumn.ExtendedObject ) ); 
        oLink.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_BusinessPartner; 
        
        // Add a column for BP Card Name
        oColumn = oColumns.Add( "DSCardName", SAPbouiCOM.BoFormItemTypes.it_EDIT ); 
        oColumn.TitleObject.Caption = "Name"; 
        oColumn.Width = 40; 
        oColumn.Editable = true; 
        
        // Add a column for BP Card Phone
        oColumn = oColumns.Add( "DSPhone", SAPbouiCOM.BoFormItemTypes.it_EDIT ); 
        oColumn.TitleObject.Caption = "Phone"; 
        oColumn.Width = 40; 
        oColumn.Editable = true; 
        
        // Add a column for BP Card Phone
        oColumn = oColumns.Add( "DSPhoneInt", SAPbouiCOM.BoFormItemTypes.it_EDIT ); 
        oColumn.TitleObject.Caption = "Int. Phone"; 
        oColumn.Width = 40; 
        oColumn.Editable = true; 
    } 
    
    
    public void AddDataSourceToForm() { 
        
        //****************************************************************
        // every item must be binded to a Data Source
        // prior of binding the data we must add Data sources to the form
        //****************************************************************
        
        // Add user data sources to the "International Phone" column in the matrix
        oUserDataSource = oForm.DataSources.UserDataSources.Add( "IntPhone", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 20 ); 
        
        // Add DB data sources for the DB bound columns in the matrix
        oDBDataSource = oForm.DataSources.DBDataSources.Add( "OCRD" ); 
    } 
    
    
    public void BindDataToForm() { 
        
        // getting the matrix column by the UID
        
        oColumn = oColumns.Item( "DSCardCode" ); 
        // oColumn.DataBind.SetBound(True, "", "DSCardCode")
        oColumn.DataBind.SetBound( true, "OCRD", "CardCode" ); 
        
        oColumn = oColumns.Item( "DSCardName" ); 
        oColumn.DataBind.SetBound( true, "OCRD", "CardName" ); 
        
        oColumn = oColumns.Item( "DSPhone" ); 
        oColumn.DataBind.SetBound( true, "OCRD", "Phone1" ); 
        
        //************************************************
        // to Data Bind an item with a user Data source
        // the table name value should be an empty string
        //************************************************
        
        oColumn = oColumns.Item( "DSPhoneInt" ); 
        oColumn.DataBind.SetBound( true, "", "IntPhone" ); 
        
    } 
    
    public void GetDataFromDataSource() { 
        
        // Ready Matrix to populate data
        oMatrix.Clear(); 
        oMatrix.AutoResizeColumns(); 
        
        // Querying the DB Data source
        oDBDataSource.Query( null ); 
        
        // setting the user data source data
        oUserDataSource.Value = "Phone with prefix"; 
        oMatrix.LoadFromDataSource(); 
        
    } 
    
    
    private void SBO_Application_ItemEvent( string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent ) { 
        BubbleEvent = true;
        if ( ( pVal.FormUID == "UidFrmMatrix" ) ) { 
            
            if ( ( ( pVal.ItemUID == "BtnPhone" ) & ( pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED ) & ( pVal.Before_Action == false ) ) ) { 
                AddPrefix(); 
            } 
            
            if ( ( ( pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD ) & ( pVal.Before_Action == false ) ) ) { 
                SBO_Application.MessageBox( "Form Unloaded, Addon will terminate", 1, "Ok", "", "" ); 
                System.Windows.Forms.Application.Exit(); 
            } 
        } 
    } 
    
    
    public void AddPrefix() { 
        int i = 0; 
        SAPbouiCOM.Column PhoneExtCol = null; 
        string newPhone = null; 
        SAPbouiCOM.Item oItem = null; 
        SAPbouiCOM.EditText oEditTxt = null; 
        
        // Get the prefix edit text item
        oItem = oForm.Items.Item( "txtPhone" ); 
        oEditTxt = ( ( SAPbouiCOM.EditText )( oItem.Specific ) ); 
        
        // Flush user input into datasources
        oMatrix.FlushToDataSource(); 
        
        // Get the DBdatasource we base the matrix on
        oDBDataSource = oForm.DataSources.DBDataSources.Item( "OCRD" ); 
        
        // Iterate all the records and add a prefix to the phone
        for ( i=0; i<=oDBDataSource.Size - 1; i++ ) { 
            newPhone = oDBDataSource.GetValue( "phone1", i ); 
            newPhone = newPhone.Trim( char.Parse( " " ) ); 
            oDBDataSource.SetValue( "phone1", i, oEditTxt.String + newPhone ); 
        } 
        
        // Load data back to 
        oMatrix.LoadFromDataSource();    
    }   
} 

    
