using System.Collections.Generic;
using UnityEngine;
using System.Linq;


using DiggyDigs.Common.Collider;

public class Entity_Collider : MonoBehaviour
{   
    public List<BoxCollider> BoxCollider;
    public Entity_Animator _Animator;
    private List<EntityRay> preception;
    private Vector3 center; 
   
    public void Disable()
    {
        if (BoxCollider == null)
            return;
        BoxCollider.ForEach(x => x.enabled = false);
    }

    public void Enable()
    {
        if (BoxCollider == null)
            return;
        BoxCollider.ForEach(x => x.enabled = true);
    }

    public void Awake()
    {        
        BoxCollider = GetComponentsInChildren<BoxCollider>().ToList<BoxCollider>();
        _Animator = GetComponentInParent<Entity_Animator>();
    }
}
