using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class PaintSplatter : MonoBehaviour
{
    [SerializeField] GameObject decalPrefab;
    [SerializeField] SoundManager soundManager;
    
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.LookRotation(-contact.normal, Vector3.up);
        float extraOffset = Random.Range(0.005f, 0.015f);
        Vector3 pos = contact.point + contact.normal * extraOffset;

        GameObject decal = Instantiate(decalPrefab, pos, rot);

        //Kleur instellen
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        DecalProjector projector = decal.GetComponent<DecalProjector>();
        Material matInstance = new Material(projector.material);
        matInstance.SetColor("_SpatColor", randomColor);
        projector.material = matInstance;

        //Schaal en rotatie
        float randomScale = Random.Range(0.5f, 1.5f);
        decal.transform.localScale *= randomScale;
        decal.transform.Rotate(Vector3.forward, Random.Range(0f, 360f), Space.Self);

        //Zet als child van geraakt object
        decal.transform.SetParent(collision.transform, true);
        
        soundManager.PlaySplatSound();
    }
}
