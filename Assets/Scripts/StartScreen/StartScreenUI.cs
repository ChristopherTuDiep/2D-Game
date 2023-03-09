using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUI : MonoBehaviour
{
    public void StartButton()
    {
        GameBrain.Instance.EmptyRun();
        SceneManager.LoadScene("Cutscene_Scene");
    }
}
