using UnityEngine;
using UnityEngine.UIElements;

public class MenuPageManager : MonoBehaviour
{
    [Header("UI Documents")]
    [SerializeField] private VisualTreeAsset mainMenuPage;
    [SerializeField] private VisualTreeAsset settingsPage;
    [SerializeField] private VisualTreeAsset hostPage;
    [SerializeField] private VisualTreeAsset joinPage;
    [SerializeField] private VisualTreeAsset creditsPage;
    [SerializeField] private VisualTreeAsset aboutUsPage;

    [Header("Social Media Links")]
    [SerializeField] private string twitterUrl = "https://twitter.com/yourhandle";
    [SerializeField] private string instagramUrl = "https://instagram.com/yourhandle";
    [SerializeField] private string discordUrl = "https://discord.gg/yourinvite";
    [SerializeField] private string steamUrl = "https://store.steampowered.com/app/yourappid";

    private UIDocument uiDocument;
    private VisualElement currentRoot;

    private void Start()
    {
        uiDocument = GetComponent<UIDocument>();

        if (uiDocument == null)
        {
            Debug.LogError("UIDocument component not found!");
            return;
        }

        // Show main menu by default
        ShowMainMenu();
    }

    private void ShowPage(VisualTreeAsset pageAsset)
    {
        if (pageAsset == null)
        {
            Debug.LogError("Page asset is null!");
            return;
        }

        // Change the source asset
        uiDocument.visualTreeAsset = pageAsset;
        currentRoot = uiDocument.rootVisualElement;

        // Setup button events for the new page
        SetupPageButtons();
    }

    private void SetupPageButtons()
    {
        // Main Menu buttons
        SetupButton("start-game__button", OnStartGame);
        SetupButton("host__button", ShowHostPage);
        SetupButton("join__button", ShowJoinPage);
        SetupButton("tutorial__button", OnTutorial);
        SetupButton("settings__button", ShowSettingsPage);
        SetupButton("credits__button", ShowCreditsPage);
        SetupButton("about-us__button", ShowAboutUsPage);

        // Back buttons (on all pages)
        SetupButton("back-button", ShowMainMenu);
        SetupButton("skip-button", ShowMainMenu);

        // Settings page
        SetupSlider("master-volume", OnMasterVolumeChanged);
        SetupSlider("music-volume", OnMusicVolumeChanged);
        SetupSlider("sfx-volume", OnSfxVolumeChanged);
        SetupToggle("fullscreen-toggle", OnFullscreenToggled);

        // Host page
        SetupButton("create-server-button", OnCreateServer);

        // Join page
        SetupButton("connect-button", OnConnect);

        // About Us page - Social links
        SetupButton("twitter-link", () => OpenURL(twitterUrl));
        SetupButton("instagram-link", () => OpenURL(instagramUrl));
        SetupButton("discord-link", () => OpenURL(discordUrl));
        SetupButton("steam-link", () => OpenURL(steamUrl));
    }

    private void SetupButton(string buttonName, System.Action callback)
    {
        var button = currentRoot.Q<Button>(buttonName);
        if (button != null)
        {
            button.clicked += callback;
        }
    }

    private void SetupSlider(string sliderName, System.Action<float> callback)
    {
        var slider = currentRoot.Q<Slider>(sliderName);
        if (slider != null)
        {
            slider.RegisterValueChangedCallback(evt => callback(evt.newValue));
        }
    }

    private void SetupToggle(string toggleName, System.Action<bool> callback)
    {
        var toggle = currentRoot.Q<Toggle>(toggleName);
        if (toggle != null)
        {
            toggle.RegisterValueChangedCallback(evt => callback(evt.newValue));
        }
    }

    // Page Navigation
    public void ShowMainMenu()
    {
        ShowPage(mainMenuPage);
    }

    public void ShowSettingsPage()
    {
        ShowPage(settingsPage);
    }

    public void ShowHostPage()
    {
        ShowPage(hostPage);
    }

    public void ShowJoinPage()
    {
        ShowPage(joinPage);
    }

    public void ShowCreditsPage()
    {
        ShowPage(creditsPage);
    }

    public void ShowAboutUsPage()
    {
        ShowPage(aboutUsPage);
    }

    // Button Callbacks
    private void OnStartGame()
    {
        Debug.Log("Start Game clicked");
        // Add your start game logic here
    }

    private void OnTutorial()
    {
        Debug.Log("Tutorial clicked");
        // Add your tutorial logic here
    }

    private void OnCreateServer()
    {
        var serverName = currentRoot.Q<TextField>("server-name")?.value;
        var maxPlayers = currentRoot.Q<SliderInt>("max-players")?.value;
        var password = currentRoot.Q<TextField>("password-field")?.value;

        Debug.Log($"Creating server: {serverName}, Max Players: {maxPlayers}, Password: {password}");
        // Add your server creation logic here
    }

    private void OnConnect()
    {
        var serverIp = currentRoot.Q<TextField>("server-ip")?.value;
        Debug.Log($"Connecting to: {serverIp}");
        // Add your connection logic here
    }

    // Settings Callbacks
    private void OnMasterVolumeChanged(float value)
    {
        AudioListener.volume = value;
        Debug.Log($"Master Volume: {value}");
    }

    private void OnMusicVolumeChanged(float value)
    {
        Debug.Log($"Music Volume: {value}");
        // Add your music volume logic here
    }

    private void OnSfxVolumeChanged(float value)
    {
        Debug.Log($"SFX Volume: {value}");
        // Add your SFX volume logic here
    }

    private void OnFullscreenToggled(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log($"Fullscreen: {isFullscreen}");
    }

    // Social Media Links
    private void OpenURL(string url)
    {
        Application.OpenURL(url);
        Debug.Log($"Opening URL: {url}");
    }
}