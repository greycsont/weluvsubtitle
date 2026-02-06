
using UnityEngine;
using TMPro;

namespace weluvsubtitle.Subtitle.MonoBehaviorClasses;

[RequireComponent(typeof(CanvasGroup))]
public class FadeUI : MonoBehaviour
{
    public float lifeTime = 3f;
    
    public float delay = 1.5f;
    
    public float updateInterval = 0.2f;

    private float _endAlpha = 0.2f;

    private float _timer;
    
    private float _lastUpdateTime;
    
    private TextMeshProUGUI _text;

    void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= lifeTime)
        {
            Destroy(gameObject);
            return;
        }
        
        if (_timer <= delay) return;

        if (_timer - _lastUpdateTime >= updateInterval)
        {
            float fadeDuration = Mathf.Max(0.001f, lifeTime - delay);
            float progress = (_timer - delay) / fadeDuration;
            
            _text.alpha = Mathf.Lerp(1f, _endAlpha, progress);
            
            _lastUpdateTime = _timer;
        }
    }

    public void Refresh()
    {
        _timer = 0f;
        _text.alpha = 1f;
    }
}
