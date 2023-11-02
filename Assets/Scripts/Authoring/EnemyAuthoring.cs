using DefaultNamespace.Components;
using Systems;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float speed = 20;

        [SerializeField] 
        private float3 boundaryData = new float3(15f, 1, 40);
        private class EnemyAuthoringBaker : Baker<EnemyAuthoring>
        {
            public override void Bake(EnemyAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<EnemyTag>(entity);
                AddComponent(entity, new AsteroidMoverSystem.AsteroidData
                {
                    speed = authoring.speed
                });
                AddComponent(entity, new AsteroidDestroySystem.BoundaryData
                {
                    boundaryValues = authoring.boundaryData
                });
            }
        }
    }
}