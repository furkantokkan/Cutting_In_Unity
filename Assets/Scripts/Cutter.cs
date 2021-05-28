using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
   public static void Cut(Transform CuttedObject,Transform cutterTransform)
    {
        Vector3 pos = new Vector3(cutterTransform.position.x, CuttedObject.position.y, CuttedObject.position.z);
        Vector3 cuttedObjectScale = CuttedObject.localScale;

        Vector3 leftPoint = CuttedObject.position - Vector3.right * cuttedObjectScale.y;
        Vector3 rightPoint = CuttedObject.position + Vector3.right * cuttedObjectScale.y;

        Material mat = CuttedObject.GetComponent<MeshRenderer>().material;
        Destroy(CuttedObject.gameObject);
        //right
        GameObject rightSideObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rightSideObj.transform.position = (rightPoint + pos) / 2;
        float rightWidth = Vector3.Distance(pos, rightPoint);

        rightSideObj.transform.localScale = new Vector3(cuttedObjectScale.x, rightWidth / 2, cuttedObjectScale.z);
        rightSideObj.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        rightSideObj.AddComponent<Rigidbody>().mass = 100f;
        rightSideObj.GetComponent<MeshRenderer>().material = mat;
        //left
        GameObject leftSideObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        leftSideObj.transform.position = (leftPoint + pos) / 2;
        float leftWidth = Vector3.Distance(pos, leftPoint);

        leftSideObj.transform.localScale = new Vector3(cuttedObjectScale.x, leftWidth / 2, cuttedObjectScale.z);
        leftSideObj.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        leftSideObj.AddComponent<Rigidbody>().mass = 100f;
        leftSideObj.GetComponent<MeshRenderer>().material = mat;
    }
}
