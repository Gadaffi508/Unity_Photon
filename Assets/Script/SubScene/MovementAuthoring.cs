using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Entities
{
    public class MovementAuthoring : MonoBehaviour
    {
        public class Baker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity, new Movement
                {
                    movementVector3 = new float3(UnityEngine.Random.Range(-1f,1f),0, UnityEngine.Random.Range(-1f, 1f))
                });
            }
        }
    }

    public struct Movement : IComponentData
    {
        public float3 movementVector3;
    }
}
