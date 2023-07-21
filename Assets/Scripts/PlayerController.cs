using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform sledge;
    [SerializeField] private float lerpSpeed;
    private LineRenderer lineRenderer;
    private int degree;
    void Awake()
    {
        Application.targetFrameRate = 60;
        lineRenderer = GetComponent<LineRenderer>();
        Rope();
    }
    void Update()
    {
        transform.Translate(Vector3.forward * .25f * Time.deltaTime);        
        Rotation();
        FollowSledge();
        Rope();
    }
    private void Rotation()
    {
        degree = Input.GetMouseButton(0) == true ? 180 : 0; 
        transform.Rotate(Vector3.up * degree * Time.deltaTime);
    }
    private void Rope()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, sledge.position);
    }
    private void FollowSledge()=>sledge.position = Vector3.Lerp(sledge.position,
    transform.position - transform.forward * .75f,lerpSpeed * Time.deltaTime);
}