using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrefabSwitcher : MonoBehaviour
{
    Transform[] prefabs;
    private int currentNum = 1;
    private GameObject current;

    void Awake () {
        prefabs = gameObject.GetComponentsInChildren<Transform>();
        Debug.Log(prefabs.Length);
        current = prefabs[1].gameObject;
    }
    
    void Start () {
        for (int i = 1; i < prefabs.Length;i++){
            if (prefabs[i].gameObject != current)
            {
                prefabs[i].gameObject.SetActive(false);

            }
        }
    }
     
    public void ChangePrefab(int numOfChild)
    {
        prefabs[currentNum].gameObject.SetActive(false);
        currentNum = numOfChild;
        prefabs[currentNum].gameObject.SetActive(true);
    }
}
