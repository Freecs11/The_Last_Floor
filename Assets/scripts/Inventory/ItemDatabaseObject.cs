using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New itemDatabase", menuName = "Items/Database")]
public class ItemDatabaseObject : ScriptableObject , ISerializationCallbackReceiver
{
    public items[] items;
    public Dictionary<items,int> GetId = new Dictionary<items, int>();
    public Dictionary<int,items> GetItem = new Dictionary<int,items>();
    // i want to get the item by name
    public Dictionary<string,items> GetItemByName = new Dictionary<string,items>();

    public void OnAfterDeserialize()
    {

        GetId = new Dictionary<items, int>();
        GetItem = new Dictionary<int, items>();
        GetItemByName = new Dictionary<string, items>();
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null) continue;
                GetId.Add(items[i], i);
                GetItem.Add(i, items[i]);
                if(items[i].name != null){
                    GetItemByName.Add(items[i].name, items[i]);
                }
                    
            
        }
    }

    public void OnBeforeSerialize()
    {
        
    }

}
