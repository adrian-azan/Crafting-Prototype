using System.Collections.Generic;
using UnityEngine;
using System.Linq;


using DiggyDigs.Common.Collider;

public class Entity_Collider : MonoBehaviour
{   
    public List<BoxCollider> BoxCollider;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
    }

    public void FixedUpdate()
    {
        int environment = (1 << 3);
        int enemy = (1 << 8);
        int transparentEnemy = (1 << 7);

        int ignore = ~(environment | enemy | transparentEnemy);


       // center =  BoxCollider.transform.position;   
       /* foreach (var s in preception)
        {          
            Ray landingRay = new Ray(center+s.Center, s.Direction);
            RaycastHit hit;

            if (Physics.Raycast(landingRay, out hit, s.Length, ignore))
                s.Hit = true;        
            else 
                s.Hit = false;         

            s.Raycast = hit;
        } */

                
        /*foreach (var s in preception)
        {
            if (s.Hit)
                Debug.DrawRay(center+s.Center, s.Direction*s.Length, Color.red );            
            else 
                Debug.DrawRay(center+s.Center, s.Direction*s.Length, s.Color );            
        } */
    }


    public EntityRay GetActive()
    {
        return preception.FirstOrDefault(r => r.Hit);        
    }

    public void SetUp()
    {   
       
        preception = new List<EntityRay>();  
        int amount = 16;

        for (float i = 0; i < 360; i += 360/amount)
        {
            //float y = Mathf.Sin(Mathf.Deg2Rad * i);
            float x = Mathf.Cos(Mathf.Deg2Rad * i);
            float z = Mathf.Sin(Mathf.Deg2Rad * i);

          //  preception.Add(new EntityRay(new Vector3(x,0,z), BoxCollider.size[0]*5, Color.blue));
          //  preception.Add(new EntityRay(new Vector3(x,-1,z), BoxCollider.size[0]*5, Color.blue));
            //  preception.Add(new EntityRay(new Vector3(x,y,0), BoxCollider.size[0]*5, Color.green));
            //  preception.Add(new EntityRay(new Vector3(x,y,z), BoxCollider.size[0]*5, Color.magenta));
        }          
    }

  

}
