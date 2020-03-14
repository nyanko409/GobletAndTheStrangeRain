using UnityEngine;

public class RippleEffectReceiver : MonoBehaviour
{
    Material material;

    Color rippleColor;
    float rippleSpreadSpeed;
    float rippleRadius = 0;
    float maxRippleRadius;
    bool isSpreading = false;


    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (isSpreading)
        {
            rippleRadius += rippleSpreadSpeed * Time.deltaTime;
            material.SetFloat("_RippleRadius", rippleRadius);

            if(rippleRadius >= maxRippleRadius)
            {
                isSpreading = false;
                material.SetColor("_BGColor", rippleColor);
            }
        }
    }

    public void ApplyEffect(Vector3 contactPoint, Color rippleColor, float spreadSpeed)
    {
        if (!isSpreading && !(rippleColor == this.rippleColor))
        {
            material.SetVector("_RippleLocation", contactPoint);
            material.SetColor("_RippleColor", rippleColor);

            rippleRadius = 0;
            maxRippleRadius = GetFarthestVertex(contactPoint);
            this.rippleColor = rippleColor;
            rippleSpreadSpeed = spreadSpeed;
            isSpreading = true;
        }
    }

    float GetFarthestVertex(Vector3 origin)
    {
        // get every vertex from mesh
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
