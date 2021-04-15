using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public  Vector3 ReachedPoint;
    PlayerData playerData;
    public  int saveHp;
    private void Start()
    {
        playerData = PlayerData.GetInstance();
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
                Debug.Log("in ");
                Debug.Log(saveHp);
            }
            
        }
    }
}
