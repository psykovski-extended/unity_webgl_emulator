using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
     bool IsMouseOverGameWindow { get { return !(0 > Input.mousePosition.x || 0 > Input.mousePosition.y || Screen.width < Input.mousePosition.x || Screen.height < Input.mousePosition.y); } }
    GameObject cam;
    public int sensitivity=1,moveSpeed,moveCap;
    private float qolMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {  
        cam=transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        qolMoveSpeed=-(cam.transform.localPosition.z+2)*10;
        if(IsMouseOverGameWindow){
            if(Input.GetMouseButton(2)||Input.GetMouseButton(0)){
                if(!Input.GetKey(KeyCode.LeftShift)){
                    transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"),0,0)*Time.deltaTime*sensitivity,Space.Self);
                    transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X"),0)*Time.deltaTime*sensitivity,Space.World);
                }
                if(Input.GetKey(KeyCode.LeftShift)){
                    transform.Translate(-new Vector3(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"),0)*Time.deltaTime*moveSpeed*qolMoveSpeed,Space.Self);
                    if(Mathf.Abs(transform.position.x)>moveCap){
                        teleport(transform,new Vector3(Mathf.Sign(transform.position.x)*moveCap,transform.position.y,transform.position.z));
                    }
                    if(Mathf.Abs(transform.position.y)>moveCap){
                        teleport(transform,new Vector3(transform.position.x,Mathf.Sign(transform.position.y)*moveCap,transform.position.z));
                    }
                    if(Mathf.Abs(transform.position.z)>moveCap){
                        teleport(transform,new Vector3(transform.position.x,transform.position.y,Mathf.Sign(transform.position.z)*moveCap));
                    }
                }
            }
            if(Input.mouseScrollDelta.y!=0){
                cam.transform.Translate(new Vector3(0,0,Input.mouseScrollDelta.y)*qolMoveSpeed*Time.deltaTime,Space.Self);
            }
        }

        if(Input.GetKeyDown(KeyCode.H)){
            transform.SetPositionAndRotation(new Vector3(0,0,0),new Quaternion(0,0,0,0));
            teleport(cam.transform,new Vector3(0,0,-10),Space.Self);
            
        }
    }

    void teleport (Transform t,Vector3 coordinates){
        t.Translate(-t.position,Space.World);
        t.Translate(coordinates,Space.World);
    }

    void teleport (Transform t,Vector3 coordinates,Space space){
        t.Translate(-t.position,space);
        t.Translate(coordinates,space);
    }

    public void setBG(string darkMode){
        if(darkMode=="true"){
            cam.GetComponent<Camera>().backgroundColor=new Color(34f/0xff,34f/0xff,34f/0xff);
        }
        else
            cam.GetComponent<Camera>().backgroundColor=new Color(0.8f,0.8f,0.8f);
    }
}


