using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour, IInteractable
{
    public bool occupied = false;
    public GameObject occupant;
    public Pot pot;

    private Transform placeSpot;
    // Start is called before the first frame update
    void Start()
    {
        
        placeSpot = transform.GetChild(0).gameObject.transform;
        if (occupied)
        {
            occupant = transform.GetChild(1).gameObject;
        }
    }

    public bool Occupied()
    {
        return occupied;
    }

    public bool Place(GameObject item)
    {
        if (occupied && item.tag == "Ingredient" && (occupant.name == "Pot" || occupant.name == "Fryer") && item.transform.GetChild(1).gameObject.activeSelf)
        {
            pot = occupant.GetComponent<Pot>();
            if (!pot.ready)
            {
                pot.AddIngredient(item);
                Destroy(item);
                return true;
            }
            
        }
        if (occupied && item.tag == "Plate" && (occupant.name == "Pot" || occupant.name == "Fryer") 
            && (item.transform.GetChild(0).gameObject.activeSelf || item.transform.GetChild(4).gameObject.activeSelf))
        {
            pot = occupant.GetComponent<Pot>();
            if (pot.ready)
            {
                
                Debug.Log("plate filled");
                pot.Reset();
                PrefabSwitcher switcher = item.GetComponent<PrefabSwitcher>();
                if (item.transform.GetChild(0).gameObject.activeSelf)
                {
                    switcher.ChangePrefab(pot.foodNum);
                }
                else if (item.transform.GetChild(4).gameObject.activeSelf)
                {
                    switcher.ChangePrefab(pot.foodNum);
                }
            }
        }
        if(!occupied)
        {
            Debug.Log("Place successful on cabinet");
            item.transform.SetParent(transform.GetChild(0));
            item.transform.position = new Vector3(placeSpot.position.x, 
                placeSpot.position.y, placeSpot.position.z);
            occupied = true;
            occupant = item;
            return true;
        }

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
