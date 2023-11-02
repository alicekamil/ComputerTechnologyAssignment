using Unity.Entities;
using Unity.Mathematics;

namespace Systems
{
    // Creates an individual random seed to entities
    public partial class RandomSystem : SystemBase
    {
        protected override void OnStartRunning()
        {
            RequireForUpdate<SpawnData>();
            Entities.ForEach((Entity e, int entityInQueryIndex, ref SpawnData spawnData) =>
            {
                spawnData.randomValue = Random.CreateFromIndex((uint)entityInQueryIndex);
            }).ScheduleParallel();
        }

        protected override void OnUpdate()
        {
            
        }
    }
}