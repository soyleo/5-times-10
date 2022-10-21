using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Attack : MonoBehaviour
{
    [SerializeField] private InputAction playerAttack;
    [SerializeField] private Animator playerAnimator;
    [SerializeField]private Transform originRigth;
    [SerializeField]private Transform originLeft;

    private RaycastHit2D upRay;
    public Vector2 originPoint;
    public Vector2 endPoint;

    private void OnEnable()
    {
        playerAttack.Enable();
        PlayerBlackboard.Instance.isAttacking = false;
    }
    //OnDisable, Note: requisite for Unity Input System
    private void OnDisable()
    {
        playerAttack.Disable();
        PlayerBlackboard.Instance.isAttacking = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerBlackboard.Instance.isAttacking = !(playerAttack.enabled && playerAnimator != null);
    }

    // Update is called once per frame
    void Update()
    {

        PlayerBlackboard.Instance.isAttacking = playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("ATTACK");
        originPoint = (PlayerBlackboard.Instance.isFacingRigth)? originRigth.position : originLeft.position;
        endPoint = ((PlayerBlackboard.Instance.isFacingRigth)? Vector2.right : Vector2.left) * 0.02f;
        upRay = Physics2D.Raycast(originPoint, endPoint);
        Debug.DrawRay(originPoint, endPoint , Color.red);
        
        if(!PlayerBlackboard.Instance.isAttacking && (playerAttack.ReadValue<float>() > 0)){
            playerAnimator.SetTrigger("AttackTrigger");
        }else if(PlayerBlackboard.Instance.isAttacking && upRay && upRay.transform.tag == "Enemy"){
            Debug.LogError("Hit");
        }
    }
}
