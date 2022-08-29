using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITool : IItem
{
   public IEnumerator Use(Inventory inventory);
}
