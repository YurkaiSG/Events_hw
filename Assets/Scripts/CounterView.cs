using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        ChangeText(_counter.StartValue);
    }

    private void OnEnable()
    {
        _counter.OnChange += ChangeText;
    }

    private void OnDisable()
    {
        _counter.OnChange -= ChangeText;
    }

    private void ChangeText(int value)
    {
        _text.text = value.ToString();
    }
}
