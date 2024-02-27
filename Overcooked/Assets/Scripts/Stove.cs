using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stove : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public bool occupied = false;
    public GameObject occupant;
    public Pot pot;
    private PrefabSwitcher switcher;

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
        if (item.tag == "Ingredient" && occupied && item.transform.GetChild(1).gameObject.activeSelf)
        {
            pot = occupant.GetComponent<Pot>();
            if (!pot.ready)
            {
                pot.AddIngredient(item);
                Destroy(item);
                return true;
            }
        }
        if (item.tag == "Plate" && occupied && (item.transform.GetChild(0).gameObject.activeSelf || item.transform.GetChild(4).gameObject.activeSelf))
        {
            pot = occupant.GetComponent<Pot>();
            if (pot.ready)
            {
                pot.Reset();
                switcher = item.GetComponent<PrefabSwitcher>();
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
        
        if ((item.name == "Pot"|| item.name == "Fryer") && !occupied)
        {
            Debug.Log("Place successful on stove");
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
            pot = occupant.GetComponent<Pot>();
            /*if (pot.ready)
            {
                switcher = item.GetComponent<PrefabSwitcher>();
                switcher.ChangePrefab(2);
                
                Debug.Log("Take successful on ready food");
                return null;
            }
            else
            {*/
                Debug.Log("Take successful on stove");
                occupied = false;
                return occupant;
           // }
        }
        else
        {
            return null;
        }
    }
    
}
