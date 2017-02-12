using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshExporter
{
	public class SkinnedMesh
	{
		public SimpleMesh Mesh{ get; set; }
		public List<VertexFrameInfomation> Animation{ get; set; }
		public SkinnedMesh ()
		{
			Mesh = new SimpleMesh ();
			Animation = new List<VertexFrameInfomation> ();
		}
	}

	public class VertexFrameInfomation
	{
		public int Frame{ get; set; }
		public List<MeshInfomation.Vertex> Vertices{ get; set; }
	}
}
