using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
	[SerializeField] CameraMotion _cm;
    public void Spawn()
	{
		for (int i = 0; i < GameManager.Single.LeftBalls; i++)
		{
            var newGO = Instantiate(prefabs[Random.Range(0, prefabs.Length)], SetPosition(), Quaternion.identity);
            newGO.transform.SetParent(transform, true);
        }
	}

	private Vector3 SetPosition()
	{
		return new Vector3(Random.Range(-_cm.Borders.x + 0.5f, _cm.Borders.x - 0.5f), 
			Random.Range(-_cm.Borders.y + 0.5f, _cm.Borders.y  - 0.5f), 0);
	}
}
