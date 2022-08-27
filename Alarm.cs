using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;

    private float _volumeScale;
    private float _runningTime;
    private float _target;
    private float _maximumVolume = 1f;

    private void Start()
    {
        _audio.Play();
        _audio.volume = 0f;
    }
    

    private void Update()
    {
        Data();

        if (Door.IsTriggered == false)
        {
            if (_audio.volume == _maximumVolume)
            {
                _target = 0f;
                _runningTime = 0;
            }

            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _target = _maximumVolume;
        Data();

        _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
    }

    private void Data()
    {
        _runningTime += Time.deltaTime;
        _volumeScale = _runningTime / _duration;
    }   
}