using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] private GameObject OptionPanel;
    [SerializeField] private GameObject CreditPanel;
    
    public void UIStartGame() => SceneManager.LoadScene(1);
    public void UIOpenOption() =>OptionPanel.SetActive(true);
    public void UICloseOption() =>OptionPanel.SetActive(false);
    public void UIOpenCredits()=> CreditPanel.SetActive(true);
    public void UICloseCredits() => CreditPanel.SetActive(false);
    
}
