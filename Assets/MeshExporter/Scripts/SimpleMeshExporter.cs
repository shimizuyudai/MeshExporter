using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshExporter;
using Newtonsoft.Json;
using System.Text;
using System.IO;

public class SimpleMeshExporter : MonoBehaviour {

	[SerializeField]
	MeshFilter meshFilter;

	public void Export(string path)
	{
		SimpleMesh mesh = new SimpleMesh ();

		//Vertices
		for(var i = 0; i < meshFilter.mesh.vertices.Length; i++){
			
			mesh.Vertices.Add (new MeshInfomation.Vertex{X = meshFilter.mesh.vertices[i].x,Y = meshFilter.mesh.vertices[i].y,Z = meshFilter.mesh.vertices[i].z});
		}

		//UV
		for(var i = 0; i < meshFilter.mesh.uv.Length; i++){ 
			mesh.UV.Add (new MeshInfomation.UV{X = meshFilter.mesh.uv[i].x,Y = meshFilter.mesh.uv[i].y});
		}

		//Normals
		for(var i = 0; i < meshFilter.mesh.normals.Length; i++){
			mesh.Normals.Add (new MeshInfomation.Normal{X = meshFilter.mesh.normals[i].x, Y = meshFilter.mesh.normals[i].y, Z = meshFilter.mesh.normals[i].z});
		}

		//Indices
		for(var i = 0; i < meshFilter.mesh.GetIndices(0).Length; i++){
			mesh.Indices.Add (meshFilter.mesh.GetIndices(0)[i]);
		}

		var json = JsonConvert.SerializeObject (mesh);
		File.WriteAllText (path,json);
		//print (json);
	}
}
