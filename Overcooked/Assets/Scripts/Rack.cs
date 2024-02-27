using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rack : MonoBehaviour, IInteractable
{
    public bool occupied = false;
    public GameObject occupant;

    private Transform placeSpot;
    // Start is called before the first frame update
    void Start()
    {
        placeSpot = transform.GetChild(0).gameObject.transform;
    }

    public bool Occupied()
    {
        return occupied;
    }

    public bool Place(GameObject item)
    {
        Debug.Log("Place successful on cabinet");
        item.transform.SetParent(transform.GetChild(0));
        item.transform.position = new Vector3(placeSpot.position.x, 
            placeSpot.position.y, placeSpot.position.z);
        occupied = true;
        occupant = item;
        return false;
    }

    public GameObject Take(GameObject item)
    {
        if (occupant != null)
        {
            Debug.Log("Take successful on cabinet");
            occupied = false;
            return occupant;
        }
        else
        {
            return null;
        }
    }
}
