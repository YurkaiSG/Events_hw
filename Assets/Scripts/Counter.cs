using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    
    private Coroutine _coroutine;
    private int _counter;
    private int _startValue = 0;

    public event Action<int> OnChange;
    public int StartValue => _startValue;

    private void Awake()
    {
        _counter = _startValue;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            else
            {
                _coroutine = StartCoroutine(IncreaseCounter());
            }
        }
    }

    private IEnumerator IncreaseCounter()
    {
        var delay = new WaitForSeconds(0.5f);

        while (enabled)
        {
            OnChange?.Invoke(++_counter);
            yield return delay;
        }
    }
}
