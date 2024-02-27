using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour,  IInteractable
{

    public GameObject ingredient;

    public bool Occupied()
    {
        return true;
    }

    public bool Place(GameObject item)
    {
        return false;
    }

    public GameObject Take(GameObject item)
    {
        GameObject returnObject = Instantiate(ingredient, new Vector3(0, 0, 100), Quaternion.identity) as GameObject;
        Debug.Log("Take successful on cabinet");
        returnObject.name = returnObject.name.Substring(0, returnObject.name.Length-7);
        return returnObject;

    }
}
