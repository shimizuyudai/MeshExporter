using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshExporter;
using Newtonsoft.Json;
using System.Text;
using System.IO;

public class SkinnedMeshExporter : MonoBehaviour {
	[SerializeField]
	SkinnedMeshRenderer skinnedMeshRenderer;
	SkinnedMesh skinnedMesh;
	bool isRecord;
	int frameCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isRecord){
			var mesh = new Mesh ();
			skinnedMeshRenderer.BakeMesh (mesh);
			//Vertices
			List<MeshInfomation.Vertex> vertices = new List<MeshInfomation.Vertex>();
			for(var i = 0; i < mesh.vertices.Length; i++){
				vertices.Add (new MeshInfomation.Vertex{X = mesh.vertices[i].x,Y = mesh.vertices[i].y});
			}
			skinnedMesh.Animation.Add (new VertexFrameInfomation{Frame = frameCount,Vertices = vertices});
			frameCount++;
		}
	}

	public void StartRecord()
	{
		if (isRecord)
			return;
		skinnedMesh = new SkinnedMesh ();

		SimpleMesh simpleMesh = new SimpleMesh ();

		//Vertices
		for(var i = 0; i < skinnedMeshRenderer.sharedMesh.vertices.Length; i++){

			simpleMesh.Vertices.Add (new MeshInfomation.Vertex{X = skinnedMeshRenderer.sharedMesh.vertices[i].x,Y = skinnedMeshRenderer.sharedMesh.vertices[i].y,Z = skinnedMeshRenderer.sharedMesh.vertices[i].z});
		}

		//UV
		for(var i = 0; i < skinnedMeshRenderer.sharedMesh.uv.Length; i++){ 
			simpleMesh.UV.Add (new MeshInfomation.UV{X = skinnedMeshRenderer.sharedMesh.uv[i].x,Y = skinnedMeshRenderer.sharedMesh.uv[i].y});
		}

		//Normals
		for(var i = 0; i < skinnedMeshRenderer.sharedMesh.normals.Length; i++){
			simpleMesh.Normals.Add (new MeshInfomation.Normal{X = skinnedMeshRenderer.sharedMesh.normals[i].x, Y = skinnedMeshRenderer.sharedMesh.normals[i].y, Z = skinnedMeshRenderer.sharedMesh.normals[i].z});
		}

		//Indices
		for(var i = 0; i < skinnedMeshRenderer.sharedMesh.GetIndices(0).Length; i++){
			simpleMesh.Indices.Add (skinnedMeshRenderer.sharedMesh.GetIndices(0)[i]);
		}

		skinnedMesh.Mesh = simpleMesh;
		frameCount = 0;
		isRecord = true;
	}

	public void StopRecord(){
		if (!isRecord)
			return;
		isRecord = false;
	}

	public void Export(string path)
	{
		var json = JsonConvert.SerializeObject (skinnedMesh);
		File.WriteAllText (path,json);
		//print (json);
	}
}
