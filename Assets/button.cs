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
    Transform wallTransform;
    Vector3 origin = new Vector3(5.7f, 1f, -15f);  // 回転中心 
    Vector3 axis = new Vector3(0f, 1f, 0f);   // 回転軸（Y 軸）
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        wallTransform = GameObject.Find("rotatewall").transform;
        angle = 0;
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
            if(angle == 90)
            {

            }
            else
            {
                angle += 2;
                wallTransform.RotateAround(origin, axis, -2f);
            }
        }
        else
        {
            if(angle == 0)
            {

            }
            else
            {
                angle -= 2;
                wallTransform.RotateAround(origin, axis, +2f);
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
    }
}