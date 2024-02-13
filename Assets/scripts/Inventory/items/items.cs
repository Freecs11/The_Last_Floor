using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Items/new item")]
[System.Serializable]
public class items : ScriptableObject {
    public string id;
    public string name;
    [TextArea(15, 20)] public string description;
    public GameObject prefab;
    public GameObject model;

}