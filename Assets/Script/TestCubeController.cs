using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestCubeController : MonoBehaviour
{
    public EventHandler<bool> OnButtonAPressed;
    public EventHandler<bool> OnButtonEPressed;
    
    
    //N'oublier pas que pour interagir avec un element il vous faut une référence. 
    //Il serait pertinent de r'ajouté un champ public pour povoir référencer dans l'inspecteur apres
    //public Animator MonAnimator;
    // Quelque chose comme ça.

    
    
    
    //Cette Méthode se lance lorsque le Bouton "A" est pressé ou relâché
    public void OnButtonA(InputValue value) {
        
        Debug.Log("Press A "+value.isPressed);
        OnButtonAPressed?.Invoke(this, value.isPressed);
        
        //-----------------------------------------------
        
        // isPressed est vrai quand le boutton est pressé et faux lorsqu'il est relâché
        bool isPressed = value.isPressed;
        
        
        
        
        
        
    }
    
    
    //Cette Méthode se lance lorsque le Bouton "E" est pressé ou relâché
    public void OnButtonE(InputValue value) {
        
        Debug.Log("Press E "+value.isPressed);
        OnButtonEPressed?.Invoke(this, value.isPressed);
        
        // isPressed est vrai quand le bouton est pressé et faux lorsqu'il est relâché
        bool isPressed = value.isPressed;
        
        
        
        
    }
}