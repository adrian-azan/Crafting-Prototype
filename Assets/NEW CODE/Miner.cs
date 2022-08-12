using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Miner
{
    // Start is called before the first frame update
    public Vector3 current;

    public int _MinerId;
    private struct Segment
    { 
        public Segment(Vector3 part, Color color)
        {
            Part = part;
            Color = color;
        }
        public Vector3 Part;
        public Color Color;

        public bool Equal( Vector3 right)
        {
            return Part == right;
        }
    }
    List<Segment> _Trail;
    private Color color;
    public int _Energy;

    public void Start(Vector3 pos)
    {
        _Trail = new List<Segment>();
       current = pos;
        color = Color.white;
        _Energy = 200;
        _MinerId = 0;
    }



    // Update is called once per frame
    public void Update()
    {   
        if (Dead() == false)
            Step();              
    }

    public void Draw()
    {
        for (int i = 0; i < _Trail.Count-1;i++)
        {
            Debug.DrawLine(_Trail[i].Part, _Trail[i+1].Part,_Trail[i].Color);
        }  
    }
  
    public bool Dead()
    {
        return _Energy <= 0;
    }

    public void Step()
    {
        var direcition = Random.Range(0,4);       
        var next = current;
         
        if (direcition == 0)
        {
            next.x += 1;        
        }  
        if (direcition == 1)
        {
            next.x -= 1;          
        }  
        if (direcition == 2)
        {
            next.z += 1;       
        }  
        if (direcition == 3)
        {
            next.z -= 1;           
        }
        _Energy -= 1;


        if(_Trail.Any(x => x.Part == next ) == false 
            && next.x >= 0 && next.x < 100 && next.z >= 0 && next.z < 100 )
        {
            _Trail.Add(new Segment(current,color));       
            current = next;
        }
        else
        {
            color = Random.ColorHSV();           
        }
    }
}
