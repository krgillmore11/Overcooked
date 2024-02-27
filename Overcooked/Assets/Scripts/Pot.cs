using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ready = false;
    public bool burnt = false;
    public int onions = 0;
    public int fish = 0;
    public int potato = 0;
    private PrefabSwitcher switcher;
    public int foodNum = 0;

    void Start()
    {
        switcher = GetComponent<PrefabSwitcher>();
        Reset();
    }

    public void AddIngredient(GameObject ingredient)
    {
        if (!ready && !burnt)
        {
            Debug.Log("not ready not burnt");
            //Add ingredients
            Debug.Log("");
            Debug.Log(ingredient.gameObject.name.Length);
            Debug.Log(ingredient.gameObject.name);
            if (ingredient.gameObject.name == "DYNAMIC ONION")
            {
                Debug.Log("onion counter iterated");
                onions++;
            }
            if (ingredient.gameObject.name == "DYNAMIC FISH")
            {
                Debug.Log("onion counter iterated");
                fish++;
            }
            if (ingredient.gameObject.name == "DYNAMIC POTATO")
            {
                Debug.Log("onion counter iterated");
                potato++;
            }
        
            //Recipe book
            if (onions == 3)//onion soup
            {
                ready = true;
                switcher.ChangePrefab(2);
                foodNum = 2;
            }

            if (fish == 1)
            {
                ready = true;
                switcher.ChangePrefab(2);
                foodNum = 4;
            }
            if (potato == 1)
            {
                ready = true;
                switcher.ChangePrefab(3);
                foodNum = 5;
            }
        }
        
    }

    public void Reset()
    {
        switcher.ChangePrefab(1);
        onions = 0;
        fish = 0;
        potato = 0;
        ready = false;
        burnt = false;
    }
}
