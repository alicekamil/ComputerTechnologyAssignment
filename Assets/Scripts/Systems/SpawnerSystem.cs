using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public struct Spawner : IComponentData
    {
        public Entity asteroidPrefab;
        
        public int hazardCount;
        public float3 spawnValues;
        public float spawnWait;
        public float startWait;
        public float waveWait;

        public float nextSpawnTime;
        public float nextWaveTime;
    }
    public partial struct SpawnerSystem : ISystem
    {
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
            {
                spawner.ValueRW.nextSpawnTime += SystemAPI.Time.DeltaTime;
                if (spawner.ValueRO.nextSpawnTime >= spawner.ValueRO.spawnWait)
                {
                    spawner.ValueRW.nextSpawnTime = 0;
                    Entity enemyEntity = state.EntityManager.Instantiate(spawner.ValueRO.asteroidPrefab);
                    state.EntityManager.SetComponentData(enemyEntity, LocalTransform.FromPosition(spawner.ValueRO.spawnValues));
                }
            }
        }
        

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}