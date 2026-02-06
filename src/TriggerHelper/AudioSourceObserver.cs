using UnityEngine;
using weluvsubtitle.Relay;

namespace weluvsubtitle.TriggerHelper;




public class AudioPlayObserver : MonoBehaviour
{
    public string id;
    private AudioSource _audioSource;
    private bool _wasPlaying = false;
    private float _lastTriggerTime;
    // 能超过这个cooldown的建议去打saragi
    private float _cooldown = 0.15f;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null) Destroy(this);
    }

    void OnEnable()
    {
        if (_audioSource != null && _audioSource.playOnAwake)
        {
            TriggerSignal();
            _wasPlaying = true;
        }
    }

    void Update()
    {
        if (_audioSource is null && !_audioSource.isPlaying) return;
        
        if (!_wasPlaying
            && Time.time - _lastTriggerTime >= _cooldown)
        {
            TriggerSignal();
            _wasPlaying = true;
            _lastTriggerTime = Time.time;
        }
        else
        {
            _wasPlaying = false;
        }
    }

    private void TriggerSignal()
        => EventRelay.Emit(id, transform.position);
    
}