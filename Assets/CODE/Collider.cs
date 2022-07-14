using UnityEngine;

namespace DiggyDigs.Common.Collider
{
     public class EntityRay
     {
        public Vector3 Direction {get; }
        public Vector3 Center {get; }
        public Color Color {get; }
        public float Length {get;set; } 
        public RaycastHit Raycast { get;set;}
        public bool Hit;

  

        public EntityRay(Vector3 direction, float length,Vector3 offset, Color color)
        {
            Direction = direction;
            Length = length;
            Center = offset;
            Color = color;
            Hit = false;
        }

        public EntityRay(Vector3 direction,float length, Color color):this(direction,length,Vector3.zero,color)
        {      
        }       
     }

    public enum Side
    {
        top,
        top_right,
        right,
        bottom_right,
        bottom,
        bottom_left,
        left,
        top_left,
        front,
        front_left,
        front_right,
        back,
        back_left,
        back_right,
        forward
    }
}
