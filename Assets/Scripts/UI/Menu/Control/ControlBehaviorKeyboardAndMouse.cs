using UnityEngine;
using UnityEngine.UI;

public class ControlBehaviorKeyboardAndMouse : IControlBehavior
{
    private ControlStateMachine _controlStateMachinae;
    private Text _buttonText;

    public ControlBehaviorKeyboardAndMouse(ControlStateMachine controlStateMachine, Text buttonText )
    {
        _controlStateMachinae = controlStateMachine;
        _buttonText = buttonText;
    }

    public void Enter()
    {
        EventSystem.ControlChanged += _controlStateMachinae.SetBehaviorKeybord;
        _buttonText.text = "”правление: клавиатура+мышь";
    }

    public void Exit()
    {
        EventSystem.ControlChanged -= _controlStateMachinae.SetBehaviorKeybord;
    }

    public void Update()
    {
        CharacterManagement();
    }

    public void CharacterManagement()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            EventSystem.OnShotButtonPressed();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButton(1))
        {
            EventSystem.OnMotionButtonPressed();
        }
        EventSystem.OnRotationButtonPressed(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
