using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DiggyDigs.Common.Tools;

public class Target : Entity, IDestroyable
{
    // Start is called before the first frame update
    
    public Vector3 _Origin;
    public Vector3 _Velocity;
    private new void Awake()
    {

        base.Awake();

        _Health = 3;       
        _Origin = transform.position;
        _Velocity = new Vector3(0,0,1);
    }
  
    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        if (Tools.DistanceToXZ(_Origin, transform.position) > 2)
        {
            _Velocity *= -1;
        }     
    }

    public IEnumerator Destroy()
    {
        _Coroutines["Destroy"] = false;
        _Animator.Play("Shrink");
        yield return new WaitUntil(() => _Animator.IsState("EXIT"));     
        Destroy(gameObject);       
    }
}
