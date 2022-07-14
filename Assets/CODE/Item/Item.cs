using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : Entity
{
    public abstract IEnumerator Use(Player player);
}
