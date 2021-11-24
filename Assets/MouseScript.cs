using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] screens = new GameObject[6];
    private int currentScreenIndex = 0;
    public void HoverOver()
    {
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    public void HoverEnd()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

    public void NextScreen()
    {
        Debug.Log("Current Screen Index: " + currentScreenIndex);
        if (currentScreenIndex < screens.Length - 1)
        {
            screens[currentScreenIndex].SetActive(false);
            currentScreenIndex++;
            screens[currentScreenIndex].SetActive(true);
        }
    }

    public void CheckScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

}
