using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerToEnd : MonoBehaviour
{

    [SerializeField] private string sceneToLoad;
    [SerializeField] private float waitTime;

    private IEnumerator WaitToLoadScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneToLoad);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WaitToLoadScene();
    }
}
