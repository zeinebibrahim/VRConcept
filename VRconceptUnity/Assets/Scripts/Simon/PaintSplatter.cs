using UnityEngine;

public class PaintSplatter : MonoBehaviour
{
    [SerializeField] GameObject paintSplatterPrefab; // prefab van de verfspat


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);

        // Spawn splatter
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.LookRotation(-contact.normal, Vector3.up);

        // Hier krijgt die een kleine offset zodat die niet IN de muur clipped
        float extraOffset = Random.Range(0.005f, 0.015f);
        Vector3 pos = contact.point + contact.normal * extraOffset;


        GameObject splat = Instantiate(paintSplatterPrefab, pos, rot);

        // Random scale
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
    }
}
