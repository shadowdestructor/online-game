using UnityEngine;
using DG.Tweening;
public class SledgeManager : MonoBehaviour
{
    public float hitForce = 1f; // Balyoz darbe gücü
    public float jumpPower = .05f; // Zıplama gücü
    public int numJumps = 1; // Zıplama sayısı
    public float duration = 10f; // Animasyon süresi
    private void OnCollisionEnter(Collision collision)
    {
        // Darbe aldığında sadece "Player" tag'ine sahip nesneleri düşün
        if (collision.gameObject.TryGetComponent(out BoxCollider boxCollider) 
        && !collision.gameObject.CompareTag("Player"))
        {
           Debug.Log(-collision.contacts[0].normal);
            Vector3 hitDirection = -collision.contacts[0].normal;
            Vector3 targetPosition = collision.transform.position + hitDirection;// * hitForce;

            // DOLocalJump kullanarak objeyi zıplat
            collision.transform.DOLocalJump(targetPosition, jumpPower, numJumps, duration)
                .SetEase(Ease.OutQuad); // Animasyonun yumuşak geçişini sağlamak için Ease.OutQuad kullanıldı
        }
    }
}
