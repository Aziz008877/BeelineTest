using TMPro;
using UnityEngine;

public class TextTimerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    
    public void ReceiveTimerData(string timer)
    {
        _timerText.text = $"Time: {timer}";
    }
}
