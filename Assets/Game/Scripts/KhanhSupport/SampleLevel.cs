using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;
public class SampleLevel : MonoBehaviour
{
    public List<Grass> lsGrass;
    public Grass currentGrass;
    public List<Slot> slots;
 
  
    public void Init()
    {
        currentGrass = lsGrass[0];
      
    }

    public void CheckGrass()
    {
        if (lsGrass.Count > 1)
        {
         
            for (int i = 0; i < lsGrass.Count; i++)
            {
                if (lsGrass[i].completeGrass )
                {
                    GamePlayControllerKhanh.Instance.lockOnEnter = false;
                    lsGrass[i + 1].gameObject.SetActive(true);
                    currentGrass = lsGrass[i + 1];
                    lsGrass.Remove(lsGrass[i]);
                    break;
                }
      
            }
        }
        else
        {
            Debug.Log("Win");
        }

   
    }
    public void CheckHint()
    {
        //Debug.Log("CheckHint");
        var gamePlayContro = GamePlayControllerKhanh.Instance;
        if (currentGrass != null)
        {
            MoveContetnScr(2);
            Debug.Log("++++++ " + currentGrass.gameObject.name);
            for (int i = 0 ; i < currentGrass.lsGoalsPost.Count; i++)
            {
                Debug.Log(""+ currentGrass.lsGoalsPost[0].id);
                Debug.Log("run");
                if (currentGrass.lsGoalsPost[i].wasActive == false)
                {
                    Debug.Log("" + i);
                    gamePlayContro.gameSence.hand.SetActive(true);
                    gamePlayContro.gameSence.hand.transform.position = currentGrass.lsGoalsPost[i].slot.transform.position;
                    gamePlayContro.gameSence.hand.GetComponent<RectTransform>().DOAnchorPos(currentGrass.lsGoalsPost[i].GetComponent<RectTransform>().anchoredPosition, 1f).OnComplete(delegate
                    {
                        gamePlayContro.gameSence.hand.SetActive(false);
                        gamePlayContro.gameSence.hand.transform.position = currentGrass.lsGoalsPost[i].slot.transform.position;
                    });
                    break;
                }
            }
        }
      
    }
    public void MoveContetnScr(int param)
    {
        Debug.Log("vao");
        foreach (Slot item in slots)
        {
            if (item.piece.id == param)
            {
                GamePlayControllerKhanh.Instance.gameSence.contentInScrollView.GetComponent<RectTransform>().DOAnchorPosX(item.GetComponent<RectTransform>().anchoredPosition.x, 1f);
            }
        }
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
  
    }

}
