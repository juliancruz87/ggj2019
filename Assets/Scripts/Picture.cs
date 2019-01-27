using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject key;

    void OnMouseDown()
    {
        animator.SetBool("IsOpen", true);
        key.SetActive(true);
    }
}