using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


public class Player : Entity
{
    public Vector3 _LastDirection;

    public Light _Light;
    public Vector3 _Facing;
    public Object[] _Items;
    public Dictionary<Object,int> _Inventory;

   // private Player_Controller _Controller;
   public bool one;
    public new void Awake()
    {
        _Items = new Object[5];
        _Inventory = new Dictionary<Object, int>();
        _Items = Resources.LoadAll<Object>("Prefabs");

        var items = Resources.LoadAll<Object>("Prefabs/Items");
        foreach (var item in items)
        {
            _Inventory.Add(item,3);
        }
        _Controller = GetComponentInChildren<Player_Controller>();        
        
    }

    protected void Start()
    {             
        one = true;
    }

    public new void Update()
    {    
        var action = Controller.Action();
        var jump = Controller.Jump();
        jump = false;
        var number = Input.GetKeyDown(KeyCode.Alpha1);

        if (number && _Inventory.ContainsKey(_Items[1]) && _Inventory[_Items[1]] > 0)
        {
            var t = Instantiate(_Items[1]) as GameObject;
            var item = t.GetComponent<IConsumable>();
            StartCoroutine(item.Consume(this)); 
            _Inventory[_Items[1]] -= 1;
        }
        if (action)
        {

           // var p = GetComponentInChildren<Pick>();
          //  StartCoroutine(p.Use(this));

            var t = Instantiate(_Items[1]) as GameObject;
            var item = t.GetComponent<IUseable>();
            item.Use(this);     
        }

        if (jump)
        {
            var t = Instantiate(_Items[1]) as GameObject;
            var item = t.GetComponent<IUseable>();
            item.Use(this);        
        }
    }   
}
