using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntesityController : MonoBehaviour
{
    [SerializeField]
    float maxDistance = 3f;
    [SerializeField]
    private LayerMask layer;
    [SerializeField]
    private Light light;
    [SerializeField]
    private Color lowColor;
    private Color initColor;

    private Transform myTransform;

    private void Start ()
    {
        myTransform = transform;
        initColor = light.color;
    }

    private void FixedUpdate ()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(myTransform.position, myTransform.TransformDirection(Vector3.forward), out hit, maxDistance, layer))
        {
            Debug.DrawRay(myTransform.position, myTransform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");
            light.color = lowColor;
        }
        else
        {
            Debug.DrawRay(myTransform.position, myTransform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            light.color = initColor;
        }
    }
}