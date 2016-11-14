using UnityEngine;
using System.Collections;

public class RaioXProfessor : MonoBehaviour {
	// Baseado em: http://docs.unity3d.com/ScriptReference/RaycastHit-triangleIndex.html
	// https://docs.unity3d.com/ScriptReference/Mesh.html

	public GameObject peleMesh;
	private Camera camera;

	void Start() {
		camera = GetComponent<Camera>();
	}
		
	void Update() {
		RaycastHit hit;
		if (!Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
			return;

		MeshCollider meshCollider = hit.collider as MeshCollider;
		if (meshCollider == null || meshCollider.sharedMesh == null)
			return;
		if (meshCollider.gameObject.name == peleMesh.name) {
			Mesh mesh = meshCollider.sharedMesh;
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = mesh.normals;
			int[] triangles = mesh.triangles;

			int i;
			for (i = 0; i < 3; i++) {
				// Mando o vértice para longe
				int j = triangles [hit.triangleIndex * 3 + i];
				vertices [j] += normals[j];
			}
			mesh.vertices = vertices;
		}
	}
}