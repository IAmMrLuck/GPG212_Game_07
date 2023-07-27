using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject panelToShow;
    private GameObject grabbedObjet;
    public Transform placeToHoldObject;
    private bool isCloseToObject = false;
    [SerializeField] private KeyCode pickUpKeyCode;
    private bool isHoldingObject = false;


    private void Start()
    {
        panelToShow.SetActive(false);
    }

    private void Update()
    {
        if(isHoldingObject == false)
        {
            if (isCloseToObject == true && Input.GetKey(pickUpKeyCode))
            {
                Debug.Log("CloseToObject true and E Pressed");
                isHoldingObject = true;
                PlayerMovement.hasKey = true;
                grabbedObjet.transform.position = placeToHoldObject.position;
                grabbedObjet.transform.SetParent(transform);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Trigger");
        panelToShow.SetActive(true);
        isCloseToObject = true;

        Debug.Log("isClose is " + isCloseToObject);

      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panelToShow.SetActive(false);
        isCloseToObject = false;
    }


}
