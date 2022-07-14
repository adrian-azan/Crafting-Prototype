using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Controller : MonoBehaviour
{
    public CharacterController _Controller;
    public Vector3 _Velocity;
    protected float _Speed;
    protected float _Gravity;
    protected float _Direction;
    
      public void Disable()
    {
        if (_Controller == null)
            return;
        _Controller.enabled = false;
    }

    public void Enable()
    {
        if (_Controller == null)
            return;
        _Controller.enabled = true;
    }

    protected void Awake()
    {
        _Controller = GetComponentInParent<CharacterController>();
        _Velocity = Vector3.zero;
    }
  
    protected void FixedUpdate()
    {
        Gravity(_Gravity);          

        if (_Controller.enabled == true)
            _Controller.Move(_Velocity * Time.fixedDeltaTime);
    }

    public void SetSpeed(float speed)
    {
        if (speed < 0)
            return;
        _Speed = speed;
    }

    public void SetGravity(float gravity)
    {
        _Gravity = gravity;
    }

    public void SetVelocity(float scale = 1)
    {
        _Velocity = new Vector3(1F, _Velocity.y, 1F);
        _Velocity.x = Mathf.RoundToInt(-_Velocity.x * Mathf.Cos(_Direction) * scale * _Speed);
        _Velocity.z = Mathf.RoundToInt(_Velocity.z * Mathf.Sin(_Direction) * scale * _Speed);      
    }

     public void Turn(Vector3 dir, float step = 10)
    {   
        if (dir == Vector3.zero)
            return;

        var angle = Quaternion.RotateTowards(_Controller.transform.rotation,Quaternion.LookRotation(dir,Vector3.up),step);        
        _Controller.transform.rotation = angle;
    }      

    

     public void SetDirection(float angle)
    {
        angle = Mathf.Deg2Rad * angle;
        angle = Mathf.Round(angle * 10.0f) * 0.1f;
      
        _Direction = angle;
    }



     public void SetDirection(Entity target)
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 directionToTarget = _Controller.transform.position - targetPosition;
        float angle = Vector3.SignedAngle(Vector3.left, directionToTarget, Vector3.up) + 180;

        SetDirection(angle);
    }
    public void SetDirection(Vector3 target)
    {        
        Vector3 directionToTarget = _Controller.transform.position - target;
        directionToTarget.y = 0;
        float angle = Vector3.SignedAngle(Vector3.left, directionToTarget, Vector3.up) + 180;

        SetDirection(angle);
    }
   
     public void Gravity(float scale = 1)
     {        
        if (_Velocity.y >= -.2f)
            _Velocity.y += (Physics.gravity.y * Time.fixedDeltaTime * scale);         
        else
            _Velocity.y = (Physics.gravity.y * Time.fixedDeltaTime * scale);        
     }
}
