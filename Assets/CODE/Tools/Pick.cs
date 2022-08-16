using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : Entity, IUseable
{

    public new void Awake()
    {
        base.Awake();
        Disable();
        
    }
    public IEnumerator Use(Inventory inventory)
    {                            
        Enable();

        _Animator.Play("Swing");

        yield return new WaitForSeconds(.2f);
        yield return new WaitUntil(() => _Animator.IsState("Idle"));

        Disable();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
    }

    private void LateUpdate()
    {
        
        var source = transform.root;        

        var x = Mathf.Sin( source.localEulerAngles.y * Mathf.Deg2Rad)*2.5f;
        var z = Mathf.Cos( source.localEulerAngles.y * Mathf.Deg2Rad)*2.5f;

        var end = source.transform.position;
        end.x += x;
        end.z += z;

        Debug.DrawLine(source.position,end,Color.red);
    }
}
