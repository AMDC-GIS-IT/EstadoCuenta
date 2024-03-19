gx.evt.autoSkip = false;
gx.define('general.ui.masterunanimosidebar', false, function () {
   this.ServerClass =  "general.ui.masterunanimosidebar" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "general.ui.masterunanimosidebar.aspx" ;
   this.setObjectType("web");
   this.IsMasterPage=true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.DSO =  "EstadoCuenta" ;
   this.SetStandaloneVars=function()
   {
      this.AV6target=gx.fn.getControlValue("vTARGET_MPAGE") ;
   };
   this.e12011_client=function()
   {
      this.clearMessages();
      this.AV6target =  this.SIDEBARMENU_MPAGEContainer.SelectedItemTarget  ;
      this.callUrl(this.AV6target);
      this.refreshOutputs([]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e13011_client=function()
   {
      this.clearMessages();
      if ( this.SIDEBARMENU_MPAGEContainer.isCollapsed )
      {
         gx.fn.setCtrlProperty("CONTENT_MPAGE","Class", "expandible-container"+" expanded" );
      }
      else
      {
         gx.fn.setCtrlProperty("CONTENT_MPAGE","Class", "expandible-container" );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CONTENT_MPAGE","Class")',ctrl:'CONTENT_MPAGE',prop:'Class'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e14012_client=function()
   {
      return this.executeServerEvent("ENTER_MPAGE", true, null, false, false);
   };
   this.e15012_client=function()
   {
      return this.executeServerEvent("CANCEL_MPAGE", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,19,20,21,22];
   this.GXLastCtrlId =22;
   this.SIDEBARMENU_MPAGEContainer = gx.uc.getNew(this, 18, 0, "GeneXusUnanimo_Sidebar", "SIDEBARMENU_MPAGEContainer", "Sidebarmenu", "SIDEBARMENU_MPAGE");
   var SIDEBARMENU_MPAGEContainer = this.SIDEBARMENU_MPAGEContainer;
   SIDEBARMENU_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   SIDEBARMENU_MPAGEContainer.setDynProp("Title", "Title", "", "str");
   SIDEBARMENU_MPAGEContainer.setProp("Class", "Class", "ch-sidebar", "str");
   SIDEBARMENU_MPAGEContainer.setProp("FooterText", "Footertext", "", "str");
   SIDEBARMENU_MPAGEContainer.setDynProp("DistanceToTop", "Distancetotop", 0, "num");
   SIDEBARMENU_MPAGEContainer.setProp("Collapsible", "Collapsible", true, "bool");
   SIDEBARMENU_MPAGEContainer.addV2CFunction('AV5sidebarItems', "vSIDEBARITEMS_MPAGE", 'setSidebarItems');
   SIDEBARMENU_MPAGEContainer.addC2VFunction(function(UC) { UC.ParentObject.AV5sidebarItems=UC.getSidebarItems();gx.fn.setControlValue("vSIDEBARITEMS_MPAGE",UC.ParentObject.AV5sidebarItems); });
   SIDEBARMENU_MPAGEContainer.setProp("SidebarItemsCurrentIndex", "Sidebaritemscurrentindex", 0, "num");
   SIDEBARMENU_MPAGEContainer.setProp("ActiveItemId", "Activeitemid", "", "str");
   SIDEBARMENU_MPAGEContainer.setProp("SelectedItemTarget", "Selecteditemtarget", "", "str");
   SIDEBARMENU_MPAGEContainer.setProp("isCollapsed", "Iscollapsed", false, "bool");
   SIDEBARMENU_MPAGEContainer.setProp("IconAutoColor", "Iconautocolor", false, "bool");
   SIDEBARMENU_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   SIDEBARMENU_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   SIDEBARMENU_MPAGEContainer.addEventHandler("ItemClick", this.e12011_client);
   SIDEBARMENU_MPAGEContainer.addEventHandler("GetState", this.e13011_client);
   this.setUserControl(SIDEBARMENU_MPAGEContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"HEADER",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"IMAGE2",grid:0};
   GXValidFnc[9]={ id: 9, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"IMAGE1",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"APPLICATIONHEADER", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"TABLESIDEBARCONTAINER",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"CONTENT",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   this.AV5sidebarItems = [ ] ;
   this.AV6target = "" ;
   this.Events = {"e14012_client": ["ENTER_MPAGE", true] ,"e15012_client": ["CANCEL_MPAGE", true] ,"e12011_client": ["SIDEBARMENU_MPAGE.ITEMCLICK_MPAGE", false] ,"e13011_client": ["SIDEBARMENU_MPAGE.GETSTATE_MPAGE", false]};
   this.EvtParms["REFRESH_MPAGE"] = [[],[]];
   this.EvtParms["SIDEBARMENU_MPAGE.ITEMCLICK_MPAGE"] = [[{av:'this.SIDEBARMENU_MPAGEContainer.SelectedItemTarget',ctrl:'SIDEBARMENU_MPAGE',prop:'SelectedItemTarget'}],[]];
   this.EvtParms["SIDEBARMENU_MPAGE.GETSTATE_MPAGE"] = [[{av:'this.SIDEBARMENU_MPAGEContainer.isCollapsed',ctrl:'SIDEBARMENU_MPAGE',prop:'isCollapsed'}],[{av:'gx.fn.getCtrlProperty("CONTENT_MPAGE","Class")',ctrl:'CONTENT_MPAGE',prop:'Class'}]];
   this.EvtParms["ENTER_MPAGE"] = [[],[]];
   this.setVCMap("AV6target", "vTARGET_MPAGE", 0, "svchar", 1000, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createMasterPage(general.ui.masterunanimosidebar);});
