using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;

public class Entity : MonoBehaviour
{
    public Entity_Collider _Collider;
    public Entity_Skin _Skin;
    public Entity_Controller _Controller;
    public Entity_Animator _Animator;
    public float _Health;

   
    public DefaultDictionary<string, bool> _Coroutines;


    public void Disable()
    {     
        _Collider?.Disable();      
        _Skin?.Disable();        
        _Controller?.Disable();

       // if(_Animator)
       //     _Animator.enabled = false;
    }

    public void Enable()
    {       
        _Collider?.Enable();      
        _Skin?.Enable();       
        _Controller?.Enable();

      //  if(_Animator)
      //      _Animator.enabled = true;

    }


    public void Awake()
    {
        _Collider = GetComponentInChildren<Entity_Collider>();
        _Skin = GetComponentInChildren<Entity_Skin>();
        _Controller = GetComponentInChildren<Entity_Controller>();
        _Animator = GetComponent<Entity_Animator>();
        _Health = _Health == 0 ? Mathf.Infinity : _Health;
        _Coroutines = new DefaultDictionary<string, bool>(true);     
    }

    public void Update()
    {
        
    }

    public IEnumerator TakeDamage(float damage)
    {
        if (damage < 0) yield return null;
        
        _Health -= damage;

        if (_Health <= 0)
        {
            if (_Animator)
            {
                _Animator?.Play("Shrink");
                yield return new WaitUntil(() => _Animator.IsState("EXIT"));
            }
            Destroy(this.gameObject);
        }
        else
        {
            _Animator?.Play("Damaged");
        }

    }

    public void SnapTo(Vector3 newPosition)
    {
        _Controller?.Disable();
        transform.position = newPosition;
        _Controller?.Enable();
    }

    public void RotateAround(Vector3 point, Vector3 axis, float angle)
    {
        _Controller?.Disable();
        transform.RotateAround(point, axis, angle);
        _Controller?.Enable();       
    }

}
