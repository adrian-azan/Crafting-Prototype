using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity_Skin : MonoBehaviour
{
    private List<Renderer> _Render;

    [Range(0.0f, 1.0f)]
    public float[] color;


    public void Disable()
    {
        if (_Render == null)
            return;
        _Render.ForEach(x => x.enabled = false);
    }

    public void Enable()
    {
        if (_Render == null)
            return;
        _Render.ForEach(x => x.enabled = true);
    }

    private void Awake()
    {
        _Render = GetComponentsInChildren<MeshRenderer>().ToList<Renderer>();                
    }

   
    void Update()
    {
        
    }

}
