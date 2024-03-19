import{r as t,c as s,h as i}from"./p-66ea3b4c.js";import{a as e}from"./p-64bdd77e.js";const n=class{constructor(i){t(this,i),this.selectionErrorEvent=s(this,"selectionError",7),this.focusEvent=s(this,"focus",7),this.changeEvent=s(this,"SuggestValueChanged",7),this.newRecordClickedEvent=s(this,"newRecordClicked",7),this.inputValueChangedEvent=s(this,"inputValueChanged",7),this.value=[],this.noresultsfoundtext="No results found",this.enableadditem=!0,this.additemcaption="New record",this.enabled=!0,this.readonlyclass="",this.searchvalue="",this.placeholder="",this.selectedValueDescription="",this.maxSelectionSize=1,this.suggestmaxitems=5,this.activeElementValue=null,this.showiconsintags=!0,this.emptyitemtext="(none)",this.container=null,this.selectedElement=null,this.searchfield=null,this.seekSuggestValuesForMissingValueExecuted=!1,this.seekSuggestValuesDebouncer=null}isCollection(){return 1!=this.maxSelectionSize}selectionIsFull(){return this.isCollection()&&0!=this.maxSelectionSize&&this.maxSelectionSize<=this.value.length}itemIsSelected(t){var s,i;return(null!==(i=null===(s=this.value)||void 0===s?void 0:s.filter((s=>s.toString().trim()==t.value.toString().trim())).length)&&void 0!==i?i:0)>0}async setFocusToSearch(){null!=this.searchfield&&this.searchfield.focus()}async updateDescription(){this.isCollection()||(this.getAtomicValues().filter((t=>this.itemIsSelected(t))).length>0?(this.searchvalue=this.getValueDescription(),this.seekSuggestValuesForMissingValueExecuted=!1):(this.seekSuggestValuesForMissingValueExecuted||(this.inputValueChangedEvent.emit(null),this.seekSuggestValuesForMissingValueExecuted=!0),this.searchvalue=""))}processInput(t){return t.target==this.searchfield&&this.changeSearchValue(this.searchfield.value),t.stopPropagation(),!1}processKeydown(t){"Escape"===t.key&&(this.open=!1,t.stopPropagation()),"Tab"===t.key&&(this.open=!1),this.isCollection()?this.processKeydownCollection(t):this.processKeydownSingleSelection(t)}processKeydownCollection(t){"Enter"==t.key?this.processEnterKeyWhenCollection(t):this.open&&("ArrowDown"==t.key?this.processArrowDownKeyWhenCollection(t):"ArrowUp"==t.key?this.processArrowUpKeyWhenCollection(t):" "!==t.key&&"Spacebar"!==t.key||this.processSpacebarKeyWhenCollection(t))}processEnterKeyWhenCollection(t){this.open&&(this.setValueWithoutClosing(this.activeElementValue),this.emitChangedEvent()),this.open=!this.open,t.stopPropagation()}processSpacebarKeyWhenCollection(t){""!==this.activeElementValue&&null!==this.activeElementValue&&(this.setValueWithoutClosing(this.activeElementValue),this.emitChangedEvent(),t.stopPropagation(),t.preventDefault())}processArrowUpKeyWhenCollection(t){t.stopPropagation(),t.preventDefault();var s=e.getAtomicValues_impl(this.getFilteredValues());if(s.length>0){var i=s.findIndex((t=>t.value==this.activeElementValue));-1==i?i=s.length-1:0===i?i=-1:i-=1,this.activeElementValue=-1!==i?s[i].value:null}}processArrowDownKeyWhenCollection(t){t.stopPropagation(),t.preventDefault();var s=e.getAtomicValues_impl(this.getFilteredValues());if(s.length>0){var i=s.findIndex((t=>t.value==this.activeElementValue));-1===i?i=0:0==(i=((i+1)%s.length+s.length)%s.length)&&(i=-1),this.activeElementValue=-1!==i?s[i].value:null}}processKeydownSingleSelection(t){"Enter"==t.key?this.processEnterKeyWhenNotCollection(t):"Tab"==t.key?this.processTabKeyWhenNotCollection(t):this.open&&("ArrowDown"==t.key?this.processArrowDownKeyWhenNotCollection(t):"ArrowUp"==t.key&&this.processArrowUpKeyWhenNotCollection(t))}processArrowUpKeyWhenNotCollection(t){t.stopPropagation(),t.preventDefault();var s=e.getAtomicValues_impl(this.getFilteredValues());if(s.length>0){var i=s.findIndex((t=>t.value==this.value[0]));this.setValueWithoutClosing(-1==i?s[s.length-1].value:s[i=((i-1)%s.length+s.length)%s.length].value)}}processArrowDownKeyWhenNotCollection(t){t.stopPropagation(),t.preventDefault();var s=e.getAtomicValues_impl(this.getFilteredValues());if(s.length>0){var i=s.findIndex((t=>t.value==this.value[0]));this.setValueWithoutClosing(-1==i?s[0].value:s[i=((i+1)%s.length+s.length)%s.length].value)}}processEnterKeyWhenNotCollection(t){this.open=!this.open,this.open||(this.searchvalue=this.getValueDescription(),this.emitChangedEvent()),t.stopPropagation()}processTabKeyWhenNotCollection(t){this.open||(this.searchvalue=this.getValueDescription(),this.emitChangedEvent()),t.stopPropagation()}closeMenu(t){this.open&&this.container&&!this.container.contains(t.target)&&(this.open=!1,this.isCollection()||this.setValue(this.value[0]))}async setValue(t){this.isCollection()||(this.open=!1),this.setValueWithoutClosing(t),this.isCollection()||(this.searchvalue=this.getValueDescription()),this.emitChangedEvent()}emitChangedEvent(){this.changeEvent.emit(this.value)}setValueWithoutClosing(t){this.isCollection()?0===this.value.filter((s=>s.toString().trim()===t.toString().trim())).length?this.selectionIsFull()?(this.errorCode=n.ERROR_SELECTION_FULL,this.selectionErrorEvent.emit({})):this.value=this.value.concat([t]):this.value=this.value.filter((s=>s.toString().trim()!==t.toString().trim())):(this.value=null!=t?[t]:[],this.selectedValueDescription=this.getValueDescription())}getRawValues(){return null==this.values?[]:"string"==typeof this.values?""==this.values?[]:JSON.parse(this.values):[...this.values]}getFilteredValues(){if(!this.open)return[];var t=this.getAtomicValues();return""!=this.searchvalue&&(t=this.getFilteredValues_impl(t)),t}getFilteredValues_impl(t){var s=[];if(null!=t)for(let n of t)if(-1!=n.description.toLocaleLowerCase().indexOf(this.searchvalue.toLocaleLowerCase()))s=s.concat(n);else{var i=this.getFilteredValues_impl(n.items);if(i.length>0){var e=Object.assign({},n);e.items=i,s=s.concat(e)}}return s}onIncludeNewRecordClick(){this.open=!1,this.newRecordClickedEvent.emit(null)}getAtomicValues(){const t=e.getAtomicValues_impl(this.getRawValues());return this.removeDuplicates(t)}removeDuplicates(t){return t.filter(((t,s,i)=>s===i.findIndex((s=>s.value===t.value))))}getSuggestPopoverContent(){const t=this.getRawValues();var s=e.containsDetails(t),n=e.containsIcons(t),h=e.containsTrailingText(t);const o=this.getFilteredValues().slice(0,this.suggestmaxitems);return o.length>0?o.map((t=>this.getItemContent(t,s,n,h))):this.seekSuggestValuesDebouncer?i("div",{class:"K2BT_LoadingSpinner"}):i("div",{class:"K2BTEnhancedComboNoItemsFound"},this.noresultsfoundtext)}onImageError(t){t.target.classList.add("K2BTEnhancedComboIconInvisible")}getItemContent(t,s,i,e){var n;return(null===(n=t.items)||void 0===n?void 0:n.length)>0?this.getCategoryContent(t,s,i,e):this.getAtomicItemContent(t,i,e,s)}getAtomicItemContent(t,s,e,n){var h=this.getItemClass(t);return i("div",{class:h,ref:s=>{(this.itemIsSelected(t)||this.activeElementValue===t.value)&&(this.selectedElement=s)},onClick:()=>{this.setValue(t.value)}},this.addCheckboxIfNecessary(t),this.addIconIfNecessary(s,t),this.addMainItemContent(t,e,n))}addMainItemContent(t,s,e){return i("div",{class:"K2BTEnhancedComboItem_TextColumn"},i("div",{class:"K2BTEnhancedComboItem_TextContainer"},i("span",{class:"K2BTEnhancedComboDescription"},this.getHighlightedText(t.description)),s?i("span",{class:"K2BTEnhancedComboTrailingText"},this.getHighlightedText(t.trailingText)):""),i("div",{class:"K2BTEnhancedComboItem_TextContainer"},e?i("span",{class:"K2BTEnhancedComboSubtitle"},this.getHighlightedText(t.detail)):""))}addIconIfNecessary(t,s){return t?i("div",{class:"K2BTEnhancedComboIconContainer"},i("img",{class:"K2BTEnhancedComboIcon",src:s.imageUrl,onError:t=>this.onImageError(t)})):""}addCheckboxIfNecessary(t){return this.isCollection()?i("div",{class:"K2BT_EnhancedComboCheckbox"},i("input",{type:"checkbox",checked:this.itemIsSelected(t),tabIndex:-1,disabled:this.selectionIsFull()&&!this.itemIsSelected(t)}),i("label",{htmlFor:"","data-gx-sr-only":""}," ")):""}getItemClass(t){var s="K2BTEnhancedComboItem";return this.itemIsSelected(t)?s+=" K2BTEnhancedComboSelected":this.selectionIsFull()&&(s+=" K2BTEnhancedComboDisabled"),this.activeElementValue===t.value&&(s+=" K2BTEnhancedComboActive"),s}getCategoryContent(t,s,e,n){return i("div",{class:"K2BTEnhancedComboCategory"},i("span",{class:"K2BTEnhancedComboCategoryName"},t.description),i("div",{class:"K2BTEnchancedComboCategoryContents"},t.items.map((t=>this.getItemContent(t,s,e,n)))))}getHighlightedText(t){var s=t.toLowerCase().indexOf(this.searchvalue.toLowerCase());return null==this.searchvalue||""==this.searchvalue||-1==s?i("span",null,t):i("span",null,t.substring(0,s),i("span",{class:"K2BTEnhancedComboSearchHighlight"},t.substring(s,s+this.searchvalue.length)),this.getHighlightedText(t.substring(s+this.searchvalue.length)))}changeSearchValue(t){if(this.searchvalue=t,this.open=!0,!this.isCollection()){var s=-1!=this.getAtomicValues().map((t=>t.value)).indexOf(this.value[0]);this.value=[],s&&this.emitChangedEvent()}this.seekSuggestValuesDebouncer&&(clearTimeout(this.seekSuggestValuesDebouncer),this.seekSuggestValuesDebouncer=null),this.seekSuggestValuesDebouncer=setTimeout((()=>{this.seekSuggestValuesDebouncer=null,this.inputValueChangedEvent.emit(null)}).bind(this),200)}getValueDescription(){if(1===this.value.length){var t=this.getAtomicValues().find((t=>t.value==this.value[0]));return null!=t?t.description:this.value[0]}return""}getReadonlyValue(t){return 0==t.length?this.emptyitemtext:t.map((t=>t.description)).join(", ")}componentWillRender(){if(null==this.value||null==this.value||0===this.value.length){const t=this.getAtomicValues().filter((t=>t.description==this.searchfield.value));t.length>0&&this.setValueWithoutClosing(t[0].value)}}getHeaderTagsContent(t){var s=e.containsIcons(this.getAtomicValues());if(this.isCollection())return t.map((t=>i("div",{class:"K2BT_EnhancedComboHeaderTag"},this.showiconsintags&&s&&""!==t.imageUrl?i("img",{class:"K2BT_EnhancedComboTagIcon",src:t.imageUrl}):"",i("span",{class:"K2BT_EnhancedComboHeaderTagDescription"},t.description),i("span",{class:"K2BT_EnhancedComboHeaderTagDelete",onClick:s=>{s.cancelBubble=!0,this.setValueWithoutClosing(t.value),this.emitChangedEvent()}}))))}render(){var t=this.getAtomicValues();const s=this.value.map((s=>t.filter((t=>s.toString().trim()===t.value.trim()))[0])).filter((t=>t));return this.selectedElement=null,i("div",null,i("p",{class:"form-control-static",style:this.enabled?{display:"none"}:{}},i("span",{class:this.readonlyclass,"data-gx-readonly":""},this.getReadonlyValue(s))),i("div",{class:"K2BTEnhancedSuggest",ref:t=>this.container=t,style:this.enabled?{}:{display:"none"}},i("div",{class:"K2BTEnhancedSuggestTags"},this.getHeaderTagsContent(s)),i("input",{type:"text",class:"form-control Attribute_Trn K2BTEnhancedSuggestInput",value:this.searchvalue,onInput:t=>(t.preventDefault(),this.changeSearchValue(t.target.value),!1),placeholder:this.placeholder,onClick:()=>{this.open=!0,this.activeElementValue=null},onFocus:()=>{this.open=!0,this.focusEvent.emit()},ref:t=>this.searchfield=t}),i("div",{class:this.open?"K2BTEnhancedComboContentsOpen":"K2BTEnhancedComboContentsClosed"},i("div",{class:"K2BTEnhancedComboItems"},this.getSuggestPopoverContent()),this.enableadditem?i("span",{class:"K2BTEnhancedComboNewAction",onClick:()=>this.onIncludeNewRecordClick()},this.additemcaption):"")))}};n.ERROR_SELECTION_FULL="SELECTION_FULL",n.style=":host{display:block}k2bt-enhancedsuggest:focus-visible{outline:none}.K2BTEnhancedComboContentsOpen{display:flex;flex-direction:column;position:absolute}.K2BTEnhancedComboItems{max-height:300px;overflow:auto;scrollbar-width:thin;scrollbar-color:#d7d7d7 transparent}.K2BTEnhancedComboItems::-webkit-scrollbar{width:6px}.K2BTEnhancedComboItems::-webkit-scrollbar-thumb{background-color:#d7d7d7;border:1px solid transparent;cursor:pointer}.K2BTEnhancedComboContentsClosed{display:none}.K2BTEnhancedComboItem{display:flex;flex-direction:row;align-items:center}.K2BTEnhancedComboItem:hover{cursor:pointer}.K2BTEnhancedComboItem_TextContainer{display:flex;flex-grow:1}.K2BTEnhancedComboSubtitle{font-size:12px}.K2BTEnhancedComboIcon{width:30px;height:30px;object-fit:cover;margin-right:4px}.K2BTEnhancedComboIconInvisible{visibility:hidden}.K2BTEnhancedComboNoItemsFound{width:100%;text-align:center;margin-top:40px;margin-bottom:40px}.K2BTEnhancedComboTrailingText{flex-grow:0}@keyframes spinner{to{transform:rotate(360deg)}}.K2BT_LoadingSpinner{-webkit-box-sizing:border-box;box-sizing:border-box;position:relative;left:50%;width:20px;height:19px;margin-top:10px;margin-bottom:10px;border-radius:50%;border:2px solid #ccc;border-top-color:#000;-webkit-animation:spinner 0.6s linear infinite;animation:spinner 0.6s linear infinite;margin-left:-10px}.K2BT_EnhancedComboCheckbox{margin-right:8px;margin-top:6px;pointer-events:none}.K2BTEnhancedComboDisabled{cursor:normal;opacity:0.8}.K2BTEnhancedSuggestTags{display:flex;flex-direction:row;flex-wrap:wrap}";export{n as k2bt_enhancedsuggest}