using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("hit respawn");
        col.gameObject.GetComponent<PlayerManager>().Respawn();
    }
}
