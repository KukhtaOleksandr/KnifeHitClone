using Architecure.Services;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreUIGameLoose : MonoBehaviour
{
    [Inject] 
    readonly ICurrentScoreService _currentScoreService;

    private TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text =_currentScoreService.Score.ToString();
    }
}
