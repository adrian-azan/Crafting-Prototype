using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Entity, IConsumable
{
    IEnumerator IConsumable.Consume(Player player)
    {
        SnapTo(player.transform.position + Vector3.forward);                  
        var angle = player.transform.eulerAngles.y; 

        if (angle < 0)
            angle = 360 + angle;
     
        RotateAround(player.transform.position, Vector3.up, angle);            
      
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
