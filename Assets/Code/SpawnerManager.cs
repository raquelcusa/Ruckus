// SpawnerManager.cs
using UnityEngine;
using System.Collections;  // necesario para IEnumerator

public class SpawnerManager : MonoBehaviour
{
    [System.Serializable]
    public class SpawnInfo
    {
        public GameObject prefab;
        public Transform spawnPoint;
        [HideInInspector] public GameObject instanciaActual;
    }

    [Header("Spawns de objetos")]
    public SpawnInfo[] spawns = new SpawnInfo[4];

    [Header("Tiempo de regeneración tras recoger")]
    public float tiempoRespawn = 2f;

    private SpawnerGenerador generador;

    void Start()
    {
        generador = GetComponent<SpawnerGenerador>();
        if (generador == null)
            Debug.LogError("No se encontró el componente SpawnerGenerador.");

        StartCoroutine(EsperarYGenerarInicial());
    }

    IEnumerator EsperarYGenerarInicial()
    {
        yield return new WaitForSeconds(tiempoRespawn);
        for (int i = 0; i < spawns.Length; i++)
            generador.InstanciarObjeto(i, this);
    }

    public void ObjetoRecogido(GameObject objetoRecogido)
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            if (spawns[i].instanciaActual == objetoRecogido)
            {
                spawns[i].instanciaActual = null;
                StartCoroutine(Reaparecer(i));
                break;
            }
        }
    }

    private IEnumerator Reaparecer(int index)
    {
        yield return new WaitForSeconds(tiempoRespawn);
        generador.InstanciarObjeto(index, this);
    }
}
