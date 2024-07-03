using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // この２行を追加する． 
using TMPro;       // この２行を追加する．

public class player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Trap;
    [SerializeField] private AudioSource contact_sound;
    [SerializeField] private AudioClip clip1;
    Transform myTransform;    // transform情報を格納する変数 
    Vector3 initial_position;     // 物体の初期位置を格納する変数
    //Vector3 initial_rotate;
    List<string> trapQueue = new List<string>();
    List<float> trapTimer = new List<float>();
    float velocity;

    // Start is called before the first frame update 
    void Start()
    { 
        Application.targetFrameRate = 60;   // ← FPSを60に設定
        myTransform = this.transform;  // 物体のtransform情報をリンクする
        initial_position = myTransform.position;  // 初期位置を取り出す
        //initial_rotate = new Vector3(0,2,0);
        velocity = 0.1f;
    } 
 
    // Update is called once per frame 
    void Update() 
    {
        if (trapQueue.Contains("Stop"))
        {

        }
        else
        {
            if(trapQueue.Contains("Direction"))
            {
                if (Input.GetKey("up")) // ↑なら前（Z方向）に0.1だけ進む 
                { 
                    transform.position += transform.forward * velocity; 
                } 
                if (Input.GetKey("down"))  // ↓なら-Z方向に0.1だけ進む 
                { 
                    transform.position -= transform.forward * velocity; 
                }
            }
            else
            {
                if (Input.GetKey("up")) // ↑なら前（Z方向）に0.1だけ進む 
                { 
                    transform.position += transform.forward * velocity;
                } 
                if (Input.GetKey("down"))  // ↓なら-Z方向に0.1だけ進む 
                { 
                    transform.position -= transform.forward * velocity;
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

        Trap.text = "";
        for(int i=0; i<trapQueue.Count; i++)
        {
            trapTimer[i] -= Time.deltaTime;
            Trap.text += trapQueue[i] + ": " + (int)trapTimer[i] + "\n";
            if((int)trapTimer[i] == 0)
            {
                if(trapQueue[i] == "Velocity")
                {
                    velocity = 0.1f;
                }
                trapQueue.RemoveAt(i);
                trapTimer.RemoveAt(i);
            }
        }
    }
    void OnCollisionEnter(Collision other)  // 衝突を判定する関数を呼ぶ 
    { 
        if (other.transform.parent.gameObject.name  == "wall")
        {
            if(trapQueue.Contains("Restart"))
            {
                trapTimer[trapQueue.IndexOf("Restart")] += 1.5f;
            }
            else
            {
                trapQueue.Add("Restart");
                trapTimer.Add(1.5f);
            }
            contact_sound.PlayOneShot(clip1);
            this.transform.position = initial_position;
            //this.transform.Rotate(initial_rotate);
        }

        if (other.transform.parent.gameObject.name == "trap")
        {
            int probability = Random.Range(0,4);
            if (probability == 0)
            {
                if(trapQueue.Contains("Restart"))
                {
                    trapTimer[trapQueue.IndexOf("Restart")] += 2;
                }
                else
                {
                    trapQueue.Add("Restart");
                    trapTimer.Add(2);
                }
                this.transform.position = initial_position;
            }
            else if (probability == 1)
            {
                if(trapQueue.Contains("Direction"))
                {
                    trapTimer[trapQueue.IndexOf("Direction")] += 10;
                }
                else
                {
                    trapQueue.Add("Direction");
                    trapTimer.Add(10);
                }
            }
            else if (probability == 2)
            {
                if(trapQueue.Contains("Velocity"))
                {
                    trapTimer[trapQueue.IndexOf("Velocity")] += 10;
                }
                else
                {
                    trapQueue.Add("Velocity");
                    trapTimer.Add(10);
                }
                velocity = 0.2f;
            }
            else if (probability == 3)
            {
                if(trapQueue.Contains("Stop"))
                {
                    trapTimer[trapQueue.IndexOf("Stop")] += 10;
                }
                else
                {
                    trapQueue.Add("Stop");
                    trapTimer.Add(10);
                }
            }
        } 
    } 
}