gx.evt.autoSkip=!1;gx.define("k2btools.designsystems.aries.masterpage5_verticalmenu",!1,function(){var n,t;this.ServerClass="k2btools.designsystems.aries.masterpage5_verticalmenu";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2btools.designsystems.aries.masterpage5_verticalmenu.aspx";this.setObjectType("web");this.IsMasterPage=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="K2BToolsDesignSystemsAriesAries";this.SetStandaloneVars=function(){this.AV17Pgmname=gx.fn.getControlValue("vPGMNAME_MPAGE")};this.e160y1_client=function(){return this.clearMessages(),this.call("k2btools.designsystems.aries.searchresult.aspx",[this.AV9SearchCriteria,""],null,["SearchCriteriaIn","EntityName"]),this.refreshOutputs([{av:"AV9SearchCriteria",fld:"vSEARCHCRITERIA_MPAGE",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110y1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("CENTERSTART_MPAGE","Class"),"K2BT_FixedMenu")==0?gx.fn.setCtrlProperty("CENTERSTART_MPAGE","Class","K2BT_FixedMenu K2BT_FixedMenuOpen"):gx.fn.setCtrlProperty("CENTERSTART_MPAGE","Class","K2BT_FixedMenu"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CENTERSTART_MPAGE","Class")',ctrl:"CENTERSTART_MPAGE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140y1_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("MYACCOUNTMENU_MPAGE","Visible")==!1?gx.fn.setCtrlProperty("MYACCOUNTMENU_MPAGE","Visible",!0):gx.fn.setCtrlProperty("MYACCOUNTMENU_MPAGE","Visible",!1),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("MYACCOUNTMENU_MPAGE","Visible")',ctrl:"MYACCOUNTMENU_MPAGE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150y1_client=function(){return this.clearMessages(),this.call("k2bchangepassword.aspx",[],null,[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120y1_client=function(){return this.clearMessages(),this.call("k2bhome.aspx",[],null,[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130y1_client=function(){return this.clearMessages(),this.call("k2bhome.aspx",[],null,[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e190y2_client=function(){return this.executeServerEvent("SIGNOUT_MPAGE",!0,null,!1,!1)};this.e210y2_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e220y2_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,55,57,59,60,61];this.GXLastCtrlId=61;this.K2BACCORDIONMENU_MPAGEContainer=gx.uc.getNew(this,37,23,"K2BAccordionMenu","K2BACCORDIONMENU_MPAGEContainer","K2baccordionmenu","K2BACCORDIONMENU_MPAGE");t=this.K2BACCORDIONMENU_MPAGEContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("IncludeSearch","Includesearch",!1,"bool");t.setProp("SearchInviteMessage","Searchinvitemessage","Search","str");t.setProp("Toggle","Toggle",!0,"bool");t.setProp("DoubleTapGo","Doubletapgo",!1,"bool");t.addV2CFunction("AV6MenuItems","vMENUITEMS_MPAGE","SetMenuItems");t.addC2VFunction(function(n){n.ParentObject.AV6MenuItems=n.GetMenuItems();gx.fn.setControlValue("vMENUITEMS_MPAGE",n.ParentObject.AV6MenuItems)});t.setProp("SelectedItem","Selecteditem","","str");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"SECTION2",grid:0};n[6]={id:6,fld:"TABLE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"MIDDLE",grid:0};n[9]={id:9,fld:"MENUCELL",grid:0};n[10]={id:10,fld:"CENTERSTART",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TOGGLEMENU",grid:0,evt:"e110y1_client"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BEFOREMENUSECTION",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"APPLICATIONICON",grid:0,evt:"e120y1_client"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"APPLICATIONNAME",format:0,grid:0,evt:"e130y1_client",ctrltype:"textblock"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"MYACCOUNT",grid:0};n[21]={id:21,fld:"USERINITIALSTEXTBLOCKSMALL",format:0,grid:0,evt:"e140y1_client",ctrltype:"textblock"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERAVATARSMALL_MPAGE",fmt:0,gxz:"ZV12UserAvatarSmall",gxold:"OV12UserAvatarSmall",gxvar:"AV12UserAvatarSmall",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12UserAvatarSmall=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12UserAvatarSmall=n)},v2c:function(){gx.fn.setMultimediaValue("vUSERAVATARSMALL_MPAGE",gx.O.AV12UserAvatarSmall,gx.O.AV18Useravatarsmall_GXI)},c2v:function(){gx.O.AV18Useravatarsmall_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV12UserAvatarSmall=this.val())},val:function(){return gx.fn.getBlobValue("vUSERAVATARSMALL_MPAGE")},val_GXI:function(){return gx.fn.getControlValue("vUSERAVATARSMALL_GXI_MPAGE")},gxvar_GXI:"AV18Useravatarsmall_GXI",nac:gx.falseFn,evt:"e140y1_client"};n[24]={id:24,fld:"USERNAMETEXTBLOCK",format:0,grid:0,evt:"e140y1_client",ctrltype:"textblock"};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"MYACCOUNTMENU",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"CHANGEPASSWORD",format:0,grid:0,evt:"e150y1_client",ctrltype:"textblock"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"SIGNOUT",format:0,grid:0,evt:"e190y2_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"MENUCONTAINER",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"CENTERMIDDLE",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"HEADER",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"TOPMIDDLE",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"MENUTOGGLE",grid:0,evt:"e110y1_client"};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"UNIVERSALSEARCH",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"char",len:150,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSEARCHCRITERIA_MPAGE",fmt:0,gxz:"ZV9SearchCriteria",gxold:"OV9SearchCriteria",gxvar:"AV9SearchCriteria",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9SearchCriteria=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9SearchCriteria=n)},v2c:function(){gx.fn.setControlValue("vSEARCHCRITERIA_MPAGE",gx.O.AV9SearchCriteria,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV9SearchCriteria=this.val())},val:function(){return gx.fn.getControlValue("vSEARCHCRITERIA_MPAGE")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"IMAGE2",grid:0,evt:"e160y1_client"};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"TOPEND",grid:0};n[53]={id:53,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[59]={id:59,fld:"FOOTERCONTAINER",grid:0};n[60]={id:60,fld:"FOOTERCONTENTS",grid:0};n[61]={id:61,fld:"",grid:0};this.AV18Useravatarsmall_GXI="";this.AV12UserAvatarSmall="";this.ZV12UserAvatarSmall="";this.OV12UserAvatarSmall="";this.AV9SearchCriteria="";this.ZV9SearchCriteria="";this.OV9SearchCriteria="";this.AV12UserAvatarSmall="";this.AV6MenuItems=[];this.AV9SearchCriteria="";this.AV17Pgmname="";this.Events={e190y2_client:["SIGNOUT_MPAGE",!0],e210y2_client:["ENTER_MPAGE",!0],e220y2_client:["CANCEL_MPAGE",!0],e160y1_client:["DOSEARCH_MPAGE",!1],e110y1_client:["TOGGLEMENU_MPAGE",!1],e140y1_client:["OPENTABLE_MPAGE",!1],e150y1_client:["CHANGEPASSWORD_MPAGE",!1],e120y1_client:["APPLICATIONICON_MPAGE.CLICK_MPAGE",!1],e130y1_client:["APPLICATIONNAME_MPAGE.CLICK_MPAGE",!1]};this.EvtParms.REFRESH_MPAGE=[[{av:"AV17Pgmname",fld:"vPGMNAME_MPAGE",pic:"",hsh:!0}],[{av:"AV9SearchCriteria",fld:"vSEARCHCRITERIA_MPAGE",pic:""}]];this.EvtParms.DOSEARCH_MPAGE=[[{av:"AV9SearchCriteria",fld:"vSEARCHCRITERIA_MPAGE",pic:""}],[{av:"AV9SearchCriteria",fld:"vSEARCHCRITERIA_MPAGE",pic:""}]];this.EvtParms.TOGGLEMENU_MPAGE=[[{av:'gx.fn.getCtrlProperty("CENTERSTART_MPAGE","Class")',ctrl:"CENTERSTART_MPAGE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("CENTERSTART_MPAGE","Class")',ctrl:"CENTERSTART_MPAGE",prop:"Class"}]];this.EvtParms.OPENTABLE_MPAGE=[[{av:'gx.fn.getCtrlProperty("MYACCOUNTMENU_MPAGE","Visible")',ctrl:"MYACCOUNTMENU_MPAGE",prop:"Visible"}],[{av:'gx.fn.getCtrlProperty("MYACCOUNTMENU_MPAGE","Visible")',ctrl:"MYACCOUNTMENU_MPAGE",prop:"Visible"}]];this.EvtParms.CHANGEPASSWORD_MPAGE=[[],[]];this.EvtParms.SIGNOUT_MPAGE=[[],[]];this.EvtParms["APPLICATIONICON_MPAGE.CLICK_MPAGE"]=[[],[]];this.EvtParms["APPLICATIONNAME_MPAGE.CLICK_MPAGE"]=[[],[]];this.EvtParms.ENTER_MPAGE=[[],[]];this.setVCMap("AV17Pgmname","vPGMNAME_MPAGE",0,"char",129,0);this.Initialize();this.setComponent({id:"NOTIFICATIONSCOMPONENT",GXClass:"k2btools.designsystems.aries.notificationsviewer",Prefix:"MPW0054",lvl:1});this.setComponent({id:"UICONFIGURATION",GXClass:"k2btools.designsystems.aries.uiconfiguration",Prefix:"MPW0056",lvl:1});this.setComponent({id:"FOOTERCOMPONENT",GXClass:"k2btools.designsystems.aries.samplefootercomponent",Prefix:"MPW0062",lvl:1})});gx.wi(function(){gx.createMasterPage(k2btools.designsystems.aries.masterpage5_verticalmenu)})