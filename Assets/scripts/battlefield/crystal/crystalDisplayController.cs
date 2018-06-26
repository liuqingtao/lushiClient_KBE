using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crystalDisplayController : MonoBehaviour {
    public List<GameObject>crystals=new List<GameObject>();
    public Sprite[] crystalSprites;
    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject obj;
            obj = transform.Find(string.Format("Image ({0})", i)).gameObject;
            crystals.Add(obj);
        }
        //setCrystalDisplay(9, 3);
    }

    public void setCrystalDisplay(int sum,int activeSum)
    {
        for(int i = 0; i < 10; i++)
        {
            crystals[i].GetComponent<Image>().enabled = (i < sum);
            if (i < sum)
            {
                if (i < activeSum)
                {
                    crystals[i].GetComponent<Image>().sprite = crystalSprites[0];
                }
                else
                {
                    crystals[i].GetComponent<Image>().sprite = crystalSprites[1];
                }
                    
            }
        }
    }


}
