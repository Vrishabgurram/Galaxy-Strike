using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    private SceneManagerScript sceneManagerScript;

    private void Start()
    {
        sceneManagerScript = FindFirstObjectByType<SceneManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            //Debug.Log("hit " + other.gameObject.name);
            Destroy(gameObject);
            sceneManagerScript.ReloadScene();
        }
    }
}
