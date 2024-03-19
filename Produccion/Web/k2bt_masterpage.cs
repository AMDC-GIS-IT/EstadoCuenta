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
   public class k2bt_masterpage : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public k2bt_masterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public k2bt_masterpage( IGxContext context )
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            PA2T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2T2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE2T2( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vMENUITEMS_MPAGE", AV6MenuItems);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENUITEMS_MPAGE", AV6MenuItems);
         }
         GxWebStd.gx_hidden_field( context, "K2BHORIZONTALMENU1_MPAGE_Expanddirection", StringUtil.RTrim( K2bhorizontalmenu1_Expanddirection));
         GxWebStd.gx_hidden_field( context, "K2BACCORDIONMENU_MPAGE_Includesearch", StringUtil.BoolToStr( K2baccordionmenu_Includesearch));
         GxWebStd.gx_hidden_field( context, "MENUCONTAINER_MPAGE_Class", StringUtil.RTrim( divMenucontainer_Class));
         GxWebStd.gx_hidden_field( context, "MENUTOGGLE_MPAGE_Class", StringUtil.RTrim( bttMenutoggle_Class));
      }

      protected void RenderHtmlCloseForm2T2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( ! ( WebComp_Notificationscomponent == null ) )
         {
            WebComp_Notificationscomponent.componentjscripts();
         }
         if ( ! ( WebComp_Uiconfiguration == null ) )
         {
            WebComp_Uiconfiguration.componentjscripts();
         }
         context.AddJavascriptSource("K2BHorizontalMenu/K2BHorizontalMenuRender.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/metisMenu-master/dist/metisMenu.min.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/K2BAccordionMenuRender.js", "", false, true);
         context.AddJavascriptSource("k2bt_masterpage.js", "?20243510202468", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "K2BT_MasterPage" ;
      }

      public override string GetPgmdesc( )
      {
         return "K2BTools Master Page" ;
      }

      protected void WB2T0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "MasterPage1", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection3_Internalname, 1, 0, "px", 0, "px", "K2BT_MasterPage1HeaderBackground", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHeader_Internalname, 1, 0, "px", 0, "px", "K2BHeader", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaStart", "start", "Middle", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTopstart_Internalname, 1, 0, "px", 0, "px", "K2BT_HeaderArea", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_HeaderItem", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',true,'',0)\"";
            ClassString = bttMenutoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttMenutoggle_Internalname, "", "|||", bttMenutoggle_Jsonclick, 7, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",true,"+"'"+"e112t1_client"+"'", TempTags, "", 2, "HLP_K2BT_MasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_HeaderItem", "start", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',true,'',0)\"";
            ClassString = "Image_HeaderLogo" + " " + ((StringUtil.StrCmp(imgApplicationicon_gximage, "")==0) ? "GX_Image_K2BLogotipo_Class" : "GX_Image_"+imgApplicationicon_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "bb4462ea-0eb3-44b4-8320-f971481f81b4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgApplicationicon_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgApplicationicon_Jsonclick, "'"+""+"'"+",true,"+"'"+"e122t1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BT_MasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_HeaderItem K2BT_AlignBottom", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblApplicationname_Internalname, "Estados de Cuenta", "", "", lblApplicationname_Jsonclick, "'"+""+"'"+",true,"+"'"+"e132t1_client"+"'", "", "K2BT_ApplicationName", 7, "", 1, 1, 0, 0, "HLP_K2BT_MasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "Middle", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMenuheadercontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucK2bhorizontalmenu1.SetProperty("ExpandDirection", K2bhorizontalmenu1_Expanddirection);
            ucK2bhorizontalmenu1.SetProperty("MenuItems", AV6MenuItems);
            ucK2bhorizontalmenu1.Render(context, "k2bhorizontalmenu", K2bhorizontalmenu1_Internalname, "K2BHORIZONTALMENU1_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaEnd", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTopend_Internalname, 1, 0, "px", 0, "px", "K2BT_HeaderArea", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0025"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0025"+"");
               }
               WebComp_Notificationscomponent.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0027"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0027"+"");
               }
               WebComp_Uiconfiguration.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMiddle_Internalname, 1, 0, "px", 0, "px", "MasterPage1_HorizontalMenu_ContentContainer", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMenucell_Internalname, 1, 0, "px", 0, "px", "K2BT_AreaStart", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCenterstart_Internalname, 1, 0, "px", 0, "px", "Flex K2BT_FixedMenu K2BT_MenuForMobile", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "PromptAdvancedBarCellCompact", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMenucontainer_Internalname, 1, 0, "px", 0, "px", divMenucontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucK2baccordionmenu.SetProperty("IncludeSearch", K2baccordionmenu_Includesearch);
            ucK2baccordionmenu.SetProperty("MenuItems", AV6MenuItems);
            ucK2baccordionmenu.Render(context, "k2baccordionmenu", K2baccordionmenu_Internalname, "K2BACCORDIONMENU_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_MasterPage1ContentContainer", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCentermiddle_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaEnd", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCenterend_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2T2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2T0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS2T2( )
      {
         START2T2( ) ;
         EVT2T2( ) ;
      }

      protected void EVT2T2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E142T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E152T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E162T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                              }
                              dynload_actions( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2));
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 25 )
                     {
                        WebComp_Notificationscomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.notificationsviewer", new Object[] {context} );
                        WebComp_Notificationscomponent.ComponentInit();
                        WebComp_Notificationscomponent.Name = "K2BTools.DesignSystems.Aries.NotificationsViewer";
                        WebComp_Notificationscomponent_Component = "K2BTools.DesignSystems.Aries.NotificationsViewer";
                        WebComp_Notificationscomponent.componentprocess("MPW0025", "", sEvt);
                     }
                     else if ( nCmpId == 27 )
                     {
                        WebComp_Uiconfiguration = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.uiconfiguration", new Object[] {context} );
                        WebComp_Uiconfiguration.ComponentInit();
                        WebComp_Uiconfiguration.Name = "K2BTools.DesignSystems.Aries.UIConfiguration";
                        WebComp_Uiconfiguration_Component = "K2BTools.DesignSystems.Aries.UIConfiguration";
                        WebComp_Uiconfiguration.componentprocess("MPW0027", "", sEvt);
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE2T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2T2( ) ;
            }
         }
      }

      protected void PA2T2( )
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
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         RF2T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            /* Execute user event: Refresh */
            E152T2 ();
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( StringUtil.StrCmp(WebComp_Notificationscomponent_Component, "") == 0 )
               {
                  WebComp_Notificationscomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.notificationsviewer", new Object[] {context} );
                  WebComp_Notificationscomponent.ComponentInit();
                  WebComp_Notificationscomponent.Name = "K2BTools.DesignSystems.Aries.NotificationsViewer";
                  WebComp_Notificationscomponent_Component = "K2BTools.DesignSystems.Aries.NotificationsViewer";
               }
               WebComp_Notificationscomponent.setjustcreated();
               WebComp_Notificationscomponent.componentprepare(new Object[] {(string)"MPW0025",(string)""});
               WebComp_Notificationscomponent.componentbind(new Object[] {});
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Notificationscomponent )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0025"+"");
                  WebComp_Notificationscomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               if ( 1 != 0 )
               {
                  WebComp_Notificationscomponent.componentstart();
               }
            }
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( StringUtil.StrCmp(WebComp_Uiconfiguration_Component, "") == 0 )
               {
                  WebComp_Uiconfiguration = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.uiconfiguration", new Object[] {context} );
                  WebComp_Uiconfiguration.ComponentInit();
                  WebComp_Uiconfiguration.Name = "K2BTools.DesignSystems.Aries.UIConfiguration";
                  WebComp_Uiconfiguration_Component = "K2BTools.DesignSystems.Aries.UIConfiguration";
               }
               WebComp_Uiconfiguration.setjustcreated();
               WebComp_Uiconfiguration.componentprepare(new Object[] {(string)"MPW0027",(string)""});
               WebComp_Uiconfiguration.componentbind(new Object[] {});
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Uiconfiguration )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0027"+"");
                  WebComp_Uiconfiguration.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               if ( 1 != 0 )
               {
                  WebComp_Uiconfiguration.componentstart();
               }
            }
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E162T2 ();
            WB2T0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes2T2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E142T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMENUITEMS_MPAGE"), AV6MenuItems);
            /* Read saved values. */
            K2bhorizontalmenu1_Expanddirection = cgiGet( "K2BHORIZONTALMENU1_MPAGE_Expanddirection");
            K2baccordionmenu_Includesearch = StringUtil.StrToBool( cgiGet( "K2BACCORDIONMENU_MPAGE_Includesearch"));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E142T2 ();
         if (returnInSub) return;
      }

      protected void E142T2( )
      {
         /* Start Routine */
         returnInSub = false;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta.addItem("viewport", "width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0", 0) ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta.addItem("apple-mobile-web-app-capable", "yes", 0) ;
         AV8GXV2 = 1;
         GXt_objcol_SdtK2BAttributeValue_Item1 = AV7GXV1;
         new GeneXus.Programs.k2btools.getdesignsystemoptions(context ).execute( out  GXt_objcol_SdtK2BAttributeValue_Item1) ;
         AV7GXV1 = GXt_objcol_SdtK2BAttributeValue_Item1;
         while ( AV8GXV2 <= AV7GXV1.Count )
         {
            AV5DesignSystemOption = ((SdtK2BAttributeValue_Item)AV7GXV1.Item(AV8GXV2));
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {AV5DesignSystemOption.gxTpr_Attributename,AV5DesignSystemOption.gxTpr_Attributevalue}, false);
            AV8GXV2 = (int)(AV8GXV2+1);
         }
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2 = AV6MenuItems;
         new k2bgetusermenu(context ).execute( out  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2) ;
         AV6MenuItems = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2;
      }

      protected void E152T2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( ! new k2bisauthenticated(context).executeUdp( ) )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim("None")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E162T2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA2T2( ) ;
         WS2T2( ) ;
         WE2T2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("shared/fontawesome-free-5.1.1-web/css/all.css", "");
         AddStyleSheetFile("shared/fontawesome-free-5.1.1-web/css/all.css", "");
         AddStyleSheetFile("K2BHorizontalMenu/css/K2BHorizontalMenu.css", "");
         AddStyleSheetFile("K2BAccordionMenu/metisMenu-master/dist/metisMenu.min.css", "");
         AddStyleSheetFile("K2BAccordionMenu/k2btoolsresources/metisFolder.css", "");
         AddStyleSheetFile("K2BAccordionMenu/k2btoolsresources/defaultTheme.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( StringUtil.StrCmp(WebComp_Notificationscomponent_Component, "") == 0 )
         {
            WebComp_Notificationscomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.notificationsviewer", new Object[] {context} );
            WebComp_Notificationscomponent.ComponentInit();
            WebComp_Notificationscomponent.Name = "K2BTools.DesignSystems.Aries.NotificationsViewer";
            WebComp_Notificationscomponent_Component = "K2BTools.DesignSystems.Aries.NotificationsViewer";
         }
         if ( ! ( WebComp_Notificationscomponent == null ) )
         {
            WebComp_Notificationscomponent.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Uiconfiguration_Component, "") == 0 )
         {
            WebComp_Uiconfiguration = getWebComponent(GetType(), "GeneXus.Programs", "k2btools.designsystems.aries.uiconfiguration", new Object[] {context} );
            WebComp_Uiconfiguration.ComponentInit();
            WebComp_Uiconfiguration.Name = "K2BTools.DesignSystems.Aries.UIConfiguration";
            WebComp_Uiconfiguration_Component = "K2BTools.DesignSystems.Aries.UIConfiguration";
         }
         if ( ! ( WebComp_Uiconfiguration == null ) )
         {
            WebComp_Uiconfiguration.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?20243510202476", true, true);
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
         context.AddJavascriptSource("k2bt_masterpage.js", "?20243510202476", false, true);
         context.AddJavascriptSource("K2BHorizontalMenu/K2BHorizontalMenuRender.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/metisMenu-master/dist/metisMenu.min.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/K2BAccordionMenuRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divSection3_Internalname = "SECTION3_MPAGE";
         bttMenutoggle_Internalname = "MENUTOGGLE_MPAGE";
         imgApplicationicon_Internalname = "APPLICATIONICON_MPAGE";
         lblApplicationname_Internalname = "APPLICATIONNAME_MPAGE";
         divTopstart_Internalname = "TOPSTART_MPAGE";
         K2bhorizontalmenu1_Internalname = "K2BHORIZONTALMENU1_MPAGE";
         divMenuheadercontainer_Internalname = "MENUHEADERCONTAINER_MPAGE";
         divTable2_Internalname = "TABLE2_MPAGE";
         divTopend_Internalname = "TOPEND_MPAGE";
         divHeader_Internalname = "HEADER_MPAGE";
         K2baccordionmenu_Internalname = "K2BACCORDIONMENU_MPAGE";
         divMenucontainer_Internalname = "MENUCONTAINER_MPAGE";
         divCenterstart_Internalname = "CENTERSTART_MPAGE";
         divMenucell_Internalname = "MENUCELL_MPAGE";
         divCentermiddle_Internalname = "CENTERMIDDLE_MPAGE";
         divCenterend_Internalname = "CENTEREND_MPAGE";
         divMiddle_Internalname = "MIDDLE_MPAGE";
         divTable1_Internalname = "TABLE1_MPAGE";
         divSection2_Internalname = "SECTION2_MPAGE";
         divMaintable_Internalname = "MAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         bttMenutoggle_Class = "K2BToolsButton_BtnToggle InvisibleInSmallButton InvisibleInMediumButton InvisibleInLargeButton";
         divMenucontainer_Class = "K2BToolsMenuContainer";
         K2baccordionmenu_Includesearch = Convert.ToBoolean( 0);
         K2bhorizontalmenu1_Expanddirection = "Down";
         Contentholder.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[]}");
         setEventMetadata("TOGGLEMENU_MPAGE","{handler:'E112T1',iparms:[{av:'divMenucontainer_Class',ctrl:'MENUCONTAINER_MPAGE',prop:'Class'},{ctrl:'MENUTOGGLE_MPAGE',prop:'Class'}]");
         setEventMetadata("TOGGLEMENU_MPAGE",",oparms:[{av:'divMenucontainer_Class',ctrl:'MENUCONTAINER_MPAGE',prop:'Class'},{ctrl:'MENUTOGGLE_MPAGE',prop:'Class'}]}");
         setEventMetadata("APPLICATIONICON_MPAGE.CLICK_MPAGE","{handler:'E122T1',iparms:[]");
         setEventMetadata("APPLICATIONICON_MPAGE.CLICK_MPAGE",",oparms:[]}");
         setEventMetadata("APPLICATIONNAME_MPAGE.CLICK_MPAGE","{handler:'E132T1',iparms:[]");
         setEventMetadata("APPLICATIONNAME_MPAGE.CLICK_MPAGE",",oparms:[]}");
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
         Contentholder = new GXDataAreaControl();
         GXKey = "";
         AV6MenuItems = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "EstadoCuenta");
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttMenutoggle_Jsonclick = "";
         imgApplicationicon_gximage = "";
         sImgUrl = "";
         imgApplicationicon_Jsonclick = "";
         lblApplicationname_Jsonclick = "";
         ucK2bhorizontalmenu1 = new GXUserControl();
         ucK2baccordionmenu = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         WebComp_Notificationscomponent_Component = "";
         WebComp_Uiconfiguration_Component = "";
         AV7GXV1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "EstadoCuenta");
         GXt_objcol_SdtK2BAttributeValue_Item1 = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "EstadoCuenta");
         AV5DesignSystemOption = new SdtK2BAttributeValue_Item(context);
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "EstadoCuenta");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         WebComp_Notificationscomponent = new GeneXus.Http.GXNullWebComponent();
         WebComp_Uiconfiguration = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int AV8GXV2 ;
      private int idxLst ;
      private string divMenucontainer_Class ;
      private string bttMenutoggle_Class ;
      private string GXKey ;
      private string K2bhorizontalmenu1_Expanddirection ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divSection2_Internalname ;
      private string divSection3_Internalname ;
      private string divTable1_Internalname ;
      private string divHeader_Internalname ;
      private string divTopstart_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttMenutoggle_Internalname ;
      private string bttMenutoggle_Jsonclick ;
      private string imgApplicationicon_gximage ;
      private string sImgUrl ;
      private string imgApplicationicon_Internalname ;
      private string imgApplicationicon_Jsonclick ;
      private string lblApplicationname_Internalname ;
      private string lblApplicationname_Jsonclick ;
      private string divMenuheadercontainer_Internalname ;
      private string K2bhorizontalmenu1_Internalname ;
      private string divTopend_Internalname ;
      private string divTable2_Internalname ;
      private string divMiddle_Internalname ;
      private string divMenucell_Internalname ;
      private string divCenterstart_Internalname ;
      private string divMenucontainer_Internalname ;
      private string K2baccordionmenu_Internalname ;
      private string divCentermiddle_Internalname ;
      private string divCenterend_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string WebComp_Notificationscomponent_Component ;
      private string WebComp_Uiconfiguration_Component ;
      private string sDynURL ;
      private bool K2baccordionmenu_Includesearch ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool bDynCreated_Notificationscomponent ;
      private bool bDynCreated_Uiconfiguration ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXWebComponent WebComp_Notificationscomponent ;
      private GXWebComponent WebComp_Uiconfiguration ;
      private GXUserControl ucK2bhorizontalmenu1 ;
      private GXUserControl ucK2baccordionmenu ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV7GXV1 ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> GXt_objcol_SdtK2BAttributeValue_Item1 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV6MenuItems ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem2 ;
      private GXWebForm Form ;
      private SdtK2BAttributeValue_Item AV5DesignSystemOption ;
   }

}
