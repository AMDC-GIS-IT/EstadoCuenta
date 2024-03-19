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
   public class mora : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_7-179127", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "MORA", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtART_ID_DOC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("AriesCustom", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public mora( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public mora( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("k2bt_masterpage", "GeneXus.Programs.k2bt_masterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "MORA", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ART_ID_DOC"+"'), id:'"+"ART_ID_DOC"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtART_ID_DOC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtART_ID_DOC_Internalname, context.GetMessage( "ART_ID_DOC", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtART_ID_DOC_Internalname, A2ART_ID_DOC, StringUtil.RTrim( context.localUtil.Format( A2ART_ID_DOC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtART_ID_DOC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtART_ID_DOC_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtACT_ID_CARD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACT_ID_CARD_Internalname, context.GetMessage( "ACT_ID_CARD", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACT_ID_CARD_Internalname, A9ACT_ID_CARD, StringUtil.RTrim( context.localUtil.Format( A9ACT_ID_CARD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACT_ID_CARD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACT_ID_CARD_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNOMBRE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNOMBRE_Internalname, context.GetMessage( "NOMBRE", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNOMBRE_Internalname, A10NOMBRE, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtNOMBRE_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "323", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSECTOR_COLONIA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSECTOR_COLONIA_Internalname, context.GetMessage( "SECTOR_COLONIA", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSECTOR_COLONIA_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SECTOR_COLONIA), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSECTOR_COLONIA_Enabled!=0) ? context.localUtil.Format( (decimal)(A11SECTOR_COLONIA), "ZZZ9") : context.localUtil.Format( (decimal)(A11SECTOR_COLONIA), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSECTOR_COLONIA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSECTOR_COLONIA_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNOMBRE_COLONIA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNOMBRE_COLONIA_Internalname, context.GetMessage( "NOMBRE_COLONIA", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNOMBRE_COLONIA_Internalname, A12NOMBRE_COLONIA, StringUtil.RTrim( context.localUtil.Format( A12NOMBRE_COLONIA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNOMBRE_COLONIA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNOMBRE_COLONIA_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOBL_YEAR_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOBL_YEAR_Internalname, context.GetMessage( "OBL_YEAR", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOBL_YEAR_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13OBL_YEAR), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtOBL_YEAR_Enabled!=0) ? context.localUtil.Format( (decimal)(A13OBL_YEAR), "ZZZ9") : context.localUtil.Format( (decimal)(A13OBL_YEAR), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOBL_YEAR_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOBL_YEAR_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDIAS_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDIAS_Internalname, context.GetMessage( "DIAS", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDIAS_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14DIAS), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDIAS_Enabled!=0) ? context.localUtil.Format( (decimal)(A14DIAS), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A14DIAS), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDIAS_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDIAS_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIMPUESTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIMPUESTO_Internalname, context.GetMessage( "IMPUESTO", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIMPUESTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A15IMPUESTO, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtIMPUESTO_Enabled!=0) ? context.localUtil.Format( A15IMPUESTO, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A15IMPUESTO, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIMPUESTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIMPUESTO_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTREN_DE_ASEO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTREN_DE_ASEO_Internalname, context.GetMessage( "TREN_DE_ASEO", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTREN_DE_ASEO_Internalname, StringUtil.LTrim( StringUtil.NToC( A16TREN_DE_ASEO, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTREN_DE_ASEO_Enabled!=0) ? context.localUtil.Format( A16TREN_DE_ASEO, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A16TREN_DE_ASEO, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTREN_DE_ASEO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTREN_DE_ASEO_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTASA_BOMBEROS_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTASA_BOMBEROS_Internalname, context.GetMessage( "TASA_BOMBEROS", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTASA_BOMBEROS_Internalname, StringUtil.LTrim( StringUtil.NToC( A17TASA_BOMBEROS, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTASA_BOMBEROS_Enabled!=0) ? context.localUtil.Format( A17TASA_BOMBEROS, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A17TASA_BOMBEROS, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTASA_BOMBEROS_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTASA_BOMBEROS_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtINTERES_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINTERES_Internalname, context.GetMessage( "INTERES", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINTERES_Internalname, StringUtil.LTrim( StringUtil.NToC( A18INTERES, 18, 6, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtINTERES_Enabled!=0) ? context.localUtil.Format( A18INTERES, "ZZZZZZZZZZ9.999999") : context.localUtil.Format( A18INTERES, "ZZZZZZZZZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'6');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINTERES_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINTERES_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMoraId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMoraId_Internalname, context.GetMessage( "Mora Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMoraId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MoraId), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMoraId_Enabled!=0) ? context.localUtil.Format( (decimal)(A19MoraId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A19MoraId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMoraId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMoraId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_MORA.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z2ART_ID_DOC = cgiGet( "Z2ART_ID_DOC");
            Z9ACT_ID_CARD = cgiGet( "Z9ACT_ID_CARD");
            Z10NOMBRE = cgiGet( "Z10NOMBRE");
            Z11SECTOR_COLONIA = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z11SECTOR_COLONIA"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n11SECTOR_COLONIA = ((0==A11SECTOR_COLONIA) ? true : false);
            Z12NOMBRE_COLONIA = cgiGet( "Z12NOMBRE_COLONIA");
            n12NOMBRE_COLONIA = (String.IsNullOrEmpty(StringUtil.RTrim( A12NOMBRE_COLONIA)) ? true : false);
            Z13OBL_YEAR = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z13OBL_YEAR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n13OBL_YEAR = ((0==A13OBL_YEAR) ? true : false);
            Z14DIAS = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z14DIAS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n14DIAS = ((0==A14DIAS) ? true : false);
            Z15IMPUESTO = context.localUtil.CToN( cgiGet( "Z15IMPUESTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n15IMPUESTO = ((Convert.ToDecimal(0)==A15IMPUESTO) ? true : false);
            Z16TREN_DE_ASEO = context.localUtil.CToN( cgiGet( "Z16TREN_DE_ASEO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n16TREN_DE_ASEO = ((Convert.ToDecimal(0)==A16TREN_DE_ASEO) ? true : false);
            Z17TASA_BOMBEROS = context.localUtil.CToN( cgiGet( "Z17TASA_BOMBEROS"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n17TASA_BOMBEROS = ((Convert.ToDecimal(0)==A17TASA_BOMBEROS) ? true : false);
            Z18INTERES = context.localUtil.CToN( cgiGet( "Z18INTERES"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n18INTERES = ((Convert.ToDecimal(0)==A18INTERES) ? true : false);
            Z19MoraId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z19MoraId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n19MoraId = ((0==A19MoraId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2ART_ID_DOC = cgiGet( edtART_ID_DOC_Internalname);
            AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
            A9ACT_ID_CARD = cgiGet( edtACT_ID_CARD_Internalname);
            AssignAttri("", false, "A9ACT_ID_CARD", A9ACT_ID_CARD);
            A10NOMBRE = cgiGet( edtNOMBRE_Internalname);
            AssignAttri("", false, "A10NOMBRE", A10NOMBRE);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSECTOR_COLONIA_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSECTOR_COLONIA_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECTOR_COLONIA");
               AnyError = 1;
               GX_FocusControl = edtSECTOR_COLONIA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A11SECTOR_COLONIA = 0;
               n11SECTOR_COLONIA = false;
               AssignAttri("", false, "A11SECTOR_COLONIA", StringUtil.LTrimStr( (decimal)(A11SECTOR_COLONIA), 4, 0));
            }
            else
            {
               A11SECTOR_COLONIA = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSECTOR_COLONIA_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n11SECTOR_COLONIA = false;
               AssignAttri("", false, "A11SECTOR_COLONIA", StringUtil.LTrimStr( (decimal)(A11SECTOR_COLONIA), 4, 0));
            }
            n11SECTOR_COLONIA = ((0==A11SECTOR_COLONIA) ? true : false);
            A12NOMBRE_COLONIA = cgiGet( edtNOMBRE_COLONIA_Internalname);
            n12NOMBRE_COLONIA = false;
            AssignAttri("", false, "A12NOMBRE_COLONIA", A12NOMBRE_COLONIA);
            n12NOMBRE_COLONIA = (String.IsNullOrEmpty(StringUtil.RTrim( A12NOMBRE_COLONIA)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOBL_YEAR_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOBL_YEAR_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OBL_YEAR");
               AnyError = 1;
               GX_FocusControl = edtOBL_YEAR_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A13OBL_YEAR = 0;
               n13OBL_YEAR = false;
               AssignAttri("", false, "A13OBL_YEAR", StringUtil.LTrimStr( (decimal)(A13OBL_YEAR), 4, 0));
            }
            else
            {
               A13OBL_YEAR = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtOBL_YEAR_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n13OBL_YEAR = false;
               AssignAttri("", false, "A13OBL_YEAR", StringUtil.LTrimStr( (decimal)(A13OBL_YEAR), 4, 0));
            }
            n13OBL_YEAR = ((0==A13OBL_YEAR) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDIAS_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDIAS_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DIAS");
               AnyError = 1;
               GX_FocusControl = edtDIAS_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A14DIAS = 0;
               n14DIAS = false;
               AssignAttri("", false, "A14DIAS", StringUtil.LTrimStr( (decimal)(A14DIAS), 9, 0));
            }
            else
            {
               A14DIAS = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDIAS_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n14DIAS = false;
               AssignAttri("", false, "A14DIAS", StringUtil.LTrimStr( (decimal)(A14DIAS), 9, 0));
            }
            n14DIAS = ((0==A14DIAS) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtIMPUESTO_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIMPUESTO_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPUESTO");
               AnyError = 1;
               GX_FocusControl = edtIMPUESTO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A15IMPUESTO = 0;
               n15IMPUESTO = false;
               AssignAttri("", false, "A15IMPUESTO", StringUtil.LTrimStr( A15IMPUESTO, 18, 2));
            }
            else
            {
               A15IMPUESTO = context.localUtil.CToN( cgiGet( edtIMPUESTO_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n15IMPUESTO = false;
               AssignAttri("", false, "A15IMPUESTO", StringUtil.LTrimStr( A15IMPUESTO, 18, 2));
            }
            n15IMPUESTO = ((Convert.ToDecimal(0)==A15IMPUESTO) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTREN_DE_ASEO_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTREN_DE_ASEO_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TREN_DE_ASEO");
               AnyError = 1;
               GX_FocusControl = edtTREN_DE_ASEO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A16TREN_DE_ASEO = 0;
               n16TREN_DE_ASEO = false;
               AssignAttri("", false, "A16TREN_DE_ASEO", StringUtil.LTrimStr( A16TREN_DE_ASEO, 18, 2));
            }
            else
            {
               A16TREN_DE_ASEO = context.localUtil.CToN( cgiGet( edtTREN_DE_ASEO_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n16TREN_DE_ASEO = false;
               AssignAttri("", false, "A16TREN_DE_ASEO", StringUtil.LTrimStr( A16TREN_DE_ASEO, 18, 2));
            }
            n16TREN_DE_ASEO = ((Convert.ToDecimal(0)==A16TREN_DE_ASEO) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTASA_BOMBEROS_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTASA_BOMBEROS_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TASA_BOMBEROS");
               AnyError = 1;
               GX_FocusControl = edtTASA_BOMBEROS_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A17TASA_BOMBEROS = 0;
               n17TASA_BOMBEROS = false;
               AssignAttri("", false, "A17TASA_BOMBEROS", StringUtil.LTrimStr( A17TASA_BOMBEROS, 18, 2));
            }
            else
            {
               A17TASA_BOMBEROS = context.localUtil.CToN( cgiGet( edtTASA_BOMBEROS_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n17TASA_BOMBEROS = false;
               AssignAttri("", false, "A17TASA_BOMBEROS", StringUtil.LTrimStr( A17TASA_BOMBEROS, 18, 2));
            }
            n17TASA_BOMBEROS = ((Convert.ToDecimal(0)==A17TASA_BOMBEROS) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtINTERES_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtINTERES_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INTERES");
               AnyError = 1;
               GX_FocusControl = edtINTERES_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A18INTERES = 0;
               n18INTERES = false;
               AssignAttri("", false, "A18INTERES", StringUtil.LTrimStr( A18INTERES, 18, 6));
            }
            else
            {
               A18INTERES = context.localUtil.CToN( cgiGet( edtINTERES_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n18INTERES = false;
               AssignAttri("", false, "A18INTERES", StringUtil.LTrimStr( A18INTERES, 18, 6));
            }
            n18INTERES = ((Convert.ToDecimal(0)==A18INTERES) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMoraId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMoraId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MORAID");
               AnyError = 1;
               GX_FocusControl = edtMoraId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A19MoraId = 0;
               n19MoraId = false;
               AssignAttri("", false, "A19MoraId", StringUtil.LTrimStr( (decimal)(A19MoraId), 9, 0));
            }
            else
            {
               A19MoraId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMoraId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n19MoraId = false;
               AssignAttri("", false, "A19MoraId", StringUtil.LTrimStr( (decimal)(A19MoraId), 9, 0));
            }
            n19MoraId = ((0==A19MoraId) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A2ART_ID_DOC = GetPar( "ART_ID_DOC");
               AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll024( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes024( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void ZM024( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z9ACT_ID_CARD = T00023_A9ACT_ID_CARD[0];
               Z10NOMBRE = T00023_A10NOMBRE[0];
               Z11SECTOR_COLONIA = T00023_A11SECTOR_COLONIA[0];
               Z12NOMBRE_COLONIA = T00023_A12NOMBRE_COLONIA[0];
               Z13OBL_YEAR = T00023_A13OBL_YEAR[0];
               Z14DIAS = T00023_A14DIAS[0];
               Z15IMPUESTO = T00023_A15IMPUESTO[0];
               Z16TREN_DE_ASEO = T00023_A16TREN_DE_ASEO[0];
               Z17TASA_BOMBEROS = T00023_A17TASA_BOMBEROS[0];
               Z18INTERES = T00023_A18INTERES[0];
               Z19MoraId = T00023_A19MoraId[0];
            }
            else
            {
               Z9ACT_ID_CARD = A9ACT_ID_CARD;
               Z10NOMBRE = A10NOMBRE;
               Z11SECTOR_COLONIA = A11SECTOR_COLONIA;
               Z12NOMBRE_COLONIA = A12NOMBRE_COLONIA;
               Z13OBL_YEAR = A13OBL_YEAR;
               Z14DIAS = A14DIAS;
               Z15IMPUESTO = A15IMPUESTO;
               Z16TREN_DE_ASEO = A16TREN_DE_ASEO;
               Z17TASA_BOMBEROS = A17TASA_BOMBEROS;
               Z18INTERES = A18INTERES;
               Z19MoraId = A19MoraId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2ART_ID_DOC = A2ART_ID_DOC;
            Z9ACT_ID_CARD = A9ACT_ID_CARD;
            Z10NOMBRE = A10NOMBRE;
            Z11SECTOR_COLONIA = A11SECTOR_COLONIA;
            Z12NOMBRE_COLONIA = A12NOMBRE_COLONIA;
            Z13OBL_YEAR = A13OBL_YEAR;
            Z14DIAS = A14DIAS;
            Z15IMPUESTO = A15IMPUESTO;
            Z16TREN_DE_ASEO = A16TREN_DE_ASEO;
            Z17TASA_BOMBEROS = A17TASA_BOMBEROS;
            Z18INTERES = A18INTERES;
            Z19MoraId = A19MoraId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load024( )
      {
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A2ART_ID_DOC});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound4 = 1;
            A9ACT_ID_CARD = T00024_A9ACT_ID_CARD[0];
            AssignAttri("", false, "A9ACT_ID_CARD", A9ACT_ID_CARD);
            A10NOMBRE = T00024_A10NOMBRE[0];
            AssignAttri("", false, "A10NOMBRE", A10NOMBRE);
            A11SECTOR_COLONIA = T00024_A11SECTOR_COLONIA[0];
            n11SECTOR_COLONIA = T00024_n11SECTOR_COLONIA[0];
            AssignAttri("", false, "A11SECTOR_COLONIA", StringUtil.LTrimStr( (decimal)(A11SECTOR_COLONIA), 4, 0));
            A12NOMBRE_COLONIA = T00024_A12NOMBRE_COLONIA[0];
            n12NOMBRE_COLONIA = T00024_n12NOMBRE_COLONIA[0];
            AssignAttri("", false, "A12NOMBRE_COLONIA", A12NOMBRE_COLONIA);
            A13OBL_YEAR = T00024_A13OBL_YEAR[0];
            n13OBL_YEAR = T00024_n13OBL_YEAR[0];
            AssignAttri("", false, "A13OBL_YEAR", StringUtil.LTrimStr( (decimal)(A13OBL_YEAR), 4, 0));
            A14DIAS = T00024_A14DIAS[0];
            n14DIAS = T00024_n14DIAS[0];
            AssignAttri("", false, "A14DIAS", StringUtil.LTrimStr( (decimal)(A14DIAS), 9, 0));
            A15IMPUESTO = T00024_A15IMPUESTO[0];
            n15IMPUESTO = T00024_n15IMPUESTO[0];
            AssignAttri("", false, "A15IMPUESTO", StringUtil.LTrimStr( A15IMPUESTO, 18, 2));
            A16TREN_DE_ASEO = T00024_A16TREN_DE_ASEO[0];
            n16TREN_DE_ASEO = T00024_n16TREN_DE_ASEO[0];
            AssignAttri("", false, "A16TREN_DE_ASEO", StringUtil.LTrimStr( A16TREN_DE_ASEO, 18, 2));
            A17TASA_BOMBEROS = T00024_A17TASA_BOMBEROS[0];
            n17TASA_BOMBEROS = T00024_n17TASA_BOMBEROS[0];
            AssignAttri("", false, "A17TASA_BOMBEROS", StringUtil.LTrimStr( A17TASA_BOMBEROS, 18, 2));
            A18INTERES = T00024_A18INTERES[0];
            n18INTERES = T00024_n18INTERES[0];
            AssignAttri("", false, "A18INTERES", StringUtil.LTrimStr( A18INTERES, 18, 6));
            A19MoraId = T00024_A19MoraId[0];
            n19MoraId = T00024_n19MoraId[0];
            AssignAttri("", false, "A19MoraId", StringUtil.LTrimStr( (decimal)(A19MoraId), 9, 0));
            ZM024( -1) ;
         }
         pr_default.close(2);
         OnLoadActions024( ) ;
      }

      protected void OnLoadActions024( )
      {
      }

      protected void CheckExtendedTable024( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors024( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey024( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A2ART_ID_DOC});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A2ART_ID_DOC});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM024( 1) ;
            RcdFound4 = 1;
            A2ART_ID_DOC = T00023_A2ART_ID_DOC[0];
            AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
            A9ACT_ID_CARD = T00023_A9ACT_ID_CARD[0];
            AssignAttri("", false, "A9ACT_ID_CARD", A9ACT_ID_CARD);
            A10NOMBRE = T00023_A10NOMBRE[0];
            AssignAttri("", false, "A10NOMBRE", A10NOMBRE);
            A11SECTOR_COLONIA = T00023_A11SECTOR_COLONIA[0];
            n11SECTOR_COLONIA = T00023_n11SECTOR_COLONIA[0];
            AssignAttri("", false, "A11SECTOR_COLONIA", StringUtil.LTrimStr( (decimal)(A11SECTOR_COLONIA), 4, 0));
            A12NOMBRE_COLONIA = T00023_A12NOMBRE_COLONIA[0];
            n12NOMBRE_COLONIA = T00023_n12NOMBRE_COLONIA[0];
            AssignAttri("", false, "A12NOMBRE_COLONIA", A12NOMBRE_COLONIA);
            A13OBL_YEAR = T00023_A13OBL_YEAR[0];
            n13OBL_YEAR = T00023_n13OBL_YEAR[0];
            AssignAttri("", false, "A13OBL_YEAR", StringUtil.LTrimStr( (decimal)(A13OBL_YEAR), 4, 0));
            A14DIAS = T00023_A14DIAS[0];
            n14DIAS = T00023_n14DIAS[0];
            AssignAttri("", false, "A14DIAS", StringUtil.LTrimStr( (decimal)(A14DIAS), 9, 0));
            A15IMPUESTO = T00023_A15IMPUESTO[0];
            n15IMPUESTO = T00023_n15IMPUESTO[0];
            AssignAttri("", false, "A15IMPUESTO", StringUtil.LTrimStr( A15IMPUESTO, 18, 2));
            A16TREN_DE_ASEO = T00023_A16TREN_DE_ASEO[0];
            n16TREN_DE_ASEO = T00023_n16TREN_DE_ASEO[0];
            AssignAttri("", false, "A16TREN_DE_ASEO", StringUtil.LTrimStr( A16TREN_DE_ASEO, 18, 2));
            A17TASA_BOMBEROS = T00023_A17TASA_BOMBEROS[0];
            n17TASA_BOMBEROS = T00023_n17TASA_BOMBEROS[0];
            AssignAttri("", false, "A17TASA_BOMBEROS", StringUtil.LTrimStr( A17TASA_BOMBEROS, 18, 2));
            A18INTERES = T00023_A18INTERES[0];
            n18INTERES = T00023_n18INTERES[0];
            AssignAttri("", false, "A18INTERES", StringUtil.LTrimStr( A18INTERES, 18, 6));
            A19MoraId = T00023_A19MoraId[0];
            n19MoraId = T00023_n19MoraId[0];
            AssignAttri("", false, "A19MoraId", StringUtil.LTrimStr( (decimal)(A19MoraId), 9, 0));
            Z2ART_ID_DOC = A2ART_ID_DOC;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load024( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey024( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey024( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey024( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound4 = 0;
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A2ART_ID_DOC});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00026_A2ART_ID_DOC[0], A2ART_ID_DOC) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00026_A2ART_ID_DOC[0], A2ART_ID_DOC) > 0 ) ) )
            {
               A2ART_ID_DOC = T00026_A2ART_ID_DOC[0];
               AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
               RcdFound4 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A2ART_ID_DOC});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00027_A2ART_ID_DOC[0], A2ART_ID_DOC) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00027_A2ART_ID_DOC[0], A2ART_ID_DOC) < 0 ) ) )
            {
               A2ART_ID_DOC = T00027_A2ART_ID_DOC[0];
               AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
               RcdFound4 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey024( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtART_ID_DOC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert024( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( StringUtil.StrCmp(A2ART_ID_DOC, Z2ART_ID_DOC) != 0 )
               {
                  A2ART_ID_DOC = Z2ART_ID_DOC;
                  AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ART_ID_DOC");
                  AnyError = 1;
                  GX_FocusControl = edtART_ID_DOC_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtART_ID_DOC_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update024( ) ;
                  GX_FocusControl = edtART_ID_DOC_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2ART_ID_DOC, Z2ART_ID_DOC) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtART_ID_DOC_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert024( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ART_ID_DOC");
                     AnyError = 1;
                     GX_FocusControl = edtART_ID_DOC_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtART_ID_DOC_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert024( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( StringUtil.StrCmp(A2ART_ID_DOC, Z2ART_ID_DOC) != 0 )
         {
            A2ART_ID_DOC = Z2ART_ID_DOC;
            AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ART_ID_DOC");
            AnyError = 1;
            GX_FocusControl = edtART_ID_DOC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtART_ID_DOC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ART_ID_DOC");
            AnyError = 1;
            GX_FocusControl = edtART_ID_DOC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACT_ID_CARD_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart024( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACT_ID_CARD_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd024( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACT_ID_CARD_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACT_ID_CARD_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart024( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext024( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACT_ID_CARD_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd024( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency024( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A2ART_ID_DOC});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MORA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z9ACT_ID_CARD, T00022_A9ACT_ID_CARD[0]) != 0 ) || ( StringUtil.StrCmp(Z10NOMBRE, T00022_A10NOMBRE[0]) != 0 ) || ( Z11SECTOR_COLONIA != T00022_A11SECTOR_COLONIA[0] ) || ( StringUtil.StrCmp(Z12NOMBRE_COLONIA, T00022_A12NOMBRE_COLONIA[0]) != 0 ) || ( Z13OBL_YEAR != T00022_A13OBL_YEAR[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z14DIAS != T00022_A14DIAS[0] ) || ( Z15IMPUESTO != T00022_A15IMPUESTO[0] ) || ( Z16TREN_DE_ASEO != T00022_A16TREN_DE_ASEO[0] ) || ( Z17TASA_BOMBEROS != T00022_A17TASA_BOMBEROS[0] ) || ( Z18INTERES != T00022_A18INTERES[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z19MoraId != T00022_A19MoraId[0] ) )
            {
               if ( StringUtil.StrCmp(Z9ACT_ID_CARD, T00022_A9ACT_ID_CARD[0]) != 0 )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"ACT_ID_CARD");
                  GXUtil.WriteLogRaw("Old: ",Z9ACT_ID_CARD);
                  GXUtil.WriteLogRaw("Current: ",T00022_A9ACT_ID_CARD[0]);
               }
               if ( StringUtil.StrCmp(Z10NOMBRE, T00022_A10NOMBRE[0]) != 0 )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"NOMBRE");
                  GXUtil.WriteLogRaw("Old: ",Z10NOMBRE);
                  GXUtil.WriteLogRaw("Current: ",T00022_A10NOMBRE[0]);
               }
               if ( Z11SECTOR_COLONIA != T00022_A11SECTOR_COLONIA[0] )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"SECTOR_COLONIA");
                  GXUtil.WriteLogRaw("Old: ",Z11SECTOR_COLONIA);
                  GXUtil.WriteLogRaw("Current: ",T00022_A11SECTOR_COLONIA[0]);
               }
               if ( StringUtil.StrCmp(Z12NOMBRE_COLONIA, T00022_A12NOMBRE_COLONIA[0]) != 0 )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"NOMBRE_COLONIA");
                  GXUtil.WriteLogRaw("Old: ",Z12NOMBRE_COLONIA);
                  GXUtil.WriteLogRaw("Current: ",T00022_A12NOMBRE_COLONIA[0]);
               }
               if ( Z13OBL_YEAR != T00022_A13OBL_YEAR[0] )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"OBL_YEAR");
                  GXUtil.WriteLogRaw("Old: ",Z13OBL_YEAR);
                  GXUtil.WriteLogRaw("Current: ",T00022_A13OBL_YEAR[0]);
               }
               if ( Z14DIAS != T00022_A14DIAS[0] )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"DIAS");
                  GXUtil.WriteLogRaw("Old: ",Z14DIAS);
                  GXUtil.WriteLogRaw("Current: ",T00022_A14DIAS[0]);
               }
               if ( Z15IMPUESTO != T00022_A15IMPUESTO[0] )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"IMPUESTO");
                  GXUtil.WriteLogRaw("Old: ",Z15IMPUESTO);
                  GXUtil.WriteLogRaw("Current: ",T00022_A15IMPUESTO[0]);
               }
               if ( Z16TREN_DE_ASEO != T00022_A16TREN_DE_ASEO[0] )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"TREN_DE_ASEO");
                  GXUtil.WriteLogRaw("Old: ",Z16TREN_DE_ASEO);
                  GXUtil.WriteLogRaw("Current: ",T00022_A16TREN_DE_ASEO[0]);
               }
               if ( Z17TASA_BOMBEROS != T00022_A17TASA_BOMBEROS[0] )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"TASA_BOMBEROS");
                  GXUtil.WriteLogRaw("Old: ",Z17TASA_BOMBEROS);
                  GXUtil.WriteLogRaw("Current: ",T00022_A17TASA_BOMBEROS[0]);
               }
               if ( Z18INTERES != T00022_A18INTERES[0] )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"INTERES");
                  GXUtil.WriteLogRaw("Old: ",Z18INTERES);
                  GXUtil.WriteLogRaw("Current: ",T00022_A18INTERES[0]);
               }
               if ( Z19MoraId != T00022_A19MoraId[0] )
               {
                  GXUtil.WriteLog("mora:[seudo value changed for attri]"+"MoraId");
                  GXUtil.WriteLogRaw("Old: ",Z19MoraId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A19MoraId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MORA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert024( )
      {
         BeforeValidate024( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable024( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM024( 0) ;
            CheckOptimisticConcurrency024( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm024( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert024( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00028 */
                     pr_default.execute(6, new Object[] {A2ART_ID_DOC, A9ACT_ID_CARD, A10NOMBRE, n11SECTOR_COLONIA, A11SECTOR_COLONIA, n12NOMBRE_COLONIA, A12NOMBRE_COLONIA, n13OBL_YEAR, A13OBL_YEAR, n14DIAS, A14DIAS, n15IMPUESTO, A15IMPUESTO, n16TREN_DE_ASEO, A16TREN_DE_ASEO, n17TASA_BOMBEROS, A17TASA_BOMBEROS, n18INTERES, A18INTERES, n19MoraId, A19MoraId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("MORA");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load024( ) ;
            }
            EndLevel024( ) ;
         }
         CloseExtendedTableCursors024( ) ;
      }

      protected void Update024( )
      {
         BeforeValidate024( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable024( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency024( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm024( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate024( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00029 */
                     pr_default.execute(7, new Object[] {A9ACT_ID_CARD, A10NOMBRE, n11SECTOR_COLONIA, A11SECTOR_COLONIA, n12NOMBRE_COLONIA, A12NOMBRE_COLONIA, n13OBL_YEAR, A13OBL_YEAR, n14DIAS, A14DIAS, n15IMPUESTO, A15IMPUESTO, n16TREN_DE_ASEO, A16TREN_DE_ASEO, n17TASA_BOMBEROS, A17TASA_BOMBEROS, n18INTERES, A18INTERES, n19MoraId, A19MoraId, A2ART_ID_DOC});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("MORA");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MORA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate024( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption020( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel024( ) ;
         }
         CloseExtendedTableCursors024( ) ;
      }

      protected void DeferredUpdate024( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate024( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency024( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls024( ) ;
            AfterConfirm024( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete024( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000210 */
                  pr_default.execute(8, new Object[] {A2ART_ID_DOC});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("MORA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound4 == 0 )
                        {
                           InitAll024( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption020( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel024( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls024( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel024( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete024( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("mora",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("mora",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart024( )
      {
         /* Using cursor T000211 */
         pr_default.execute(9);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound4 = 1;
            A2ART_ID_DOC = T000211_A2ART_ID_DOC[0];
            AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext024( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound4 = 1;
            A2ART_ID_DOC = T000211_A2ART_ID_DOC[0];
            AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
         }
      }

      protected void ScanEnd024( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm024( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert024( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate024( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete024( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete024( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate024( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes024( )
      {
         edtART_ID_DOC_Enabled = 0;
         AssignProp("", false, edtART_ID_DOC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtART_ID_DOC_Enabled), 5, 0), true);
         edtACT_ID_CARD_Enabled = 0;
         AssignProp("", false, edtACT_ID_CARD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACT_ID_CARD_Enabled), 5, 0), true);
         edtNOMBRE_Enabled = 0;
         AssignProp("", false, edtNOMBRE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRE_Enabled), 5, 0), true);
         edtSECTOR_COLONIA_Enabled = 0;
         AssignProp("", false, edtSECTOR_COLONIA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSECTOR_COLONIA_Enabled), 5, 0), true);
         edtNOMBRE_COLONIA_Enabled = 0;
         AssignProp("", false, edtNOMBRE_COLONIA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRE_COLONIA_Enabled), 5, 0), true);
         edtOBL_YEAR_Enabled = 0;
         AssignProp("", false, edtOBL_YEAR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOBL_YEAR_Enabled), 5, 0), true);
         edtDIAS_Enabled = 0;
         AssignProp("", false, edtDIAS_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDIAS_Enabled), 5, 0), true);
         edtIMPUESTO_Enabled = 0;
         AssignProp("", false, edtIMPUESTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIMPUESTO_Enabled), 5, 0), true);
         edtTREN_DE_ASEO_Enabled = 0;
         AssignProp("", false, edtTREN_DE_ASEO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTREN_DE_ASEO_Enabled), 5, 0), true);
         edtTASA_BOMBEROS_Enabled = 0;
         AssignProp("", false, edtTASA_BOMBEROS_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASA_BOMBEROS_Enabled), 5, 0), true);
         edtINTERES_Enabled = 0;
         AssignProp("", false, edtINTERES_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINTERES_Enabled), 5, 0), true);
         edtMoraId_Enabled = 0;
         AssignProp("", false, edtMoraId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMoraId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes024( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("mora.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z2ART_ID_DOC", Z2ART_ID_DOC);
         GxWebStd.gx_hidden_field( context, "Z9ACT_ID_CARD", Z9ACT_ID_CARD);
         GxWebStd.gx_hidden_field( context, "Z10NOMBRE", Z10NOMBRE);
         GxWebStd.gx_hidden_field( context, "Z11SECTOR_COLONIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11SECTOR_COLONIA), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z12NOMBRE_COLONIA", Z12NOMBRE_COLONIA);
         GxWebStd.gx_hidden_field( context, "Z13OBL_YEAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13OBL_YEAR), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z14DIAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14DIAS), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z15IMPUESTO", StringUtil.LTrim( StringUtil.NToC( Z15IMPUESTO, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z16TREN_DE_ASEO", StringUtil.LTrim( StringUtil.NToC( Z16TREN_DE_ASEO, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z17TASA_BOMBEROS", StringUtil.LTrim( StringUtil.NToC( Z17TASA_BOMBEROS, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z18INTERES", StringUtil.LTrim( StringUtil.NToC( Z18INTERES, 18, 6, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z19MoraId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19MoraId), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("mora.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "MORA" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "MORA", "") ;
      }

      protected void InitializeNonKey024( )
      {
         A9ACT_ID_CARD = "";
         AssignAttri("", false, "A9ACT_ID_CARD", A9ACT_ID_CARD);
         A10NOMBRE = "";
         AssignAttri("", false, "A10NOMBRE", A10NOMBRE);
         A11SECTOR_COLONIA = 0;
         n11SECTOR_COLONIA = false;
         AssignAttri("", false, "A11SECTOR_COLONIA", StringUtil.LTrimStr( (decimal)(A11SECTOR_COLONIA), 4, 0));
         n11SECTOR_COLONIA = ((0==A11SECTOR_COLONIA) ? true : false);
         A12NOMBRE_COLONIA = "";
         n12NOMBRE_COLONIA = false;
         AssignAttri("", false, "A12NOMBRE_COLONIA", A12NOMBRE_COLONIA);
         n12NOMBRE_COLONIA = (String.IsNullOrEmpty(StringUtil.RTrim( A12NOMBRE_COLONIA)) ? true : false);
         A13OBL_YEAR = 0;
         n13OBL_YEAR = false;
         AssignAttri("", false, "A13OBL_YEAR", StringUtil.LTrimStr( (decimal)(A13OBL_YEAR), 4, 0));
         n13OBL_YEAR = ((0==A13OBL_YEAR) ? true : false);
         A14DIAS = 0;
         n14DIAS = false;
         AssignAttri("", false, "A14DIAS", StringUtil.LTrimStr( (decimal)(A14DIAS), 9, 0));
         n14DIAS = ((0==A14DIAS) ? true : false);
         A15IMPUESTO = 0;
         n15IMPUESTO = false;
         AssignAttri("", false, "A15IMPUESTO", StringUtil.LTrimStr( A15IMPUESTO, 18, 2));
         n15IMPUESTO = ((Convert.ToDecimal(0)==A15IMPUESTO) ? true : false);
         A16TREN_DE_ASEO = 0;
         n16TREN_DE_ASEO = false;
         AssignAttri("", false, "A16TREN_DE_ASEO", StringUtil.LTrimStr( A16TREN_DE_ASEO, 18, 2));
         n16TREN_DE_ASEO = ((Convert.ToDecimal(0)==A16TREN_DE_ASEO) ? true : false);
         A17TASA_BOMBEROS = 0;
         n17TASA_BOMBEROS = false;
         AssignAttri("", false, "A17TASA_BOMBEROS", StringUtil.LTrimStr( A17TASA_BOMBEROS, 18, 2));
         n17TASA_BOMBEROS = ((Convert.ToDecimal(0)==A17TASA_BOMBEROS) ? true : false);
         A18INTERES = 0;
         n18INTERES = false;
         AssignAttri("", false, "A18INTERES", StringUtil.LTrimStr( A18INTERES, 18, 6));
         n18INTERES = ((Convert.ToDecimal(0)==A18INTERES) ? true : false);
         A19MoraId = 0;
         n19MoraId = false;
         AssignAttri("", false, "A19MoraId", StringUtil.LTrimStr( (decimal)(A19MoraId), 9, 0));
         n19MoraId = ((0==A19MoraId) ? true : false);
         Z9ACT_ID_CARD = "";
         Z10NOMBRE = "";
         Z11SECTOR_COLONIA = 0;
         Z12NOMBRE_COLONIA = "";
         Z13OBL_YEAR = 0;
         Z14DIAS = 0;
         Z15IMPUESTO = 0;
         Z16TREN_DE_ASEO = 0;
         Z17TASA_BOMBEROS = 0;
         Z18INTERES = 0;
         Z19MoraId = 0;
      }

      protected void InitAll024( )
      {
         A2ART_ID_DOC = "";
         AssignAttri("", false, "A2ART_ID_DOC", A2ART_ID_DOC);
         InitializeNonKey024( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024341462767", true, true);
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
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 13800), false, true);
         context.AddJavascriptSource("mora.js", "?2024341462767", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtART_ID_DOC_Internalname = "ART_ID_DOC";
         edtACT_ID_CARD_Internalname = "ACT_ID_CARD";
         edtNOMBRE_Internalname = "NOMBRE";
         edtSECTOR_COLONIA_Internalname = "SECTOR_COLONIA";
         edtNOMBRE_COLONIA_Internalname = "NOMBRE_COLONIA";
         edtOBL_YEAR_Internalname = "OBL_YEAR";
         edtDIAS_Internalname = "DIAS";
         edtIMPUESTO_Internalname = "IMPUESTO";
         edtTREN_DE_ASEO_Internalname = "TREN_DE_ASEO";
         edtTASA_BOMBEROS_Internalname = "TASA_BOMBEROS";
         edtINTERES_Internalname = "INTERES";
         edtMoraId_Internalname = "MORAID";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "MORA", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMoraId_Jsonclick = "";
         edtMoraId_Enabled = 1;
         edtINTERES_Jsonclick = "";
         edtINTERES_Enabled = 1;
         edtTASA_BOMBEROS_Jsonclick = "";
         edtTASA_BOMBEROS_Enabled = 1;
         edtTREN_DE_ASEO_Jsonclick = "";
         edtTREN_DE_ASEO_Enabled = 1;
         edtIMPUESTO_Jsonclick = "";
         edtIMPUESTO_Enabled = 1;
         edtDIAS_Jsonclick = "";
         edtDIAS_Enabled = 1;
         edtOBL_YEAR_Jsonclick = "";
         edtOBL_YEAR_Enabled = 1;
         edtNOMBRE_COLONIA_Jsonclick = "";
         edtNOMBRE_COLONIA_Enabled = 1;
         edtSECTOR_COLONIA_Jsonclick = "";
         edtSECTOR_COLONIA_Enabled = 1;
         edtNOMBRE_Enabled = 1;
         edtACT_ID_CARD_Jsonclick = "";
         edtACT_ID_CARD_Enabled = 1;
         edtART_ID_DOC_Jsonclick = "";
         edtART_ID_DOC_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtACT_ID_CARD_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Art_id_doc( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A9ACT_ID_CARD", A9ACT_ID_CARD);
         AssignAttri("", false, "A10NOMBRE", A10NOMBRE);
         AssignAttri("", false, "A11SECTOR_COLONIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SECTOR_COLONIA), 4, 0, ".", "")));
         AssignAttri("", false, "A12NOMBRE_COLONIA", A12NOMBRE_COLONIA);
         AssignAttri("", false, "A13OBL_YEAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13OBL_YEAR), 4, 0, ".", "")));
         AssignAttri("", false, "A14DIAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14DIAS), 9, 0, ".", "")));
         AssignAttri("", false, "A15IMPUESTO", StringUtil.LTrim( StringUtil.NToC( A15IMPUESTO, 18, 2, ".", "")));
         AssignAttri("", false, "A16TREN_DE_ASEO", StringUtil.LTrim( StringUtil.NToC( A16TREN_DE_ASEO, 18, 2, ".", "")));
         AssignAttri("", false, "A17TASA_BOMBEROS", StringUtil.LTrim( StringUtil.NToC( A17TASA_BOMBEROS, 18, 2, ".", "")));
         AssignAttri("", false, "A18INTERES", StringUtil.LTrim( StringUtil.NToC( A18INTERES, 18, 6, ".", "")));
         AssignAttri("", false, "A19MoraId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MoraId), 9, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2ART_ID_DOC", Z2ART_ID_DOC);
         GxWebStd.gx_hidden_field( context, "Z9ACT_ID_CARD", Z9ACT_ID_CARD);
         GxWebStd.gx_hidden_field( context, "Z10NOMBRE", Z10NOMBRE);
         GxWebStd.gx_hidden_field( context, "Z11SECTOR_COLONIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11SECTOR_COLONIA), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z12NOMBRE_COLONIA", Z12NOMBRE_COLONIA);
         GxWebStd.gx_hidden_field( context, "Z13OBL_YEAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13OBL_YEAR), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14DIAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14DIAS), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z15IMPUESTO", StringUtil.LTrim( StringUtil.NToC( Z15IMPUESTO, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z16TREN_DE_ASEO", StringUtil.LTrim( StringUtil.NToC( Z16TREN_DE_ASEO, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17TASA_BOMBEROS", StringUtil.LTrim( StringUtil.NToC( Z17TASA_BOMBEROS, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z18INTERES", StringUtil.LTrim( StringUtil.NToC( Z18INTERES, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z19MoraId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19MoraId), 9, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_ART_ID_DOC","{handler:'Valid_Art_id_doc',iparms:[{av:'A2ART_ID_DOC',fld:'ART_ID_DOC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ART_ID_DOC",",oparms:[{av:'A9ACT_ID_CARD',fld:'ACT_ID_CARD',pic:''},{av:'A10NOMBRE',fld:'NOMBRE',pic:''},{av:'A11SECTOR_COLONIA',fld:'SECTOR_COLONIA',pic:'ZZZ9'},{av:'A12NOMBRE_COLONIA',fld:'NOMBRE_COLONIA',pic:''},{av:'A13OBL_YEAR',fld:'OBL_YEAR',pic:'ZZZ9'},{av:'A14DIAS',fld:'DIAS',pic:'ZZZZZZZZ9'},{av:'A15IMPUESTO',fld:'IMPUESTO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A16TREN_DE_ASEO',fld:'TREN_DE_ASEO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A17TASA_BOMBEROS',fld:'TASA_BOMBEROS',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A18INTERES',fld:'INTERES',pic:'ZZZZZZZZZZ9.999999'},{av:'A19MoraId',fld:'MORAID',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2ART_ID_DOC'},{av:'Z9ACT_ID_CARD'},{av:'Z10NOMBRE'},{av:'Z11SECTOR_COLONIA'},{av:'Z12NOMBRE_COLONIA'},{av:'Z13OBL_YEAR'},{av:'Z14DIAS'},{av:'Z15IMPUESTO'},{av:'Z16TREN_DE_ASEO'},{av:'Z17TASA_BOMBEROS'},{av:'Z18INTERES'},{av:'Z19MoraId'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2ART_ID_DOC = "";
         Z9ACT_ID_CARD = "";
         Z10NOMBRE = "";
         Z12NOMBRE_COLONIA = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A2ART_ID_DOC = "";
         A9ACT_ID_CARD = "";
         A10NOMBRE = "";
         A12NOMBRE_COLONIA = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00024_A2ART_ID_DOC = new string[] {""} ;
         T00024_A9ACT_ID_CARD = new string[] {""} ;
         T00024_A10NOMBRE = new string[] {""} ;
         T00024_A11SECTOR_COLONIA = new short[1] ;
         T00024_n11SECTOR_COLONIA = new bool[] {false} ;
         T00024_A12NOMBRE_COLONIA = new string[] {""} ;
         T00024_n12NOMBRE_COLONIA = new bool[] {false} ;
         T00024_A13OBL_YEAR = new short[1] ;
         T00024_n13OBL_YEAR = new bool[] {false} ;
         T00024_A14DIAS = new int[1] ;
         T00024_n14DIAS = new bool[] {false} ;
         T00024_A15IMPUESTO = new decimal[1] ;
         T00024_n15IMPUESTO = new bool[] {false} ;
         T00024_A16TREN_DE_ASEO = new decimal[1] ;
         T00024_n16TREN_DE_ASEO = new bool[] {false} ;
         T00024_A17TASA_BOMBEROS = new decimal[1] ;
         T00024_n17TASA_BOMBEROS = new bool[] {false} ;
         T00024_A18INTERES = new decimal[1] ;
         T00024_n18INTERES = new bool[] {false} ;
         T00024_A19MoraId = new int[1] ;
         T00024_n19MoraId = new bool[] {false} ;
         T00025_A2ART_ID_DOC = new string[] {""} ;
         T00023_A2ART_ID_DOC = new string[] {""} ;
         T00023_A9ACT_ID_CARD = new string[] {""} ;
         T00023_A10NOMBRE = new string[] {""} ;
         T00023_A11SECTOR_COLONIA = new short[1] ;
         T00023_n11SECTOR_COLONIA = new bool[] {false} ;
         T00023_A12NOMBRE_COLONIA = new string[] {""} ;
         T00023_n12NOMBRE_COLONIA = new bool[] {false} ;
         T00023_A13OBL_YEAR = new short[1] ;
         T00023_n13OBL_YEAR = new bool[] {false} ;
         T00023_A14DIAS = new int[1] ;
         T00023_n14DIAS = new bool[] {false} ;
         T00023_A15IMPUESTO = new decimal[1] ;
         T00023_n15IMPUESTO = new bool[] {false} ;
         T00023_A16TREN_DE_ASEO = new decimal[1] ;
         T00023_n16TREN_DE_ASEO = new bool[] {false} ;
         T00023_A17TASA_BOMBEROS = new decimal[1] ;
         T00023_n17TASA_BOMBEROS = new bool[] {false} ;
         T00023_A18INTERES = new decimal[1] ;
         T00023_n18INTERES = new bool[] {false} ;
         T00023_A19MoraId = new int[1] ;
         T00023_n19MoraId = new bool[] {false} ;
         sMode4 = "";
         T00026_A2ART_ID_DOC = new string[] {""} ;
         T00027_A2ART_ID_DOC = new string[] {""} ;
         T00022_A2ART_ID_DOC = new string[] {""} ;
         T00022_A9ACT_ID_CARD = new string[] {""} ;
         T00022_A10NOMBRE = new string[] {""} ;
         T00022_A11SECTOR_COLONIA = new short[1] ;
         T00022_n11SECTOR_COLONIA = new bool[] {false} ;
         T00022_A12NOMBRE_COLONIA = new string[] {""} ;
         T00022_n12NOMBRE_COLONIA = new bool[] {false} ;
         T00022_A13OBL_YEAR = new short[1] ;
         T00022_n13OBL_YEAR = new bool[] {false} ;
         T00022_A14DIAS = new int[1] ;
         T00022_n14DIAS = new bool[] {false} ;
         T00022_A15IMPUESTO = new decimal[1] ;
         T00022_n15IMPUESTO = new bool[] {false} ;
         T00022_A16TREN_DE_ASEO = new decimal[1] ;
         T00022_n16TREN_DE_ASEO = new bool[] {false} ;
         T00022_A17TASA_BOMBEROS = new decimal[1] ;
         T00022_n17TASA_BOMBEROS = new bool[] {false} ;
         T00022_A18INTERES = new decimal[1] ;
         T00022_n18INTERES = new bool[] {false} ;
         T00022_A19MoraId = new int[1] ;
         T00022_n19MoraId = new bool[] {false} ;
         T000211_A2ART_ID_DOC = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2ART_ID_DOC = "";
         ZZ9ACT_ID_CARD = "";
         ZZ10NOMBRE = "";
         ZZ12NOMBRE_COLONIA = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mora__default(),
            new Object[][] {
                new Object[] {
               T00022_A2ART_ID_DOC, T00022_A9ACT_ID_CARD, T00022_A10NOMBRE, T00022_A11SECTOR_COLONIA, T00022_n11SECTOR_COLONIA, T00022_A12NOMBRE_COLONIA, T00022_n12NOMBRE_COLONIA, T00022_A13OBL_YEAR, T00022_n13OBL_YEAR, T00022_A14DIAS,
               T00022_n14DIAS, T00022_A15IMPUESTO, T00022_n15IMPUESTO, T00022_A16TREN_DE_ASEO, T00022_n16TREN_DE_ASEO, T00022_A17TASA_BOMBEROS, T00022_n17TASA_BOMBEROS, T00022_A18INTERES, T00022_n18INTERES, T00022_A19MoraId,
               T00022_n19MoraId
               }
               , new Object[] {
               T00023_A2ART_ID_DOC, T00023_A9ACT_ID_CARD, T00023_A10NOMBRE, T00023_A11SECTOR_COLONIA, T00023_n11SECTOR_COLONIA, T00023_A12NOMBRE_COLONIA, T00023_n12NOMBRE_COLONIA, T00023_A13OBL_YEAR, T00023_n13OBL_YEAR, T00023_A14DIAS,
               T00023_n14DIAS, T00023_A15IMPUESTO, T00023_n15IMPUESTO, T00023_A16TREN_DE_ASEO, T00023_n16TREN_DE_ASEO, T00023_A17TASA_BOMBEROS, T00023_n17TASA_BOMBEROS, T00023_A18INTERES, T00023_n18INTERES, T00023_A19MoraId,
               T00023_n19MoraId
               }
               , new Object[] {
               T00024_A2ART_ID_DOC, T00024_A9ACT_ID_CARD, T00024_A10NOMBRE, T00024_A11SECTOR_COLONIA, T00024_n11SECTOR_COLONIA, T00024_A12NOMBRE_COLONIA, T00024_n12NOMBRE_COLONIA, T00024_A13OBL_YEAR, T00024_n13OBL_YEAR, T00024_A14DIAS,
               T00024_n14DIAS, T00024_A15IMPUESTO, T00024_n15IMPUESTO, T00024_A16TREN_DE_ASEO, T00024_n16TREN_DE_ASEO, T00024_A17TASA_BOMBEROS, T00024_n17TASA_BOMBEROS, T00024_A18INTERES, T00024_n18INTERES, T00024_A19MoraId,
               T00024_n19MoraId
               }
               , new Object[] {
               T00025_A2ART_ID_DOC
               }
               , new Object[] {
               T00026_A2ART_ID_DOC
               }
               , new Object[] {
               T00027_A2ART_ID_DOC
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000211_A2ART_ID_DOC
               }
            }
         );
      }

      private short Z11SECTOR_COLONIA ;
      private short Z13OBL_YEAR ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A11SECTOR_COLONIA ;
      private short A13OBL_YEAR ;
      private short RcdFound4 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ11SECTOR_COLONIA ;
      private short ZZ13OBL_YEAR ;
      private int Z14DIAS ;
      private int Z19MoraId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtART_ID_DOC_Enabled ;
      private int edtACT_ID_CARD_Enabled ;
      private int edtNOMBRE_Enabled ;
      private int edtSECTOR_COLONIA_Enabled ;
      private int edtNOMBRE_COLONIA_Enabled ;
      private int edtOBL_YEAR_Enabled ;
      private int A14DIAS ;
      private int edtDIAS_Enabled ;
      private int edtIMPUESTO_Enabled ;
      private int edtTREN_DE_ASEO_Enabled ;
      private int edtTASA_BOMBEROS_Enabled ;
      private int edtINTERES_Enabled ;
      private int A19MoraId ;
      private int edtMoraId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ14DIAS ;
      private int ZZ19MoraId ;
      private decimal Z15IMPUESTO ;
      private decimal Z16TREN_DE_ASEO ;
      private decimal Z17TASA_BOMBEROS ;
      private decimal Z18INTERES ;
      private decimal A15IMPUESTO ;
      private decimal A16TREN_DE_ASEO ;
      private decimal A17TASA_BOMBEROS ;
      private decimal A18INTERES ;
      private decimal ZZ15IMPUESTO ;
      private decimal ZZ16TREN_DE_ASEO ;
      private decimal ZZ17TASA_BOMBEROS ;
      private decimal ZZ18INTERES ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtART_ID_DOC_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtART_ID_DOC_Jsonclick ;
      private string edtACT_ID_CARD_Internalname ;
      private string edtACT_ID_CARD_Jsonclick ;
      private string edtNOMBRE_Internalname ;
      private string edtSECTOR_COLONIA_Internalname ;
      private string edtSECTOR_COLONIA_Jsonclick ;
      private string edtNOMBRE_COLONIA_Internalname ;
      private string edtNOMBRE_COLONIA_Jsonclick ;
      private string edtOBL_YEAR_Internalname ;
      private string edtOBL_YEAR_Jsonclick ;
      private string edtDIAS_Internalname ;
      private string edtDIAS_Jsonclick ;
      private string edtIMPUESTO_Internalname ;
      private string edtIMPUESTO_Jsonclick ;
      private string edtTREN_DE_ASEO_Internalname ;
      private string edtTREN_DE_ASEO_Jsonclick ;
      private string edtTASA_BOMBEROS_Internalname ;
      private string edtTASA_BOMBEROS_Jsonclick ;
      private string edtINTERES_Internalname ;
      private string edtINTERES_Jsonclick ;
      private string edtMoraId_Internalname ;
      private string edtMoraId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode4 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n11SECTOR_COLONIA ;
      private bool n12NOMBRE_COLONIA ;
      private bool n13OBL_YEAR ;
      private bool n14DIAS ;
      private bool n15IMPUESTO ;
      private bool n16TREN_DE_ASEO ;
      private bool n17TASA_BOMBEROS ;
      private bool n18INTERES ;
      private bool n19MoraId ;
      private bool Gx_longc ;
      private string Z2ART_ID_DOC ;
      private string Z9ACT_ID_CARD ;
      private string Z10NOMBRE ;
      private string Z12NOMBRE_COLONIA ;
      private string A2ART_ID_DOC ;
      private string A9ACT_ID_CARD ;
      private string A10NOMBRE ;
      private string A12NOMBRE_COLONIA ;
      private string ZZ2ART_ID_DOC ;
      private string ZZ9ACT_ID_CARD ;
      private string ZZ10NOMBRE ;
      private string ZZ12NOMBRE_COLONIA ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00024_A2ART_ID_DOC ;
      private string[] T00024_A9ACT_ID_CARD ;
      private string[] T00024_A10NOMBRE ;
      private short[] T00024_A11SECTOR_COLONIA ;
      private bool[] T00024_n11SECTOR_COLONIA ;
      private string[] T00024_A12NOMBRE_COLONIA ;
      private bool[] T00024_n12NOMBRE_COLONIA ;
      private short[] T00024_A13OBL_YEAR ;
      private bool[] T00024_n13OBL_YEAR ;
      private int[] T00024_A14DIAS ;
      private bool[] T00024_n14DIAS ;
      private decimal[] T00024_A15IMPUESTO ;
      private bool[] T00024_n15IMPUESTO ;
      private decimal[] T00024_A16TREN_DE_ASEO ;
      private bool[] T00024_n16TREN_DE_ASEO ;
      private decimal[] T00024_A17TASA_BOMBEROS ;
      private bool[] T00024_n17TASA_BOMBEROS ;
      private decimal[] T00024_A18INTERES ;
      private bool[] T00024_n18INTERES ;
      private int[] T00024_A19MoraId ;
      private bool[] T00024_n19MoraId ;
      private string[] T00025_A2ART_ID_DOC ;
      private string[] T00023_A2ART_ID_DOC ;
      private string[] T00023_A9ACT_ID_CARD ;
      private string[] T00023_A10NOMBRE ;
      private short[] T00023_A11SECTOR_COLONIA ;
      private bool[] T00023_n11SECTOR_COLONIA ;
      private string[] T00023_A12NOMBRE_COLONIA ;
      private bool[] T00023_n12NOMBRE_COLONIA ;
      private short[] T00023_A13OBL_YEAR ;
      private bool[] T00023_n13OBL_YEAR ;
      private int[] T00023_A14DIAS ;
      private bool[] T00023_n14DIAS ;
      private decimal[] T00023_A15IMPUESTO ;
      private bool[] T00023_n15IMPUESTO ;
      private decimal[] T00023_A16TREN_DE_ASEO ;
      private bool[] T00023_n16TREN_DE_ASEO ;
      private decimal[] T00023_A17TASA_BOMBEROS ;
      private bool[] T00023_n17TASA_BOMBEROS ;
      private decimal[] T00023_A18INTERES ;
      private bool[] T00023_n18INTERES ;
      private int[] T00023_A19MoraId ;
      private bool[] T00023_n19MoraId ;
      private string[] T00026_A2ART_ID_DOC ;
      private string[] T00027_A2ART_ID_DOC ;
      private string[] T00022_A2ART_ID_DOC ;
      private string[] T00022_A9ACT_ID_CARD ;
      private string[] T00022_A10NOMBRE ;
      private short[] T00022_A11SECTOR_COLONIA ;
      private bool[] T00022_n11SECTOR_COLONIA ;
      private string[] T00022_A12NOMBRE_COLONIA ;
      private bool[] T00022_n12NOMBRE_COLONIA ;
      private short[] T00022_A13OBL_YEAR ;
      private bool[] T00022_n13OBL_YEAR ;
      private int[] T00022_A14DIAS ;
      private bool[] T00022_n14DIAS ;
      private decimal[] T00022_A15IMPUESTO ;
      private bool[] T00022_n15IMPUESTO ;
      private decimal[] T00022_A16TREN_DE_ASEO ;
      private bool[] T00022_n16TREN_DE_ASEO ;
      private decimal[] T00022_A17TASA_BOMBEROS ;
      private bool[] T00022_n17TASA_BOMBEROS ;
      private decimal[] T00022_A18INTERES ;
      private bool[] T00022_n18INTERES ;
      private int[] T00022_A19MoraId ;
      private bool[] T00022_n19MoraId ;
      private string[] T000211_A2ART_ID_DOC ;
      private GXWebForm Form ;
   }

   public class mora__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@ART_ID_DOC",GXType.NVarChar,40,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@ART_ID_DOC",GXType.NVarChar,40,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@ART_ID_DOC",GXType.NVarChar,40,0)
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@ART_ID_DOC",GXType.NVarChar,40,0)
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@ART_ID_DOC",GXType.NVarChar,40,0)
          };
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@ART_ID_DOC",GXType.NVarChar,40,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@ART_ID_DOC",GXType.NVarChar,40,0) ,
          new ParDef("@ACT_ID_CARD",GXType.NVarChar,40,0) ,
          new ParDef("@NOMBRE",GXType.NVarChar,323,0) ,
          new ParDef("@SECTOR_COLONIA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@NOMBRE_COLONIA",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@OBL_YEAR",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@DIAS",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@IMPUESTO",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@TREN_DE_ASEO",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@TASA_BOMBEROS",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@INTERES",GXType.Decimal,18,6){Nullable=true} ,
          new ParDef("@MoraId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@ACT_ID_CARD",GXType.NVarChar,40,0) ,
          new ParDef("@NOMBRE",GXType.NVarChar,323,0) ,
          new ParDef("@SECTOR_COLONIA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@NOMBRE_COLONIA",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@OBL_YEAR",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@DIAS",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@IMPUESTO",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@TREN_DE_ASEO",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@TASA_BOMBEROS",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@INTERES",GXType.Decimal,18,6){Nullable=true} ,
          new ParDef("@MoraId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@ART_ID_DOC",GXType.NVarChar,40,0)
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@ART_ID_DOC",GXType.NVarChar,40,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [ART_ID_DOC], [ACT_ID_CARD], [NOMBRE], [SECTOR_COLONIA], [NOMBRE_COLONIA], [OBL_YEAR], [DIAS], [IMPUESTO], [TREN_DE_ASEO], [TASA_BOMBEROS], [INTERES], [MoraId] FROM dbo.[MORA] WITH (UPDLOCK) WHERE [ART_ID_DOC] = @ART_ID_DOC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [ART_ID_DOC], [ACT_ID_CARD], [NOMBRE], [SECTOR_COLONIA], [NOMBRE_COLONIA], [OBL_YEAR], [DIAS], [IMPUESTO], [TREN_DE_ASEO], [TASA_BOMBEROS], [INTERES], [MoraId] FROM dbo.[MORA] WHERE [ART_ID_DOC] = @ART_ID_DOC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT TM1.[ART_ID_DOC], TM1.[ACT_ID_CARD], TM1.[NOMBRE], TM1.[SECTOR_COLONIA], TM1.[NOMBRE_COLONIA], TM1.[OBL_YEAR], TM1.[DIAS], TM1.[IMPUESTO], TM1.[TREN_DE_ASEO], TM1.[TASA_BOMBEROS], TM1.[INTERES], TM1.[MoraId] FROM dbo.[MORA] TM1 WHERE TM1.[ART_ID_DOC] = @ART_ID_DOC ORDER BY TM1.[ART_ID_DOC]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [ART_ID_DOC] FROM dbo.[MORA] WHERE [ART_ID_DOC] = @ART_ID_DOC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT TOP 1 [ART_ID_DOC] FROM dbo.[MORA] WHERE ( [ART_ID_DOC] > @ART_ID_DOC) ORDER BY [ART_ID_DOC]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00027", "SELECT TOP 1 [ART_ID_DOC] FROM dbo.[MORA] WHERE ( [ART_ID_DOC] < @ART_ID_DOC) ORDER BY [ART_ID_DOC] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00028", "INSERT INTO dbo.[MORA]([ART_ID_DOC], [ACT_ID_CARD], [NOMBRE], [SECTOR_COLONIA], [NOMBRE_COLONIA], [OBL_YEAR], [DIAS], [IMPUESTO], [TREN_DE_ASEO], [TASA_BOMBEROS], [INTERES], [MoraId]) VALUES(@ART_ID_DOC, @ACT_ID_CARD, @NOMBRE, @SECTOR_COLONIA, @NOMBRE_COLONIA, @OBL_YEAR, @DIAS, @IMPUESTO, @TREN_DE_ASEO, @TASA_BOMBEROS, @INTERES, @MoraId)", GxErrorMask.GX_NOMASK,prmT00028)
             ,new CursorDef("T00029", "UPDATE dbo.[MORA] SET [ACT_ID_CARD]=@ACT_ID_CARD, [NOMBRE]=@NOMBRE, [SECTOR_COLONIA]=@SECTOR_COLONIA, [NOMBRE_COLONIA]=@NOMBRE_COLONIA, [OBL_YEAR]=@OBL_YEAR, [DIAS]=@DIAS, [IMPUESTO]=@IMPUESTO, [TREN_DE_ASEO]=@TREN_DE_ASEO, [TASA_BOMBEROS]=@TASA_BOMBEROS, [INTERES]=@INTERES, [MoraId]=@MoraId  WHERE [ART_ID_DOC] = @ART_ID_DOC", GxErrorMask.GX_NOMASK,prmT00029)
             ,new CursorDef("T000210", "DELETE FROM dbo.[MORA]  WHERE [ART_ID_DOC] = @ART_ID_DOC", GxErrorMask.GX_NOMASK,prmT000210)
             ,new CursorDef("T000211", "SELECT [ART_ID_DOC] FROM dbo.[MORA] ORDER BY [ART_ID_DOC]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(11);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((int[]) buf[19])[0] = rslt.getInt(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(11);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((int[]) buf[19])[0] = rslt.getInt(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(11);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((int[]) buf[19])[0] = rslt.getInt(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
