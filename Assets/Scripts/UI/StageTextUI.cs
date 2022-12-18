using Architecure.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StageTextUI : MonoBehaviour
    {
        [Inject]
        readonly IStageConfigGeneratorService _stageConfigGeneratorService;
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = "STAGE " + _stageConfigGeneratorService.GetCurrentStageNumber().ToString();
        }
    }
}
