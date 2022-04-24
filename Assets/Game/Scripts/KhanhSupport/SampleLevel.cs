using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SampleLevel : MonoBehaviour
{
    public List<Grass> lsGrass;
    public Grass currentGrass;
    private bool isWin;

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

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
  
    }

}
