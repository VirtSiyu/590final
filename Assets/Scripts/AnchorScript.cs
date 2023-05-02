using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnchorScript : MonoBehaviour
{
    public GameObject movableScene;
    public GameObject cubeAnchor;

    public GameObject table1;
    public GameObject table2;
    public GameObject table3;
    public GameObject table4;
    public GameObject table5;
    public GameObject table6;
    public GameObject table7;
    public GameObject table8;

    public bool hideTable = false;
    public TMP_Text hideButtonText;

    bool position1ready = false;
    bool position2ready = false;

    public bool startCalibrate = false;
    public TMP_Text calibrateButtonText;

    Vector3 position1 = new Vector3(0, 0, 0);
    Vector3 position2 = new Vector3(0, 0, 0);
    Quaternion rotation1 = new Quaternion(0, 0, 0, 0);
    Quaternion rotation2 = new Quaternion(0, 0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (startCalibrate)
        {
            cubeAnchor.SetActive(true);

            // first anchor
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                position1 = cubeAnchor.transform.position;
                position1ready = true;
                rotation1 = cubeAnchor.transform.rotation;
            }

            // second anchor
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                position2 = cubeAnchor.transform.position;
                position2ready = true;
                rotation2 = cubeAnchor.transform.rotation;
            }

            // calibrate
            if (position1ready == true && position2ready == true)
            {
                // adjust transform Position
                Vector3 calibratedPos = Vector3.Lerp(position1, position2, 0.5f);
                movableScene.transform.position = calibratedPos + new Vector3(0, 0.012f, 0.205f);
                // z offset tablewidth51cm, cubeAnchor10cm: +(25.5-5)cm


                // adjust transform Rotation
                Quaternion calibratedRot = Quaternion.Lerp(rotation1, rotation2, 0.5f);
                movableScene.transform.rotation = calibratedRot;

                position1ready = false;
                position2ready = false;
                startCalibrate = false;
                cubeAnchor.SetActive(false);
                calibrateButtonText.text = "Calibrate";
            }
        }
        else
        {
            cubeAnchor.SetActive(false);
        }


        if (hideTable)
        {
            table1.SetActive(false);
            table2.SetActive(false);
            table3.SetActive(false);
            table4.SetActive(false);
            table5.SetActive(false);
            table6.SetActive(false);
            table7.SetActive(false);
            table8.SetActive(false);
        }
        else
        {
            table1.SetActive(true);
            table2.SetActive(true);
            table3.SetActive(true);
            table4.SetActive(true);
            table5.SetActive(true);
            table6.SetActive(true);
            table7.SetActive(true);
            table8.SetActive(true);
        }
    }

    public void resetButtonPressed()
    {
        startCalibrate = !startCalibrate;
        if (startCalibrate)
        {
            calibrateButtonText.text = "Cancel Calibrate";
        }
        else
        {
            // cancel calibrating
            calibrateButtonText.text = "Calibrate";
            position1ready = false;
            position2ready = false;
        }
    }

    public void hideButtonPressed()
    {
        hideTable = !hideTable;
        if (hideTable)
        {
            hideButtonText.text = "Show Table";
        }
        else
        {
            // show table
            hideButtonText.text = "Hide table";
        }
    }
}
