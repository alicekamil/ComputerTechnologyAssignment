using DefaultNamespace.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public partial class AsteroidDestroySystem : SystemBase
    {
        public struct BoundaryData : IComponentData
        {
            public float3 boundaryValues;
        }
        
        protected override void OnUpdate()
        {
            var ecb = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(World.Unmanaged);
            
            //destroy entity if the position is outside of the boundaryvalues 
            Entities.ForEach((Entity e, in BoundaryData boundaryData, in LocalTransform transform) =>
            {
                //Debug.Log("Foreach");
                //Debug.Log(boundaryData.boundaryValues.z.ToString());
                if(!Inside(transform.Position, boundaryData.boundaryValues))
                {
                    //Debug.Log(" not inside " + transform.Position);
                    ecb.DestroyEntity(e);
                }
            }).Schedule();
        }

        public static bool Inside(float3 point, float3 boundaryData)
        {
            //Debug.Log("calling Inside function");
            float x = -boundaryData.x / 2;
            float XPW = boundaryData.x / 2;
            float z = -boundaryData.z / 2;
            float ZPH = boundaryData.z / 2;
            //Debug.Log("px: " + point.x.ToString() + ", pz: " + point.z.ToString() + " [" + x.ToString() + "," + XPW.ToString() + "," + z.ToString() + "," + ZPH.ToString());
            return point.x >= x && point.x <= XPW &&
                   point.y >= -boundaryData.y / 2 && point.y <= boundaryData.y / 2 &&
                   point.z >= z && point.z <= ZPH;
        }
    }
}

