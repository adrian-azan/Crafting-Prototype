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
    public Item[] _Items;
    public Inventory _Inventory;


    public int index;
  
    public new void Awake()
    {
        _Inventory = GetComponentInChildren<Inventory>();
    
        var itemObjects = Resources.LoadAll<GameObject>("Prefabs/Items");
        _Items = new Item[itemObjects.Length];

        for (int i = 0; i < itemObjects.Length;i++)
        {
            _Items[i] = itemObjects[i].GetComponent<Item>();
        }

        var test = _Inventory.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        test.text = _Items[0] == null ? "N/A" : _Items[0]._Name;
        index = 0;
        
        _Controller = GetComponentInChildren<Player_Controller>();       
        
    }

    protected void Start()
    {             
       
    }

    public void Next()
    {
        index ++;
        index %= _Items.Length;
        _Inventory.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _Items[index] == null ? "N/A" : _Items[index]._Name;
        
        
    }
    public void Prev()
    {
         index = index == 0 ? _Items.Length -1 : index-1;
        _Inventory.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _Items[index] == null ? "N/A" : _Items[index]._Name;     
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
