using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VersusFightingInputDisplayerUI : MonoBehaviour
{
    [SerializeField] private VersusFightingController _versusFightingController;
    [Space(10)]
    [SerializeField] private Image _imgNorth;
    [SerializeField] private Image _imgEast;
    [SerializeField] private Image _imgSouth;
    [SerializeField] private Image _imgWest;
    [SerializeField] private Image _imgMoveLeft;
    [SerializeField] private Image _imgMoveRight;
    [SerializeField] private TMP_Text _txtMoveValue;
    [Space(10)] [SerializeField]
    private Color _pressedColor;
    [SerializeField] private Color _notPressedColor;
    public void Start()
    {
        _versusFightingController.OnKickButton += VersusFightingController_OnKickButton;
        _versusFightingController.OnMoveButton += VersusFightingController_OnMoveButton;
        _versusFightingController.OnPunchButton += VersusFightingController_OnPunchButton;
        _versusFightingController.OnHeadBumpButton += VersusFightingController_OnHeadBumpButton;
        _versusFightingController.OnJumpButton += VersusFightingController_OnJumpButton;
    }

    private void VersusFightingController_OnHeadBumpButton(object sender, bool e) => _imgWest.color = e ? _pressedColor : _notPressedColor;
    private void VersusFightingController_OnJumpButton(object sender, bool e)=> _imgSouth.color = e ? _pressedColor : _notPressedColor;
    private void VersusFightingController_OnPunchButton(object sender, bool e)=> _imgNorth.color = e ? _pressedColor : _notPressedColor;
    private void VersusFightingController_OnKickButton(object sender, bool e) => _imgEast.color = e ? _pressedColor : _notPressedColor;

    
    private void VersusFightingController_OnMoveButton(object sender, float e) {
        _txtMoveValue.text = (Math.Truncate(e*100)/100).ToString();
        if (e > 0) {
            _imgMoveLeft.fillAmount = 0;
            _imgMoveRight.fillAmount = e;
        }
        else {
            _imgMoveLeft.fillAmount = -e;
            _imgMoveRight.fillAmount = 0;
        }
    }

    
    
}
