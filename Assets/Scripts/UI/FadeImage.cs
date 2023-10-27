using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Playables;
public class FadeImage : MonoBehaviour
{
    public Image logoImage;
    public CanvasGroup gameTitle;
    public float fadeInDuration = 1f;
    public float stayDuration = 2f;
    public float fadeOutDuration = 1f;
    public PlayableDirector timelineDirector;

    void Start()
    {
        logoImage.gameObject.SetActive(true);
        gameTitle.gameObject.SetActive(true);
        logoImage.DOFade(0, 0); // ���� �� �ΰ� �����ϰ� ����
        gameTitle.DOFade(0, 0);
        StartCoroutine(LogoSequence());
    }

    IEnumerator LogoSequence()
    {
        yield return logoImage.DOFade(1, fadeInDuration).WaitForCompletion(); // ���̵� ��
        yield return new WaitForSeconds(stayDuration); // �ΰ� ����
        yield return logoImage.DOFade(0, fadeOutDuration).WaitForCompletion(); // ���̵� �ƿ�

        // �ΰ� �ִϸ��̼��� ���� �� Ÿ�Ӷ��� �ִϸ��̼��� �����մϴ�.
        StartTimelineAnimation();
        
    }
    
    void StartTimelineAnimation()
    {
        timelineDirector.Play();
    }
    public void titleFadeIn()
    {
        gameTitle.DOFade(1, fadeInDuration);
    }

}
