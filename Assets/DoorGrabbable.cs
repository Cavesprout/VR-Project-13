using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGrabbable : UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable
{
    public Transform handler;
    protected override void Detach()
    {
        base.Detach();
        this.transform.position = handler.position;
        this.transform.rotation = handler.rotation;
    }

}
