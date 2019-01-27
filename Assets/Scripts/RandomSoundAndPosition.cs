
using UnityEngine;

public class RandomSoundAndPosition : RandomSound
{
    [SerializeField]
    private float radius = 10;
    protected override void PlayAction()
    {
        base.PlayAction();
        transform.position = Random.insideUnitSphere * radius;
    }
}