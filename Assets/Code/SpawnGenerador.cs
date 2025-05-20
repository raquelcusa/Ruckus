// SpawnerGenerador.cs
using UnityEngine;

public class SpawnerGenerador : MonoBehaviour
{
    public void InstanciarObjeto(int index, SpawnerManager manager)
    {
        var info = manager.spawns[index];
        if (info.prefab == null || info.spawnPoint == null) return;

        GameObject nuevo = Instantiate(
            info.prefab,
            info.spawnPoint.position,
            info.spawnPoint.rotation
        );

        // Si quieres mantener jerarquía con el punto de spawn:
        nuevo.transform.SetParent(info.spawnPoint);

        info.instanciaActual = nuevo;

        // Asigna el manager al script del prefab
        ObjetoInteractivo oi = nuevo.GetComponent<ObjetoInteractivo>();
        if (oi != null)
        {
            oi.manager = manager;
        }
        else
        {
            Debug.LogWarning("El prefab no tiene ObjetoInteractivo.");
        }
    }
}
