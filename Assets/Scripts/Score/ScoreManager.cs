using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI contador_;
    public int score_;

    void Update()
    {
        contador_.text = score_.ToString();
    }
}
