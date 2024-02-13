using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class randomizeHints : MonoBehaviour
{
    public GameObject[] cubes;
    Vector3 initialPos;
    public float distanceBetweenCubes = 2f;
    public static string finalCode;

    private void Awake() {
        int randomNum = Random.Range(1000, 9999);
        string randomNumString = randomNum.ToString();
        finalCode = randomNumString;  
        initialPos = cubes[0].transform.position; 
    }
    
    public GameObject[] Shuffle(GameObject[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            GameObject tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
        return array;
    }

    public List<string> finalOrder()
    {
        List<string> finalOrder = new List<string>();
        for (int i = 0; i < cubes.Length; i++)
        {
            string cubeName = cubes[i].name.ToLower();
            finalOrder.Add(cubeName);
        }
        return finalOrder;
    }

    // Start is called before the first frame update
    void Start()
    {
        Shuffle(cubes);
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.position = new Vector3(initialPos.x + (i * distanceBetweenCubes), initialPos.y, initialPos.z);
        }
        makeRandomLockCode();
    } 

    
    void makeRandomLockCode()
    {
        List<string> lockCode = finalOrder();

        // print lock code 
        foreach (string cube in lockCode)
        {
            Debug.Log(cube);
        }
        
        Debug.Log("final code: " + finalCode);
        

        for (int i = 0; i < lockCode.Count; i++)
        {
            GameObject hint = GameObject.Find(lockCode[i] + "Hint");
            refTextHint hintScript = hint.GetComponent<refTextHint>();
            hintScript.textMesh.text = finalCode[i].ToString();
        }
    }
    

}