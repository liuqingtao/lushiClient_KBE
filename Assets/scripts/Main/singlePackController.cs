using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singlePackController : MonoBehaviour {
    public openPackController controller;
    public Transform displayPostion;
    public void OnMouseDrag()
    {
        transform.position = Input.mousePosition;
        
    }
    public void endDrag()
    {
        Debug.Log("停止挪动");
        float x = transform.position.x;
        float y = transform.position.y;

        if (x>controller.point[0].position.x &&  x<controller.point[1].position.x &&
            y<controller.point[0].position.y && y > controller.point[1].position.y)
        {
            Debug.Log("在触发范围");
            transform.position = displayPostion.position;
            controller.openPack();
        }
        else
        {
            transform.position = displayPostion.position;
        }
    }
}
