using UnityEngine;

public class RippleEffectReceiver : MonoBehaviour
{
    Material material;          // reference to the material
    const int rippleCount = 2;  // maximum active ripple count

    // values for the shader to pass in
    Color[] rippleColor;      
    float[] rippleSpreadSpeed;
    float[] rippleRadius;
    float[] maxRippleRadius;
    bool[] isSpreading;


    void Start()
    {
        material = GetComponent<Renderer>().material;

        rippleColor = new Color[rippleCount];
        rippleSpreadSpeed = new float[rippleCount];
        rippleRadius = new float[rippleCount];
        maxRippleRadius = new float[rippleCount];
        isSpreading = new bool[rippleCount];
    }

    void Update()
    {
        // update every active ripple
        for (int i = 0; i < rippleCount; ++i)
        {
            if (isSpreading[i])
            {
                rippleRadius[i] += rippleSpreadSpeed[i] * Time.deltaTime;
                material.SetFloat("_RippleRadius" + (i + 1), rippleRadius[i]);

                // ripple finished expanding through the whole mesh
                if (rippleRadius[i] >= maxRippleRadius[i])
                {
                    isSpreading[i] = false;
                    material.SetColor("_BGColor", rippleColor[i]);

                    // set ripple radius forcefully to 0 to prevent overlapping
                    material.SetFloat("_RippleRadius" + (i + 1), 0);
                }
            }
        }
    }

    public void ApplyEffect(Vector3 contactPoint, Color rippleColor, float spreadSpeed)
    {
        // activate the ripple effect if there is a free space
        for(int i = 0; i < rippleCount; ++i)
        {
            if(!isSpreading[i])
            {
                material.SetVector("_RippleLocation" + (i + 1), contactPoint);
                material.SetColor("_RippleColor" + (i + 1), rippleColor);

                rippleRadius[i] = 0;
                maxRippleRadius[i] = GetFarthestVertex(contactPoint);
                this.rippleColor[i] = rippleColor;
                rippleSpreadSpeed[i] = spreadSpeed;
                isSpreading[i] = true;
                break;
            }
        }
    }
    
    float GetFarthestVertex(Vector3 origin)
    {
        // get every vertex from mesh (enable read/write in mesh settings!)
        Vector3[] vertices = GetComponent<MeshFilter>().sharedMesh.vertices;

        // get the local to world transformation matrix
        Matrix4x4 localToWorld = transform.localToWorldMatrix;

        // offset each vertex to world position and
        // calculate the distance between contact point and vertex position
        float[] dist = new float[vertices.Length];
        for(int i = 0; i < vertices.Length; ++i)
        {
            vertices[i] = localToWorld.MultiplyPoint3x4(vertices[i]);
            dist[i] = Mathf.Abs(Vector3.Distance(vertices[i], origin));
        }

        // sort the array and return the farthest vertex position
        System.Array.Sort(dist);
        return dist[dist.Length - 1];
    }
}
