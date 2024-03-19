using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gx0020 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0020( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("EstadoCuenta", true);
      }

      public gx0020( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_pART_ID_DOC )
      {
         this.AV13pART_ID_DOC = "" ;
         ExecutePrivate();
         aP0_pART_ID_DOC=this.AV13pART_ID_DOC;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pART_ID_DOC");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pART_ID_DOC");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pART_ID_DOC");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pART_ID_DOC = gxfirstwebparm;
               AssignAttri("", false, "AV13pART_ID_DOC", AV13pART_ID_DOC);
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cART_ID_DOC = GetPar( "cART_ID_DOC");
         AV7cACT_ID_CARD = GetPar( "cACT_ID_CARD");
         AV8cSECTOR_COLONIA = (short)(Math.Round(NumberUtil.Val( GetPar( "cSECTOR_COLONIA"), "."), 18, MidpointRounding.ToEven));
         AV9cNOMBRE_COLONIA = GetPar( "cNOMBRE_COLONIA");
         AV10cOBL_YEAR = (short)(Math.Round(NumberUtil.Val( GetPar( "cOBL_YEAR"), "."), 18, MidpointRounding.ToEven));
         AV11cDIAS = (int)(Math.Round(NumberUtil.Val( GetPar( "cDIAS"), "."), 18, MidpointRounding.ToEven));
         AV12cIMPUESTO = NumberUtil.Val( GetPar( "cIMPUESTO"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cART_ID_DOC, AV7cACT_ID_CARD, AV8cSECTOR_COLONIA, AV9cNOMBRE_COLONIA, AV10cOBL_YEAR, AV11cDIAS, AV12cIMPUESTO) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA042( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START042( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 13800), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 13800), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 13800), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0020.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pART_ID_DOC))}, new string[] {"pART_ID_DOC"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCART_ID_DOC", AV6cART_ID_DOC);
         GxWebStd.gx_hidden_field( context, "GXH_vCACT_ID_CARD", AV7cACT_ID_CARD);
         GxWebStd.gx_hidden_field( context, "GXH_vCSECTOR_COLONIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cSECTOR_COLONIA), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCNOMBRE_COLONIA", AV9cNOMBRE_COLONIA);
         GxWebStd.gx_hidden_field( context, "GXH_vCOBL_YEAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cOBL_YEAR), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCDIAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cDIAS), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCIMPUESTO", StringUtil.LTrim( StringUtil.NToC( AV12cIMPUESTO, 18, 2, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPART_ID_DOC", AV13pART_ID_DOC);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "ART_ID_DOCFILTERCONTAINER_Class", StringUtil.RTrim( divArt_id_docfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ACT_ID_CARDFILTERCONTAINER_Class", StringUtil.RTrim( divAct_id_cardfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SECTOR_COLONIAFILTERCONTAINER_Class", StringUtil.RTrim( divSector_coloniafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "NOMBRE_COLONIAFILTERCONTAINER_Class", StringUtil.RTrim( divNombre_coloniafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "OBL_YEARFILTERCONTAINER_Class", StringUtil.RTrim( divObl_yearfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DIASFILTERCONTAINER_Class", StringUtil.RTrim( divDiasfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "IMPUESTOFILTERCONTAINER_Class", StringUtil.RTrim( divImpuestofiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE042( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT042( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx0020.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pART_ID_DOC))}, new string[] {"pART_ID_DOC"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0020" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List MORA" ;
      }

      protected void WB040( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divArt_id_docfiltercontainer_Internalname, 1, 0, "px", 0, "px", divArt_id_docfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblart_id_docfilter_Internalname, "ART_ID_DOC", "", "", lblLblart_id_docfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCart_id_doc_Internalname, "ART_ID_DOC", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCart_id_doc_Internalname, AV6cART_ID_DOC, StringUtil.RTrim( context.localUtil.Format( AV6cART_ID_DOC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCart_id_doc_Jsonclick, 0, "Attribute", "", "", "", "", edtavCart_id_doc_Visible, edtavCart_id_doc_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAct_id_cardfiltercontainer_Internalname, 1, 0, "px", 0, "px", divAct_id_cardfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblact_id_cardfilter_Internalname, "ACT_ID_CARD", "", "", lblLblact_id_cardfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCact_id_card_Internalname, "ACT_ID_CARD", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCact_id_card_Internalname, AV7cACT_ID_CARD, StringUtil.RTrim( context.localUtil.Format( AV7cACT_ID_CARD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCact_id_card_Jsonclick, 0, "Attribute", "", "", "", "", edtavCact_id_card_Visible, edtavCact_id_card_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSector_coloniafiltercontainer_Internalname, 1, 0, "px", 0, "px", divSector_coloniafiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsector_coloniafilter_Internalname, "SECTOR_COLONIA", "", "", lblLblsector_coloniafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsector_colonia_Internalname, "SECTOR_COLONIA", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsector_colonia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cSECTOR_COLONIA), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCsector_colonia_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cSECTOR_COLONIA), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cSECTOR_COLONIA), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsector_colonia_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsector_colonia_Visible, edtavCsector_colonia_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNombre_coloniafiltercontainer_Internalname, 1, 0, "px", 0, "px", divNombre_coloniafiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblnombre_coloniafilter_Internalname, "NOMBRE_COLONIA", "", "", lblLblnombre_coloniafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCnombre_colonia_Internalname, "NOMBRE_COLONIA", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCnombre_colonia_Internalname, AV9cNOMBRE_COLONIA, StringUtil.RTrim( context.localUtil.Format( AV9cNOMBRE_COLONIA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCnombre_colonia_Jsonclick, 0, "Attribute", "", "", "", "", edtavCnombre_colonia_Visible, edtavCnombre_colonia_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divObl_yearfiltercontainer_Internalname, 1, 0, "px", 0, "px", divObl_yearfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblobl_yearfilter_Internalname, "OBL_YEAR", "", "", lblLblobl_yearfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCobl_year_Internalname, "OBL_YEAR", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCobl_year_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cOBL_YEAR), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCobl_year_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cOBL_YEAR), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cOBL_YEAR), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCobl_year_Jsonclick, 0, "Attribute", "", "", "", "", edtavCobl_year_Visible, edtavCobl_year_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiasfiltercontainer_Internalname, 1, 0, "px", 0, "px", divDiasfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldiasfilter_Internalname, "DIAS", "", "", lblLbldiasfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdias_Internalname, "DIAS", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdias_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cDIAS), 9, 0, ".", "")), StringUtil.LTrim( ((edtavCdias_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cDIAS), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV11cDIAS), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdias_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdias_Visible, edtavCdias_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImpuestofiltercontainer_Internalname, 1, 0, "px", 0, "px", divImpuestofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblimpuestofilter_Internalname, "IMPUESTO", "", "", lblLblimpuestofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17041_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCimpuesto_Internalname, "IMPUESTO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCimpuesto_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12cIMPUESTO, 18, 2, ".", "")), StringUtil.LTrim( ((edtavCimpuesto_Enabled!=0) ? context.localUtil.Format( AV12cIMPUESTO, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV12cIMPUESTO, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCimpuesto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCimpuesto_Visible, edtavCimpuesto_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18041_client"+"'", TempTags, "", 2, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START042( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_7-179127", 0) ;
            }
         }
         Form.Meta.addItem("description", "Selection List MORA", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP040( ) ;
      }

      protected void WS042( )
      {
         START042( ) ;
         EVT042( ) ;
      }

      protected void EVT042( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A2ART_ID_DOC = cgiGet( edtART_ID_DOC_Internalname);
                              A9ACT_ID_CARD = cgiGet( edtACT_ID_CARD_Internalname);
                              A11SECTOR_COLONIA = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSECTOR_COLONIA_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n11SECTOR_COLONIA = false;
                              A13OBL_YEAR = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtOBL_YEAR_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n13OBL_YEAR = false;
                              A14DIAS = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDIAS_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n14DIAS = false;
                              A19MoraId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMoraId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n19MoraId = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19042 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20042 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cart_id_doc Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCART_ID_DOC"), AV6cART_ID_DOC) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cact_id_card Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCACT_ID_CARD"), AV7cACT_ID_CARD) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csector_colonia Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTOR_COLONIA"), ".", ",") != Convert.ToDecimal( AV8cSECTOR_COLONIA )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cnombre_colonia Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCNOMBRE_COLONIA"), AV9cNOMBRE_COLONIA) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cobl_year Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOBL_YEAR"), ".", ",") != Convert.ToDecimal( AV10cOBL_YEAR )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdias Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDIAS"), ".", ",") != Convert.ToDecimal( AV11cDIAS )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cimpuesto Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCIMPUESTO"), ".", ",") != AV12cIMPUESTO )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21042 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE042( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA042( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        string AV6cART_ID_DOC ,
                                        string AV7cACT_ID_CARD ,
                                        short AV8cSECTOR_COLONIA ,
                                        string AV9cNOMBRE_COLONIA ,
                                        short AV10cOBL_YEAR ,
                                        int AV11cDIAS ,
                                        decimal AV12cIMPUESTO )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF042( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ART_ID_DOC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A2ART_ID_DOC, "")), context));
         GxWebStd.gx_hidden_field( context, "ART_ID_DOC", A2ART_ID_DOC);
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF042( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF042( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cACT_ID_CARD ,
                                                 AV8cSECTOR_COLONIA ,
                                                 AV9cNOMBRE_COLONIA ,
                                                 AV10cOBL_YEAR ,
                                                 AV11cDIAS ,
                                                 AV12cIMPUESTO ,
                                                 A9ACT_ID_CARD ,
                                                 A11SECTOR_COLONIA ,
                                                 A12NOMBRE_COLONIA ,
                                                 A13OBL_YEAR ,
                                                 A14DIAS ,
                                                 A15IMPUESTO ,
                                                 A2ART_ID_DOC ,
                                                 AV6cART_ID_DOC } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                                 }
            });
            lV6cART_ID_DOC = StringUtil.Concat( StringUtil.RTrim( AV6cART_ID_DOC), "%", "");
            lV7cACT_ID_CARD = StringUtil.Concat( StringUtil.RTrim( AV7cACT_ID_CARD), "%", "");
            lV9cNOMBRE_COLONIA = StringUtil.Concat( StringUtil.RTrim( AV9cNOMBRE_COLONIA), "%", "");
            /* Using cursor H00042 */
            pr_default.execute(0, new Object[] {lV6cART_ID_DOC, lV7cACT_ID_CARD, AV8cSECTOR_COLONIA, lV9cNOMBRE_COLONIA, AV10cOBL_YEAR, AV11cDIAS, AV12cIMPUESTO, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A15IMPUESTO = H00042_A15IMPUESTO[0];
               n15IMPUESTO = H00042_n15IMPUESTO[0];
               A12NOMBRE_COLONIA = H00042_A12NOMBRE_COLONIA[0];
               n12NOMBRE_COLONIA = H00042_n12NOMBRE_COLONIA[0];
               A19MoraId = H00042_A19MoraId[0];
               n19MoraId = H00042_n19MoraId[0];
               A14DIAS = H00042_A14DIAS[0];
               n14DIAS = H00042_n14DIAS[0];
               A13OBL_YEAR = H00042_A13OBL_YEAR[0];
               n13OBL_YEAR = H00042_n13OBL_YEAR[0];
               A11SECTOR_COLONIA = H00042_A11SECTOR_COLONIA[0];
               n11SECTOR_COLONIA = H00042_n11SECTOR_COLONIA[0];
               A9ACT_ID_CARD = H00042_A9ACT_ID_CARD[0];
               A2ART_ID_DOC = H00042_A2ART_ID_DOC[0];
               /* Execute user event: Load */
               E20042 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB040( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes042( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ART_ID_DOC"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A2ART_ID_DOC, "")), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cACT_ID_CARD ,
                                              AV8cSECTOR_COLONIA ,
                                              AV9cNOMBRE_COLONIA ,
                                              AV10cOBL_YEAR ,
                                              AV11cDIAS ,
                                              AV12cIMPUESTO ,
                                              A9ACT_ID_CARD ,
                                              A11SECTOR_COLONIA ,
                                              A12NOMBRE_COLONIA ,
                                              A13OBL_YEAR ,
                                              A14DIAS ,
                                              A15IMPUESTO ,
                                              A2ART_ID_DOC ,
                                              AV6cART_ID_DOC } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV6cART_ID_DOC = StringUtil.Concat( StringUtil.RTrim( AV6cART_ID_DOC), "%", "");
         lV7cACT_ID_CARD = StringUtil.Concat( StringUtil.RTrim( AV7cACT_ID_CARD), "%", "");
         lV9cNOMBRE_COLONIA = StringUtil.Concat( StringUtil.RTrim( AV9cNOMBRE_COLONIA), "%", "");
         /* Using cursor H00043 */
         pr_default.execute(1, new Object[] {lV6cART_ID_DOC, lV7cACT_ID_CARD, AV8cSECTOR_COLONIA, lV9cNOMBRE_COLONIA, AV10cOBL_YEAR, AV11cDIAS, AV12cIMPUESTO});
         GRID1_nRecordCount = H00043_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cART_ID_DOC, AV7cACT_ID_CARD, AV8cSECTOR_COLONIA, AV9cNOMBRE_COLONIA, AV10cOBL_YEAR, AV11cDIAS, AV12cIMPUESTO) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cART_ID_DOC, AV7cACT_ID_CARD, AV8cSECTOR_COLONIA, AV9cNOMBRE_COLONIA, AV10cOBL_YEAR, AV11cDIAS, AV12cIMPUESTO) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cART_ID_DOC, AV7cACT_ID_CARD, AV8cSECTOR_COLONIA, AV9cNOMBRE_COLONIA, AV10cOBL_YEAR, AV11cDIAS, AV12cIMPUESTO) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cART_ID_DOC, AV7cACT_ID_CARD, AV8cSECTOR_COLONIA, AV9cNOMBRE_COLONIA, AV10cOBL_YEAR, AV11cDIAS, AV12cIMPUESTO) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cART_ID_DOC, AV7cACT_ID_CARD, AV8cSECTOR_COLONIA, AV9cNOMBRE_COLONIA, AV10cOBL_YEAR, AV11cDIAS, AV12cIMPUESTO) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtART_ID_DOC_Enabled = 0;
         AssignProp("", false, edtART_ID_DOC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtART_ID_DOC_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtACT_ID_CARD_Enabled = 0;
         AssignProp("", false, edtACT_ID_CARD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACT_ID_CARD_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtSECTOR_COLONIA_Enabled = 0;
         AssignProp("", false, edtSECTOR_COLONIA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSECTOR_COLONIA_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtOBL_YEAR_Enabled = 0;
         AssignProp("", false, edtOBL_YEAR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOBL_YEAR_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtDIAS_Enabled = 0;
         AssignProp("", false, edtDIAS_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDIAS_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtMoraId_Enabled = 0;
         AssignProp("", false, edtMoraId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMoraId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP040( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19042 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV6cART_ID_DOC = cgiGet( edtavCart_id_doc_Internalname);
            AssignAttri("", false, "AV6cART_ID_DOC", AV6cART_ID_DOC);
            AV7cACT_ID_CARD = cgiGet( edtavCact_id_card_Internalname);
            AssignAttri("", false, "AV7cACT_ID_CARD", AV7cACT_ID_CARD);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsector_colonia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsector_colonia_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSECTOR_COLONIA");
               GX_FocusControl = edtavCsector_colonia_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cSECTOR_COLONIA = 0;
               AssignAttri("", false, "AV8cSECTOR_COLONIA", StringUtil.LTrimStr( (decimal)(AV8cSECTOR_COLONIA), 4, 0));
            }
            else
            {
               AV8cSECTOR_COLONIA = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsector_colonia_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cSECTOR_COLONIA", StringUtil.LTrimStr( (decimal)(AV8cSECTOR_COLONIA), 4, 0));
            }
            AV9cNOMBRE_COLONIA = cgiGet( edtavCnombre_colonia_Internalname);
            AssignAttri("", false, "AV9cNOMBRE_COLONIA", AV9cNOMBRE_COLONIA);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCobl_year_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCobl_year_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOBL_YEAR");
               GX_FocusControl = edtavCobl_year_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cOBL_YEAR = 0;
               AssignAttri("", false, "AV10cOBL_YEAR", StringUtil.LTrimStr( (decimal)(AV10cOBL_YEAR), 4, 0));
            }
            else
            {
               AV10cOBL_YEAR = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCobl_year_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cOBL_YEAR", StringUtil.LTrimStr( (decimal)(AV10cOBL_YEAR), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdias_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdias_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDIAS");
               GX_FocusControl = edtavCdias_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cDIAS = 0;
               AssignAttri("", false, "AV11cDIAS", StringUtil.LTrimStr( (decimal)(AV11cDIAS), 9, 0));
            }
            else
            {
               AV11cDIAS = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCdias_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cDIAS", StringUtil.LTrimStr( (decimal)(AV11cDIAS), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCimpuesto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCimpuesto_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIMPUESTO");
               GX_FocusControl = edtavCimpuesto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cIMPUESTO = 0;
               AssignAttri("", false, "AV12cIMPUESTO", StringUtil.LTrimStr( AV12cIMPUESTO, 18, 2));
            }
            else
            {
               AV12cIMPUESTO = context.localUtil.CToN( cgiGet( edtavCimpuesto_Internalname), ".", ",");
               AssignAttri("", false, "AV12cIMPUESTO", StringUtil.LTrimStr( AV12cIMPUESTO, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCART_ID_DOC"), AV6cART_ID_DOC) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCACT_ID_CARD"), AV7cACT_ID_CARD) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTOR_COLONIA"), ".", ",") != Convert.ToDecimal( AV8cSECTOR_COLONIA )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCNOMBRE_COLONIA"), AV9cNOMBRE_COLONIA) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOBL_YEAR"), ".", ",") != Convert.ToDecimal( AV10cOBL_YEAR )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDIAS"), ".", ",") != Convert.ToDecimal( AV11cDIAS )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCIMPUESTO"), ".", ",") != AV12cIMPUESTO )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E19042 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19042( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "MORA", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20042( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21042 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21042( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pART_ID_DOC = A2ART_ID_DOC;
         AssignAttri("", false, "AV13pART_ID_DOC", AV13pART_ID_DOC);
         context.setWebReturnParms(new Object[] {(string)AV13pART_ID_DOC});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pART_ID_DOC"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pART_ID_DOC = (string)getParm(obj,0);
         AssignAttri("", false, "AV13pART_ID_DOC", AV13pART_ID_DOC);
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA042( ) ;
         WS042( ) ;
         WE042( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243410223829", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 13800), false, true);
         context.AddJavascriptSource("gx0020.js", "?20243410223829", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtART_ID_DOC_Internalname = "ART_ID_DOC_"+sGXsfl_84_idx;
         edtACT_ID_CARD_Internalname = "ACT_ID_CARD_"+sGXsfl_84_idx;
         edtSECTOR_COLONIA_Internalname = "SECTOR_COLONIA_"+sGXsfl_84_idx;
         edtOBL_YEAR_Internalname = "OBL_YEAR_"+sGXsfl_84_idx;
         edtDIAS_Internalname = "DIAS_"+sGXsfl_84_idx;
         edtMoraId_Internalname = "MORAID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtART_ID_DOC_Internalname = "ART_ID_DOC_"+sGXsfl_84_fel_idx;
         edtACT_ID_CARD_Internalname = "ACT_ID_CARD_"+sGXsfl_84_fel_idx;
         edtSECTOR_COLONIA_Internalname = "SECTOR_COLONIA_"+sGXsfl_84_fel_idx;
         edtOBL_YEAR_Internalname = "OBL_YEAR_"+sGXsfl_84_fel_idx;
         edtDIAS_Internalname = "DIAS_"+sGXsfl_84_fel_idx;
         edtMoraId_Internalname = "MORAID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB040( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A2ART_ID_DOC)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtART_ID_DOC_Internalname,(string)A2ART_ID_DOC,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtART_ID_DOC_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtACT_ID_CARD_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A2ART_ID_DOC)+"'"+"]);";
            AssignProp("", false, edtACT_ID_CARD_Internalname, "Link", edtACT_ID_CARD_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtACT_ID_CARD_Internalname,(string)A9ACT_ID_CARD,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtACT_ID_CARD_Link,(string)"",(string)"",(string)"",(string)edtACT_ID_CARD_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSECTOR_COLONIA_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SECTOR_COLONIA), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A11SECTOR_COLONIA), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSECTOR_COLONIA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOBL_YEAR_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13OBL_YEAR), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13OBL_YEAR), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOBL_YEAR_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDIAS_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14DIAS), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14DIAS), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDIAS_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMoraId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MoraId), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19MoraId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMoraId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes042( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "ART_ID_DOC") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "ACT_ID_CARD") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "SECTOR_COLONIA") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "OBL_YEAR") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "DIAS") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Mora Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A2ART_ID_DOC));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A9ACT_ID_CARD));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtACT_ID_CARD_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SECTOR_COLONIA), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A13OBL_YEAR), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A14DIAS), 9, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MoraId), 9, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblart_id_docfilter_Internalname = "LBLART_ID_DOCFILTER";
         edtavCart_id_doc_Internalname = "vCART_ID_DOC";
         divArt_id_docfiltercontainer_Internalname = "ART_ID_DOCFILTERCONTAINER";
         lblLblact_id_cardfilter_Internalname = "LBLACT_ID_CARDFILTER";
         edtavCact_id_card_Internalname = "vCACT_ID_CARD";
         divAct_id_cardfiltercontainer_Internalname = "ACT_ID_CARDFILTERCONTAINER";
         lblLblsector_coloniafilter_Internalname = "LBLSECTOR_COLONIAFILTER";
         edtavCsector_colonia_Internalname = "vCSECTOR_COLONIA";
         divSector_coloniafiltercontainer_Internalname = "SECTOR_COLONIAFILTERCONTAINER";
         lblLblnombre_coloniafilter_Internalname = "LBLNOMBRE_COLONIAFILTER";
         edtavCnombre_colonia_Internalname = "vCNOMBRE_COLONIA";
         divNombre_coloniafiltercontainer_Internalname = "NOMBRE_COLONIAFILTERCONTAINER";
         lblLblobl_yearfilter_Internalname = "LBLOBL_YEARFILTER";
         edtavCobl_year_Internalname = "vCOBL_YEAR";
         divObl_yearfiltercontainer_Internalname = "OBL_YEARFILTERCONTAINER";
         lblLbldiasfilter_Internalname = "LBLDIASFILTER";
         edtavCdias_Internalname = "vCDIAS";
         divDiasfiltercontainer_Internalname = "DIASFILTERCONTAINER";
         lblLblimpuestofilter_Internalname = "LBLIMPUESTOFILTER";
         edtavCimpuesto_Internalname = "vCIMPUESTO";
         divImpuestofiltercontainer_Internalname = "IMPUESTOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtART_ID_DOC_Internalname = "ART_ID_DOC";
         edtACT_ID_CARD_Internalname = "ACT_ID_CARD";
         edtSECTOR_COLONIA_Internalname = "SECTOR_COLONIA";
         edtOBL_YEAR_Internalname = "OBL_YEAR";
         edtDIAS_Internalname = "DIAS";
         edtMoraId_Internalname = "MORAID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("EstadoCuenta", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtMoraId_Jsonclick = "";
         edtDIAS_Jsonclick = "";
         edtOBL_YEAR_Jsonclick = "";
         edtSECTOR_COLONIA_Jsonclick = "";
         edtACT_ID_CARD_Jsonclick = "";
         edtACT_ID_CARD_Link = "";
         edtART_ID_DOC_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtMoraId_Enabled = 0;
         edtDIAS_Enabled = 0;
         edtOBL_YEAR_Enabled = 0;
         edtSECTOR_COLONIA_Enabled = 0;
         edtACT_ID_CARD_Enabled = 0;
         edtART_ID_DOC_Enabled = 0;
         edtavCimpuesto_Jsonclick = "";
         edtavCimpuesto_Enabled = 1;
         edtavCimpuesto_Visible = 1;
         edtavCdias_Jsonclick = "";
         edtavCdias_Enabled = 1;
         edtavCdias_Visible = 1;
         edtavCobl_year_Jsonclick = "";
         edtavCobl_year_Enabled = 1;
         edtavCobl_year_Visible = 1;
         edtavCnombre_colonia_Jsonclick = "";
         edtavCnombre_colonia_Enabled = 1;
         edtavCnombre_colonia_Visible = 1;
         edtavCsector_colonia_Jsonclick = "";
         edtavCsector_colonia_Enabled = 1;
         edtavCsector_colonia_Visible = 1;
         edtavCact_id_card_Jsonclick = "";
         edtavCact_id_card_Enabled = 1;
         edtavCact_id_card_Visible = 1;
         edtavCart_id_doc_Jsonclick = "";
         edtavCart_id_doc_Enabled = 1;
         edtavCart_id_doc_Visible = 1;
         divImpuestofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDiasfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divObl_yearfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divNombre_coloniafiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSector_coloniafiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divAct_id_cardfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divArt_id_docfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List MORA";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cART_ID_DOC',fld:'vCART_ID_DOC',pic:''},{av:'AV7cACT_ID_CARD',fld:'vCACT_ID_CARD',pic:''},{av:'AV8cSECTOR_COLONIA',fld:'vCSECTOR_COLONIA',pic:'ZZZ9'},{av:'AV9cNOMBRE_COLONIA',fld:'vCNOMBRE_COLONIA',pic:''},{av:'AV10cOBL_YEAR',fld:'vCOBL_YEAR',pic:'ZZZ9'},{av:'AV11cDIAS',fld:'vCDIAS',pic:'ZZZZZZZZ9'},{av:'AV12cIMPUESTO',fld:'vCIMPUESTO',pic:'ZZZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18041',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLART_ID_DOCFILTER.CLICK","{handler:'E11041',iparms:[{av:'divArt_id_docfiltercontainer_Class',ctrl:'ART_ID_DOCFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLART_ID_DOCFILTER.CLICK",",oparms:[{av:'divArt_id_docfiltercontainer_Class',ctrl:'ART_ID_DOCFILTERCONTAINER',prop:'Class'},{av:'edtavCart_id_doc_Visible',ctrl:'vCART_ID_DOC',prop:'Visible'}]}");
         setEventMetadata("LBLACT_ID_CARDFILTER.CLICK","{handler:'E12041',iparms:[{av:'divAct_id_cardfiltercontainer_Class',ctrl:'ACT_ID_CARDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLACT_ID_CARDFILTER.CLICK",",oparms:[{av:'divAct_id_cardfiltercontainer_Class',ctrl:'ACT_ID_CARDFILTERCONTAINER',prop:'Class'},{av:'edtavCact_id_card_Visible',ctrl:'vCACT_ID_CARD',prop:'Visible'}]}");
         setEventMetadata("LBLSECTOR_COLONIAFILTER.CLICK","{handler:'E13041',iparms:[{av:'divSector_coloniafiltercontainer_Class',ctrl:'SECTOR_COLONIAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSECTOR_COLONIAFILTER.CLICK",",oparms:[{av:'divSector_coloniafiltercontainer_Class',ctrl:'SECTOR_COLONIAFILTERCONTAINER',prop:'Class'},{av:'edtavCsector_colonia_Visible',ctrl:'vCSECTOR_COLONIA',prop:'Visible'}]}");
         setEventMetadata("LBLNOMBRE_COLONIAFILTER.CLICK","{handler:'E14041',iparms:[{av:'divNombre_coloniafiltercontainer_Class',ctrl:'NOMBRE_COLONIAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLNOMBRE_COLONIAFILTER.CLICK",",oparms:[{av:'divNombre_coloniafiltercontainer_Class',ctrl:'NOMBRE_COLONIAFILTERCONTAINER',prop:'Class'},{av:'edtavCnombre_colonia_Visible',ctrl:'vCNOMBRE_COLONIA',prop:'Visible'}]}");
         setEventMetadata("LBLOBL_YEARFILTER.CLICK","{handler:'E15041',iparms:[{av:'divObl_yearfiltercontainer_Class',ctrl:'OBL_YEARFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLOBL_YEARFILTER.CLICK",",oparms:[{av:'divObl_yearfiltercontainer_Class',ctrl:'OBL_YEARFILTERCONTAINER',prop:'Class'},{av:'edtavCobl_year_Visible',ctrl:'vCOBL_YEAR',prop:'Visible'}]}");
         setEventMetadata("LBLDIASFILTER.CLICK","{handler:'E16041',iparms:[{av:'divDiasfiltercontainer_Class',ctrl:'DIASFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDIASFILTER.CLICK",",oparms:[{av:'divDiasfiltercontainer_Class',ctrl:'DIASFILTERCONTAINER',prop:'Class'},{av:'edtavCdias_Visible',ctrl:'vCDIAS',prop:'Visible'}]}");
         setEventMetadata("LBLIMPUESTOFILTER.CLICK","{handler:'E17041',iparms:[{av:'divImpuestofiltercontainer_Class',ctrl:'IMPUESTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIMPUESTOFILTER.CLICK",",oparms:[{av:'divImpuestofiltercontainer_Class',ctrl:'IMPUESTOFILTERCONTAINER',prop:'Class'},{av:'edtavCimpuesto_Visible',ctrl:'vCIMPUESTO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21042',iparms:[{av:'A2ART_ID_DOC',fld:'ART_ID_DOC',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pART_ID_DOC',fld:'vPART_ID_DOC',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cART_ID_DOC',fld:'vCART_ID_DOC',pic:''},{av:'AV7cACT_ID_CARD',fld:'vCACT_ID_CARD',pic:''},{av:'AV8cSECTOR_COLONIA',fld:'vCSECTOR_COLONIA',pic:'ZZZ9'},{av:'AV9cNOMBRE_COLONIA',fld:'vCNOMBRE_COLONIA',pic:''},{av:'AV10cOBL_YEAR',fld:'vCOBL_YEAR',pic:'ZZZ9'},{av:'AV11cDIAS',fld:'vCDIAS',pic:'ZZZZZZZZ9'},{av:'AV12cIMPUESTO',fld:'vCIMPUESTO',pic:'ZZZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cART_ID_DOC',fld:'vCART_ID_DOC',pic:''},{av:'AV7cACT_ID_CARD',fld:'vCACT_ID_CARD',pic:''},{av:'AV8cSECTOR_COLONIA',fld:'vCSECTOR_COLONIA',pic:'ZZZ9'},{av:'AV9cNOMBRE_COLONIA',fld:'vCNOMBRE_COLONIA',pic:''},{av:'AV10cOBL_YEAR',fld:'vCOBL_YEAR',pic:'ZZZ9'},{av:'AV11cDIAS',fld:'vCDIAS',pic:'ZZZZZZZZ9'},{av:'AV12cIMPUESTO',fld:'vCIMPUESTO',pic:'ZZZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cART_ID_DOC',fld:'vCART_ID_DOC',pic:''},{av:'AV7cACT_ID_CARD',fld:'vCACT_ID_CARD',pic:''},{av:'AV8cSECTOR_COLONIA',fld:'vCSECTOR_COLONIA',pic:'ZZZ9'},{av:'AV9cNOMBRE_COLONIA',fld:'vCNOMBRE_COLONIA',pic:''},{av:'AV10cOBL_YEAR',fld:'vCOBL_YEAR',pic:'ZZZ9'},{av:'AV11cDIAS',fld:'vCDIAS',pic:'ZZZZZZZZ9'},{av:'AV12cIMPUESTO',fld:'vCIMPUESTO',pic:'ZZZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cART_ID_DOC',fld:'vCART_ID_DOC',pic:''},{av:'AV7cACT_ID_CARD',fld:'vCACT_ID_CARD',pic:''},{av:'AV8cSECTOR_COLONIA',fld:'vCSECTOR_COLONIA',pic:'ZZZ9'},{av:'AV9cNOMBRE_COLONIA',fld:'vCNOMBRE_COLONIA',pic:''},{av:'AV10cOBL_YEAR',fld:'vCOBL_YEAR',pic:'ZZZ9'},{av:'AV11cDIAS',fld:'vCDIAS',pic:'ZZZZZZZZ9'},{av:'AV12cIMPUESTO',fld:'vCIMPUESTO',pic:'ZZZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Moraid',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         AV13pART_ID_DOC = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cART_ID_DOC = "";
         AV7cACT_ID_CARD = "";
         AV9cNOMBRE_COLONIA = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblart_id_docfilter_Jsonclick = "";
         TempTags = "";
         lblLblact_id_cardfilter_Jsonclick = "";
         lblLblsector_coloniafilter_Jsonclick = "";
         lblLblnombre_coloniafilter_Jsonclick = "";
         lblLblobl_yearfilter_Jsonclick = "";
         lblLbldiasfilter_Jsonclick = "";
         lblLblimpuestofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV15Linkselection_GXI = "";
         A2ART_ID_DOC = "";
         A9ACT_ID_CARD = "";
         lV6cART_ID_DOC = "";
         lV7cACT_ID_CARD = "";
         lV9cNOMBRE_COLONIA = "";
         A12NOMBRE_COLONIA = "";
         H00042_A15IMPUESTO = new decimal[1] ;
         H00042_n15IMPUESTO = new bool[] {false} ;
         H00042_A12NOMBRE_COLONIA = new string[] {""} ;
         H00042_n12NOMBRE_COLONIA = new bool[] {false} ;
         H00042_A19MoraId = new int[1] ;
         H00042_n19MoraId = new bool[] {false} ;
         H00042_A14DIAS = new int[1] ;
         H00042_n14DIAS = new bool[] {false} ;
         H00042_A13OBL_YEAR = new short[1] ;
         H00042_n13OBL_YEAR = new bool[] {false} ;
         H00042_A11SECTOR_COLONIA = new short[1] ;
         H00042_n11SECTOR_COLONIA = new bool[] {false} ;
         H00042_A9ACT_ID_CARD = new string[] {""} ;
         H00042_A2ART_ID_DOC = new string[] {""} ;
         H00043_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0020__default(),
            new Object[][] {
                new Object[] {
               H00042_A15IMPUESTO, H00042_n15IMPUESTO, H00042_A12NOMBRE_COLONIA, H00042_n12NOMBRE_COLONIA, H00042_A19MoraId, H00042_n19MoraId, H00042_A14DIAS, H00042_n14DIAS, H00042_A13OBL_YEAR, H00042_n13OBL_YEAR,
               H00042_A11SECTOR_COLONIA, H00042_n11SECTOR_COLONIA, H00042_A9ACT_ID_CARD, H00042_A2ART_ID_DOC
               }
               , new Object[] {
               H00043_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV8cSECTOR_COLONIA ;
      private short AV10cOBL_YEAR ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A11SECTOR_COLONIA ;
      private short A13OBL_YEAR ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int AV11cDIAS ;
      private int edtavCart_id_doc_Visible ;
      private int edtavCart_id_doc_Enabled ;
      private int edtavCact_id_card_Visible ;
      private int edtavCact_id_card_Enabled ;
      private int edtavCsector_colonia_Enabled ;
      private int edtavCsector_colonia_Visible ;
      private int edtavCnombre_colonia_Visible ;
      private int edtavCnombre_colonia_Enabled ;
      private int edtavCobl_year_Enabled ;
      private int edtavCobl_year_Visible ;
      private int edtavCdias_Enabled ;
      private int edtavCdias_Visible ;
      private int edtavCimpuesto_Enabled ;
      private int edtavCimpuesto_Visible ;
      private int A14DIAS ;
      private int A19MoraId ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtART_ID_DOC_Enabled ;
      private int edtACT_ID_CARD_Enabled ;
      private int edtSECTOR_COLONIA_Enabled ;
      private int edtOBL_YEAR_Enabled ;
      private int edtDIAS_Enabled ;
      private int edtMoraId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV12cIMPUESTO ;
      private decimal A15IMPUESTO ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divArt_id_docfiltercontainer_Class ;
      private string divAct_id_cardfiltercontainer_Class ;
      private string divSector_coloniafiltercontainer_Class ;
      private string divNombre_coloniafiltercontainer_Class ;
      private string divObl_yearfiltercontainer_Class ;
      private string divDiasfiltercontainer_Class ;
      private string divImpuestofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divArt_id_docfiltercontainer_Internalname ;
      private string lblLblart_id_docfilter_Internalname ;
      private string lblLblart_id_docfilter_Jsonclick ;
      private string edtavCart_id_doc_Internalname ;
      private string TempTags ;
      private string edtavCart_id_doc_Jsonclick ;
      private string divAct_id_cardfiltercontainer_Internalname ;
      private string lblLblact_id_cardfilter_Internalname ;
      private string lblLblact_id_cardfilter_Jsonclick ;
      private string edtavCact_id_card_Internalname ;
      private string edtavCact_id_card_Jsonclick ;
      private string divSector_coloniafiltercontainer_Internalname ;
      private string lblLblsector_coloniafilter_Internalname ;
      private string lblLblsector_coloniafilter_Jsonclick ;
      private string edtavCsector_colonia_Internalname ;
      private string edtavCsector_colonia_Jsonclick ;
      private string divNombre_coloniafiltercontainer_Internalname ;
      private string lblLblnombre_coloniafilter_Internalname ;
      private string lblLblnombre_coloniafilter_Jsonclick ;
      private string edtavCnombre_colonia_Internalname ;
      private string edtavCnombre_colonia_Jsonclick ;
      private string divObl_yearfiltercontainer_Internalname ;
      private string lblLblobl_yearfilter_Internalname ;
      private string lblLblobl_yearfilter_Jsonclick ;
      private string edtavCobl_year_Internalname ;
      private string edtavCobl_year_Jsonclick ;
      private string divDiasfiltercontainer_Internalname ;
      private string lblLbldiasfilter_Internalname ;
      private string lblLbldiasfilter_Jsonclick ;
      private string edtavCdias_Internalname ;
      private string edtavCdias_Jsonclick ;
      private string divImpuestofiltercontainer_Internalname ;
      private string lblLblimpuestofilter_Internalname ;
      private string lblLblimpuestofilter_Jsonclick ;
      private string edtavCimpuesto_Internalname ;
      private string edtavCimpuesto_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtART_ID_DOC_Internalname ;
      private string edtACT_ID_CARD_Internalname ;
      private string edtSECTOR_COLONIA_Internalname ;
      private string edtOBL_YEAR_Internalname ;
      private string edtDIAS_Internalname ;
      private string edtMoraId_Internalname ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtART_ID_DOC_Jsonclick ;
      private string edtACT_ID_CARD_Link ;
      private string edtACT_ID_CARD_Jsonclick ;
      private string edtSECTOR_COLONIA_Jsonclick ;
      private string edtOBL_YEAR_Jsonclick ;
      private string edtDIAS_Jsonclick ;
      private string edtMoraId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n11SECTOR_COLONIA ;
      private bool n13OBL_YEAR ;
      private bool n14DIAS ;
      private bool n19MoraId ;
      private bool gxdyncontrolsrefreshing ;
      private bool n15IMPUESTO ;
      private bool n12NOMBRE_COLONIA ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV13pART_ID_DOC ;
      private string AV6cART_ID_DOC ;
      private string AV7cACT_ID_CARD ;
      private string AV9cNOMBRE_COLONIA ;
      private string AV15Linkselection_GXI ;
      private string A2ART_ID_DOC ;
      private string A9ACT_ID_CARD ;
      private string lV6cART_ID_DOC ;
      private string lV7cACT_ID_CARD ;
      private string lV9cNOMBRE_COLONIA ;
      private string A12NOMBRE_COLONIA ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00042_A15IMPUESTO ;
      private bool[] H00042_n15IMPUESTO ;
      private string[] H00042_A12NOMBRE_COLONIA ;
      private bool[] H00042_n12NOMBRE_COLONIA ;
      private int[] H00042_A19MoraId ;
      private bool[] H00042_n19MoraId ;
      private int[] H00042_A14DIAS ;
      private bool[] H00042_n14DIAS ;
      private short[] H00042_A13OBL_YEAR ;
      private bool[] H00042_n13OBL_YEAR ;
      private short[] H00042_A11SECTOR_COLONIA ;
      private bool[] H00042_n11SECTOR_COLONIA ;
      private string[] H00042_A9ACT_ID_CARD ;
      private string[] H00042_A2ART_ID_DOC ;
      private long[] H00043_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_pART_ID_DOC ;
      private GXWebForm Form ;
   }

   public class gx0020__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00042( IGxContext context ,
                                             string AV7cACT_ID_CARD ,
                                             short AV8cSECTOR_COLONIA ,
                                             string AV9cNOMBRE_COLONIA ,
                                             short AV10cOBL_YEAR ,
                                             int AV11cDIAS ,
                                             decimal AV12cIMPUESTO ,
                                             string A9ACT_ID_CARD ,
                                             short A11SECTOR_COLONIA ,
                                             string A12NOMBRE_COLONIA ,
                                             short A13OBL_YEAR ,
                                             int A14DIAS ,
                                             decimal A15IMPUESTO ,
                                             string A2ART_ID_DOC ,
                                             string AV6cART_ID_DOC )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [IMPUESTO], [NOMBRE_COLONIA], [MoraId], [DIAS], [OBL_YEAR], [SECTOR_COLONIA], [ACT_ID_CARD], [ART_ID_DOC]";
         sFromString = " FROM dbo.[MORA]";
         sOrderString = "";
         AddWhere(sWhereString, "([ART_ID_DOC] like @lV6cART_ID_DOC)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cACT_ID_CARD)) )
         {
            AddWhere(sWhereString, "([ACT_ID_CARD] like @lV7cACT_ID_CARD)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cSECTOR_COLONIA) )
         {
            AddWhere(sWhereString, "([SECTOR_COLONIA] >= @AV8cSECTOR_COLONIA)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cNOMBRE_COLONIA)) )
         {
            AddWhere(sWhereString, "([NOMBRE_COLONIA] like @lV9cNOMBRE_COLONIA)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cOBL_YEAR) )
         {
            AddWhere(sWhereString, "([OBL_YEAR] >= @AV10cOBL_YEAR)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cDIAS) )
         {
            AddWhere(sWhereString, "([DIAS] >= @AV11cDIAS)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12cIMPUESTO) )
         {
            AddWhere(sWhereString, "([IMPUESTO] >= @AV12cIMPUESTO)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [ART_ID_DOC]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00043( IGxContext context ,
                                             string AV7cACT_ID_CARD ,
                                             short AV8cSECTOR_COLONIA ,
                                             string AV9cNOMBRE_COLONIA ,
                                             short AV10cOBL_YEAR ,
                                             int AV11cDIAS ,
                                             decimal AV12cIMPUESTO ,
                                             string A9ACT_ID_CARD ,
                                             short A11SECTOR_COLONIA ,
                                             string A12NOMBRE_COLONIA ,
                                             short A13OBL_YEAR ,
                                             int A14DIAS ,
                                             decimal A15IMPUESTO ,
                                             string A2ART_ID_DOC ,
                                             string AV6cART_ID_DOC )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM dbo.[MORA]";
         AddWhere(sWhereString, "([ART_ID_DOC] like @lV6cART_ID_DOC)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cACT_ID_CARD)) )
         {
            AddWhere(sWhereString, "([ACT_ID_CARD] like @lV7cACT_ID_CARD)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cSECTOR_COLONIA) )
         {
            AddWhere(sWhereString, "([SECTOR_COLONIA] >= @AV8cSECTOR_COLONIA)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cNOMBRE_COLONIA)) )
         {
            AddWhere(sWhereString, "([NOMBRE_COLONIA] like @lV9cNOMBRE_COLONIA)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cOBL_YEAR) )
         {
            AddWhere(sWhereString, "([OBL_YEAR] >= @AV10cOBL_YEAR)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cDIAS) )
         {
            AddWhere(sWhereString, "([DIAS] >= @AV11cDIAS)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12cIMPUESTO) )
         {
            AddWhere(sWhereString, "([IMPUESTO] >= @AV12cIMPUESTO)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00042(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (int)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_H00043(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (int)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00042;
          prmH00042 = new Object[] {
          new ParDef("@lV6cART_ID_DOC",GXType.NVarChar,40,0) ,
          new ParDef("@lV7cACT_ID_CARD",GXType.NVarChar,40,0) ,
          new ParDef("@AV8cSECTOR_COLONIA",GXType.Int16,4,0) ,
          new ParDef("@lV9cNOMBRE_COLONIA",GXType.NVarChar,60,0) ,
          new ParDef("@AV10cOBL_YEAR",GXType.Int16,4,0) ,
          new ParDef("@AV11cDIAS",GXType.Int32,9,0) ,
          new ParDef("@AV12cIMPUESTO",GXType.Decimal,18,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00043;
          prmH00043 = new Object[] {
          new ParDef("@lV6cART_ID_DOC",GXType.NVarChar,40,0) ,
          new ParDef("@lV7cACT_ID_CARD",GXType.NVarChar,40,0) ,
          new ParDef("@AV8cSECTOR_COLONIA",GXType.Int16,4,0) ,
          new ParDef("@lV9cNOMBRE_COLONIA",GXType.NVarChar,60,0) ,
          new ParDef("@AV10cOBL_YEAR",GXType.Int16,4,0) ,
          new ParDef("@AV11cDIAS",GXType.Int32,9,0) ,
          new ParDef("@AV12cIMPUESTO",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00042", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00042,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00043", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00043,1, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
