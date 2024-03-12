using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller2DInputDisplayUI : MonoBehaviour
{
    [SerializeField] private Controller2DBase _controller2DBase;
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
    public void Start() {
        _controller2DBase.OnMoveButton += Controller2DBaseBaseOnMove;
        _controller2DBase.OnNorthButton += Controller2DBaseBaseOnNorthButton;
        _controller2DBase.OnWestButton += Controller2DBaseBaseOnWestButton;
        _controller2DBase.OnEastButton += Controller2DBaseBaseOnEastButton;
        
    }

    private void Controller2DBaseBaseOnWestButton(object sender, bool e)=> _imgWest.color = e ? _pressedColor : _notPressedColor;
    private void Controller2DBaseBaseOnEastButton(object sender, bool e)=> _imgEast.color = e ? _pressedColor : _notPressedColor;
    private void Controller2DBaseBaseOnNorthButton(object sender, bool e)=> _imgNorth.color = e ? _pressedColor : _notPressedColor;

    private void Controller2DBaseBaseOnMove(object sender, Vector2 e) {
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