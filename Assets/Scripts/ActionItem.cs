using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionItem : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    string triggerAnimationName;
    [SerializeField]
    GameObject key;

    public void ClickInKey(BaseEventData eventData)
    {
        if(!string.IsNullOrEmpty(triggerAnimationName) && animator != null)
            animator.SetBool(triggerAnimationName, true);
        key.SetActive(true);
    }
}