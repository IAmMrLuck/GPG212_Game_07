using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private GameObject thisGameobject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Trigger");
        PlayerMovement.hasKey = true;
        Destroy(thisGameobject);
    }

}
