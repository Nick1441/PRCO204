using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    //This Method Will move the Player to the interactive scene
    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }
}
