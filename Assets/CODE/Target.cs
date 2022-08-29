using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DiggyDigs.Common.Tools;

public class Target : Entity, IDestroyable
{
    // Start is called before the first frame update
    
    public Vector3 _Origin;
    public Vector3 _Velocity;

    public List<Color> colors;
    public int colorIndex;
    private new void Awake()
    {

        base.Awake();

        _Health = 3;       
        _Origin = transform.position;
        _Velocity = new Vector3(0,0,1);
        _Animator.Disable();
        colors = new List<Color>{ Color.red,Color.blue,Color.yellow};
        colorIndex = 0;
        StartCoroutine(ShiftColor());
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

    public IEnumerator ShiftColor()
    {
        yield return new WaitForSeconds(2);
        _Skin.SetColor(colors[(colorIndex++)%3]);
        StartCoroutine(ShiftColor());

    }

    public IEnumerator Destroy()
    {
        _Animator.Enable();
        _Coroutines["Destroy"] = false;
        _Animator.Play("Destroyed");
        yield return null;
    }
}
