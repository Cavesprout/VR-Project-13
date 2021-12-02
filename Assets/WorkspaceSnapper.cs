using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceSnapper : MonoBehaviour
{
    Transform tempParent;
    public Transform snapSpot;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "LaserCutterMaterial")
        {
            tempParent = collision.transform.parent;
            collision.transform.parent = transform;
            collision.transform.localPosition = new Vector3(collision.transform.localScale.x/-2f, collision.transform.localScale.z/-2f, 0f);
            collision.transform.localRotation = new Quaternion(90f, 0f, 0f, 0f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = tempParent;
        tempParent = null;
    }
}
