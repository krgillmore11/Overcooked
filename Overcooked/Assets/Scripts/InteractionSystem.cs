using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
//Need to add comments
//Need to add list too single out interactable
//and funtion for highlighting
    private Color highlightColor = Color.white;
    public GameObject inHand = null;
    private bool itemHighlighted = false;
    private Collider highlighted;
    private InputManager inputManager;
    private Transform hold;

    private void Awake() //called before start
    {
        inputManager = GetComponent<InputManager>(); //gets from player input manager
        hold = transform.GetChild(1).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.interactPress == true)
        {
            inputManager.interactPress = false;
            AttemptInteraction();
        }
    }

    void AttemptInteraction()
    {

        if (itemHighlighted && inHand == null)
        {
            if (highlighted.GetComponent<IInteractable>() != null)
            {
                if (highlighted.GetComponent<IInteractable>().Occupied())
                {
                    Debug.Log("take tried");
                    inHand = highlighted.gameObject.GetComponent<IInteractable>().Take(inHand);
                    
                    inHand.transform.SetParent(transform);
                    inHand.transform.position = new Vector3(hold.position.x, 
                        hold.position.y, hold.position.z);
                }
            }

        }
        
        else if (itemHighlighted && inHand != null)
        {
            if (highlighted.GetComponent<IInteractable>() != null)
            {
                Debug.Log("place tried");
                if (highlighted.gameObject.GetComponent<IInteractable>().Place(inHand))
                {
                    inHand = null;

                }
            
            }
        }
        
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Interactable")
        {
            if (itemHighlighted == false && col.gameObject != inHand)
            {
                highlighted = col;
                itemHighlighted = true;
                
                foreach (Material mat in col.gameObject.GetComponent<Renderer>().materials)
                {
                    mat.EnableKeyword("_EMISSION");
                    mat.SetColor("_EmissionColor", highlightColor);
                }
            }
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col == highlighted)
        {
            itemHighlighted = false;
            foreach (Material mat in col.gameObject.GetComponent<Renderer>().materials)
            {
                mat.DisableKeyword("_EMISSION");
            }
        }
    }
}
