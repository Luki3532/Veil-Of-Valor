using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MenuButtonAudio : MonoBehaviour
{
    [SerializeField] private AudioClip hoverButtonSound;
    [SerializeField] private AudioSource audioSource;
    
    private UIDocument uiDocument;

    private void Start()
    {
        // Get the UIDocument component
        uiDocument = GetComponent<UIDocument>();
        
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument component not found!");
            return;
        }

        // Get the audio source (from Lobby music object or this object)
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                // Try to find the Lobby music object
                GameObject lobbyMusic = GameObject.Find("Lobby music");
                if (lobbyMusic != null)
                {
                    audioSource = lobbyMusic.GetComponent<AudioSource>();
                }
            }
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found! Please assign it in the inspector or ensure 'Lobby music' object has an AudioSource.");
            return;
        }

        // Set up button hover events
        SetupButtonHoverEvents();
    }

    private void SetupButtonHoverEvents()
    {
        var root = uiDocument.rootVisualElement;

        // Find all buttons with the menuRegularButton class
        var buttons = root.Query<Button>(className: "menuRegularButton").ToList();

        foreach (var button in buttons)
        {
            // Register hover event (mouse enter)
            button.RegisterCallback<MouseEnterEvent>(evt => PlayHoverSound());
        }
    }

    private void PlayHoverSound()
    {
        if (audioSource != null && hoverButtonSound != null)
        {
            audioSource.PlayOneShot(hoverButtonSound);
        }
    }
}
