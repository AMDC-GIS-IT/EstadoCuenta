gx.evt.autoSkip=!1;gx.define("k2btoolstabstitlecomponent",!0,function(n){this.ServerClass="k2btoolstabstitlecomponent";this.PackageName="GeneXus.Programs";this.ServerFullClass="k2btoolstabstitlecomponent.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="AriesCustom";this.SetStandaloneVars=function(){this.AV16Tabs=gx.fn.getControlValue("vTABS");this.AV5FirstTab=gx.fn.getIntegerValue("vFIRSTTAB",gx.thousandSeparator);this.AV9LastTab=gx.fn.getIntegerValue("vLASTTAB",gx.thousandSeparator);this.AV11SelectedTab=gx.fn.getIntegerValue("vSELECTEDTAB",gx.thousandSeparator);this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV13TabCode=gx.fn.getControlValue("vTABCODE")};this.s112_client=function(){for(this.AV6Found=!1,this.AV7Index=gx.num.trunc(1,0);this.AV7Index<=this.AV16Tabs.length;){if(gx.text.compare(this.AV16Tabs[this.AV7Index-1].Code,this.AV13TabCode)==0){this.AV11SelectedTab=gx.num.trunc(this.AV7Index,0);this.AV6Found=!0;break}this.AV7Index=gx.num.trunc(this.AV7Index+1,0)}!this.AV6Found&&this.AV16Tabs.length>0&&(this.AV11SelectedTab=gx.num.trunc(1,0))};this.s122_client=function(){this.AV19TotalTabs=gx.num.trunc(8,0);this.AV22CurrentPage=gx.num.trunc((this.AV11SelectedTab-1)/this.AV19TotalTabs,0);this.AV5FirstTab=gx.num.trunc(this.AV22CurrentPage*this.AV19TotalTabs+1,0);this.AV9LastTab=gx.num.trunc(this.AV5FirstTab+this.AV19TotalTabs-1,0);this.AV9LastTab>this.AV16Tabs.length&&(this.AV9LastTab=gx.num.trunc(this.AV16Tabs.length,0));this.AV5FirstTab<=this.AV19TotalTabs?gx.fn.setCtrlProperty("TABPREVIOUS","Visible",!1):gx.fn.setCtrlProperty("TABPREVIOUS","Link",gx.util.invalidFunc("[link(][ t([ t('Tabs',23),[ t('item(',1),t('Firsttab',23),t(-,5),t('Totaltabs',23),t(')',4) ],t('Link',3) ],29),t(')',4) ]"));this.AV9LastTab>=this.AV16Tabs.length?gx.fn.setCtrlProperty("TABNEXT","Visible",!1):gx.fn.setCtrlProperty("TABNEXT","Link",gx.util.invalidFunc("[link(][ t([ t('Tabs',23),[ t('item(',1),t('Firsttab',23),t(+,5),t('Totaltabs',23),t(')',4) ],t('Link',3) ],29),t(')',4) ]"))};this.e130k2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140k2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5];this.GXLastCtrlId=5;t[2]={id:2,fld:"TABCONTAINER",grid:0};t[3]={id:3,fld:"TABS",format:1,grid:0,ctrltype:"textblock"};t[4]={id:4,fld:"TABPREVIOUS",grid:0};t[5]={id:5,fld:"TABNEXT",grid:0};this.AV16Tabs=[];this.AV13TabCode="";this.AV5FirstTab=0;this.AV9LastTab=0;this.AV11SelectedTab=0;this.Gx_mode="";this.AV7Index=0;this.AV6Found=!1;this.AV22CurrentPage=0;this.AV19TotalTabs=0;this.Events={e130k2_client:["ENTER",!0],e140k2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV16Tabs",fld:"vTABS",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"AV13TabCode",fld:"vTABCODE",pic:""},{av:"AV5FirstTab",fld:"vFIRSTTAB",pic:"ZZZ9",hsh:!0},{av:"AV9LastTab",fld:"vLASTTAB",pic:"ZZZ9",hsh:!0},{av:"AV11SelectedTab",fld:"vSELECTEDTAB",pic:"ZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("TABS","Caption")',ctrl:"TABS",prop:"Caption"},{av:"AV11SelectedTab",fld:"vSELECTEDTAB",pic:"ZZZ9",hsh:!0},{av:"AV5FirstTab",fld:"vFIRSTTAB",pic:"ZZZ9",hsh:!0},{av:"AV9LastTab",fld:"vLASTTAB",pic:"ZZZ9",hsh:!0},{av:'gx.fn.getCtrlProperty("TABPREVIOUS","Visible")',ctrl:"TABPREVIOUS",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TABPREVIOUS","Link")',ctrl:"TABPREVIOUS",prop:"Link"},{av:'gx.fn.getCtrlProperty("TABNEXT","Visible")',ctrl:"TABNEXT",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TABNEXT","Link")',ctrl:"TABNEXT",prop:"Link"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV16Tabs","TABS",0,"CollK2BTabOptions.K2BTabOptionsItem",0,0);this.setVCMap("AV5FirstTab","vFIRSTTAB",0,"int",4,0);this.setVCMap("AV9LastTab","vLASTTAB",0,"int",4,0);this.setVCMap("AV11SelectedTab","vSELECTEDTAB",0,"int",4,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV13TabCode","vTABCODE",0,"char",20,0);this.Initialize()})