using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Light))]
public class LightSwitch : MonoBehaviour
{
    [Header("Bind this to Quest 2 Right Hand A (primaryButton)")]
    public InputAction toggleAction;

    private Light _light;
    private int _index = 0;

    // You can add/remove colors here if you want
    private readonly Color[] _colors = new Color[]
    {
        Color.white,
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        new Color(1f, 0f, 1f) // magenta
    };

    void Awake()
    {
        _light = GetComponent<Light>();
        _light.color = _colors[_index];
    }

    void OnEnable()
    {
        toggleAction.Enable();
    }

    void OnDisable()
    {
        toggleAction.Disable();
    }

    void Update()
    {
        if (toggleAction.triggered)
        {
            _index = (_index + 1) % _colors.Length;
            _light.color = _colors[_index];
        }
    }
}
