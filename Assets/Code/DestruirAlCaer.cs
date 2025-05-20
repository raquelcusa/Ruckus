using UnityEngine;
using System.Collections;

public class DestruirAlCaer : MonoBehaviour
{
    [Header("Planos que forman el suelo")]
    public GameObject[] suelos;

    private bool enProcesoDeDestruir = false;

    void OnCollisionEnter(Collision collision)
    {
        if (enProcesoDeDestruir) return;

        foreach (GameObject suelo in suelos)
        {
            if (collision.gameObject == suelo)
            {
                enProcesoDeDestruir = true;
                StartCoroutine(DestruirDespues());
                break;
            }
        }
    }

    IEnumerator DestruirDespues()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
