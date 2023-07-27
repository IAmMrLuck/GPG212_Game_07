using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject panelToShow;
    [SerializeField] private GameObject thisGameObject;
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
        if (isHoldingObject == false && isCloseToObject == true && Input.GetKey(pickUpKeyCode))
        {
            Debug.Log("CloseToObject true and E Pressed");
            isHoldingObject = true;
            PlayerMovement.hasKey = true;
            thisGameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            thisGameObject.transform.position = placeToHoldObject.position;
            thisGameObject.transform.SetParent(transform);
        }

        else if (isHoldingObject == true && Input.GetKey(pickUpKeyCode))
        {
            thisGameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            thisGameObject.transform.SetParent(null);

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
