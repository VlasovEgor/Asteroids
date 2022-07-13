using UnityEngine;
using UnityEngine.UI;

public class ControlBehaviorKeyboard : IControlBehavior
{
    private Text _buttonText;
    private ControlStateMachine _controlStateMachinae;
    private Transform _playerTransform;

    public ControlBehaviorKeyboard(ControlStateMachine controlStateMachine, Text buttonText, Transform playerTransfrom)
    {
        _controlStateMachinae = controlStateMachine;
        _buttonText = buttonText;
        _playerTransform = playerTransfrom;
    }

    public void Enter()
    {
        EventSystem.ControlChanged += _controlStateMachinae.SetBehaviorKeyboardAndMouse;
        _buttonText.text = "Управление: клавиатура";
    }

    public void Exit()
    {
        EventSystem.ControlChanged -= _controlStateMachinae.SetBehaviorKeyboardAndMouse;
    }


    void IControlBehavior.Update()
    {
        CharacterManagement();
    }

    public void CharacterManagement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventSystem.OnShotButtonPressed();
        }
        if (Input.GetKey(KeyCode.W))
        {
            EventSystem.OnMotionButtonPressed();
        }
        if (Input.GetKey(KeyCode.A))
        {
            EventSystem.OnRotationButtonPressed(-_playerTransform.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            EventSystem.OnRotationButtonPressed(_playerTransform.right);
        }
    }
}
