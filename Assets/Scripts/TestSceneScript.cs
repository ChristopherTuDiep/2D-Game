using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneScript : MonoBehaviour
{
    private bool isPaused;

    public GameObject pauseMenu;

    private void Start()
    {
        GameBrain.Instance.EmptyRun();
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("World_Scene");
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                isPaused = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isPaused = false;
            }
        }
        pauseMenu.SetActive(isPaused);
    }
}
