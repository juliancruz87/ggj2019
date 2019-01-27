using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField]
    private Transform[] transforms;
    [SerializeField]
    UnityEngine.AI.NavMeshAgent myNavMeshAgent;

    private Transform target;
    private Transform myTransform;

    private void Start ()
    {
        myTransform = transform;
        SetTarget();
    }

    private void Update ()
    {
        if (target == null || myTransform == null)
            return;
        
        float dist = Vector3.Distance(target.position, myTransform.position);
        if(dist <= 1)
            SetTarget();
    }

    private void SetTarget()
    {
        int targetIndex = Random.Range(0, transforms.Length);
        target = transforms[targetIndex];
        myNavMeshAgent.SetDestination(target.position);
    }
}