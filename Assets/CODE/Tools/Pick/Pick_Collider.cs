using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Collider : Entity_Collider
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
        Disable();
        var target = other.GetComponentInParent<Entity>();
        StartCoroutine(target?.TakeDamage(1));
       _Animator.Play("Twang");
    }
}
