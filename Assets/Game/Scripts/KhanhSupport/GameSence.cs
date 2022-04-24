using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameSence : MonoBehaviour
{
    public Button hintBtn;
    public GameObject hand;
    public Transform contentInScrollView;
    public void Init()
    {
        hintBtn.onClick.AddListener(GamePlayControllerKhanh.Instance.level.CheckHint);
    }
    public void MoveContentInScrollView(Vector3 param)
    {
        
    contentInScrollView.GetComponent<RectTransform>().DOAnchorPos(param,1);


    }
}
