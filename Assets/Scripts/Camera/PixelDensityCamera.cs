using UnityEngine;

public class PixelDensityCamera : MonoBehaviour
{
    [SerializeField] private float _pixelsToUnits;
    [SerializeField] private int _targetWidth;
    [SerializeField] private Camera _camera;

    void Start()
    {
        int height = Mathf.RoundToInt(_targetWidth / (float)Screen.width * Screen.height);
        _camera.orthographicSize = height / _pixelsToUnits / 2;
    }

}
