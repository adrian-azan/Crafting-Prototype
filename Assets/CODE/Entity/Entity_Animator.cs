using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Entity_Animator : MonoBehaviour
{
    private Animator _Animator;

    public void Awake()
    {
        _Animator = GetComponent<Animator>();
    }

    public void Play(string stateName, int layer = 0)
    {        
        _Animator.Play(stateName,layer);
    }

    public bool IsState(string stateName, int layer = 0)
    {
        return _Animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
        
    }

    public void Speed(int speed = 1)
    {
        _Animator.speed = speed;
    }

    public void SetInteger(string parameterName, int value)
    {
        try
        {
            _Animator.SetInteger(parameterName,value);
        }
        catch
        { 
            Debug.LogError(string.Format("{} in {} does not exist",parameterName,this.gameObject));
        }
    }

    public void SetBool(string parameterName, bool value)
    {
        try
        {
            _Animator.SetBool(parameterName,value);
        }
        catch
        { 
            Debug.LogError(string.Format("{} in {} does not exist",parameterName,this.gameObject));
        }
    }



}
