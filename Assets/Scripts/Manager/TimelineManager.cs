using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class TimelineManager : MonoBehaviour
{
    [HideInInspector]
    public PlayableDirector playableDirector;
    public CharacterMove player;
    public Volume volume;
    private Vignette vignette;

    public float targetValue = 10f;  // ��ǥ�� x
    public float changeDuration = 2.0f;  // ���� ��ȭ�ϴµ� �ɸ��� �ð�

    private float currentValue = 0f;
    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            // �ʱ� intensity ���� ������ �� �ֽ��ϴ�.
            vignette.intensity.Override(currentValue);
        }
    }
    public void PlayTimeline()
    {
        player.canMove = false;
        playableDirector.Play();
        TweenVignetteIntensity();
    }
    private void TweenVignetteIntensity()
    {
        DOTween.To(() => vignette.intensity.value, x => vignette.intensity.value = x, targetValue, changeDuration);
    }
}
