using DefaultNamespace.Components;
using Systems;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyAuthoring : MonoBehaviour
    {
        [SerializeField] private float speed = 20;
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
            }
        }
    }
}