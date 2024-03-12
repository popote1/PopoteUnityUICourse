using System;
using UnityEngine;
using UnityEngine.UI;

public class TestCubeControllerInputDisplayUI : MonoBehaviour
{
    
    [SerializeField] private TestCubeController _testCubeController;
    [Space(10)]
    
    [SerializeField] private Image _imgA;
    [SerializeField] private Image _imgE;
    
    [Space(10)] [SerializeField]
    private Color _pressedColor;
    [SerializeField] private Color _notPressedColor;

    private void Start() {
        if (_testCubeController == null) return;
        _testCubeController.OnButtonAPressed += TestCubeController_OnButtonA;
        _testCubeController.OnButtonEPressed += TestCubeController_OnButtonE;
    }

    private void TestCubeController_OnButtonA(object sender, bool e)  => _imgA.color = e ? _pressedColor : _notPressedColor;
    private void TestCubeController_OnButtonE(object sender, bool e)  => _imgE.color = e ? _pressedColor : _notPressedColor;
}