using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour 
{
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip [] clips;

    [SerializeField]
    private float minTime;

    [SerializeField]
    private float maxTime;
    private float timer;

	private void Start()
	{
        timer = Random.Range(minTime, maxTime);
	}

	private void Update()
	{
        if (timer < 0)
        {
            timer = Random.Range(minTime, maxTime);
            int audioIndex = Random.Range(0, clips.Length);
            source.panStereo = Random.Range(-1, 1);
            source.PlayOneShot(clips[audioIndex]);
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}
}