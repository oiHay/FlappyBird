using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument document;

    private Button btn;

    private void Awake()
    {
        document = GetComponent<UIDocument>();

        btn = document.rootVisualElement.Q("StartGameButton") as Button;
        btn.RegisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnDisable()
    {
        btn.UnregisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        print("Start clicked");
    }
}
