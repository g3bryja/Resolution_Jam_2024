using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialScale;

    [SerializeField]
    private Vector3 onHoverScale;

    [SerializeField]
    private float duration;

    public void Awake() {
        initialScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (DOTween.IsTweening(transform)) {
            DOTween.Kill(false, transform);
        }
        transform.DOScale(onHoverScale, duration).SetEase(Ease.OutBounce);
    }
    
    public void OnPointerExit(PointerEventData eventData) {
        if (DOTween.IsTweening(transform)) {
            DOTween.Kill(false, transform);
        }
        transform.DOScale(initialScale, duration).SetEase(Ease.OutBounce);
    }
}
