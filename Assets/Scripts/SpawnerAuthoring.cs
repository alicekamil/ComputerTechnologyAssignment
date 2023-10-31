using Systems;
using Unity.Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class SpawnerAuthoring : MonoBehaviour
    {
        public GameObject asteroidPrefab;
        
        [SerializeField] 
        private int hazardCount = 10;
        [SerializeField]
        private Vector3 spawnValues;
        [SerializeField] 
        private float spawnWait;
        [SerializeField]
        private float startWait;
        [SerializeField] 
        private float waveWait;
        
        
        private class SpawnerAuthoringBaker : Baker<SpawnerAuthoring>
        {
            public override void Bake(SpawnerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                AddComponent(entity, new Spawner
                {
                    asteroidPrefab = GetEntity(authoring.asteroidPrefab, TransformUsageFlags.Dynamic),
                    hazardCount = authoring.hazardCount,
                    spawnValues = authoring.spawnValues,
                    spawnWait = authoring.spawnWait,
                    startWait = authoring.startWait,
                    waveWait = authoring.waveWait,
                    nextSpawnTime = authoring.startWait
                });
            }
        }
    }
}