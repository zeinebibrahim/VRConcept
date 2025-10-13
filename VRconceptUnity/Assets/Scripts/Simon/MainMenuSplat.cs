using UnityEngine;

public class MainMenuSplat : MonoBehaviour
{
    [SerializeField] GameObject paintSplatterPrefab; // prefab van de verfspat


    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;
        Vector3 pos = contact.point + normal * 0.01f;

        // Basis rotatie: align prefab Y-as met de normaal
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, normal);

        // Zet X en Y volledig op 0 om scheve rotatie te vermijden
        Vector3 euler = rot.eulerAngles;
        euler.x = 0f;
        euler.y = 0f;
        rot = Quaternion.Euler(euler);

        // Random draai rond de normaal (Z-as)
        rot *= Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        // Instantiate
        GameObject splat = Instantiate(paintSplatterPrefab, pos, rot);

        // Random schaal
        float randomScale = Random.Range(0.5f, 1.5f);
        splat.transform.localScale *= randomScale;

        // Felle kleur
        Renderer r = splat.GetComponent<Renderer>();
        if (r != null)
        {
            r.material.color = new Color(Random.value, Random.value, Random.value);
        }

        // Destroy bullet
        Destroy(gameObject);


    }
}
