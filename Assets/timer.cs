using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // この２行を追加する． 
using TMPro;       // この２行を追加する．

public class timer : MonoBehaviour
{
    // Textを外部に出力するための変数を定義する 
    // […]をつけることで，内部変数がインスペクターから操作できるようになる． 
    // private を public にしても操作可能になる． 
    [SerializeField] private TextMeshProUGUI TextTime;
    [SerializeField] private TextMeshProUGUI Messeage;
    [SerializeField] private AudioSource goal_sound;
    [SerializeField] private AudioSource finish_sound;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;

    float time_limit = 4*60;
    int f_goal = 0;
    
    // Start is called before the first frame update 
    void Start() 
    { 

    } 
 
    // Update is called once per frame 
    void Update() 
    {
        if(time_limit < 0)
        {
            Messeage.text = "Finish!";
            finish_sound.PlayOneShot(clip2);
        }
        else
        {
            if (f_goal == 0)  // ゴールに到達していない場合だけ時間を加算する 
            {
                time_limit -= Time.deltaTime;
            }
        }
        TextTime.text = string.Format("Time  {0:f2} sec", time_limit); 
    }

    // 衝突を判定する処理を追加する 
    void OnCollisionEnter(Collision other)  // 衝突を判定する関数を呼ぶ 
    {
        if(time_limit >= 0)
        {
            if (other.gameObject.name == "goal")  // 衝突した物体が「ゴール」なら（※） 
            { 
                f_goal = 1;  // 衝突フラグを上げる
                Messeage.text = "GOAL!!!";
                goal_sound.PlayOneShot(clip1);
            }
        }
    }
}