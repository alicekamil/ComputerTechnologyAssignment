using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAuthoring : MonoBehaviour
    {
        private float moveSpeed = 10f;

        [SerializeField] private GameObject projectilePrefab;
        
        private class PlayerAuthoringBaker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<PlayerTag>(entity);
                AddComponent<PlayerMoveInput>(entity);
                
                AddComponent<FireProjectileTag>(entity);
                SetComponentEnabled<FireProjectileTag>(entity, false);
                
                AddComponent(entity, new PlayerMoveSpeed
                {
                    Value = authoring.moveSpeed
                });
                AddComponent(entity, new ProjectilePrefab
                {
                    Value = GetEntity(authoring.projectilePrefab, TransformUsageFlags.Dynamic)
                });
            }
        }
    }
}