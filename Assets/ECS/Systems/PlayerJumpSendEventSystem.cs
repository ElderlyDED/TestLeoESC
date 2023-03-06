using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;


public class PlayerJumpSendEventSystem : IEcsRunSystem
{
    readonly EcsFilter<PlayerTag, JumpComponent> _playerFilter = null;
    public void Run()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        
        foreach(var i in _playerFilter)
        {
            ref var entity = ref _playerFilter.GetEntity(i);
            entity.Get<PlayerJumpEvent>();
            Debug.Log("Gay");
        }
    }
}
