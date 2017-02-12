using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshExporter
{
	public class SimpleMesh
	{
		public SimpleMesh ()
		{
			this.Vertices = new List<MeshInfomation.Vertex> ();
			this.UV = new List<MeshInfomation.UV> ();
			this.Indices = new List<int> ();
			this.Normals = new List<MeshInfomation.Normal> ();
		}

		public List<MeshInfomation.Vertex> Vertices{ get; set; }

		public List<int> Indices{ get; set; }

		public List<MeshInfomation.UV> UV{ get; set; }

		public List<MeshInfomation.Normal> Normals{ get; set; }
	}
}
