using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public bool occupied = false;

    public bool Occupied()
    {
        return occupied;
    }
    
    public bool Place(GameObject item)
    {
        if (item.tag == "Plate"){
            item.GetComponent<PrefabSwitcher>().ChangePrefab(1);
            return false;
        }
        else
        {
            Destroy(item);
        }

        return true;
    }

    public GameObject Take(GameObject item)
    {
        return null;
    }
}
