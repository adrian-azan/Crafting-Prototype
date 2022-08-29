using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOptimize :MonoBehaviour
{

    private void OnBecameInvisible()
    {
        var e = GetComponentInParent<Entity>();

        if (e != null)
        { 
       //     StartCoroutine(e.DisableAnimator());
           
        }
    }

    private void OnBecameVisible()
    {
        var e = GetComponentInParent<Entity>();

        if (e != null)
        { 
         //   StartCoroutine(e.EnableAnimator());
          
        }
    }
}
