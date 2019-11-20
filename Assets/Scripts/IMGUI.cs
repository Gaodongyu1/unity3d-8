using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUI : MonoBehaviour {
    //血条位置
    private Rect healthPos; 
    //加血按钮位置
    private Rect upPos;
    //减血按钮位置
    private Rect downPos; 
    //当前血量
    private float health = 0.0f; 
    //加/减血之后的血量
    private float newHealth; 

    // Use this for initialization
    void Start () {
        healthPos = new Rect(200, 80, 100, 20);
        upPos = new Rect(100, 80, 40, 20);
        downPos = new Rect(150, 80, 40, 20);
        //开始的时候新的血量等于0
        newHealth = health;
    }

    // Update is called once per frame
    void Update () {

    }
    private void OnGUI()
    {
        if (GUI.Button(upPos, "加血"))
        {
            //血量最多为1，每次加0.1
            newHealth = health + 0.1f > 1.0f ? 1.0f : health + 0.1f;
        } else if (GUI.Button(downPos, "减血"))
        {
            //血量最低为0，每次减0.1
            newHealth = health - 0.1f < 0 ? 0.0f: health - 0.1f;
        }
        //用Mathf.Lerp()函数插值计算health，使得血条值平滑变化，而不是突变。
        health = Mathf.Lerp(health, newHealth, 0.05f);
        GUI.HorizontalScrollbar(healthPos, 0, health, 0, 1);
    }
}
