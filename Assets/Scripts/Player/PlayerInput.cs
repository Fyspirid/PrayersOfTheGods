using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private Animator anim;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        if (Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            anim.SetTrigger("isRanged");
        }
        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}
