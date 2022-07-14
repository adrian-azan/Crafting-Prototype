using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : Entity_Controller
{
    public Animator _Animator;
    public Vector3 _Facing ;
    
    new void Awake()
    {
        base.Awake();
        _Animator = GetComponentInParent<Animator>();      
        _Speed = 2;
    }


    new void FixedUpdate()
    {        
        float vertical = Controller.Vertical();
        float horizontal = Controller.Horizontal();    
        _Facing  = new Vector3(Controller.LeftRightArrow(),0,Controller.UpDownArrow()).normalized;
        

        var vel = new Vector3(horizontal,_Velocity.y,vertical).normalized;   
      
        if (_Facing == Vector3.zero)
        { 
            _Facing = vel;
            _Facing.y = 0;
        }        
        Turn(_Facing);  


        SetDirection(vel+transform.position);     
        if (vel.x == 0 && vel.z == 0)
            SetVelocity(0);
        else
            SetVelocity( );    
             

        base.FixedUpdate();   
    }    
    
}
