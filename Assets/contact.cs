using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // この２行を追加する． 
using TMPro;       // この２行を追加する．

public class contact : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ContactCount;
    private int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ContactCount.text = string.Format("death  {0}", cnt);
    }

    void OnCollisionEnter(Collision other)  // 衝突を判定する関数を呼ぶ 
    {
        if (other.transform.parent.gameObject.name  == "wall")
        {
            cnt += 1;
        }
    }
}
