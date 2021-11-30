using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCutterButton : MonoBehaviour
{
    public Color hoverColor;

    private void Start()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", Color.green);
    }
    
    public void HoverOver()
    {
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    public void HoverEnd()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
}
