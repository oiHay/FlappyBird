using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument document;

    private VisualElement settingsPanel;

    private Button btnStart;
    private Button btnSettings;
    private Button btnCloseSettings;


    private void Awake()
    {
        document = GetComponent<UIDocument>();

        settingsPanel = document.rootVisualElement.Q("SettingsPanel");

        btnStart = document.rootVisualElement.Q("StartGameButton") as Button;
        btnStart.RegisterCallback<ClickEvent>(OnPlayGameClick);

        btnSettings = document.rootVisualElement.Q("Settings") as Button;
        btnSettings.RegisterCallback<ClickEvent>(OnOpeningSettings);

        btnCloseSettings = document.rootVisualElement.Q("QuitSettings") as Button;
        btnCloseSettings.RegisterCallback<ClickEvent>(OnClosingSettings);
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
}
