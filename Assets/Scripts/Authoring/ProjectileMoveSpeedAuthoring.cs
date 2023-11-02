using DefaultNamespace.Components;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class ProjectileMoveSpeedAuthoring : MonoBehaviour
    {
        private float projectileMoveSpeed = 20f;
        private class ProjectileMoveSpeedAuthoringBaker : Baker<ProjectileMoveSpeedAuthoring>
        {
            public override void Bake(ProjectileMoveSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new ProjectileMoveSpeed
                {
                    Value = authoring.projectileMoveSpeed
                });
            }
        }
    }
}