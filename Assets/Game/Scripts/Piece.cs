using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class Piece : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //public Transform correctPosition;
    [SerializeField] private Canvas canvas;
    public int id;
    protected bool isDragged;
    protected bool isDone;
    protected RectTransform rectTrans;
    protected Vector3 startScale;
    public int scaleValue = 2;
    //public float scaleValue = 1.1f;

    public void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        startScale = transform.localScale;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragged && !isDone)
        {
            rectTrans.anchoredPosition = rectTrans.anchoredPosition + eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1) return;
        if (!isDragged && !isDone)
        {
            isDragged = true;
            GamePlayControllerKhanh.Instance.lockOnEnter = true;
            //transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
            this.gameObject.GetComponent<RectTransform>().DOScale(scaleValue, 0.2f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GamePlayControllerKhanh.Instance.lockOnEnter = false;
        transform.localScale = Vector3.one;
        //rectTrans.anchoredPosition = Vector3.zero;
        rectTrans.DOAnchorPos(Vector3.zero, 0.2f);
        isDragged = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isDragged && !isDone)
        {
            //transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
            GamePlayControllerKhanh.Instance.lockOnEnter = true;
            GamePlayControllerKhanh.Instance.level.currentGrass.SetRaycasTaget(this.id);

           
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isDragged && !isDone)
        {
            GamePlayControllerKhanh.Instance.lockOnEnter = false;
            transform.localScale = Vector3.one;
            rectTrans.DOAnchorPos(Vector3.zero, 0.2f);
        }
    }
}
