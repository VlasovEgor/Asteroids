using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlStateMachine : MonoBehaviour
{
    [SerializeField] private Button _controlButton;
    public Text _buttonText;

    private Dictionary<Type, IControlBehavior> behaviorsMap;
    private IControlBehavior behaviorCurrent;

    private void Start()
    {
        InitBehaviors();
        SetBehaviorByDefault();
        _buttonText = _controlButton.GetComponentInChildren<Text>();
    }

    private void InitBehaviors()
    {
        behaviorsMap = new Dictionary<Type, IControlBehavior>();

        behaviorsMap[typeof(ControlBehaviorKeyboard)] = new ControlBehaviorKeyboard(this, _buttonText,this.transform);
        behaviorsMap[typeof(ControlBehaviorKeyboardAndMouse)] = new ControlBehaviorKeyboardAndMouse(this, _buttonText);
    }
    private void SetBehaviorByDefault()
    {
        SetBehaviorKeyboardAndMouse();
    }

    private IControlBehavior GetBehavior<T>() where T : IControlBehavior
    {
        var type = typeof(T);
        return behaviorsMap[type];
    }

    private void SetBehavior(IControlBehavior newBehavior)
    {
        if (behaviorCurrent != null)
        {
            behaviorCurrent.Exit();
        }
        behaviorCurrent = newBehavior;
        behaviorCurrent.Enter();
    }

    public void SetBehaviorKeybord()
    {
        var behavior = GetBehavior<ControlBehaviorKeyboard>();
        SetBehavior(behavior);
    }

    public void SetBehaviorKeyboardAndMouse()
    {
        var behavior = GetBehavior<ControlBehaviorKeyboardAndMouse>();
        SetBehavior(behavior);
    }

    private void Update()
    {
        if (behaviorCurrent != null)
        {
            behaviorCurrent.Update();
        }
    }
}
