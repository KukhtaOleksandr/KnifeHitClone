using Global.Progress;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreMenuUI : MonoBehaviour
{
    [Inject]
    IGameProgressService _gameProgressService;

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text= "SCORE " + _gameProgressService.GameProgress.MaxScore;  
    }
}
