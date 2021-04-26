using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public  Vector3 ReachedPoint;
    PlayerData playerData;
    public  int saveHp;
    public GameObject cam;
    public CameraFolow camFollow;
    public PlayerContloller playerController;
    private void Start()
    {
        playerData = PlayerData.GetInstance();
        cam = GameObject.Find("CameraContainer");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContloller>();
        camFollow = cam.GetComponent<CameraFolow>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ruby")
        {
            
            if (playerData.hp > 0)
            {
                saveHp = playerData.hp;
                playerData.savedHp = playerData.hp;

                ReachedPoint = transform.position;
                playerData.savePoint = ReachedPoint;

                playerData.camRotation = cam.transform.rotation;
                playerData.cameraOffset = camFollow.offset;

                playerData.cameraRotationIndex = playerController.cameraRotationIndex;
                playerData.cameraRotationIndex2 = playerController.cameraRotationIndex2;
                playerData.cameraRotationIndex3 = playerController.cameraRotationIndex3;
                playerData.isArrivingFromRight = playerController.isArrivingFromRight;
                playerData.isPlayerComingFromLeft = playerController.isPlayerComingFromLeft;
                playerData.isPlayerComingFromRight = playerController.isPlayerComingFromRight;

                Debug.Log("in ");
                Debug.Log(saveHp);
            }
            
        }
    }
}
