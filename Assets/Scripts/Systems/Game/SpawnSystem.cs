using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public struct SpawnData : IComponentData
    {
        public Random randomValue;
    }
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

        public float boundX;
    }
    public partial class SpawnSystem : SystemBase
    {

        protected override void OnUpdate()
        {
            var ecb = SystemAPI.GetSingleton<EndFixedStepSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(World.Unmanaged);
            Entities.ForEach((ref Spawner spawner, ref SpawnData spawnData) =>
            {
                spawner.nextSpawnTime += SystemAPI.Time.DeltaTime;
                if (spawner.nextSpawnTime >= spawner.spawnWait)
                {
                    for (int i = 0; i < spawner.hazardCount; i++)
                    {
                        float xPos = spawnData.randomValue.NextFloat(-spawner.boundX, spawner.boundX);
                        spawner.nextSpawnTime = 0;
                        Entity enemyEntity = ecb.Instantiate(spawner.asteroidPrefab);
                        ecb.SetComponent(enemyEntity, LocalTransform.FromPosition(new float3(xPos, 0, 20)));
                    }
                }
            }).Schedule();
        }
    }
}