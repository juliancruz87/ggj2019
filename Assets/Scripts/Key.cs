using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Key : MonoBehaviour 
{
    [SerializeField]
    private GameObject particle;
    public void ClickInKey(BaseEventData eventData)
    {
        particle.SetActive(false);
        gameObject.SetActive(false);
    }
}
