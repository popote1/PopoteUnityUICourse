using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonControllerInputDisplayUI : MonoBehaviour
{
    [SerializeField] private ThirdPersonControllerBase thirdPersonController;
    [Space(10)]
    [SerializeField] private Image _imgNorth;
    [SerializeField] private Image _imgEast;
    
    [SerializeField] private Image _imgWest;
    [SerializeField] private Image _imgMoveLeft;
    [SerializeField] private Image _imgMoveRight;
    [SerializeField] private Image _imgMoveUp;
    [SerializeField] private Image _imgMoveDown;
    [SerializeField] private TMP_Text _txtMoveValue;
    [Space(10)] [SerializeField]
    private Color _pressedColor;
    [SerializeField] private Color _notPressedColor;
    public void Start()
    {

        thirdPersonController.OnMoveButton += ThirdPersonControllerBaseOnMove;
        thirdPersonController.OnNorthButton += ThirdPersonControllerBaseOnNorthButton;
        thirdPersonController.OnWestButton += ThirdPersonControllerBaseOnWestButton;
        thirdPersonController.OnEastButton += ThirdPersonControllerBaseOnEastButton;
        
    }

    private void ThirdPersonControllerBaseOnWestButton(object sender, bool e)=> _imgWest.color = e ? _pressedColor : _notPressedColor;
    private void ThirdPersonControllerBaseOnEastButton(object sender, bool e)=> _imgEast.color = e ? _pressedColor : _notPressedColor;
    private void ThirdPersonControllerBaseOnNorthButton(object sender, bool e)=> _imgNorth.color = e ? _pressedColor : _notPressedColor;

    private void ThirdPersonControllerBaseOnMove(object sender, Vector2 e) {
        _txtMoveValue.text = "X :"+(Math.Truncate(e.x * 100) / 100) +"\nY :"+Math.Truncate(e.y * 100) / 100;
        if (e.x > 0) {
            _imgMoveLeft.fillAmount = 0;
            _imgMoveRight.fillAmount = e.x;
        }
        else {
            _imgMoveLeft.fillAmount = -e.x;
            _imgMoveRight.fillAmount = 0;
        }
        
        if (e.y > 0) {
            _imgMoveDown.fillAmount = 0;
            _imgMoveUp.fillAmount = e.y;
        }
        else {
            _imgMoveDown.fillAmount = -e.y;
            _imgMoveUp.fillAmount = 0;
        }
    }

    
}