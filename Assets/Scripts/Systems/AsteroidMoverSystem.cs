using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

namespace Systems
{
    public partial class AsteroidMoverSystem : SystemBase
    {
        public struct AsteroidData : IComponentData
        {
            public float speed;
        }
        
        protected override void OnUpdate()
        {
            // ref = change, in = read
            Entities.ForEach((ref PhysicsVelocity velocity, in AsteroidData asteroidData) =>
            {
                velocity.Linear = new float3(0, 0, -asteroidData.speed);
            }).ScheduleParallel();
        }
    }
}