using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.UI;

public class PlayerContloller : MonoBehaviour
{
    

    public float speed = 6.0F;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float radius;
    public float jumpSpeed = 10.0f;
    public int damage = 10;
    public float gravity;
    public float NumberEmission;
    public float h;
    public int a;


    public GameObject cam;
    public GameObject energy;

    public Light sphereLight;
    public Animator animator;
    public SphereCollider AttackPosition;
    public Rigidbody rb;
    public CharacterController CharaController;
    public ParticleSystem powerParticle;
    public AudioSource walkSound;

    private Vector3 moveDirection = new Vector3(0, 0, 0);
    SpriteRenderer sprite;

    private bool facingRight;

   
    float jump_ct = 0;//何回か押したことを数える
    float pushPower = 4.0f;
    int stage_st;
    int moveValue;

    float y;
    float y2;
    float y3;
    float y4;
    float camOffsetZ;
    float camOffsetX;
    int cameraRotationIndex;
    int cameraRotationIndex2;
    int cameraRotationIndex3;
    int cameraRotationIndex4;

    int redDoorIndex;
    int greenDoorIndex;

    bool isCameraRotating;
    bool isArrivingFromRight;

    bool isPlayerComingFromLeft;
    bool isPlayerComingFromRight;


    void Start()
    {
        isArrivingFromRight = false;
        facingRight = true;
        moveValue = a;
        NumberEmission = 1.0f;
        rb = GetComponent<Rigidbody>();
        sprite = GetComponent<SpriteRenderer>();
        animator.SetBool("jump", false);
        cam = GameObject.Find("Main Camera");
        energy = GameObject.Find("SliderEnergy");
        walkSound = GetComponent<AudioSource>();
        CharaController = GetComponent<CharacterController>();
    }

    private void LateUpdate()
    {
        AttackPosition.transform.position = transform.position;
        EmiteAuraOfPower();
    }

    void Update()
    {
        Debug.Log("num of emission" + NumberEmission);
        AttackPosition.transform.rotation=cam.transform.rotation;
        Move(moveValue);
    }
    
    void EmiteAuraOfPower()
    {
        var emission = powerParticle.emission;
        emission.rateOverTime = NumberEmission;
        energy.GetComponent<Image>().fillAmount = NumberEmission/60;
    }
    public void Move(int freezValue)
    {
        transform.rotation = cam.transform.rotation;//カメラとと同じように回転する

        if (CharaController.isGrounded)
        {
            ResetJump();
            if (h != 0)
            {
                if (!walkSound.isPlaying)
                {
                    walkSound.volume = 0.1f;
                    walkSound.pitch = 1;
                    walkSound.Play();
                }
            }
            else
            {
                walkSound.Stop();
            }
        }
        else
        {
            walkSound.Stop();
        }


        if (jump_ct < 2)
        {

            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
        }

        h = Input.GetAxis("Horizontal");
        //Debug.Log(h);
        
        if (h < 0 && !facingRight || h > 0 && facingRight)
        {
            Flip(h);
        }

        CharaController = GetComponent<CharacterController>();
        moveValue = freezValue;
        if (freezValue == 0)
        {
            moveDirection.x = h * speed;
            moveDirection.z = 0;
            animator.SetFloat("speed", Mathf.Abs(h));

        }
        else if (freezValue == 1)
        {
            moveDirection.z = h * speed;
            moveDirection.x = 0;
            animator.SetFloat("speed", Mathf.Abs(h));
        }
        else if (freezValue == 2)
        {
            moveDirection.x = -h * speed;
            moveDirection.z = 0;
            animator.SetFloat("speed", Mathf.Abs(h));
        }
        else if (freezValue == 3)
        {
            moveDirection.z = -h * speed;
            moveDirection.x = 0;
            animator.SetFloat("speed", Mathf.Abs(h));
        }
        else if (freezValue == -1)
        {
            moveDirection.z = -h * speed;
            moveDirection.x = 0;
            animator.SetFloat("speed", Mathf.Abs(h));
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        CharaController.Move(moveDirection * Time.deltaTime);

    }
    
    void ResetJump()
    {
        animator.SetBool("isJumpFinished", true);
        jump_ct = 0;
        moveDirection.y = 0;
    }
    public void Jump()
    {
        moveDirection.y = jumpSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        CharaController.Move(moveDirection * Time.deltaTime);
        animator.SetTrigger("jump 0");
        animator.SetBool("isJumpFinished", false);
        jump_ct++;
    }
    private void Flip(float h)
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        if (theScale.x > 0)
        {
            sprite.flipX = false;
            AttackPosition.center = new Vector3(-0.5f, 0.0f, 0.0f);
        }
        else
        {
            sprite.flipX = true;
            AttackPosition.center = new Vector3(0.5f, 0.0f, 0.0f);
        }
    }
    

