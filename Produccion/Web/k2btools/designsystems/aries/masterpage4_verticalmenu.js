gx.evt.autoSkip=!1;gx.define("k2btools.designsystems.aries.masterpage4_verticalmenu",!1,function(){var n,t;this.ServerClass="k2btools.designsystems.aries.masterpage4_verticalmenu";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2btools.designsystems.aries.masterpage4_verticalmenu.aspx";this.setObjectType("web");this.IsMasterPage=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="K2BToolsDesignSystemsAriesAries";this.SetStandaloneVars=function(){this.AV17Pgmname=gx.fn.getControlValue("vPGMNAME_MPAGE")};this.e14101_client=function(){return this.clearMessages(),this.call("k2btools.designsystems.aries.searchresult.aspx",[this.AV9SearchCriteria,""],null,["SearchCriteriaIn","EntityName"]),this.refreshOutputs([{av:"AV9SearchCriteria",fld:"vSEARCHCRITERIA_MPAGE",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11101_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("MAINTABLE_MPAGE","Class"),"MasterPage4")==0?gx.fn.setCtrlProperty("MAINTABLE_MPAGE","Class","MasterPage4 K2BT_FixedMenuCollapsed"):gx.fn.setCtrlProperty("MAINTABLE_MPAGE","Class","MasterPage4"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("MAINTABLE_MPAGE","Class")',ctrl:"MAINTABLE_MPAGE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15101_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("MYACCOUNTMENU_MPAGE","Visible")==!1?gx.fn.setCtrlProperty("MYACCOUNTMENU_MPAGE","Visible",!0):gx.fn.setCtrlProperty("MYACCOUNTMENU_MPAGE","Visible",!1),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("MYACCOUNTMENU_MPAGE","Visible")',ctrl:"MYACCOUNTMENU_MPAGE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e16101_client=function(){return this.clearMessages(),this.call("k2bchangepassword.aspx",[],null,[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12101_client=function(){return this.clearMessages(),this.call("k2bhome.aspx",[],null,[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13101_client=function(){return this.clearMessages(),this.call("k2bhome.aspx",[],null,[]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e19102_client=function(){return this.executeServerEvent("SIGNOUT_MPAGE",!0,null,!1,!1)};this.e21102_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e22102_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,28,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,59,60,61,62,63,65,66,67];this.GXLastCtrlId=67;this.K2BACCORDIONMENU_MPAGEContainer=gx.uc.getNew(this,58,24,"K2BAccordionMenu","K2BACCORDIONMENU_MPAGEContainer","K2baccordionmenu","K2BACCORDIONMENU_MPAGE");t=this.K2BACCORDIONMENU_MPAGEContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("IncludeSearch","Includesearch",!1,"bool");t.setProp("SearchInviteMessage","Searchinvitemessage","Search","str");t.setProp("Toggle","Toggle",!0,"bool");t.setProp("DoubleTapGo","Doubletapgo",!1,"bool");t.addV2CFunction("AV6MenuItems","vMENUITEMS_MPAGE","SetMenuItems");t.addC2VFunction(function(n){n.ParentObject.AV6MenuItems=n.GetMenuItems();gx.fn.setControlValue("vMENUITEMS_MPAGE",n.ParentObject.AV6MenuItems)});t.setProp("SelectedItem","Selecteditem","","str");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"SECTION2",grid:0};n[6]={id:6,fld:"TABLE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"HEADER",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"TABLE3",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"MENUTOGGLE",grid:0,evt:"e11101_client"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"APPLICATIONICON",grid:0,evt:"e12101_client"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"APPLICATIONNAME",format:0,grid:0,evt:"e13101_client",ctrltype:"textblock"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"TOPMIDDLE",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TOPEND",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"UNIVERSALSEARCH",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,lvl:0,type:"char",len:150,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSEARCHCRITERIA_MPAGE",fmt:0,gxz:"ZV9SearchCriteria",gxold:"OV9SearchCriteria",gxvar:"AV9SearchCriteria",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9SearchCriteria=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9SearchCriteria=n)},v2c:function(){gx.fn.setControlValue("vSEARCHCRITERIA_MPAGE",gx.O.AV9SearchCriteria,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV9SearchCriteria=this.val())},val:function(){return gx.fn.getControlValue("vSEARCHCRITERIA_MPAGE")},nac:gx.falseFn};this.declareDomainHdlr(24,function(){});n[25]={id:25,fld:"IMAGE2",grid:0,evt:"e14101_client"};n[26]={id:26,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TABLE4",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"MYACCOUNT",grid:0};n[34]={id:34,fld:"USERINITIALSTEXTBLOCKSMALL",format:0,grid:0,evt:"e15101_client",ctrltype:"textblock"};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERAVATARSMALL_MPAGE",fmt:0,gxz:"ZV12UserAvatarSmall",gxold:"OV12UserAvatarSmall",gxvar:"AV12UserAvatarSmall",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12UserAvatarSmall=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12UserAvatarSmall=n)},v2c:function(){gx.fn.setMultimediaValue("vUSERAVATARSMALL_MPAGE",gx.O.AV12UserAvatarSmall,gx.O.AV18Useravatarsmall_GXI)},c2v:function(){gx.O.AV18Useravatarsmall_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV12UserAvatarSmall=this.val())},val:function(){return gx.fn.getBlobValue("vUSERAVATARSMALL_MPAGE")},val_GXI:function(){return gx.fn.getControlValue("vUSERAVATARSMALL_GXI_MPAGE")},gxvar_GXI:"AV18Useravatarsmall_GXI",nac:gx.falseFn,evt:"e15101_client"};n[37]={id:37,fld:"USERNAMETEXTBLOCK",format:0,grid:0,evt:"e15101_client",ctrltype:"textblock"};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"MYACCOUNTMENU",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"SECTION1",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERAVATAR_MPAGE",fmt:0,gxz:"ZV11UserAvatar",gxold:"OV11UserAvatar",gxvar:"AV11UserAvatar",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11UserAvatar=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11UserAvatar=n)},v2c:function(){gx.fn.setMultimediaValue("vUSERAVATAR_MPAGE",gx.O.AV11UserAvatar,gx.O.AV19Useravatar_GXI)},c2v:function(){gx.O.AV19Useravatar_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV11UserAvatar=this.val())},val:function(){return gx.fn.getBlobValue("vUSERAVATAR_MPAGE")},val_GXI:function(){return gx.fn.getControlValue("vUSERAVATAR_GXI_MPAGE")},gxvar_GXI:"AV19Useravatar_GXI",nac:gx.falseFn};n[44]={id:44,fld:"USERINITIALSTEXTBLOCK",format:0,grid:0,ctrltype:"textblock"};n[45]={id:45,fld:"USERNAME",format:0,grid:0,ctrltype:"textblock"};n[46]={id:46,fld:"USEREMAIL",format:0,grid:0,ctrltype:"textblock"};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"CHANGEPASSWORD",format:0,grid:0,evt:"e16101_client",ctrltype:"textblock"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"SIGNOUT",format:0,grid:0,evt:"e19102_client",ctrltype:"textblock"};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"MIDDLE",grid:0};n[53]={id:53,fld:"MENUCELL",grid:0};n[54]={id:54,fld:"CENTERSTART",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"MENUCONTAINER",grid:0};n[57]={id:57,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"CENTERMIDDLE",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"TABLE2",grid:0};n[63]={id:63,fld:"",grid:0};n[65]={id:65,fld:"FOOTERCONTAINER",grid:0};n[66]={id:66,fld:"FOOTERCONTENTS",grid:0};n[67]={id:67,fld:"",grid:0};this.AV9SearchCriteria="";this.ZV9SearchCriteria="";this.OV9SearchCriteria="";this.AV18Useravatarsmall_GXI="";this.AV12UserAvatarSmall="";this.ZV12UserAvatarSmall="";this.OV12UserAvatarSmall="";this.AV19Useravatar_GXI="";this.AV11UserAvatar="";this.ZV11UserAvatar="";this.OV11UserAvatar="";this.AV9SearchCriteria="";this.AV12UserAvatarSmall="";this.AV11UserAvatar="";this.AV6MenuItems=[];this.AV17Pgmname="";this.Events={e19102_client:["SIGNOUT_MPAGE",!0],e21102_client:["ENTER_MPAGE",!0],e22102_client:["CANCEL_MPAGE",!0],e14101_client:["DOSEARCH_MPAGE",!1],e11101_client:["TOGGLEMENU_MPAGE",!1],e15101_client:["OPENTABLE_MPAGE",!1],e16101_client:["CHANGEPASSWORD_MPAGE",!1],e12101_client:["APPLICATIONICON_MPAGE.CLICK_MPAGE",!1],e13101_client:["APPLICATIONNAME_MPAGE.CLICK_MPAGE",!1]};this.EvtParms.REFRESH_MPAGE=[[{av:"AV17Pgmname",fld:"vPGMNAME_MPAGE",pic:"",hsh:!0}],[{av:"AV9SearchCriteria",fld:"vSEARCHCRITERIA_MPAGE",pic:""}]];this.EvtParms.DOSEARCH_MPAGE=[[{av:"AV9SearchCriteria",fld:"vSEARCHCRITERIA_MPAGE",pic:""}],[{av:"AV9SearchCriteria",fld:"vSEARCHCRITERIA_MPAGE",pic:""}]];this.EvtParms.TOGGLEMENU_MPAGE=[[{av:'gx.fn.getCtrlProperty("MAINTABLE_MPAGE","Class")',ctrl:"MAINTABLE_MPAGE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("MAINTABLE_MPAGE","Class")',ctrl:"MAINTABLE_MPAGE",prop:"Class"}]];this.EvtParms.OPENTABLE_MPAGE=[[{av:'gx.fn.getCtrlProperty("MYACCOUNTMENU_MPAGE","Visible")',ctrl:"MYACCOUNTMENU_MPAGE",prop:"Visible"}],[{av:'gx.fn.getCtrlProperty("MYACCOUNTMENU_MPAGE","Visible")',ctrl:"MYACCOUNTMENU_MPAGE",prop:"Visible"}]];this.EvtParms.CHANGEPASSWORD_MPAGE=[[],[]];this.EvtParms.SIGNOUT_MPAGE=[[],[]];this.EvtParms["APPLICATIONICON_MPAGE.CLICK_MPAGE"]=[[],[]];this.EvtParms["APPLICATIONNAME_MPAGE.CLICK_MPAGE"]=[[],[]];this.EvtParms.ENTER_MPAGE=[[],[]];this.setVCMap("AV17Pgmname","vPGMNAME_MPAGE",0,"char",129,0);this.Initialize();this.setComponent({id:"NOTIFICATIONSCOMPONENT",GXClass:"k2btools.designsystems.aries.notificationsviewer",Prefix:"MPW0027",lvl:1});this.setComponent({id:"UICONFIGURATION",GXClass:"k2btools.designsystems.aries.uiconfiguration",Prefix:"MPW0029",lvl:1});this.setComponent({id:"FOOTERCOMPONENT",GXClass:"k2btools.designsystems.aries.samplefootercomponent",Prefix:"MPW0068",lvl:1})});gx.wi(function(){gx.createMasterPage(k2btools.designsystems.aries.masterpage4_verticalmenu)})