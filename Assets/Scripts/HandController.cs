using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject[]Th;
    GameObject[]If;
    GameObject[]Mf;
    GameObject[]Rf;
    GameObject[]P;
    GameObject palm;
    public GameObject[][] Fingers;
    
    // Start is called before the first frame update
    void Start()
    {
        Th=new GameObject[3];
        If=new GameObject[3];
        Mf=new GameObject[3];
        Rf=new GameObject[3];
        P=new GameObject[3];

        


        palm=transform.GetChild(0).gameObject;

        Th[0]=transform.Find("Palm/th_s3").gameObject;
        Th[1]=transform.Find("Palm/th_s3/th_s2").gameObject;
        Th[2]=transform.Find("Palm/th_s3/th_s2/th_s1").gameObject;

        If[0]=transform.Find("Palm/if_s3").gameObject;
        If[1]=transform.Find("Palm/if_s3/if_s2").gameObject;
        If[2]=transform.Find("Palm/if_s3/if_s2/if_s1").gameObject;

        Mf[0]=transform.Find("Palm/mf_s3").gameObject;
        Mf[1]=transform.Find("Palm/mf_s3/mf_s2").gameObject;
        Mf[2]=transform.Find("Palm/mf_s3/mf_s2/mf_s1").gameObject;

        Rf[0]=transform.Find("Palm/rf_s3").gameObject;
        Rf[1]=transform.Find("Palm/rf_s3/rf_s2").gameObject;
        Rf[2]=transform.Find("Palm/rf_s3/rf_s2/rf_s1").gameObject;

        P[0]=transform.Find("Palm/pf_s3").gameObject;
        P[1]=transform.Find("Palm/pf_s3/pf_s2").gameObject;
        P[2]=transform.Find("Palm/pf_s3/pf_s2/pf_s1").gameObject;

        Fingers =new GameObject[][]{Th,If,Mf,Rf,P};
    }

    void Update(){
        if(Input.GetKey(KeyCode.T))
        parseHandValues("10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10");
    }

    [System.Obsolete]
    void parseHandValues(string Values){       

        var parsed = System.Array.ConvertAll(
        Values.Split(new[] { ',', }, System.StringSplitOptions.RemoveEmptyEntries),
        System.Double.Parse);


        Th[0].transform.Rotate((float)parsed[1]-radToDeg(Th[0].transform.rotation.x),(float)parsed[0]-radToDeg(Th[0].transform.rotation.y),0,Space.World);
        Debug.Log((float)parsed[0]+", "+(Th[0].transform.rotation.y));
        Debug.Log((float)parsed[1]+", "+Th[0].transform.rotation.x);

        
        Th[0].transform.localEulerAngles=new Vector3((float)parsed[1],(float)parsed[0],0);
        Th[1].transform.localEulerAngles=new Vector3(0,0,(float)parsed[2]);
        Th[2].transform.localEulerAngles=new Vector3(0,0,(float)parsed[3]);

        If[0].transform.localEulerAngles=new Vector3((float)parsed[5],(float)parsed[4],0);
        If[1].transform.localEulerAngles=new Vector3(0,0,(float)parsed[6]);
        If[2].transform.localEulerAngles=new Vector3(0,0,(float)parsed[7]);

        Mf[0].transform.localEulerAngles=new Vector3((float)parsed[9],(float)parsed[8],0);
        Mf[1].transform.localEulerAngles=new Vector3(0,0,(float)parsed[10]);
        Mf[2].transform.localEulerAngles=new Vector3(0,0,(float)parsed[11]);

        Rf[0].transform.localEulerAngles=new Vector3((float)parsed[13],(float)parsed[12],0);
        Rf[1].transform.localEulerAngles=new Vector3(0,0,(float)parsed[14]);
        Rf[2].transform.localEulerAngles=new Vector3(0,0,(float)parsed[15]);

        P[0].transform.localEulerAngles=new Vector3((float)parsed[17],(float)parsed[16],0);
        P[1].transform.localEulerAngles=new Vector3(0,0,(float)parsed[18]);
        P[2].transform.localEulerAngles=new Vector3(0,0,(float)parsed[19]);
    }

    float radToDeg(float rad){
        return rad*180/Mathf.PI;
    }
}
