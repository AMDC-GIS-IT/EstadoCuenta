gx.evt.autoSkip = false;
gx.define('gx0010', false, function () {
   this.ServerClass =  "gx0010" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "gx0010.aspx" ;
   this.setObjectType("web");
   this.anyGridBaseTable = true;
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.DSO =  "EstadoCuenta" ;
   this.SetStandaloneVars=function()
   {
      this.AV9pCLAVE_CATASTRAL=gx.fn.getControlValue("vPCLAVE_CATASTRAL") ;
   };
   this.e14031_client=function()
   {
      this.clearMessages();
      if ( gx.text.compare( gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class") , "AdvancedContainer" ) == 0 )
      {
         gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class", "AdvancedContainer"+" "+"AdvancedContainerVisible" );
         gx.fn.setCtrlProperty("BTNTOGGLE","Class", gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" "+"BtnToggleActive" );
      }
      else
      {
         gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class", "AdvancedContainer" );
         gx.fn.setCtrlProperty("BTNTOGGLE","Class", "BtnToggle" );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e11031_client=function()
   {
      this.clearMessages();
      if ( gx.text.compare( gx.fn.getCtrlProperty("CLAVES_RUTASRUTAFILTERCONTAINER","Class") , "AdvancedContainerItem" ) == 0 )
      {
         gx.fn.setCtrlProperty("CLAVES_RUTASRUTAFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCCLAVES_RUTASRUTA","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CLAVES_RUTASRUTAFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCCLAVES_RUTASRUTA","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CLAVES_RUTASRUTAFILTERCONTAINER","Class")',ctrl:'CLAVES_RUTASRUTAFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLAVES_RUTASRUTA","Visible")',ctrl:'vCCLAVES_RUTASRUTA',prop:'Visible'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e12031_client=function()
   {
      this.clearMessages();
      if ( gx.text.compare( gx.fn.getCtrlProperty("UMAPSFILTERCONTAINER","Class") , "AdvancedContainerItem" ) == 0 )
      {
         gx.fn.setCtrlProperty("UMAPSFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCUMAPS","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("UMAPSFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCUMAPS","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("UMAPSFILTERCONTAINER","Class")',ctrl:'UMAPSFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCUMAPS","Visible")',ctrl:'vCUMAPS',prop:'Visible'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e13031_client=function()
   {
      this.clearMessages();
      if ( gx.text.compare( gx.fn.getCtrlProperty("CLAVESRUTAIDFILTERCONTAINER","Class") , "AdvancedContainerItem" ) == 0 )
      {
         gx.fn.setCtrlProperty("CLAVESRUTAIDFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCCLAVESRUTAID","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CLAVESRUTAIDFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCCLAVESRUTAID","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CLAVESRUTAIDFILTERCONTAINER","Class")',ctrl:'CLAVESRUTAIDFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLAVESRUTAID","Visible")',ctrl:'vCCLAVESRUTAID',prop:'Visible'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e17032_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e18031_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51,52];
   this.GXLastCtrlId =52;
   this.Grid1Container = new gx.grid.grid(this, 2,"WbpLvl2",44,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0010",[],false,1,false,true,10,true,false,false,"",0,"px",0,"px","Nueva fila",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var Grid1Container = this.Grid1Container;
   Grid1Container.addBitmap("&Linkselection","vLINKSELECTION",45,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");
   Grid1Container.addSingleLineEdit(6,46,"CLAVES_RUTASRUTA","RUTA","","CLAVES_RUTASRUTA","decimal",0,"px",18,18,"end",null,[],6,"CLAVES_RUTASRUTA",true,6,false,false,"DescriptionAttribute",0,"WWColumn");
   Grid1Container.addSingleLineEdit(7,47,"UMAPS","UMAPS","","UMAPS","decimal",0,"px",18,18,"end",null,[],7,"UMAPS",true,6,false,false,"Attribute",0,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(8,48,"CLAVESRUTAID","Claves Ruta Id","","ClavesRutaId","int",0,"px",9,9,"end",null,[],8,"ClavesRutaId",true,0,false,false,"Attribute",0,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(1,49,"CLAVE_CATASTRAL","CLAVE_CATASTRAL","","CLAVE_CATASTRAL","svchar",0,"px",255,80,"start",null,[],1,"CLAVE_CATASTRAL",false,0,false,false,"Attribute",0,"");
   this.Grid1Container.emptyText = "";
   this.setGrid(Grid1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAIN",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"ADVANCEDCONTAINER",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"CLAVES_RUTASRUTAFILTERCONTAINER",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"LBLCLAVES_RUTASRUTAFILTER", format:1,grid:0,evt:"e11031_client", ctrltype: "textblock"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id:16 ,lvl:0,type:"decimal",len:18,dec:6,sign:false,pic:"ZZZZZZZZZZ9.999999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCLAVES_RUTASRUTA",fmt:0,gxz:"ZV6cCLAVES_RUTASRUTA",gxold:"OV6cCLAVES_RUTASRUTA",gxvar:"AV6cCLAVES_RUTASRUTA",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV6cCLAVES_RUTASRUTA=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.ZV6cCLAVES_RUTASRUTA=gx.fn.toDecimalValue(Value,'.',',')},v2c:function(){gx.fn.setDecimalValue("vCCLAVES_RUTASRUTA",gx.O.AV6cCLAVES_RUTASRUTA,6,',')},c2v:function(){if(this.val()!==undefined)gx.O.AV6cCLAVES_RUTASRUTA=this.val()},val:function(){return gx.fn.getDecimalValue("vCCLAVES_RUTASRUTA",'.',',')},nac:gx.falseFn};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"UMAPSFILTERCONTAINER",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"LBLUMAPSFILTER", format:1,grid:0,evt:"e12031_client", ctrltype: "textblock"};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id:26 ,lvl:0,type:"decimal",len:18,dec:6,sign:false,pic:"ZZZZZZZZZZ9.999999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCUMAPS",fmt:0,gxz:"ZV7cUMAPS",gxold:"OV7cUMAPS",gxvar:"AV7cUMAPS",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV7cUMAPS=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.ZV7cUMAPS=gx.fn.toDecimalValue(Value,'.',',')},v2c:function(){gx.fn.setDecimalValue("vCUMAPS",gx.O.AV7cUMAPS,6,',')},c2v:function(){if(this.val()!==undefined)gx.O.AV7cUMAPS=this.val()},val:function(){return gx.fn.getDecimalValue("vCUMAPS",'.',',')},nac:gx.falseFn};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"CLAVESRUTAIDFILTERCONTAINER",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"LBLCLAVESRUTAIDFILTER", format:1,grid:0,evt:"e13031_client", ctrltype: "textblock"};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"int",len:9,dec:0,sign:false,pic:"ZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCLAVESRUTAID",fmt:0,gxz:"ZV8cClavesRutaId",gxold:"OV8cClavesRutaId",gxvar:"AV8cClavesRutaId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV8cClavesRutaId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV8cClavesRutaId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCCLAVESRUTAID",gx.O.AV8cClavesRutaId,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV8cClavesRutaId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCCLAVESRUTAID",'.')},nac:gx.falseFn};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"GRIDTABLE",grid:0};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"BTNTOGGLE",grid:0,evt:"e14031_client"};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[45]={ id:45 ,lvl:2,type:"bits",len:1024,dec:0,sign:false,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.AV5LinkSelection=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5LinkSelection=Value},v2c:function(row){gx.fn.setGridMultimediaValue("vLINKSELECTION",row || gx.fn.currentGridRowImpl(44),gx.O.AV5LinkSelection,gx.O.AV11Linkselection_GXI)},c2v:function(row){gx.O.AV11Linkselection_GXI=this.val_GXI();if(this.val(row)!==undefined)gx.O.AV5LinkSelection=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vLINKSELECTION",row || gx.fn.currentGridRowImpl(44))},val_GXI:function(row){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",row || gx.fn.currentGridRowImpl(44))}, gxvar_GXI:'AV11Linkselection_GXI',nac:gx.falseFn};
   GXValidFnc[46]={ id:46 ,lvl:2,type:"decimal",len:18,dec:6,sign:false,pic:"ZZZZZZZZZZ9.999999",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLAVES_RUTASRUTA",fmt:0,gxz:"Z6CLAVES_RUTASRUTA",gxold:"O6CLAVES_RUTASRUTA",gxvar:"A6CLAVES_RUTASRUTA",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A6CLAVES_RUTASRUTA=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z6CLAVES_RUTASRUTA=gx.fn.toDecimalValue(Value,'.',',')},v2c:function(row){gx.fn.setGridDecimalValue("CLAVES_RUTASRUTA",row || gx.fn.currentGridRowImpl(44),gx.O.A6CLAVES_RUTASRUTA,6,',')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A6CLAVES_RUTASRUTA=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("CLAVES_RUTASRUTA",row || gx.fn.currentGridRowImpl(44),'.',',')},nac:gx.falseFn};
   GXValidFnc[47]={ id:47 ,lvl:2,type:"decimal",len:18,dec:6,sign:false,pic:"ZZZZZZZZZZ9.999999",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"UMAPS",fmt:0,gxz:"Z7UMAPS",gxold:"O7UMAPS",gxvar:"A7UMAPS",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A7UMAPS=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z7UMAPS=gx.fn.toDecimalValue(Value,'.',',')},v2c:function(row){gx.fn.setGridDecimalValue("UMAPS",row || gx.fn.currentGridRowImpl(44),gx.O.A7UMAPS,6,',')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A7UMAPS=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("UMAPS",row || gx.fn.currentGridRowImpl(44),'.',',')},nac:gx.falseFn};
   GXValidFnc[48]={ id:48 ,lvl:2,type:"int",len:9,dec:0,sign:false,pic:"ZZZZZZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLAVESRUTAID",fmt:0,gxz:"Z8ClavesRutaId",gxold:"O8ClavesRutaId",gxvar:"A8ClavesRutaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A8ClavesRutaId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z8ClavesRutaId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CLAVESRUTAID",row || gx.fn.currentGridRowImpl(44),gx.O.A8ClavesRutaId,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A8ClavesRutaId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CLAVESRUTAID",row || gx.fn.currentGridRowImpl(44),'.')},nac:gx.falseFn};
   GXValidFnc[49]={ id:49 ,lvl:2,type:"svchar",len:255,dec:0,sign:false,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLAVE_CATASTRAL",fmt:0,gxz:"Z1CLAVE_CATASTRAL",gxold:"O1CLAVE_CATASTRAL",gxvar:"A1CLAVE_CATASTRAL",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A1CLAVE_CATASTRAL=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1CLAVE_CATASTRAL=Value},v2c:function(row){gx.fn.setGridControlValue("CLAVE_CATASTRAL",row || gx.fn.currentGridRowImpl(44),gx.O.A1CLAVE_CATASTRAL,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A1CLAVE_CATASTRAL=this.val(row)},val:function(row){return gx.fn.getGridControlValue("CLAVE_CATASTRAL",row || gx.fn.currentGridRowImpl(44))},nac:gx.falseFn};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"BTN_CANCEL",grid:0,evt:"e18031_client"};
   this.AV6cCLAVES_RUTASRUTA = 0 ;
   this.ZV6cCLAVES_RUTASRUTA = 0 ;
   this.OV6cCLAVES_RUTASRUTA = 0 ;
   this.AV7cUMAPS = 0 ;
   this.ZV7cUMAPS = 0 ;
   this.OV7cUMAPS = 0 ;
   this.AV8cClavesRutaId = 0 ;
   this.ZV8cClavesRutaId = 0 ;
   this.OV8cClavesRutaId = 0 ;
   this.ZV5LinkSelection = "" ;
   this.OV5LinkSelection = "" ;
   this.Z6CLAVES_RUTASRUTA = 0 ;
   this.O6CLAVES_RUTASRUTA = 0 ;
   this.Z7UMAPS = 0 ;
   this.O7UMAPS = 0 ;
   this.Z8ClavesRutaId = 0 ;
   this.O8ClavesRutaId = 0 ;
   this.Z1CLAVE_CATASTRAL = "" ;
   this.O1CLAVE_CATASTRAL = "" ;
   this.AV6cCLAVES_RUTASRUTA = 0 ;
   this.AV7cUMAPS = 0 ;
   this.AV8cClavesRutaId = 0 ;
   this.AV9pCLAVE_CATASTRAL = "" ;
   this.AV5LinkSelection = "" ;
   this.A6CLAVES_RUTASRUTA = 0 ;
   this.A7UMAPS = 0 ;
   this.A8ClavesRutaId = 0 ;
   this.A1CLAVE_CATASTRAL = "" ;
   this.Events = {"e17032_client": ["ENTER", true] ,"e18031_client": ["CANCEL", true] ,"e14031_client": ["'TOGGLE'", false] ,"e11031_client": ["LBLCLAVES_RUTASRUTAFILTER.CLICK", false] ,"e12031_client": ["LBLUMAPSFILTER.CLICK", false] ,"e13031_client": ["LBLCLAVESRUTAIDFILTER.CLICK", false]};
   this.EvtParms["REFRESH"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cCLAVES_RUTASRUTA',fld:'vCCLAVES_RUTASRUTA',pic:'ZZZZZZZZZZ9.999999'},{av:'AV7cUMAPS',fld:'vCUMAPS',pic:'ZZZZZZZZZZ9.999999'},{av:'AV8cClavesRutaId',fld:'vCCLAVESRUTAID',pic:'ZZZZZZZZ9'}],[]];
   this.EvtParms["'TOGGLE'"] = [[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]];
   this.EvtParms["LBLCLAVES_RUTASRUTAFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CLAVES_RUTASRUTAFILTERCONTAINER","Class")',ctrl:'CLAVES_RUTASRUTAFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CLAVES_RUTASRUTAFILTERCONTAINER","Class")',ctrl:'CLAVES_RUTASRUTAFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLAVES_RUTASRUTA","Visible")',ctrl:'vCCLAVES_RUTASRUTA',prop:'Visible'}]];
   this.EvtParms["LBLUMAPSFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("UMAPSFILTERCONTAINER","Class")',ctrl:'UMAPSFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("UMAPSFILTERCONTAINER","Class")',ctrl:'UMAPSFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCUMAPS","Visible")',ctrl:'vCUMAPS',prop:'Visible'}]];
   this.EvtParms["LBLCLAVESRUTAIDFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CLAVESRUTAIDFILTERCONTAINER","Class")',ctrl:'CLAVESRUTAIDFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CLAVESRUTAIDFILTERCONTAINER","Class")',ctrl:'CLAVESRUTAIDFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLAVESRUTAID","Visible")',ctrl:'vCCLAVESRUTAID',prop:'Visible'}]];
   this.EvtParms["ENTER"] = [[{av:'A1CLAVE_CATASTRAL',fld:'CLAVE_CATASTRAL',pic:'',hsh:true}],[{av:'AV9pCLAVE_CATASTRAL',fld:'vPCLAVE_CATASTRAL',pic:''}]];
   this.EvtParms["GRID1_FIRSTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cCLAVES_RUTASRUTA',fld:'vCCLAVES_RUTASRUTA',pic:'ZZZZZZZZZZ9.999999'},{av:'AV7cUMAPS',fld:'vCUMAPS',pic:'ZZZZZZZZZZ9.999999'},{av:'AV8cClavesRutaId',fld:'vCCLAVESRUTAID',pic:'ZZZZZZZZ9'}],[]];
   this.EvtParms["GRID1_PREVPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cCLAVES_RUTASRUTA',fld:'vCCLAVES_RUTASRUTA',pic:'ZZZZZZZZZZ9.999999'},{av:'AV7cUMAPS',fld:'vCUMAPS',pic:'ZZZZZZZZZZ9.999999'},{av:'AV8cClavesRutaId',fld:'vCCLAVESRUTAID',pic:'ZZZZZZZZ9'}],[]];
   this.EvtParms["GRID1_NEXTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cCLAVES_RUTASRUTA',fld:'vCCLAVES_RUTASRUTA',pic:'ZZZZZZZZZZ9.999999'},{av:'AV7cUMAPS',fld:'vCUMAPS',pic:'ZZZZZZZZZZ9.999999'},{av:'AV8cClavesRutaId',fld:'vCCLAVESRUTAID',pic:'ZZZZZZZZ9'}],[]];
   this.EvtParms["GRID1_LASTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cCLAVES_RUTASRUTA',fld:'vCCLAVES_RUTASRUTA',pic:'ZZZZZZZZZZ9.999999'},{av:'AV7cUMAPS',fld:'vCUMAPS',pic:'ZZZZZZZZZZ9.999999'},{av:'AV8cClavesRutaId',fld:'vCCLAVESRUTAID',pic:'ZZZZZZZZ9'}],[]];
   this.setVCMap("AV9pCLAVE_CATASTRAL", "vPCLAVE_CATASTRAL", 0, "svchar", 255, 0);
   Grid1Container.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid1"});
   Grid1Container.addRefreshingVar(this.GXValidFnc[16]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[26]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[36]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[16]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[26]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[36]);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(this.gx0010);});
