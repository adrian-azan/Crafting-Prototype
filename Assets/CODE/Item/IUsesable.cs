using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IUseable : IItem
{    
   public IEnumerator Use(Player player);  
}
