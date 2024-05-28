using Unity.Entities;
using UnityEngine;

namespace Entities
{
    public class RotatingCubeAuthoring : MonoBehaviour
    {
        public class Baker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity,new RotatingCube());
            }
        }
    }

    public struct RotatingCube : IComponentData
    {

    }
}
