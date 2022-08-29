using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item, IConsumable
{


    IEnumerator IConsumable.Consume(Inventory inventory)
    {
        SnapTo(inventory.transform.position + Vector3.forward);                  
        var angle = inventory.transform.eulerAngles.y; 

        if (angle < 0)
            angle = 360 + angle;
     
        RotateAround(inventory.transform.position, Vector3.up, angle);            
      
        _Animator.Play("CountDown");
        yield return new WaitWhile(() => _Animator.IsState("Idle"));
       

         yield return new WaitForSeconds(3);           
        
         _Animator.Speed(3);       
         yield return new WaitForSeconds(2);        

         _Animator.Speed(6);
         yield return new WaitForSeconds(1);
        _Animator.SetBool("Dead",true);

        yield return new WaitUntil(() => _Animator.IsState("EXIT"));
        
        Destroy(this.gameObject);        
    }    
}
