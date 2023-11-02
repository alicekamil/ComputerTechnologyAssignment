using DefaultNamespace.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;

namespace Systems
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateAfter(typeof(PhysicsSystemGroup))]
    public partial struct ProjectileCollisionSystem : ISystem
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
            
        }
    }

    struct ProjectileTriggerJob : ITriggerEventsJob
    {
        public ComponentLookup<ProjectileTag> ProjectileGroup;
        public ComponentLookup<EnemyTag> EnemyGroup;
        public EntityCommandBuffer ecb;
        
        public void Execute(TriggerEvent triggerEvent)
        {
            Entity entityA = triggerEvent.EntityA;
            Entity entityB = triggerEvent.EntityB;

            bool entityAIsProjectile = ProjectileGroup.HasComponent(entityA);
            bool entityBIsProjectile = ProjectileGroup.HasComponent(entityB); 
            bool entityAIsEnemy = EnemyGroup.HasComponent(entityA);
            bool entityBIsEnemy = EnemyGroup.HasComponent(entityB);

            if (entityAIsProjectile && entityBIsEnemy)
            {
                ecb.DestroyEntity(entityB);
                //Debug.Log("VAR1");
            }
            if (entityAIsEnemy && entityBIsProjectile)
            {
                ecb.DestroyEntity(entityA);
                //Debug.Log("VAR2");
            }
        }
    }
}