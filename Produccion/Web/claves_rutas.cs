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
   public class claves_rutas : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         Form.Meta.addItem("description", "CLAVES_RUTAS", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("AriesCustom", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public claves_rutas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public claves_rutas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CLAVES_RUTAS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_CLAVES_RUTAS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLAVES_RUTAS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLAVES_RUTAS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLAVES_RUTAS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLAVES_RUTAS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLAVE_CATASTRAL"+"'), id:'"+"CLAVE_CATASTRAL"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_CLAVES_RUTAS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCLAVE_CATASTRAL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAVE_CATASTRAL_Internalname, "CLAVE_CATASTRAL", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCLAVE_CATASTRAL_Internalname, A1CLAVE_CATASTRAL, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", 0, 1, edtCLAVE_CATASTRAL_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_CLAVES_RUTAS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCLAVES_RUTASRUTA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAVES_RUTASRUTA_Internalname, "RUTA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLAVES_RUTASRUTA_Internalname, StringUtil.LTrim( StringUtil.NToC( A6CLAVES_RUTASRUTA, 18, 6, ".", "")), StringUtil.LTrim( ((edtCLAVES_RUTASRUTA_Enabled!=0) ? context.localUtil.Format( A6CLAVES_RUTASRUTA, "ZZZZZZZZZZ9.999999") : context.localUtil.Format( A6CLAVES_RUTASRUTA, "ZZZZZZZZZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAVES_RUTASRUTA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAVES_RUTASRUTA_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CLAVES_RUTAS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUMAPS_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUMAPS_Internalname, "UMAPS", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUMAPS_Internalname, StringUtil.LTrim( StringUtil.NToC( A7UMAPS, 18, 6, ".", "")), StringUtil.LTrim( ((edtUMAPS_Enabled!=0) ? context.localUtil.Format( A7UMAPS, "ZZZZZZZZZZ9.999999") : context.localUtil.Format( A7UMAPS, "ZZZZZZZZZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUMAPS_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUMAPS_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CLAVES_RUTAS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClavesRutaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClavesRutaId_Internalname, "Claves Ruta Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClavesRutaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8ClavesRutaId), 9, 0, ".", "")), StringUtil.LTrim( ((edtClavesRutaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A8ClavesRutaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A8ClavesRutaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClavesRutaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClavesRutaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CLAVES_RUTAS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLAVES_RUTAS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLAVES_RUTAS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLAVES_RUTAS.htm");
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
            Z1CLAVE_CATASTRAL = cgiGet( "Z1CLAVE_CATASTRAL");
            Z6CLAVES_RUTASRUTA = context.localUtil.CToN( cgiGet( "Z6CLAVES_RUTASRUTA"), ".", ",");
            n6CLAVES_RUTASRUTA = ((Convert.ToDecimal(0)==A6CLAVES_RUTASRUTA) ? true : false);
            Z7UMAPS = context.localUtil.CToN( cgiGet( "Z7UMAPS"), ".", ",");
            n7UMAPS = ((Convert.ToDecimal(0)==A7UMAPS) ? true : false);
            Z8ClavesRutaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z8ClavesRutaId"), ".", ","), 18, MidpointRounding.ToEven));
            n8ClavesRutaId = ((0==A8ClavesRutaId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A1CLAVE_CATASTRAL = cgiGet( edtCLAVE_CATASTRAL_Internalname);
            AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLAVES_RUTASRUTA_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLAVES_RUTASRUTA_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLAVES_RUTASRUTA");
               AnyError = 1;
               GX_FocusControl = edtCLAVES_RUTASRUTA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A6CLAVES_RUTASRUTA = 0;
               n6CLAVES_RUTASRUTA = false;
               AssignAttri("", false, "A6CLAVES_RUTASRUTA", StringUtil.LTrimStr( A6CLAVES_RUTASRUTA, 18, 6));
            }
            else
            {
               A6CLAVES_RUTASRUTA = context.localUtil.CToN( cgiGet( edtCLAVES_RUTASRUTA_Internalname), ".", ",");
               n6CLAVES_RUTASRUTA = false;
               AssignAttri("", false, "A6CLAVES_RUTASRUTA", StringUtil.LTrimStr( A6CLAVES_RUTASRUTA, 18, 6));
            }
            n6CLAVES_RUTASRUTA = ((Convert.ToDecimal(0)==A6CLAVES_RUTASRUTA) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUMAPS_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUMAPS_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UMAPS");
               AnyError = 1;
               GX_FocusControl = edtUMAPS_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A7UMAPS = 0;
               n7UMAPS = false;
               AssignAttri("", false, "A7UMAPS", StringUtil.LTrimStr( A7UMAPS, 18, 6));
            }
            else
            {
               A7UMAPS = context.localUtil.CToN( cgiGet( edtUMAPS_Internalname), ".", ",");
               n7UMAPS = false;
               AssignAttri("", false, "A7UMAPS", StringUtil.LTrimStr( A7UMAPS, 18, 6));
            }
            n7UMAPS = ((Convert.ToDecimal(0)==A7UMAPS) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtClavesRutaId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClavesRutaId_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLAVESRUTAID");
               AnyError = 1;
               GX_FocusControl = edtClavesRutaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A8ClavesRutaId = 0;
               n8ClavesRutaId = false;
               AssignAttri("", false, "A8ClavesRutaId", StringUtil.LTrimStr( (decimal)(A8ClavesRutaId), 9, 0));
            }
            else
            {
               A8ClavesRutaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClavesRutaId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n8ClavesRutaId = false;
               AssignAttri("", false, "A8ClavesRutaId", StringUtil.LTrimStr( (decimal)(A8ClavesRutaId), 9, 0));
            }
            n8ClavesRutaId = ((0==A8ClavesRutaId) ? true : false);
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
               A1CLAVE_CATASTRAL = GetPar( "CLAVE_CATASTRAL");
               AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
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
               InitAll015( ) ;
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
         DisableAttributes015( ) ;
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

      protected void ResetCaption010( )
      {
      }

      protected void ZM015( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z6CLAVES_RUTASRUTA = T00013_A6CLAVES_RUTASRUTA[0];
               Z7UMAPS = T00013_A7UMAPS[0];
               Z8ClavesRutaId = T00013_A8ClavesRutaId[0];
            }
            else
            {
               Z6CLAVES_RUTASRUTA = A6CLAVES_RUTASRUTA;
               Z7UMAPS = A7UMAPS;
               Z8ClavesRutaId = A8ClavesRutaId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1CLAVE_CATASTRAL = A1CLAVE_CATASTRAL;
            Z6CLAVES_RUTASRUTA = A6CLAVES_RUTASRUTA;
            Z7UMAPS = A7UMAPS;
            Z8ClavesRutaId = A8ClavesRutaId;
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

      protected void Load015( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A1CLAVE_CATASTRAL});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound5 = 1;
            A6CLAVES_RUTASRUTA = T00014_A6CLAVES_RUTASRUTA[0];
            n6CLAVES_RUTASRUTA = T00014_n6CLAVES_RUTASRUTA[0];
            AssignAttri("", false, "A6CLAVES_RUTASRUTA", StringUtil.LTrimStr( A6CLAVES_RUTASRUTA, 18, 6));
            A7UMAPS = T00014_A7UMAPS[0];
            n7UMAPS = T00014_n7UMAPS[0];
            AssignAttri("", false, "A7UMAPS", StringUtil.LTrimStr( A7UMAPS, 18, 6));
            A8ClavesRutaId = T00014_A8ClavesRutaId[0];
            n8ClavesRutaId = T00014_n8ClavesRutaId[0];
            AssignAttri("", false, "A8ClavesRutaId", StringUtil.LTrimStr( (decimal)(A8ClavesRutaId), 9, 0));
            ZM015( -1) ;
         }
         pr_default.close(2);
         OnLoadActions015( ) ;
      }

      protected void OnLoadActions015( )
      {
      }

      protected void CheckExtendedTable015( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors015( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey015( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1CLAVE_CATASTRAL});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1CLAVE_CATASTRAL});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM015( 1) ;
            RcdFound5 = 1;
            A1CLAVE_CATASTRAL = T00013_A1CLAVE_CATASTRAL[0];
            AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
            A6CLAVES_RUTASRUTA = T00013_A6CLAVES_RUTASRUTA[0];
            n6CLAVES_RUTASRUTA = T00013_n6CLAVES_RUTASRUTA[0];
            AssignAttri("", false, "A6CLAVES_RUTASRUTA", StringUtil.LTrimStr( A6CLAVES_RUTASRUTA, 18, 6));
            A7UMAPS = T00013_A7UMAPS[0];
            n7UMAPS = T00013_n7UMAPS[0];
            AssignAttri("", false, "A7UMAPS", StringUtil.LTrimStr( A7UMAPS, 18, 6));
            A8ClavesRutaId = T00013_A8ClavesRutaId[0];
            n8ClavesRutaId = T00013_n8ClavesRutaId[0];
            AssignAttri("", false, "A8ClavesRutaId", StringUtil.LTrimStr( (decimal)(A8ClavesRutaId), 9, 0));
            Z1CLAVE_CATASTRAL = A1CLAVE_CATASTRAL;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load015( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey015( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey015( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey015( ) ;
         if ( RcdFound5 == 0 )
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
         RcdFound5 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1CLAVE_CATASTRAL});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00016_A1CLAVE_CATASTRAL[0], A1CLAVE_CATASTRAL) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00016_A1CLAVE_CATASTRAL[0], A1CLAVE_CATASTRAL) > 0 ) ) )
            {
               A1CLAVE_CATASTRAL = T00016_A1CLAVE_CATASTRAL[0];
               AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
               RcdFound5 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1CLAVE_CATASTRAL});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00017_A1CLAVE_CATASTRAL[0], A1CLAVE_CATASTRAL) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00017_A1CLAVE_CATASTRAL[0], A1CLAVE_CATASTRAL) < 0 ) ) )
            {
               A1CLAVE_CATASTRAL = T00017_A1CLAVE_CATASTRAL[0];
               AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
               RcdFound5 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey015( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert015( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( StringUtil.StrCmp(A1CLAVE_CATASTRAL, Z1CLAVE_CATASTRAL) != 0 )
               {
                  A1CLAVE_CATASTRAL = Z1CLAVE_CATASTRAL;
                  AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLAVE_CATASTRAL");
                  AnyError = 1;
                  GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update015( ) ;
                  GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A1CLAVE_CATASTRAL, Z1CLAVE_CATASTRAL) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert015( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLAVE_CATASTRAL");
                     AnyError = 1;
                     GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert015( ) ;
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
         if ( StringUtil.StrCmp(A1CLAVE_CATASTRAL, Z1CLAVE_CATASTRAL) != 0 )
         {
            A1CLAVE_CATASTRAL = Z1CLAVE_CATASTRAL;
            AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLAVE_CATASTRAL");
            AnyError = 1;
            GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLAVE_CATASTRAL");
            AnyError = 1;
            GX_FocusControl = edtCLAVE_CATASTRAL_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCLAVES_RUTASRUTA_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart015( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAVES_RUTASRUTA_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd015( ) ;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAVES_RUTASRUTA_Internalname;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAVES_RUTASRUTA_Internalname;
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
         ScanStart015( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound5 != 0 )
            {
               ScanNext015( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAVES_RUTASRUTA_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd015( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency015( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1CLAVE_CATASTRAL});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLAVES_RUTAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z6CLAVES_RUTASRUTA != T00012_A6CLAVES_RUTASRUTA[0] ) || ( Z7UMAPS != T00012_A7UMAPS[0] ) || ( Z8ClavesRutaId != T00012_A8ClavesRutaId[0] ) )
            {
               if ( Z6CLAVES_RUTASRUTA != T00012_A6CLAVES_RUTASRUTA[0] )
               {
                  GXUtil.WriteLog("claves_rutas:[seudo value changed for attri]"+"CLAVES_RUTASRUTA");
                  GXUtil.WriteLogRaw("Old: ",Z6CLAVES_RUTASRUTA);
                  GXUtil.WriteLogRaw("Current: ",T00012_A6CLAVES_RUTASRUTA[0]);
               }
               if ( Z7UMAPS != T00012_A7UMAPS[0] )
               {
                  GXUtil.WriteLog("claves_rutas:[seudo value changed for attri]"+"UMAPS");
                  GXUtil.WriteLogRaw("Old: ",Z7UMAPS);
                  GXUtil.WriteLogRaw("Current: ",T00012_A7UMAPS[0]);
               }
               if ( Z8ClavesRutaId != T00012_A8ClavesRutaId[0] )
               {
                  GXUtil.WriteLog("claves_rutas:[seudo value changed for attri]"+"ClavesRutaId");
                  GXUtil.WriteLogRaw("Old: ",Z8ClavesRutaId);
                  GXUtil.WriteLogRaw("Current: ",T00012_A8ClavesRutaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLAVES_RUTAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert015( )
      {
         BeforeValidate015( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable015( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM015( 0) ;
            CheckOptimisticConcurrency015( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm015( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert015( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {A1CLAVE_CATASTRAL, n6CLAVES_RUTASRUTA, A6CLAVES_RUTASRUTA, n7UMAPS, A7UMAPS, n8ClavesRutaId, A8ClavesRutaId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("CLAVES_RUTAS");
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
                           ResetCaption010( ) ;
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
               Load015( ) ;
            }
            EndLevel015( ) ;
         }
         CloseExtendedTableCursors015( ) ;
      }

      protected void Update015( )
      {
         BeforeValidate015( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable015( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency015( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm015( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate015( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {n6CLAVES_RUTASRUTA, A6CLAVES_RUTASRUTA, n7UMAPS, A7UMAPS, n8ClavesRutaId, A8ClavesRutaId, A1CLAVE_CATASTRAL});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("CLAVES_RUTAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLAVES_RUTAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate015( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption010( ) ;
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
            EndLevel015( ) ;
         }
         CloseExtendedTableCursors015( ) ;
      }

      protected void DeferredUpdate015( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate015( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency015( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls015( ) ;
            AfterConfirm015( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete015( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000110 */
                  pr_default.execute(8, new Object[] {A1CLAVE_CATASTRAL});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("CLAVES_RUTAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound5 == 0 )
                        {
                           InitAll015( ) ;
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
                        ResetCaption010( ) ;
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel015( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls015( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel015( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete015( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("claves_rutas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("claves_rutas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart015( )
      {
         /* Using cursor T000111 */
         pr_default.execute(9);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound5 = 1;
            A1CLAVE_CATASTRAL = T000111_A1CLAVE_CATASTRAL[0];
            AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext015( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound5 = 1;
            A1CLAVE_CATASTRAL = T000111_A1CLAVE_CATASTRAL[0];
            AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
         }
      }

      protected void ScanEnd015( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm015( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert015( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate015( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete015( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete015( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate015( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes015( )
      {
         edtCLAVE_CATASTRAL_Enabled = 0;
         AssignProp("", false, edtCLAVE_CATASTRAL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAVE_CATASTRAL_Enabled), 5, 0), true);
         edtCLAVES_RUTASRUTA_Enabled = 0;
         AssignProp("", false, edtCLAVES_RUTASRUTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAVES_RUTASRUTA_Enabled), 5, 0), true);
         edtUMAPS_Enabled = 0;
         AssignProp("", false, edtUMAPS_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUMAPS_Enabled), 5, 0), true);
         edtClavesRutaId_Enabled = 0;
         AssignProp("", false, edtClavesRutaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClavesRutaId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes015( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("claves_rutas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1CLAVE_CATASTRAL", Z1CLAVE_CATASTRAL);
         GxWebStd.gx_hidden_field( context, "Z6CLAVES_RUTASRUTA", StringUtil.LTrim( StringUtil.NToC( Z6CLAVES_RUTASRUTA, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z7UMAPS", StringUtil.LTrim( StringUtil.NToC( Z7UMAPS, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8ClavesRutaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8ClavesRutaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
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
         return formatLink("claves_rutas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLAVES_RUTAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "CLAVES_RUTAS" ;
      }

      protected void InitializeNonKey015( )
      {
         A6CLAVES_RUTASRUTA = 0;
         n6CLAVES_RUTASRUTA = false;
         AssignAttri("", false, "A6CLAVES_RUTASRUTA", StringUtil.LTrimStr( A6CLAVES_RUTASRUTA, 18, 6));
         n6CLAVES_RUTASRUTA = ((Convert.ToDecimal(0)==A6CLAVES_RUTASRUTA) ? true : false);
         A7UMAPS = 0;
         n7UMAPS = false;
         AssignAttri("", false, "A7UMAPS", StringUtil.LTrimStr( A7UMAPS, 18, 6));
         n7UMAPS = ((Convert.ToDecimal(0)==A7UMAPS) ? true : false);
         A8ClavesRutaId = 0;
         n8ClavesRutaId = false;
         AssignAttri("", false, "A8ClavesRutaId", StringUtil.LTrimStr( (decimal)(A8ClavesRutaId), 9, 0));
         n8ClavesRutaId = ((0==A8ClavesRutaId) ? true : false);
         Z6CLAVES_RUTASRUTA = 0;
         Z7UMAPS = 0;
         Z8ClavesRutaId = 0;
      }

      protected void InitAll015( )
      {
         A1CLAVE_CATASTRAL = "";
         AssignAttri("", false, "A1CLAVE_CATASTRAL", A1CLAVE_CATASTRAL);
         InitializeNonKey015( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20243510202099", true, true);
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
         context.AddJavascriptSource("claves_rutas.js", "?2024351020210", false, true);
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
         edtCLAVE_CATASTRAL_Internalname = "CLAVE_CATASTRAL";
         edtCLAVES_RUTASRUTA_Internalname = "CLAVES_RUTASRUTA";
         edtUMAPS_Internalname = "UMAPS";
         edtClavesRutaId_Internalname = "CLAVESRUTAID";
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
         Form.Caption = "CLAVES_RUTAS";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtClavesRutaId_Jsonclick = "";
         edtClavesRutaId_Enabled = 1;
         edtUMAPS_Jsonclick = "";
         edtUMAPS_Enabled = 1;
         edtCLAVES_RUTASRUTA_Jsonclick = "";
         edtCLAVES_RUTASRUTA_Enabled = 1;
         edtCLAVE_CATASTRAL_Enabled = 1;
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
         GX_FocusControl = edtCLAVES_RUTASRUTA_Internalname;
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

      public void Valid_Clave_catastral( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A6CLAVES_RUTASRUTA", StringUtil.LTrim( StringUtil.NToC( A6CLAVES_RUTASRUTA, 18, 6, ".", "")));
         AssignAttri("", false, "A7UMAPS", StringUtil.LTrim( StringUtil.NToC( A7UMAPS, 18, 6, ".", "")));
         AssignAttri("", false, "A8ClavesRutaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8ClavesRutaId), 9, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1CLAVE_CATASTRAL", Z1CLAVE_CATASTRAL);
         GxWebStd.gx_hidden_field( context, "Z6CLAVES_RUTASRUTA", StringUtil.LTrim( StringUtil.NToC( Z6CLAVES_RUTASRUTA, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z7UMAPS", StringUtil.LTrim( StringUtil.NToC( Z7UMAPS, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8ClavesRutaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8ClavesRutaId), 9, 0, ".", "")));
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
         setEventMetadata("VALID_CLAVE_CATASTRAL","{handler:'Valid_Clave_catastral',iparms:[{av:'A1CLAVE_CATASTRAL',fld:'CLAVE_CATASTRAL',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CLAVE_CATASTRAL",",oparms:[{av:'A6CLAVES_RUTASRUTA',fld:'CLAVES_RUTASRUTA',pic:'ZZZZZZZZZZ9.999999'},{av:'A7UMAPS',fld:'UMAPS',pic:'ZZZZZZZZZZ9.999999'},{av:'A8ClavesRutaId',fld:'CLAVESRUTAID',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z1CLAVE_CATASTRAL'},{av:'Z6CLAVES_RUTASRUTA'},{av:'Z7UMAPS'},{av:'Z8ClavesRutaId'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z1CLAVE_CATASTRAL = "";
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
         A1CLAVE_CATASTRAL = "";
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
         T00014_A1CLAVE_CATASTRAL = new string[] {""} ;
         T00014_A6CLAVES_RUTASRUTA = new decimal[1] ;
         T00014_n6CLAVES_RUTASRUTA = new bool[] {false} ;
         T00014_A7UMAPS = new decimal[1] ;
         T00014_n7UMAPS = new bool[] {false} ;
         T00014_A8ClavesRutaId = new int[1] ;
         T00014_n8ClavesRutaId = new bool[] {false} ;
         T00015_A1CLAVE_CATASTRAL = new string[] {""} ;
         T00013_A1CLAVE_CATASTRAL = new string[] {""} ;
         T00013_A6CLAVES_RUTASRUTA = new decimal[1] ;
         T00013_n6CLAVES_RUTASRUTA = new bool[] {false} ;
         T00013_A7UMAPS = new decimal[1] ;
         T00013_n7UMAPS = new bool[] {false} ;
         T00013_A8ClavesRutaId = new int[1] ;
         T00013_n8ClavesRutaId = new bool[] {false} ;
         sMode5 = "";
         T00016_A1CLAVE_CATASTRAL = new string[] {""} ;
         T00017_A1CLAVE_CATASTRAL = new string[] {""} ;
         T00012_A1CLAVE_CATASTRAL = new string[] {""} ;
         T00012_A6CLAVES_RUTASRUTA = new decimal[1] ;
         T00012_n6CLAVES_RUTASRUTA = new bool[] {false} ;
         T00012_A7UMAPS = new decimal[1] ;
         T00012_n7UMAPS = new bool[] {false} ;
         T00012_A8ClavesRutaId = new int[1] ;
         T00012_n8ClavesRutaId = new bool[] {false} ;
         T000111_A1CLAVE_CATASTRAL = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1CLAVE_CATASTRAL = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.claves_rutas__default(),
            new Object[][] {
                new Object[] {
               T00012_A1CLAVE_CATASTRAL, T00012_A6CLAVES_RUTASRUTA, T00012_n6CLAVES_RUTASRUTA, T00012_A7UMAPS, T00012_n7UMAPS, T00012_A8ClavesRutaId, T00012_n8ClavesRutaId
               }
               , new Object[] {
               T00013_A1CLAVE_CATASTRAL, T00013_A6CLAVES_RUTASRUTA, T00013_n6CLAVES_RUTASRUTA, T00013_A7UMAPS, T00013_n7UMAPS, T00013_A8ClavesRutaId, T00013_n8ClavesRutaId
               }
               , new Object[] {
               T00014_A1CLAVE_CATASTRAL, T00014_A6CLAVES_RUTASRUTA, T00014_n6CLAVES_RUTASRUTA, T00014_A7UMAPS, T00014_n7UMAPS, T00014_A8ClavesRutaId, T00014_n8ClavesRutaId
               }
               , new Object[] {
               T00015_A1CLAVE_CATASTRAL
               }
               , new Object[] {
               T00016_A1CLAVE_CATASTRAL
               }
               , new Object[] {
               T00017_A1CLAVE_CATASTRAL
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000111_A1CLAVE_CATASTRAL
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound5 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z8ClavesRutaId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCLAVE_CATASTRAL_Enabled ;
      private int edtCLAVES_RUTASRUTA_Enabled ;
      private int edtUMAPS_Enabled ;
      private int A8ClavesRutaId ;
      private int edtClavesRutaId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ8ClavesRutaId ;
      private decimal Z6CLAVES_RUTASRUTA ;
      private decimal Z7UMAPS ;
      private decimal A6CLAVES_RUTASRUTA ;
      private decimal A7UMAPS ;
      private decimal ZZ6CLAVES_RUTASRUTA ;
      private decimal ZZ7UMAPS ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCLAVE_CATASTRAL_Internalname ;
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
      private string edtCLAVES_RUTASRUTA_Internalname ;
      private string edtCLAVES_RUTASRUTA_Jsonclick ;
      private string edtUMAPS_Internalname ;
      private string edtUMAPS_Jsonclick ;
      private string edtClavesRutaId_Internalname ;
      private string edtClavesRutaId_Jsonclick ;
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
      private string sMode5 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n6CLAVES_RUTASRUTA ;
      private bool n7UMAPS ;
      private bool n8ClavesRutaId ;
      private string Z1CLAVE_CATASTRAL ;
      private string A1CLAVE_CATASTRAL ;
      private string ZZ1CLAVE_CATASTRAL ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00014_A1CLAVE_CATASTRAL ;
      private decimal[] T00014_A6CLAVES_RUTASRUTA ;
      private bool[] T00014_n6CLAVES_RUTASRUTA ;
      private decimal[] T00014_A7UMAPS ;
      private bool[] T00014_n7UMAPS ;
      private int[] T00014_A8ClavesRutaId ;
      private bool[] T00014_n8ClavesRutaId ;
      private string[] T00015_A1CLAVE_CATASTRAL ;
      private string[] T00013_A1CLAVE_CATASTRAL ;
      private decimal[] T00013_A6CLAVES_RUTASRUTA ;
      private bool[] T00013_n6CLAVES_RUTASRUTA ;
      private decimal[] T00013_A7UMAPS ;
      private bool[] T00013_n7UMAPS ;
      private int[] T00013_A8ClavesRutaId ;
      private bool[] T00013_n8ClavesRutaId ;
      private string[] T00016_A1CLAVE_CATASTRAL ;
      private string[] T00017_A1CLAVE_CATASTRAL ;
      private string[] T00012_A1CLAVE_CATASTRAL ;
      private decimal[] T00012_A6CLAVES_RUTASRUTA ;
      private bool[] T00012_n6CLAVES_RUTASRUTA ;
      private decimal[] T00012_A7UMAPS ;
      private bool[] T00012_n7UMAPS ;
      private int[] T00012_A8ClavesRutaId ;
      private bool[] T00012_n8ClavesRutaId ;
      private string[] T000111_A1CLAVE_CATASTRAL ;
      private GXWebForm Form ;
   }

   public class claves_rutas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0) ,
          new ParDef("@CLAVES_RUTASRUTA",GXType.Decimal,18,6){Nullable=true} ,
          new ParDef("@UMAPS",GXType.Decimal,18,6){Nullable=true} ,
          new ParDef("@ClavesRutaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@CLAVES_RUTASRUTA",GXType.Decimal,18,6){Nullable=true} ,
          new ParDef("@UMAPS",GXType.Decimal,18,6){Nullable=true} ,
          new ParDef("@ClavesRutaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [CLAVE_CATASTRAL], [RUTA], [UMAPS], [ClavesRutaId] FROM dbo.[CLAVES_RUTAS] WITH (UPDLOCK) WHERE [CLAVE_CATASTRAL] = @CLAVE_CATASTRAL ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [CLAVE_CATASTRAL], [RUTA], [UMAPS], [ClavesRutaId] FROM dbo.[CLAVES_RUTAS] WHERE [CLAVE_CATASTRAL] = @CLAVE_CATASTRAL ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT TM1.[CLAVE_CATASTRAL], TM1.[RUTA], TM1.[UMAPS], TM1.[ClavesRutaId] FROM dbo.[CLAVES_RUTAS] TM1 WHERE TM1.[CLAVE_CATASTRAL] = @CLAVE_CATASTRAL ORDER BY TM1.[CLAVE_CATASTRAL]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [CLAVE_CATASTRAL] FROM dbo.[CLAVES_RUTAS] WHERE [CLAVE_CATASTRAL] = @CLAVE_CATASTRAL  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT TOP 1 [CLAVE_CATASTRAL] FROM dbo.[CLAVES_RUTAS] WHERE ( [CLAVE_CATASTRAL] > @CLAVE_CATASTRAL) ORDER BY [CLAVE_CATASTRAL]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00017", "SELECT TOP 1 [CLAVE_CATASTRAL] FROM dbo.[CLAVES_RUTAS] WHERE ( [CLAVE_CATASTRAL] < @CLAVE_CATASTRAL) ORDER BY [CLAVE_CATASTRAL] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00018", "INSERT INTO dbo.[CLAVES_RUTAS]([CLAVE_CATASTRAL], [RUTA], [UMAPS], [ClavesRutaId]) VALUES(@CLAVE_CATASTRAL, @CLAVES_RUTASRUTA, @UMAPS, @ClavesRutaId)", GxErrorMask.GX_NOMASK,prmT00018)
             ,new CursorDef("T00019", "UPDATE dbo.[CLAVES_RUTAS] SET [RUTA]=@CLAVES_RUTASRUTA, [UMAPS]=@UMAPS, [ClavesRutaId]=@ClavesRutaId  WHERE [CLAVE_CATASTRAL] = @CLAVE_CATASTRAL", GxErrorMask.GX_NOMASK,prmT00019)
             ,new CursorDef("T000110", "DELETE FROM dbo.[CLAVES_RUTAS]  WHERE [CLAVE_CATASTRAL] = @CLAVE_CATASTRAL", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "SELECT [CLAVE_CATASTRAL] FROM dbo.[CLAVES_RUTAS] ORDER BY [CLAVE_CATASTRAL]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
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
