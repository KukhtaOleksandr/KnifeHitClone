using Architecure.Services;
using UnityEngine;
using Zenject;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [Inject]
    private SignalBus _signalBus;

    private TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _signalBus.Subscribe<SignalScoreChanged>(ChangeScoreText);
    }

    void OnDestroy()
    {
        _signalBus.Unsubscribe<SignalScoreChanged>(ChangeScoreText);
    }

    private void ChangeScoreText(SignalScoreChanged args)
    {
        _text.text = args.Score.ToString();
    }
}
