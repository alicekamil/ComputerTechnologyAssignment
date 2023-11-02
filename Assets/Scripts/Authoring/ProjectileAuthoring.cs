using DefaultNamespace.Components;
using Systems;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class ProjectileAuthoring : MonoBehaviour
    {
        public Vector3 boundaryData = new Vector3(15, 1, 40);
        private class ProjectileAuthoringBaker : Baker<ProjectileAuthoring>
        {
            public override void Bake(ProjectileAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<ProjectileTag>(entity);
                AddComponent(entity, new AsteroidDestroySystem.BoundaryData
                {
                    boundaryValues = authoring.boundaryData
                });
            }
        }
    }
}