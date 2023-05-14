using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
* https://www.youtube.com/watch?v=WU23Uj1oeh8
* Half Life Alyx Distance Grab - Unity Tutorial 
* by Valem Tutorials
*/
public class XRAlyxGrabInteractable : XRGrabInteractable
{
    public float velocityThreshold = 2;
    [SerializeField]
    private XRRayInteractor rayInteractor;
    private Vector3 previousPos;
    private Rigidbody interactableRigidbody;
    protected override void Awake()
    {
        base.Awake();
        interactableRigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject is XRRayInteractor)
        {
            trackPosition = false;
            trackRotation = false;
            throwOnDetach = false;
        }
        else
        {
            trackPosition = true;
            trackRotation = true;
            throwOnDetach = true;
        }
        base.OnSelectEntered(args);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(isSelected && firstInteractorSelecting is XRRayInteractor)
        {
            Vector3 velocity = (rayInteractor.transform.position - previousPos) / Time.fixedDeltaTime;
            previousPos = rayInteractor.transform.position;

            if(velocity.magnitude > velocityThreshold)
            {
                Drop();
                interactableRigidbody.velocity = Vector3.up;
            }
        }

    }
}
