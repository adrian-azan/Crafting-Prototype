using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : Entity_Controller
{
    public Animator _Animator;
    public Vector3 _Facing ;
    private Vector3 _Vel;
    public PlayerInput _Pad;
    private Player _Player;
    
    new void Awake()
    {
        base.Awake();
        _Animator = GetComponentInParent<Animator>();  
        _Player = GetComponentInParent<Player>();
        _Speed = 2;
        _Pad = GetComponent<PlayerInput>();
        
        
        if (_Pad == null)
            Debug.Log("Not Connected");
    }

    public void OnDash(InputValue input)
    {       
        _Animator.Play("Dash");
    }

    public void OnEquipmentNext(InputValue input)
    {
        Debug.Log("Next");
    }

    public void OnMove(InputValue input)
    {
        _Vel = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y); 

        if (_Facing == Vector3.zero)
            Turn(_Vel);

        SetDirection(_Vel+transform.position);     
        if (_Vel.x == 0 && _Vel.z == 0)
            SetVelocity(0);
        else
            SetVelocity(1);  
    }

    public void OnLook(InputValue input)
    {
        Vector2 facing = input.Get<Vector2>();
        _Facing = new Vector3(facing.x,0,facing.y);        
        Turn(_Facing);
    }


    new void FixedUpdate()
    {
        base.FixedUpdate();   
    }        
}
