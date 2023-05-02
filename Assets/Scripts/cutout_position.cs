using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cutout_position : MonoBehaviour
{
    private float pos = 3;
    public TMP_Text disText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        curPos.z = pos;
        transform.position = curPos;
        //transform.Translate(Vector3.forward);
        //transform.position += new Vector3(0, 0, 1);
        //transform.Rotate(0, posDiff * Time.deltaTime, 0);
    }

    public void adjustPos(float sliderPos)
    {
        pos = sliderPos;
        updateText();
    }

    void updateText()
    {
        disText.text = pos.ToString();
    }

}
