using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Entities
{
    public partial struct RotatingCubeSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<RotateSpeed>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach ((RefRW<LocalTransform> localTransfom, RefRO<RotateSpeed> rotateSpeed) 
                in SystemAPI.Query<RefRW<LocalTransform>,RefRO <RotateSpeed>>())
            {
                float power = 1f;

                for (int i = 0; i < 100000; i++)
                {
                    power *= 2f;
                    power /= 2f;
                }

                localTransfom.ValueRW = localTransfom.ValueRW.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime * power);
            }
        }

        public partial struct RotatingCubeJop : IJobEntity
        {
            public float deltaTime;

            public void Execute(ref LocalTransform localTransform,in RotateSpeed rotateSpeed)
            {
                float power = 1f;

                for (int i = 0; i < 100000; i++)
                {
                    power *= 2f;
                    power /= 2f;
                }

                localTransform = localTransform.RotateY(rotateSpeed.value * deltaTime * power);
            }
        }
    }
}
