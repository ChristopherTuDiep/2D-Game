using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneScript : MonoBehaviour
{
    private void Start()
    {
        GameBrain.Instance.EmptyRun();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Battle_Scene");
        }
    }
}
