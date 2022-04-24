using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Grass : MonoBehaviour
{
    public List<GoalsPost> lsGoalsPost;
    public Image outLine;
    public bool completeGrass;
    public int count;
    public void CheckAllGoalsPost()
    {
        count = 0;
        foreach (GoalsPost item in lsGoalsPost)
        {
            if (item.wasActive)
            {
                count += 1;
                if(count == lsGoalsPost.Count )
                {
                    completeGrass = true;
                    //this.transform.GetComponentInParent<SampleLevel>().CheckGrass();
                    GamePlayControllerKhanh.Instance.level.CheckGrass();
                    outLine.gameObject.SetActive(false);
                    Debug.Log("completeGrass " );
                }
            }
        }
    }

    #region Get
    public GoalsPost GoalsPost(int param)
    {
        foreach (GoalsPost item in lsGoalsPost)
        {
            if (param == item.id)
            {
                return item;
            }

        }
        return null;
    }
    #endregion


    public void SetRaycasTaget(int param)
    {
        Debug.Log("SetRaycasTaget " + param);
        foreach (GoalsPost item in lsGoalsPost)
        {
            item.thumnails.raycastTarget = false;

        }
        try
        {
            GoalsPost(param).thumnails.raycastTarget = true;
        }
        catch
        {

        }
        //lsGoalsPost[param].thumnails.raycastTarget = true;
    }
}
