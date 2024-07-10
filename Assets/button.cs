using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // この２行を追加する． 
using TMPro;       // この２行を追加する．

public class button : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Button;
    [SerializeField] private AudioSource button_sound;
    [SerializeField] private AudioClip clip2;
    List<string> buttonQueue = new List<string>();
    List<float> buttonTimer = new List<float>();
    Transform wallTransform_1;
    Transform wallTransform_2;
    Transform wallTransform_3_1;
    Vector3 origin_1 = new Vector3(5.7f, 1f, -15f);  // 回転中心 
    Vector3 origin_2 = new Vector3(-3f, 1f, 64f);
    Vector3 origin_3_1 = new Vector3(7.15f, 1f, 35f); //未実装
    Vector3 origin_3_2 = new Vector3(9.67f, 1f, 52f); //未実装
    Vector3 axis = new Vector3(0f, 1f, 0f);   // 回転軸（Y 軸）
    float angle_1;
    float angle_2;
    float angle_3_1;
    // Start is called before the first frame update
    void Start()
    {
        wallTransform_1 = GameObject.Find("rotatewall1").transform;
        wallTransform_2 = GameObject.Find("rotatewall2").transform;
        wallTransform_3_1 = GameObject.Find("rotatewall3_1").transform;
        angle_1 = 0;
        angle_2 = 0;
        angle_3_1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Button.text = "";
        for(int i=0; i<buttonQueue.Count; i++)
        {
            buttonTimer[i] -= Time.deltaTime;
            Button.text += buttonQueue[i] + ": " + (int)buttonTimer[i] + "\n";
            if((int)buttonTimer[i] == 0)
            {
                buttonQueue.RemoveAt(i);
                buttonTimer.RemoveAt(i);
            }
        }
        if(buttonQueue.Contains("Button1"))
        {
            if(angle_1 == 90)
            {

            }
            else
            {
                angle_1 += 2;
                wallTransform_1.RotateAround(origin_1, axis, -2f);
            }
        }
        else
        {
            if(angle_1 == 0)
            {

            }
            else
            {
                angle_1 -= 2;
                wallTransform_1.RotateAround(origin_1, axis, +2f);
            }
        }
        if(buttonQueue.Contains("Button2"))
        {
            if(angle_2 == 90)
            {

            }
            else
            {
                angle_2 += 2;
                wallTransform_2.RotateAround(origin_2, axis, +2f);
            }
        }
        else
        {
            if(angle_2 == 0)
            {

            }
            else
            {
                angle_2 -= 2;
                wallTransform_2.RotateAround(origin_2, axis, -2f);
            }
        }
        if(buttonQueue.Contains("Button3"))
        {
            if(angle_3_1 == 90)
            {

            }
            else
            {
                angle_3_1 += 2;
                wallTransform_3_1.RotateAround(origin_3_1, axis, -2f);
            }
        }
        else
        {
            if(angle_3_1 == 0)
            {

            }
            else
            {
                angle_3_1 -= 2;
                wallTransform_3_1.RotateAround(origin_3_1, axis, +2f);
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "button1")
        {
            if(buttonQueue.Contains("Button1"))
            {
                buttonTimer[buttonQueue.IndexOf("Button1")] = 30;
            }
            else
            {
                buttonQueue.Add("Button1");
                buttonTimer.Add(30);
            }
            button_sound.PlayOneShot(clip2);
        }
        if(other.gameObject.name == "button2")
        {
            if(buttonQueue.Contains("Button2"))
            {
                buttonTimer[buttonQueue.IndexOf("Button2")] = 30;
            }
            else
            {
                buttonQueue.Add("Button2");
                buttonTimer.Add(30);
            }
            button_sound.PlayOneShot(clip2);
        }
        if(other.gameObject.name == "button3")
        {
            if(buttonQueue.Contains("Button3"))
            {
                buttonTimer[buttonQueue.IndexOf("Button3")] = 30;
            }
            else
            {
                buttonQueue.Add("Button3");
                buttonTimer.Add(30);
            }
            button_sound.PlayOneShot(clip2);
        }
        if(other.transform.parent.gameObject.name == "wall")
        {
            if(buttonQueue.Contains("Button1"))
            {
                buttonTimer[buttonQueue.IndexOf("Button1")] = 0.1f;
            }
        }
    }
}