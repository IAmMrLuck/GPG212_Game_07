using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerToEnd : MonoBehaviour
{

    [SerializeField] private string sceneToLoad;

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneToLoad);
        NarrationManager.instance.PlayOneShot(FMODEvents.instance.Narration111);
    }
}
