using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : Item, ITool
{

    public new void Awake()
    {
        base.Awake();        
    }
       
   

    public IEnumerator Use(Inventory inventory)
    {

        SnapTo(inventory.transform.position + Vector3.forward/2);

        var angle = inventory.transform.eulerAngles.y;
        if (angle < 0)
            angle = 360 + angle;
        RotateAround(inventory.transform.position, Vector3.up, angle);
        transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, transform.eulerAngles.z);

        
        
        _Animator.Play("Swing");
        transform.SetParent(inventory.transform);
        yield return new WaitForSeconds(.2f);
        yield return new WaitUntil(() => _Animator.IsState("Idle"));

        Destroy(this.gameObject);
    }
}
