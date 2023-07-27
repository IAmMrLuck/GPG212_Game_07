using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InteractToEnd : MonoBehaviour
{

    [SerializeField] private GameObject panelToLoad;
    [SerializeField] private string sceneToLoad;
    private bool atSceneLoadingObject = false;

    

    private void Awake()
    {
        panelToLoad.SetActive(false);
    }

    private void Update()
    {
        if(atSceneLoadingObject == true && Input.GetKeyDown(KeyCode.E))
        {
            LoadEndingScene();
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        atSceneLoadingObject = true;

        panelToLoad?.SetActive(true);

        Debug.Log("In the Trigger");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panelToLoad?.SetActive(false);

        atSceneLoadingObject = false;
    }

    private void LoadEndingScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
