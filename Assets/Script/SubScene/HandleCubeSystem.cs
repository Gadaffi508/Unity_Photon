using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Entities
{
    public partial struct HandleCubeSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            foreach ((RefRW<LocalTransform> localTranform,RefRO<RotateSpeed> rotateSpeed,RefRO <Movement> movement)
                in SystemAPI.Query<RefRW<LocalTransform>,RefRO<RotateSpeed>,RefRO<Movement>>().WithAll<RotatingCube>())
            {
                localTranform.ValueRW = localTranform.ValueRO.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime);
                localTranform.ValueRW = localTranform.ValueRO.Translate(movement.ValueRO.movementVector3 * SystemAPI.Time.DeltaTime);
            }
        }
    }
}
