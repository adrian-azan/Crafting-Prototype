using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Potion : Item, IThrowable
{   
    public PlayerInput _AimingController;
    public GameObject crossHair;

    public void Awake()
    {
        _AimingController = GetComponent<PlayerInput>();
        _AimingController.SwitchCurrentActionMap("Aiming");
        _AimingController.SwitchCurrentControlScheme("GamePad", Gamepad.current);
        base.Awake();
    }

    public IEnumerator Consume(Inventory inventory)
    {            
        SnapTo(inventory._Root.position + Vector3.forward);
        var angle = inventory.transform.eulerAngles.y; 

        if (angle < 0)
            angle = 360 + angle;
     
        RotateAround(inventory.transform.position, Vector3.up, angle);            

         _Controller.Disable();
        _Skin.Disable();

        GetComponentInChildren<BoxCollider>().enabled = false;
        transform.SetParent(inventory._Root);     

        yield return null;
    }
    public IEnumerator Throw()
    {

        _Animator.Play("Rise");

        _Controller.SetDirection(transform.eulerAngles.y + 90);
        _Controller.SetVelocity(5);
        _Controller.Enable();
        _Skin.Enable();

        transform.SetParent(null);
        yield return new WaitUntil(() => _Animator.IsState("EXIT"));
        Destroy(this.gameObject);
    }

    public void OnRelease(InputValue input)
    {
        if (input.isPressed == false)    
            StartCoroutine(Throw());
    }
    
    
}
