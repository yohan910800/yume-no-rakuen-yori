using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCube : MonoBehaviour
{
    public GameObject turnCube;
    int turnCubeIndex;
    bool isCubeTurning;

    float z;
    void Start()
    {
        turnCubeIndex = 0;
        if (turnCube.gameObject.name.Contains("Runer"))
        {
            turnCubeIndex = 1;
        }
        z = -90;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            if (Input.GetKeyDown("e") || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                
                Debug.Log("Pressed");
                if (turnCubeIndex == 0)
                {
                    isCubeTurning = true;
                    StartCoroutine(TurnCube1(0.01f));
                    turnCubeIndex++;
                }
                else if (turnCubeIndex == 1)
                {
                    isCubeTurning = true;
                    StartCoroutine(TurnCube2(0.01f));
                    turnCubeIndex++;
                }
                else if (turnCubeIndex == 2)
                {
                    isCubeTurning = true;
                    StartCoroutine(TurnCube3(0.01f));
                    turnCubeIndex++;
                }
                else if (turnCubeIndex == 3)
                {
                    isCubeTurning = true;
                    StartCoroutine(TurnCube4(0.01f));
                    turnCubeIndex=0;
                }
            }
        }
    }
    IEnumerator TurnCube1(float waitTime)
    {
        while (isCubeTurning == true)
        {
            SetCubeRotation();
            if (z <= -180)
            {
                z = -180;
                turnCube.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, z);
                isCubeTurning = false;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    IEnumerator TurnCube2(float waitTime)
    {
        while (isCubeTurning == true)
        {
            SetCubeRotation();
            if (z <= -270)
            {
                z = -270;
                turnCube.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, z);
                isCubeTurning = false;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    IEnumerator TurnCube3(float waitTime)
    {
        while (isCubeTurning == true)
        {
            SetCubeRotation();
            if (z <= -360)
            {
                z = -360;
                turnCube.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, z);
                isCubeTurning = false;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    IEnumerator TurnCube4(float waitTime)
    {
        while (isCubeTurning == true)
        {
            SetCubeRotation();
            if (z <= -450)
            {
                z = -90;
                turnCube.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, z);
                isCubeTurning = false;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SetCubeRotation()
    {
        z -= Time.deltaTime + 2f;
        turnCube.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, z);
    }
}