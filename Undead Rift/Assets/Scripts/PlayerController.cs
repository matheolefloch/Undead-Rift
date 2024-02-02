using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float horizontalMouseSensitivity = 10f;

    [SerializeField]
    private float verticalMouseSensitivity = 10f;

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

        //Calculer la rotation horizontale du joueur (souris)
        float YRot = Input.GetAxisRaw("Mouse X");
        
        Vector3 rotation =  new Vector3(0, YRot, 0) * horizontalMouseSensitivity;
        motor.Rotate(rotation);

        //Calculer la rotation verticale du joueur (on bouge seulement la camera sinon le joueur va se pencher)
        float XRot = Input.GetAxisRaw("Mouse Y");
        
        Vector3 cameraRotation =  new Vector3(XRot, 0, 0) * verticalMouseSensitivity;
        motor.RotateCamera(cameraRotation);
    }
}