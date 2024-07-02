using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // この２行を追加する． 
using TMPro;       // この２行を追加する．

public class player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Trap;
    Transform myTransform;    // transform情報を格納する変数 
    Vector3 initial_position;     // 物体の初期位置を格納する変数
    //Vector3 initial_rotate;
    int f_time = 0;
    int f_move = 0;
    int f_direction = 0;
    int f_velocity = 0;
    int timer = 0;
    // Start is called before the first frame update 
    void Start() 
    { 
        Application.targetFrameRate = 60;   // ← FPSを60に設定
        myTransform = this.transform;  // 物体のtransform情報をリンクする
        initial_position = myTransform.position;  // 初期位置を取り出す
        //initial_rotate = new Vector3(0,2,0);
    } 
 
    // Update is called once per frame 
    void Update() 
    {
        if (f_time == 1)
        {
            if (f_direction == 1)
            {
                if (Input.GetKey("up")) // ↑なら前（Z方向）に0.1だけ進む 
                { 
                    transform.position += transform.forward * 0.1f; 
                } 
                if (Input.GetKey("down"))  // ↓なら-Z方向に0.1だけ進む 
                { 
                    transform.position -= transform.forward * 0.1f; 
                }
            }
            else if (f_move == 1)
            {

            }
            else if (f_velocity == 1)
            {
                if (Input.GetKey("up")) // ↑なら前（Z方向）に0.1だけ進む 
                { 
                    transform.position += transform.forward * 0.2f; 
                } 
                if (Input.GetKey("down"))  // ↓なら-Z方向に0.1だけ進む 
                { 
                    transform.position -= transform.forward * 0.2f; 
                } 
                if (Input.GetKey ("right"))   // ←ならY軸に3度回転する 
                { 
                    transform.Rotate(0f,3.0f,0f); 
                } 
                if (Input.GetKey ("left"))   // →ならY軸に-3度回転する 
                { 
                    transform.Rotate(0f, -3.0f, 0f); 
                }
            }
            timer += 1;
            if (timer == 60 * 10)
            {
                f_time = 0;
                f_move = 0;
                f_direction = 0;
                timer = 0;
            }
        }
        else
        {
            if (Input.GetKey("up")) // ↑なら前（Z方向）に0.1だけ進む 
            { 
                transform.position += transform.forward * 0.1f; 
            } 
            if (Input.GetKey("down"))  // ↓なら-Z方向に0.1だけ進む 
            { 
                transform.position -= transform.forward * 0.1f; 
            } 
            if (Input.GetKey ("right"))   // ←ならY軸に3度回転する 
            { 
                transform.Rotate(0f,3.0f,0f); 
            } 
            if (Input.GetKey ("left"))   // →ならY軸に-3度回転する 
            { 
                transform.Rotate(0f, -3.0f, 0f); 
            }
        }
    }
    void OnCollisionEnter(Collision other)  // 衝突を判定する関数を呼ぶ 
    { 
        if (other.transform.parent.gameObject.name  == "wall")  // 衝突した物体が「ゴール」なら（※） 
        { 
            this.transform.position = initial_position;
            //this.transform.Rotate(initial_rotate);
        }

        if (other.gameObject.name == "trap")  // 衝突した物体が「ゴール」なら（※） 
        { 
            int probability = Random.Range(0,4);
            if (probability == 0)
            {
                this.transform.position = initial_position;
                //this.transform.Rotate(initial_rotate);
                Trap.text = "リスタート";
            }
            else if (probability == 1)
            {
                f_time = 1;
                f_direction = 1;
                Trap.text = "特定の方向";
            }
            else if (probability == 2)
            {
                f_time = 1;
                f_velocity = 1;
                Trap.text = "速度2倍";
            }
            else if (probability == 3)
            {
                f_time = 1;
                f_move = 1;
                Trap.text = "動きを止める";
            }
        } 
    } 
}
