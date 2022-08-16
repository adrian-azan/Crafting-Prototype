using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Item[] _Items;
    public Queue<Item> _ItemQueue;
    public Transform _Root;
    public int index;

    public void Awake()
    {
        _Root = GetComponentInParent<Player>().transform;     
        
        _ItemQueue = new Queue<Item>();
        var itemObjects = Resources.LoadAll<GameObject>("Prefabs/Items");
        _Items = new Item[itemObjects.Length];

        for (int i = 0; i < itemObjects.Length;i++)
        {
            _Items[i] = itemObjects[i].GetComponent<Item>();
        }

        var test = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        test.text = _Items[0] == null ? "N/A" : _Items[0]._Name;
        index = 0;
    }

    public void Next()
    {
        index ++;
        index %= _Items.Length;
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _Items[index] == null ? "N/A" : _Items[index]._Name;
        
        
    }
    public void Prev()
    {
         index = index == 0 ? _Items.Length -1 : index-1;
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _Items[index] == null ? "N/A" : _Items[index]._Name;     
    }

    public void Create()
    {
         if (_Items[index] == null)
            return;
         Item t = null;
         if (_ItemQueue.Count == 0)
            t = Instantiate(_Items[index]);
         else
            t = _ItemQueue.Dequeue();

        var item = t.GetComponent<IItem>();
        if (item is IConsumable)  
            StartCoroutine(((IConsumable)item).Consume(this)); 
        else if (item is IUseable)
            StartCoroutine(((IUseable)item).Use(this)); 
    }

    public void Update()
    {     
       
    }
}
