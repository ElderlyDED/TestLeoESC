using Leopotam.Ecs;
using System;
using Unity.VisualScripting;

sealed class PlayerJumpSystem : IEcsRunSystem
{
    readonly EcsFilter<PlayerTag, GroundCheckSphereComponent, JumpComponent, PlayerJumpEvent> _jumpFilter = null;
    public void Run()
    {
        foreach (var i in _jumpFilter)
        {
            ref var entity = ref _jumpFilter.GetEntity(i);
            ref var groundCheck = ref _jumpFilter.Get2(i);
            ref var jumpComponent = ref _jumpFilter.Get3(i);
            ref var movable = ref entity.Get<MovableComponent>();
            ref var velocity = ref movable.velocity;

            if (!groundCheck.isGrounded) continue;
            velocity.y = MathF.Sqrt(jumpComponent.force * -2f * movable.gravity);
        }
    }
}
