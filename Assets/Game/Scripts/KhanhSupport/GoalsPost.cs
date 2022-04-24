using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class GoalsPost : MonoBehaviour, IDropHandler, IPointerEnterHandler
{
    public int id;
    public Image thumnails;
    public Slot slot;
    public bool wasActive;
    int speedFade = 255;

    public void OnDrop(PointerEventData eventData)
    {
    

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(GamePlayControllerKhanh.Instance.lockOnEnter == true)
        {
            if (eventData.pointerEnter != null)
            {
                Debug.Log("OnPointerEnter");
                eventData.pointerEnter.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                thumnails.DOColor(new Color32(255,255,255,255),1);

                slot.gameObject.SetActive(false);
                wasActive = true;
                GamePlayControllerKhanh.Instance.level.currentGrass.CheckAllGoalsPost();
              //  this.transform.GetComponentInParent<Grass>().CheckAllGoalsPost();
                //this.transform.SetParent(GamePlayControllerKhanh.Instance.doneCanvas);
                GamePlayControllerKhanh.Instance.SortingLayer(this.id, this.gameObject);
            }
        }
     
    }


  

}
