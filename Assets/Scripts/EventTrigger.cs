using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;


public class EventTrigger : MonoBehaviour
{
    private bool atComputer = false;
    [SerializeField] private string methodToCall;

    private void Update()
    {
        if (atComputer == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E in Trigger");

            // Call the method specified by the methodToCall string using reflection
            // reflections are apparently not great for performance 

            if (!string.IsNullOrEmpty(methodToCall))
            {
                MethodInfo method = GetType().GetMethod(methodToCall, BindingFlags.Instance | BindingFlags.NonPublic);
                if (method != null)
                {
                    method.Invoke(this, null);
                }
                else
                {
                    Debug.LogError("Method not found: " + methodToCall);
                }
            }
        }
    }

    private void PlayComputerNarration()
    {
        NarrationManager.instance.PlayOneShot(FMODEvents.instance.Narration111);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        atComputer = true;
        Debug.Log("In the Trigger");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        atComputer = false;
    }
}
