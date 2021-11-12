using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject ContentHider;

    public void HoverOver()
    {
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    public void HoverEnd()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

    public void IndicatorClicked()
    {
        if (ContentHider != null)
        {
            ContentHider.SetActive(false);
        }
        Material mat = GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", Color.green);
        mat.SetColor("_Color", Color.green);
    }
}
