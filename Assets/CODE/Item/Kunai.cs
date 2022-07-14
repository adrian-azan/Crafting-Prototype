using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : Entity, IUseable
{
    public new void Awake()
    {
        base.Awake();
        _Controller.SetSpeed(10);
        _Controller.SetGravity(.05f);
    }
    public IEnumerator Use(Player player)
    {        
        SnapTo(player.transform.position + Vector3.forward);                  
        var angle = player.transform.eulerAngles.y; 

        if (angle < 0)
            angle = 360 + angle;
      
        RotateAround(player.transform.position, Vector3.up, angle);

        _Controller.SetDirection(angle+90);
        _Controller.SetVelocity();        
        
        return null;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var target = hit.gameObject.GetComponentInParent<Entity>();
        var animator = target?.GetComponentInParent<Animator>();

        _Controller.SetVelocity(0);
        GetComponent<CharacterController>().enabled = false;
        GetComponentInChildren<BoxCollider>().enabled = false;

        if (target)
        { 
            target._Health -= 1;
            transform.SetParent(target.transform);
        }
        animator?.Play("Damaged");
    }



}
