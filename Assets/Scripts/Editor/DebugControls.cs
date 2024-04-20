using TMPro;
using TopDos.Controls;
using UnityEngine;

public class DebugControls : MonoBehaviour
{
    [SerializeField] private ControlsHandler _controls;
    [SerializeField] private TextMeshProUGUI _text;

    private void Update()
    {
        _text.text = _controls.MoveInputDirection.ToString();
    }
}
