using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Dictionary<Object,int> _Inventory;
    public List<RawImage> _HotBar;
    public int _Selection;
    private Canvas _Canvas;

    public void Awake()
    {
         _Inventory = new Dictionary<Object, int>();
        var items = Resources.LoadAll<Object>("Prefabs/Items");
        foreach (var item in items)
        {
            _Inventory.Add(item,3);
        }


        _HotBar = GetComponentsInChildren<RawImage>().ToList();
        _Canvas = GetComponentInChildren<Canvas>();
        _Selection = 0;
    }

    public void Update()
    {

     
       
    }



}
