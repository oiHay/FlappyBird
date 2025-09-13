using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument document;

    private VisualElement settingsPanel;
    private VisualElement deathPanel;

    private Button btnStart;
    private Button btnSettings;
    private Button btnCloseSettings;

    private Button Death_RetryBtn;
    private Button Death_SettingsBtn;
    private Button Death_MainMenuBtn;


    private Button btnTest;


    private void Awake()
    {
        document = GetComponent<UIDocument>();

        settingsPanel = document.rootVisualElement.Q("SettingsPanel");
        deathPanel = document.rootVisualElement.Q("DeathPanel");

        btnStart = document.rootVisualElement.Q("StartGameButton") as Button;
        btnStart.RegisterCallback<ClickEvent>(OnPlayGameClick);

        btnSettings = document.rootVisualElement.Q("Settings") as Button;
        btnSettings.RegisterCallback<ClickEvent>(OnOpeningSettings);

        btnCloseSettings = document.rootVisualElement.Q("QuitSettings") as Button;
        btnCloseSettings.RegisterCallback<ClickEvent>(OnClosingSettings);

        Death_RetryBtn = document.rootVisualElement.Q("TryBtn") as Button;
        Death_RetryBtn.RegisterCallback<ClickEvent>(OnTrying);

        Death_SettingsBtn = document.rootVisualElement.Q("DeathSettingsBtn") as Button;
        Death_SettingsBtn.RegisterCallback<ClickEvent>(OnOpeningSettings);

        Death_MainMenuBtn = document.rootVisualElement.Q("MainMenuBtn") as Button;
        Death_MainMenuBtn.RegisterCallback<ClickEvent>(BacktoMain);

        btnTest = document.rootVisualElement.Q("testBtn") as Button;
        btnTest.RegisterCallback<ClickEvent>(OnDying);
    }

    private void OnDisable()
    {
        btnStart.UnregisterCallback<ClickEvent>(OnPlayGameClick);
        btnSettings.UnregisterCallback<ClickEvent>(OnOpeningSettings);
        btnCloseSettings.UnregisterCallback<ClickEvent>(OnClosingSettings);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        LoadNextLevel();
    }


    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnOpeningSettings(ClickEvent evt)
    {
        if (settingsPanel != null)
            settingsPanel.style.display = DisplayStyle.Flex;
    }

    private void OnClosingSettings(ClickEvent evt)
    {
        settingsPanel.style.display = DisplayStyle.None;
    }

    private void OnDying(ClickEvent evt)
    {
        if (deathPanel != null)
            deathPanel.style.display = DisplayStyle.Flex;
    }

    private void OnTrying(ClickEvent evt)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void BacktoMain(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
