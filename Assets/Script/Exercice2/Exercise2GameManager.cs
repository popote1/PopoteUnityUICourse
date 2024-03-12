using UnityEngine;

public class Exercise2GameManager : MonoBehaviour {
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay=2;
    [SerializeField] private GameObject[] _prefabEnnemi;

    private float _spawnTimer;


    private void Update() {
        ManageSpawn();
    }

    private void ManageSpawn() {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnDelay) {
            _spawnTimer = 0;

            Transform pos = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            GameObject prefabs = _prefabEnnemi[Random.Range(0, _prefabEnnemi.Length)];
            if (prefabs == null) {
                Debug.LogWarning(" L'ennemi sélectionné est null, vérifiez la liste des prefab.");
                return;
            }
            Instantiate(prefabs, pos.position, Quaternion.identity);
        }
    }
}