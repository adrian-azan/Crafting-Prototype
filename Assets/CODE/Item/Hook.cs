using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiggyDigs.Common.Tools;

public class Hook : Item, IConsumable
{

    Transform compliment;
    public Object piece;

    public IEnumerator Consume(Player player)
    {
        SnapTo(player.transform.position + Vector3.forward);                  
        var angle = player.transform.eulerAngles.y; 

        if (angle < 0)
            angle = 360 + angle;
      
        RotateAround(player.transform.position, Vector3.up, angle);

        _Controller.SetDirection(angle+90);
        _Controller.SetVelocity();  

        compliment = player.transform;

        yield return null;
    }

     public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var target = hit.gameObject.GetComponentInParent<Entity>();

        _Controller.SetVelocity(0);
        GetComponent<CharacterController>().enabled = false;
        GetComponentInChildren<BoxCollider>().enabled = false;

        if (target)
        { 
            transform.SetParent(target.transform);
        }    

        StartCoroutine(Connect());      
    }

    public IEnumerator Connect()
    {
        var rise = compliment.localPosition.z - transform.localPosition.z;
        var run = compliment.localPosition.x - transform.localPosition.x;
        var slope = Mathf.Abs(rise / run);

        var start = transform.localPosition;
        var end = compliment.localPosition;

        yield return new WaitWhile(() => {

            start.x += Mathf.Sign(run) * .25f;
            start.z += Mathf.Sign(rise) * slope * .25f;

            Instantiate(piece, new Vector3(start.x, start.y,start.z), Quaternion.identity);
            return Tools.DistanceToXZ(start,end) > 1;
        });
    }

    // Start is called before the first frame update
    public new void Awake()
    {
        base.Awake();
        _Controller.SetSpeed(10);
        _Controller.SetGravity(.05f);  
    }   
}
