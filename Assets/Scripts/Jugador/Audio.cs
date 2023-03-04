using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{  
    // Update is called once per frame
    void Update()
    {
        // input for testing number 1
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {	
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // search scene by index
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ManagerAudio.Pause();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ManagerAudio.Resume();
        }
    }
}
