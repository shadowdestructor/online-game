using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private float lerpSpeed;
    private void LateUpdate()=>transform.position = Vector3.Lerp(transform.position,player.transform.position+offsetPosition,lerpSpeed * Time.deltaTime);
}
