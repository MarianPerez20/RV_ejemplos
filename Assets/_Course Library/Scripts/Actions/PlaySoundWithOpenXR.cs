using UnityEngine;
using UnityEngine.InputSystem;

public class PlaySoundWithOpenXR : MonoBehaviour
{
    // Referencia al Input Action Asset
    public InputActionAsset inputActions;

    // Referencia al AudioSource
    public AudioSource audioSource;

    // Input Action
    private InputAction buttonAction;

    void OnEnable()
    {
        // Obtén la acción asociada al botón
    var actionMap = inputActions.FindActionMap("XRActions");
        buttonAction = actionMap.FindAction("ButtonPress");

        // Activa la acción y suscribe el evento
        buttonAction.Enable();
        buttonAction.performed += OnButtonPressed;
    }

    void OnDisable()
    {
        // Desuscribe el evento y desactiva la acción
        buttonAction.performed -= OnButtonPressed;
        buttonAction.Disable();
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        // Reproduce el sonido al presionar el botón
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}