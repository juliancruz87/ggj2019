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
            PlayAction();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    protected virtual void PlayAction()
    {
        timer = Random.Range(minTime, maxTime);
        int audioIndex = Random.Range(0, clips.Length);
        source.panStereo = Random.Range(-1, 1);
        source.PlayOneShot(clips[audioIndex]);
    }
}
