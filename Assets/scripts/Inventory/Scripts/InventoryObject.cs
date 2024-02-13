using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;



[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject , ISerializationCallbackReceiver
{
    public string savePath;
    private ItemDatabaseObject database;
    public List<InventorySlot> Container = new List<InventorySlot>();

    private void OnEnable() {
#if UNITY_EDITOR
            database = (ItemDatabaseObject) AssetDatabase.LoadAssetAtPath("Assets/Ressources/itemsDatabase.asset", typeof(ItemDatabaseObject));
#else
            database = Resources.Load<ItemDatabaseObject>("ItemDatabase");
#endif
    }

    public void addItem(items _item, int _amount){
        for (int i = 0; i < Container.Count; i++){
            if(Container[i].item == _item){
                Container[i].addAmount(_amount);
                return;
            }
        }
        Container.Add(new InventorySlot(database.GetId[_item],_item, _amount));
    }

    public void removeItem(items _item, int _amount){
        // print all the items in the container    
        for (int i = 0; i < Container.Count; i++){
            if(Container[i].item.id == _item.id){
                Debug.Log("found item");
                Container[i].addAmount(-_amount);
                Debug.Log("amount: " + Container[i].amount);
                
                return;
            }
        }
    }

    public items GetItem(string name) {
        for (int i = 0; i < Container.Count; i++){
            if(Container[i].item.name == name){
                // return the item
                return Container[i].item;
            }
        }
        // if we don't find the item, return null
        return null;
    }
    
    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
            Container[i].item = database.GetItem[Container[i].ID];
    }

    public void OnBeforeSerialize()
    {
        
    }

    [ContextMenu("Save")]
    public void Save(){
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        System.IO.FileStream file = System.IO.File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    [ContextMenu("Load")]
    public void Load(){
        if(System.IO.File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            BinaryFormatter bf = new BinaryFormatter();
            System.IO.FileStream file = System.IO.File.Open(string.Concat(Application.persistentDataPath, savePath), System.IO.FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

}

[System.Serializable]
public class InventorySlot {
    public int ID;
    public items item;
    public int amount;

    public InventorySlot(int _id, items _item, int _amount){
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void addAmount(int value){
        amount += value;
    }

    public void removeAmount(int value){
        amount -= value;
    }
}