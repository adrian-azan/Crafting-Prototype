using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiggyDigs.Common.Tools
{
    public static class Tools
    {
       public static float DistanceToXZ(Transform source, Transform target)
        {
            var sourceXZ = source.localPosition;
            sourceXZ.y = 0;
            
            var targetXZ = target.localPosition;
            targetXZ.y = 0;

            return (sourceXZ-targetXZ).magnitude;
        }

        public static float DistanceToXZ(Vector3 source, Vector3 target)
        {
            var sourceXZ = source;
            sourceXZ.y = 0;
            
            var targetXZ = target;
            targetXZ.y = 0;

            return (sourceXZ-targetXZ).magnitude;
        }
    }
}
