using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EffectsManager : GaneEventListener
{
    [SerializeField] private ParticleSystem _snowEffect;
    [SerializeField] private VolumeProfile VolumeProfile;
    [SerializeField] private Vector2 _alarmAnimationBounds = new Vector2(0.224f, 0.336f);
    [SerializeField] private float _alarmAnimationTime = 2;
    [SerializeField] private GameObject _water;
    
    private Tween alarmAnimationTween;
    
    public override void OnGameEvent(GameEvent gameEvent)
    {
        StopAll();
        
        switch (gameEvent)
        {
            case GameEvent.Freeze: 
                _snowEffect.gameObject.SetActive(true);
                _snowEffect.Play(); break;
            case GameEvent.Alarm: 
                 
                Vignette vignette;
 
                if(!VolumeProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
                vignette.active = true;
                vignette.intensity.Override(_alarmAnimationBounds.x);
                alarmAnimationTween = DOTween.To(() => vignette.intensity.value, value => vignette.intensity.Override(value), _alarmAnimationBounds.y, _alarmAnimationTime)
                    .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuart); break;
            
            case GameEvent.Flood:
                _water.SetActive(true); break;
                default: break;
        }
    }
    
    [ContextMenu("fire alarm effect")]
    public void FireAlarm()
    {
        OnGameEvent(GameEvent.Alarm);
    }
    
    [ContextMenu("fire freeze effect")]
    public void FireFreeze()
    {
        OnGameEvent(GameEvent.Freeze);
    }
    
    [ContextMenu("fire Flood effect")]
    public void FireWater()
    {
        OnGameEvent(GameEvent.Flood);
    }
    private void StopAll()
    {
        _snowEffect.gameObject.SetActive(false);
        _snowEffect.Stop();
        
        alarmAnimationTween.Kill();
        
        Vignette vignette;
        if(!VolumeProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
        vignette.active = false;
        
        _water.SetActive(false);
    }
    
    
    
}
