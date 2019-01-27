using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject shape;
    [SerializeField]
    private Transform[] transforms;
    [SerializeField]
    UnityEngine.AI.NavMeshAgent myNavMeshAgent;

    [SerializeField]
    private float minTime;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private float maxTime;

    [SerializeField]
    private float maxTimeVisible = 1.5f;

    private float timer;
	private Transform target;
	private Transform myTransform;

    private void Start ()
    {
        myTransform = transform;
        SetTarget();
		Disabled();
    }

    private void Update ()
    {
        if (target == null || myTransform == null)
            return;
        
        float dist = Vector3.Distance(target.position, myTransform.position);
        if(dist <= 1)
            SetTarget();

        if(Vector3.Distance(player.position, myTransform.position) < 2)
        {
            Scream();
        }

        if (timer < 0)
        {
            PlayAction();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void Scream()
    {
        source.PlayOneShot(clip);
    }

    private void PlayAction ()
    {
        shape.SetActive(true);
        Invoke("Disabled",maxTimeVisible);
    }

    private void Disabled ()
    {
        timer = Random.Range(minTime, maxTime);
        shape.SetActive(false);
    }

    private void SetTarget()
    {
        int targetIndex = Random.Range(0, transforms.Length);
        target = transforms[targetIndex];
        myNavMeshAgent.SetDestination(target.position);
    }
}