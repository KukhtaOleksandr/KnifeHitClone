using Global.Progress;
using UnityEngine;
using Zenject;
using TMPro;

public class StageMenuUI : MonoBehaviour
{
    [Inject]
    IGameProgressService _gameProgressService;

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text= "STAGE " + _gameProgressService.GameProgress.MaxStage;  
    }
}
