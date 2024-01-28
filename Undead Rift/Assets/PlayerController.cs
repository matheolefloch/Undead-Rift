using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

     [SerializeField]
    private float lookSensitivity;

    private PlayerMotor motor;
    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }
    private void Update()
    {
        //Calculer la vitesse du joueur
        float XMov = Input.GetAxisRaw("Horizontal");
        float ZMov = Input.GetAxisRaw("Vertical");
        Vector3 moveHorizontal = transform.right * XMov;
        Vector3 moveVertical = transform.forward * ZMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

    }
}