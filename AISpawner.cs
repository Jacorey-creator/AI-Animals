using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgentSpawner : MonoBehaviour
{

	public AIAgent[] agents;
	public LayerMask layerMask;

	int index = 0;

	void Update()
	{
		//tab to switch agent to spawn
		if (Input.GetKeyDown(KeyCode.Tab)) index = (++index % agents.Length);
		//click to spwan
		if (Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl)))
		{
			//get ray from camera to screen position
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
			{
				Instantiate(agents[index], hitInfo.point, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
			}
		}
	}
}

