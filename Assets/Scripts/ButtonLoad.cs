using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonLoad : MonoBehaviour
{
    
    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainScene");
    }    


}
