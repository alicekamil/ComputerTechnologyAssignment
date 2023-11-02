using DefaultNamespace.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public partial struct ProjectileMoveSystem : ISystem
    {

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
           
            foreach (var (transform, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, ProjectileMoveSpeed>())
            {
                transform.ValueRW.Position += transform.ValueRO.Forward() * moveSpeed.Value * deltaTime;
            }
        }
    }
}