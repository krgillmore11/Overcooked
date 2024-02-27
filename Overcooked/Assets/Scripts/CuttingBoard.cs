using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour, IInteractable
{
    private PrefabSwitcher switcher;

    public bool Occupied()
    {
        return false;
    }

    public bool Place(GameObject item)
    {
        Debug.Log(item);
        if (item.GetComponent<PrefabSwitcher>() != null && item.tag == "Ingredient")
        {
            switcher = item.GetComponent<PrefabSwitcher>();
            Debug.Log(switcher);
            switcher.ChangePrefab(2);
        }
        return false;
    }

    public GameObject Take(GameObject item)
    {
        return null;
    }
}
