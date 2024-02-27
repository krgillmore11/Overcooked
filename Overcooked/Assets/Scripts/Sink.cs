using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public bool occupied = false;
    public List<string> tickets = new List<string>();
    public GameObject rack;
    

    public bool Occupied()
    {
        return occupied;
    }
    
    public bool Place(GameObject item)
    {
        if (item.tag == "Plate" && item.transform.GetChild(2).gameObject.activeSelf)
        {
            item.GetComponent<PrefabSwitcher>().ChangePrefab(1);
                    if (rack.GetComponent<IInteractable>() != null)
                    {
                        rack.GetComponent<IInteractable>().Place(item);
                    }
                    return true;
        }

        return false;
    }

    public GameObject Take(GameObject item)
    {
        return null;
    }
}
