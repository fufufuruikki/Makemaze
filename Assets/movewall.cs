using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewall : MonoBehaviour
{
    Transform myTransform;    // transform情報を格納する変数 
    Vector3 position_start;     // 物体の初期位置を格納する変数 
    Vector3 position_now;       // 物体の現在位置を格納する変数
    private int f_wall;
 
    // Start is called before the first frame update 
    void Start() 
    { 
        myTransform = this.transform;  // 物体のtransform情報をリンクする 
        position_start = myTransform.position;  // 初期位置を取り出す 
        position_now = position_start;  // 最初は同じ場所
        f_wall = 0;
    } 
 
    // Update is called once per frame 
    void Update() 
    {
        if (f_wall == 0)
        {
            position_now.z += 0.05f;
            if (position_now.z - position_start.z > 4)
            {
                f_wall = 1;
                position_start = position_now;
            }
        }
        else
        {
            position_now.z -= 0.05f;
            if (position_start.z - position_now.z > 4)
            {
                f_wall = 0;
                position_start = position_now;
            }
        }
        myTransform.position = position_now;
    } 
}
