using DefaultNamespace.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;

namespace Systems
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateAfter(typeof(PhysicsSystemGroup))]
    public partial struct CollisionSystem : ISystem
    {
        private EntityCommandBuffer ecb;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndFixedStepSimulationEntityCommandBufferSystem.Singleton>();
            state.RequireForUpdate<SimulationSingleton>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            JobHandle jobHandle1 = new TriggerJob
            {
                PlayerGroup = SystemAPI.GetComponentLookup<PlayerTag>(),
                EnemyGroup = SystemAPI.GetComponentLookup<EnemyTag>(),
                ecb = SystemAPI.GetSingleton<EndFixedStepSimulationEntityCommandBufferSystem.Singleton>()
                    .CreateCommandBuffer(state.WorldUnmanaged)
            }.Schedule(SystemAPI.GetSingleton<SimulationSingleton>(), state.Dependency);
            
            JobHandle jobHandle2 = new ProjectileTriggerJob
            {
                ProjectileGroup = SystemAPI.GetComponentLookup<ProjectileTag>(),
                EnemyGroup = SystemAPI.GetComponentLookup<EnemyTag>(),
                ecb = SystemAPI.GetSingleton<EndFixedStepSimulationEntityCommandBufferSystem.Singleton>()
                    .CreateCommandBuffer(state.WorldUnmanaged)
            }.Schedule(SystemAPI.GetSingleton<SimulationSingleton>(), jobHandle1);
            
            jobHandle2.Complete();
        }
    
        [BurstCompile]
        struct TriggerJob : ITriggerEventsJob
        {
            public ComponentLookup<PlayerTag> PlayerGroup;
            public ComponentLookup<EnemyTag> EnemyGroup;
            public EntityCommandBuffer ecb;
        
            public void Execute(TriggerEvent triggerEvent)
            {
                Entity entityA = triggerEvent.EntityA;
                Entity entityB = triggerEvent.EntityB;

                bool entityAIsPlayer = PlayerGroup.HasComponent(entityA);
                bool entityBIsPlayer = PlayerGroup.HasComponent(entityB); 
                bool entityAIsEnemy = EnemyGroup.HasComponent(entityA);
                bool entityBIsEnemy = EnemyGroup.HasComponent(entityB);

                if (entityAIsPlayer && entityBIsEnemy)
                {
                    ecb.DestroyEntity(entityA);
                    //Debug.Log("VAR1");
                }
                if (entityAIsEnemy && entityBIsPlayer)
                {
                    ecb.DestroyEntity(entityB);
                    //Debug.Log("VAR2");
                }
            }
        }
    }
}