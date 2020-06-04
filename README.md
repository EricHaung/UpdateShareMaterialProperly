# UpdateShareMaterialProperly
### 目的：<br>
ShareMaterials將重複使用之材質球視作同樣來源，如此一來不用再使用額外的記憶體空間存放重複資訊，也可以節省渲染時計算之複雜度，妥善利用可以造成可觀的效能節省。<br><br>
然而ShareMaterials在使用上有特殊限制 : 可以被各別提取，卻無法被各別存入。同時，如果錯誤的使用ShareMaterials也可能讓Unity生成獨立的Material進而違背了ShareMaterials的設計精神。<br><br>
因此設計出此腳本作為更新ShaderMaterial參數時之修改流程範例。<br><br>

### 方法：<br>
1.搜尋物件Renderer底下之所有ShareMaterials並用Dictionary紀錄物件上所有未重複之Material<br>

2.針對每個Renderer底下之所有ShareMaterials 使用一張Material List逐個針對下面兩種情況做反應<br>

* 如果ShareMaterials[index]不存在於Dictionary，則:<br>
    將ShareMaterials[index]存入Dictionary，並新增一個對應之材質球存入Material List<br>
    
* 如果ShareMaterials[index]存在於Dictionary，則:<br>
    找到Dictionary對應之Material，並存入Material List<br>
    
3.將Renderer底下之ShareMaterials 指派成Material List<br>

