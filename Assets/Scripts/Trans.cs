using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Trans : MonoBehaviour
{
    public LayerMask layerMask;
    public float fadeDuration = 0.5f;

    private Transform playerTransform;
    private Transform cameraTransform;
    private Dictionary<GameObject, Material> initialMaterials = new Dictionary<GameObject, Material>();

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cameraTransform = transform;
    }

    private void Update()
    {
        // Objelerin þeffaf hale getirilip getirilmediðini kontrol etmek için bir liste tutarýz.
        List<GameObject> objectsToRestore = new List<GameObject>(initialMaterials.Keys);

        RaycastHit[] hits;
        Vector3 playerToCamera = cameraTransform.position - playerTransform.position;
        Ray ray = new Ray(playerTransform.position, playerToCamera.normalized);

        hits = Physics.RaycastAll(ray, playerToCamera.magnitude, layerMask);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject != playerTransform.gameObject && hit.collider.gameObject != cameraTransform.gameObject)
            {
                if (hit.collider.gameObject.TryGetComponent<Renderer>(out Renderer renderer))
                {
                    // Objeyi þeffaf yap.
                    renderer.material.DOFade(0.1f, fadeDuration);

                    // Eðer obje daha önce kaydedilmediyse, baþlangýç materyalini kaydet.
                    if (!initialMaterials.ContainsKey(hit.collider.gameObject))
                    {
                        initialMaterials.Add(hit.collider.gameObject, renderer.material);
                    }

                    // Bu objeyi listeden kaldýr, çünkü hala kamera ve oyuncu arasýnda.
                    objectsToRestore.Remove(hit.collider.gameObject);
                }
            }
        }

        // Kamera ve oyuncu arasýndan çýkan objelerin þeffaflýðýný geri al.
        foreach (GameObject obj in objectsToRestore)
        {
            if (obj.TryGetComponent<Renderer>(out Renderer renderer))
            {
                // Objeyi tekrar görünür yap.
                renderer.material.DOFade(1f, fadeDuration);

                initialMaterials.Remove(obj);
            }
        }
    }
}
