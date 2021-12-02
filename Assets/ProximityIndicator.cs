using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Focus Object Detected");
        if (other.gameObject.tag == "LaserCutterMaterial")
        {
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LaserCutterMaterial")
        {
            GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
    }
}
