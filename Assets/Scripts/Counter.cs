using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Coroutine _coroutine;
    private int _counter;
    private bool _isActive = false;

    private void Awake()
    {
        _counter = 0;
        _text.text = _counter.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isActive)
            {
                StopCoroutine(_coroutine);
                _isActive = false;
            }
            else
            {
                _coroutine = StartCoroutine(IncreaseCounter());
                _isActive = true;
            }
        }
    }

    private IEnumerator IncreaseCounter()
    {
        var delay = new WaitForSeconds(0.5f);

        while (true)
        {
            _counter++;
            _text.text = _counter.ToString();
            yield return delay;
        }
    }
}
