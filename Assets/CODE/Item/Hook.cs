using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiggyDigs.Common.Tools;

public class Hook : Item, IConsumable
{

    public Transform compliment;
    public Object piece;

    private Coroutine deathTimer;

    public IEnumerator Consume(Inventory inventory)
    {

        if (compliment == null)
        {
            var other = Instantiate(this);
            other.compliment = this.transform;
            inventory._ItemQueue.Enqueue(other);
        }

        SnapTo(inventory.transform.position + Vector3.forward);                  
        var angle = inventory.transform.eulerAngles.y; 

        if (angle < 0)
            angle = 360 + angle;
      
        RotateAround(inventory.transform.position, Vector3.up, angle);

        _Controller.SetDirection(angle+90);
        _Controller.SetVelocity();  

        deathTimer = StartCoroutine(DeathTimer(inventory));
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

        StopCoroutine(deathTimer);
        if (compliment != null)
            StartCoroutine(Connect());      
    }

    public IEnumerator Connect()
    {
        
        yield return new WaitWhile(() => compliment.transform.parent == null);
        var rise = compliment.position.z - transform.position.z;
        var run = compliment.position.x - transform.position.x;
        var slope = Mathf.Abs(rise / run);

        var start = transform.position;
        var end = compliment.position;

        
        if (Tools.DistanceToXZ(start,end) > 20)
        {
            Destroy(compliment.gameObject);
            Destroy(this.gameObject);
            yield return null;
        }

        yield return new WaitWhile(() => {

            start.x += Mathf.Sign(run) * .25f;
            start.z += Mathf.Sign(rise) * slope * .25f;

            Instantiate(piece, new Vector3(start.x, start.y,start.z), Quaternion.identity);
            return Tools.DistanceToXZ(start,end) > .2f;
        });
    }

    public IEnumerator DeathTimer(Inventory inventory)
    {
        float start = Time.time;
        yield return new WaitUntil(() => {
            Debug.Log(Time.time - start);
            return Time.time - start > 10;
            });
        
        if (compliment != null)
            Destroy(compliment.gameObject);
        
        if (this != null)
            Destroy(this.gameObject);        
    }


    // Start is called before the first frame update
    public new void Awake()
    {
        base.Awake();
        _Controller.SetSpeed(10);
        _Controller.SetGravity(.05f);  
    }   
}
