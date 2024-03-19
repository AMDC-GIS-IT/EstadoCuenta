gx.evt.autoSkip = false;
gx.define('general.ui.masterprompt', false, function () {
   this.ServerClass =  "general.ui.masterprompt" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "general.ui.masterprompt.aspx" ;
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
   };
   this.e12022_client=function()
   {
      return this.executeServerEvent("ENTER_MPAGE", true, null, false, false);
   };
   this.e13022_client=function()
   {
      return this.executeServerEvent("CANCEL_MPAGE", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5];
   this.GXLastCtrlId =5;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   this.Events = {"e12022_client": ["ENTER_MPAGE", true] ,"e13022_client": ["CANCEL_MPAGE", true]};
   this.EvtParms["REFRESH_MPAGE"] = [[],[]];
   this.EvtParms["ENTER_MPAGE"] = [[],[]];
   this.Initialize( );
});
gx.wi( function() { gx.createMasterPage(general.ui.masterprompt);});
