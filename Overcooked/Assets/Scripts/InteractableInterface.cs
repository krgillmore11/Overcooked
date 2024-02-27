using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool Occupied();
    bool Place(GameObject item);
    GameObject Take(GameObject item);
}

