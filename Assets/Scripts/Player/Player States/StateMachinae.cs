using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachinae : MonoBehaviour
{
    public PlayerAnimations PlayerAnimations;

    private Dictionary<Type, IPlayerBehavior> behaviorsMap;
    private IPlayerBehavior behaviorCurrent;

    private void Start()
    {
        InitBehaviors();
        SetBehaviorByDefault();
    }
    
    private void InitBehaviors()
    {
        behaviorsMap = new Dictionary<Type, IPlayerBehavior>();
    
        behaviorsMap[typeof(PlayerBehaviorInvulnerability)] = new PlayerBehaviorInvulnerability(this, PlayerAnimations.PlayerAnimator);
        behaviorsMap[typeof(PlayerBehaviorVulnerability)] = new PlayerBehaviorVulnerability(this, PlayerAnimations.PlayerAnimator);
    }

    private void SetBehaviorByDefault()
    {
        SetBehaviorInvulnerability();
    }

    private IPlayerBehavior GetBehavior<T>() where T : IPlayerBehavior
    {
        var type = typeof(T);
        return behaviorsMap[type];
    }

    private void SetBehavior(IPlayerBehavior newBehavior)
    {
        if(behaviorCurrent!=null)
        {
            behaviorCurrent.Exit();
        }
        behaviorCurrent = newBehavior;
        behaviorCurrent.Enter();
    }

    public void SetBehaviorInvulnerability()
    {
        var behavior = GetBehavior<PlayerBehaviorInvulnerability>();
        SetBehavior(behavior);
    }

    public void SetBehaviorVulnerability()
    {
        var behavior = GetBehavior<PlayerBehaviorVulnerability>();
        SetBehavior(behavior);
    }

    private void Update()
    {
        if(behaviorCurrent!=null)
        {
            behaviorCurrent.Update();
        }
    }
}