    //箱押し
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        if (hit.gameObject.tag == "hako")
        {
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // If you know how fast your character is trying to move,
            // then you can also multiply the push velocity by that.

            // Apply the push
            body.velocity = pushDir * pushPower;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SphereLigth")
        {
            sphereLight.range += 10;
            Destroy(other.gameObject);
        }    
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="red")
        {
            DoorsManager doorManager= other.gameObject.GetComponent<DoorsManager>();
            if (Input.GetKeyDown("e"))
            {
                if (redDoorIndex == 0)
                {

                    doorManager.OpenTheDoor("OpenEffectRed");
                    redDoorIndex++;
                }
                else
                {
                    doorManager.CloseTheDoor("CloseEffectRed");
                    redDoorIndex--;
                }
            }

        }

        else if (other.gameObject.tag == "green")
        {
            DoorsManager doorManager = other.gameObject.GetComponent<DoorsManager>();
            if (Input.GetKeyDown("e"))
            {
                if (greenDoorIndex == 0)
                {
                    doorManager.OpenTheDoor("OpenEffect");
                    greenDoorIndex++;
                }
                else
                {
                    doorManager.CloseTheDoor("CloseEffect");
                    greenDoorIndex--;
                }
            }

        }

        // turn feature
        switch (other.gameObject.tag)
        {
            case "RotatorButton":
                if (Input.GetKeyDown("e"))
                {
                    if (isPlayerComingFromLeft == false)
                    {
                        isPlayerComingFromRight = true;
                    }
                    TurnCamera(other);
                }
                break;

            case "RotatorButton2":
                if (Input.GetKeyDown("e"))
                {
                    TurnCamera2(other);
                }
                break;

            case "RotatorButton3":
                if (Input.GetKeyDown("e"))
                {
                    isArrivingFromRight = true;
                    TurnCamera3(other);
                }
                break;
            case "RotatorButton4":
                if (Input.GetKeyDown("e"))
                {
                    if (isPlayerComingFromRight == false)
                    {
                        isPlayerComingFromLeft = true;
                    }
                    TurnCamera(other);
                }
                break;
        }
    }

    void TurnCameraFromLeft(Collider other)
    {
        if (cameraRotationIndex == 0)
        {
            cameraRotationIndex++;
            isCameraRotating = true;
            StartCoroutine(TurnRight(0.01f, other));
        }
        else
        {
            cameraRotationIndex--;
            isCameraRotating = true;
            StartCoroutine(TurnLeft(0.01f, other));
        }
    }
    void TurnCamera(Collider other)
    {
        if (cameraRotationIndex == 0)
        {
            cameraRotationIndex++;
            isCameraRotating = true;
            StartCoroutine(TurnRight(0.01f, other));
        }
        else
        {
            cameraRotationIndex--;
            isCameraRotating = true;
            StartCoroutine(TurnLeft(0.01f, other));
        }
    }

    void TurnCamera2(Collider other)
    {
        if (cameraRotationIndex2 == 0)
        {
            cameraRotationIndex2++;
            isCameraRotating = true;
            StartCoroutine(TurnRight2(0.01f, other));
        }
        else
        {
            cameraRotationIndex2--;
            isCameraRotating = true;
            StartCoroutine(TurnLeft2(0.01f, other));
        }
    }

    void TurnCamera3(Collider other)
    {
        if (cameraRotationIndex3 == 0)
        {
            cameraRotationIndex3++;
            isCameraRotating = true;
            StartCoroutine(TurnRight3(0.01f, other));
        }
        else
        {
            cameraRotationIndex3--;
            isCameraRotating = true;
            StartCoroutine(TurnLeft3(0.01f, other));
        }
    }

    IEnumerator TurnRight3(float waitTime, Collider triggerPowerBtn)
    {
        if (isPlayerComingFromRight == true)
        {
            while (isCameraRotating == true)
            {
                TurnCamAndButtonToRight(triggerPowerBtn);
                Move(3);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                SetCameraOffsetXToMinus5();
                triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 90, 0.0f);
                CharaController.enabled = false;
                if (y <= -270)
                {
                    y = -270;
                    cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                    triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                    cameraRotationIndex = 0;
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
        else if (isPlayerComingFromLeft == true)
        {
            while (isCameraRotating == true)
            {
                TurnBackCamAndButtonToLeft(triggerPowerBtn);
                Move(2);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                
                SetCameraOffsetTo5();
                triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 90, 0.0f);
                CharaController.enabled = false;
                if (y >= 180)
                {
                    y = 180;
                    cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                    triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

    IEnumerator TurnLeft3(float waitTime, Collider triggerPowerBtn)
    {
        if (isPlayerComingFromRight == true)
        {
            while (isCameraRotating == true)
            {
                TurnBackCamAndButtonToLeft(triggerPowerBtn);
                Move(2);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 90, 0.0f);
                SetCameraOffsetTo5();
                CharaController.enabled = false;
                if (y >= -180)
                {
                    cameraRotationIndex = 1;
                    isCameraRotating = false;

                }
                yield return new WaitForSeconds(waitTime);
            }
        }
        else if (isPlayerComingFromLeft == true)
        {
            while (isCameraRotating == true)
            {
                TurnCamAndButtonToRight(triggerPowerBtn);
                Move(3);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 90, 0.0f);
                SetCameraOffsetXToMinus5();
                CharaController.enabled = false;
                if (y <= 90)
                {
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }

    }

    IEnumerator TurnRight2(float waitTime, Collider triggerPowerBtn)
    {
        if (isPlayerComingFromRight == true)
        {
            while (isCameraRotating == true)
            {
                TurnCamAndButtonToRight(triggerPowerBtn);
                Move(2);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 90, 0.0f);
                CharaController.enabled = false;
                SetCameraOffsetTo5();
                if (y <= -180)
                {
                    y = -180;
                    cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                    triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
        else if (isPlayerComingFromLeft == true)
        {
            while (isCameraRotating == true)
            {
                TurnBackCamAndButtonToLeft(triggerPowerBtn);
                Move(1);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                //triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 90, 0.0f);
                CharaController.enabled = false;
                SetCameraOffsetTo5();
                if (y >= 270)
                {
                    y = 270;
                    cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                    triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
   
    IEnumerator TurnLeft2(float waitTime, Collider triggerPowerBtn)
    {
        if (isPlayerComingFromRight == true)
        {
            while (isCameraRotating == true)
            {
                TurnBackCamAndButtonToLeft(triggerPowerBtn);
                Move(1);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 0, 0.0f);
                CharaController.enabled = false;
                if (y >= -90)
                {
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
        else if (isPlayerComingFromLeft == true)
        {
            while (isCameraRotating == true)
            {
                TurnCamAndButtonToRight(triggerPowerBtn);
                Move(2);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 0, 0.0f);
                CharaController.enabled = false;
                if (y <= 180)
                {
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }

    }

    IEnumerator TurnRight(float waitTime, Collider triggerPowerBtn)
    {
        if (isPlayerComingFromRight == true)
        {
            if (isArrivingFromRight == true)
            {
                while (isCameraRotating == true)
                {
                    TurnCamAndButtonToRight(triggerPowerBtn);
                    Move(0);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                    SetCameraOffsetXToMinus5();
                    CharaController.enabled = false;
                    if (y <= -360)
                    {
                        y = 0;
                        cameraRotationIndex = 0;
                        cameraRotationIndex2 = 0;
                        cameraRotationIndex3 = 0;
                        cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                        triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
                        isArrivingFromRight = false;
                        isPlayerComingFromRight = false;
                        isPlayerComingFromLeft = false;
                        isCameraRotating = false;
                    }
                    yield return new WaitForSeconds(waitTime);
                }
            }
            else
            {
                while (isCameraRotating == true)
                {
                    TurnCamAndButtonToRight(triggerPowerBtn);
                    Move(1);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                    SetCameraOffsetTo5();
                    CharaController.enabled = false;
                    if (y <= -90)
                    {
                        isCameraRotating = false;
                    }
                    yield return new WaitForSeconds(waitTime);
                }
            }
        }
        else if (isPlayerComingFromLeft == true)
        {
            while (isCameraRotating == true)
            {
                TurnBackCamAndButtonToLeft(triggerPowerBtn);
                Move(3);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                CharaController.enabled = false;
                if (y >= 90)
                {
                    isArrivingFromRight = false;
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
    
    IEnumerator TurnLeft(float waitTime, Collider triggerPowerBtn)
    {
        if (isPlayerComingFromRight == true)
        {
            while (isCameraRotating == true)
            {

                TurnBackCamAndButtonToLeft(triggerPowerBtn);
                Move(0);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                SetCameraOffsetXToMinus5();
                CharaController.enabled = false;
                if (y >= 0)
                {
                    cameraRotationIndex = 0;
                    cameraRotationIndex2 = 0;
                    cameraRotationIndex3 = 0;
                    isPlayerComingFromLeft = false;
                    isPlayerComingFromRight = false;
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
        else if (isPlayerComingFromLeft == true)
        {
            while (isCameraRotating == true)
            {
                TurnCamAndButtonToRight(triggerPowerBtn);
                Move(0);//playerControllerスクリプトに1の値を送って、プレイヤーの動きを変える
                CharaController.enabled = false;
                if (y <= 0)
                {
                    cameraRotationIndex = 0;
                    cameraRotationIndex2 = 0;
                    cameraRotationIndex3 = 0;
                    isPlayerComingFromLeft = false;
                    isPlayerComingFromRight = false;
                    isCameraRotating = false;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
    }





   



    void TurnCamAndButtonToRight(Collider triggerPowerBtn)
    {
        y -= Time.deltaTime + 2f;
        cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
        triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
    }
    void TurnBackCamAndButtonToLeft(Collider triggerPowerBtn)
    {
        y += Time.deltaTime + 2f;//-９０度までカメラを回転する
        cam.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
        triggerPowerBtn.gameObject.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
    }

    void SetCameraOffsetTo5()
    {
        if (camOffsetX < 5)
        {
            camOffsetX += Time.deltaTime + 1f;
            camOffsetZ += Time.deltaTime + 1f;
            cam.GetComponent<CameraFolow>().offset = new Vector3(camOffsetX, 0, camOffsetZ);
        }
    }
    void SetCameraOffsetXToMinus5()
    {
        if (camOffsetX > -5)
        {
            camOffsetX += Time.deltaTime - 1f;
            camOffsetZ += Time.deltaTime -1f;
            cam.GetComponent<CameraFolow>().offset = new Vector3(camOffsetX, 0, camOffsetZ);
        }
    }
}