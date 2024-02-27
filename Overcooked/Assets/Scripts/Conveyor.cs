using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Conveyor : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public bool occupied = false;
    public List<string> tickets = new List<string>();
    public TextMeshProUGUI ticketDisplay;
    public TextMeshProUGUI tipsDisplay;
    public TextMeshProUGUI timer;
    public GameObject receptical;
    private int tips = 0;
    
    public float targetTime = 120.0f;
    

    void Start()
    {
        ChangeDisplay();
    }

    void Update()
    {
        if (targetTime > 0)
        {
            targetTime -= Time.deltaTime;
            timer.text = targetTime.ToString("F0");
        }
        else
        {
            timer.text = "Game Over";
        }
        
    }


    public bool Occupied()
    {
        return occupied;
    }
    
    public bool Place(GameObject item)
    {
        GameObject first = null;
        if (item.tag == "Plate")
        {
            for (int i = 0; i < item.transform.childCount; i++)
            {
                if(item.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    first = item.transform.GetChild(i).gameObject;
                }
            }
            for (int i = 0; i < tickets.Count; i++)
            {
                if (first != null && tickets[i] == first.name)
                {
                    tickets.RemoveAt(i);
                    ChangeDisplay();
                    tips += (10+(int)targetTime);
                    tipsDisplay.text = tips.ToString();
                    item.GetComponent<PrefabSwitcher>().ChangePrefab(3);
                    if (receptical.GetComponent<IInteractable>() != null)
                    {
                        receptical.GetComponent<IInteractable>().Place(item);
                    }
                    return true;
                }
            }
            
        }

        return false;
    }

    public GameObject Take(GameObject item)
    {
        return null;
    }

    private void ChangeDisplay()
    {
        ticketDisplay.text = String.Empty;
        for (int i = 0; i < tickets.Count; i++)
            {
                ticketDisplay.text += (tickets[i] + "\n");
            }
    }
    
}
