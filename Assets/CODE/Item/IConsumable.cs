using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IConsumable : IItem
{    
   public IEnumerator Consume(Inventory inventory);  
}
