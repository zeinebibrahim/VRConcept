using UnityEngine;

public class PaintSplatter : MonoBehaviour
{
    [SerializeField] GameObject paintSplatterPrefab; // prefab van de verfspat


    void OnCollisionEnter(Collision collision)
    {
        // Spawn splatter
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, contact.normal);
        rot *= Quaternion.Euler(180, 0, 0);

        Vector3 pos = contact.point + contact.normal * 0.01f; // een beetje offset zodat hij niet in de muur clippt

        GameObject splat = Instantiate(paintSplatterPrefab, pos, rot);

        // Random schaal
        float randomScale = Random.Range(0.5f, 1.5f);
        splat.transform.localScale *= randomScale;

        // Random draai rond de Z-as
        splat.transform.Rotate(Vector3.forward, Random.Range(0f, 360f));

        // Random kleur
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Pas de kleur toe op de Renderer
        Renderer r = splat.GetComponent<Renderer>();
        if (r != null)
        {
            r.material.color = randomColor;
        }

        // Projectile verwijderen
        Destroy(gameObject);
    }
}
