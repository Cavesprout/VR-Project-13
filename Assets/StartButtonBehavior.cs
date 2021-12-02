using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehavior : MonoBehaviour
{
    public void HoverOver()
    {
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    public void HoverEnd()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
    public void StartSafetyTraining()
    {

    }

    public void StartLaserCutterTraining()
    {
        SceneManager.LoadScene(sceneBuildIndex:1, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }
}
