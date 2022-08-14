using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
 using System.Linq;


public class Player : Entity
{
    public Vector3 _LastDirection;

    public Light _Light;
    public Vector3 _Facing;
    
    public Inventory _Inventory;


    public Object lastUsed;

    public int index;
  
    public new void Awake()
    {       
        _Controller = GetComponentInChildren<Player_Controller>();       
    }

    protected void Start()
    {             
       
    }

    

    public new void Update()
    {    

        
     //   var action = Controller.Action();
   //     var jump = Controller.Jump();
     //   jump = false;
       // var number = Input.GetKeyDown(KeyCode.Alpha1);

        /*
        if (number && _Inventory.ContainsKey(_Items[1]) && _Inventory[_Items[1]] > 0)
        {
            var t = Instantiate(_Items[1]) as GameObject;
            var item = t.GetComponent<IConsumable>();
            StartCoroutine(item.Consume(this)); 
            _Inventory[_Items[1]] -= 1;
        } */ 
    }   
}
