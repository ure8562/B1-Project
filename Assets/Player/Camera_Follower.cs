using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follower : MonoBehaviour
{
    public GameObject Target;             // 따라다닐 타겟 오브젝트
    public float follow_speed = 4.0f;    // 따라가는 속도
    public float z = -10.0f;            // 고정시킬 카메라의 z축의 값

    Transform this_transform;            // 카메라의 좌표
    Transform Target_transform;         // 타겟의 좌표

    // Start is called before the first frame update
    /*
     *  Update()함수에서 굳이 this.transform과 target.transform을 통해 값에 접근하지 않고 Start()함수에서 GetComponent를 이용하여 변수에 동기화시키고 있습니다. 
     *  그 이유는 가비지 콜렉션 때문인데요, 간단히 설명하면 쓸데없는 계산을 줄이기 위해서입니다.
     *  만약 위처럼 하지 않고 Update()에서 바로 접근하면 접근할 때마다 Transform속성을 불러오게 되고, 시간이 낭비되는 것이지요.
     */
    void Start()
    {
        this_transform = GetComponent<Transform>();
        Target_transform = Target.GetComponent<Transform>();
    }

    // Update is called once per frame
    /*  Vector2.Lerp(a,b,c)는 a의 좌표에서 b의 좌표까지의 차이를 계산하고, 최대 c의 속도로 이동한 후의 결과값을 반환합니다.
     *  이 때 거리가 가까워질 수록 그 반환된 값과 원래 좌표와의 차이가 적어지기 때문에 부드러운 이동이 구현됩니다.
     */
    void Update()
    {
        this_transform.position = Vector2.Lerp(this_transform.position, Target_transform.position, follow_speed * Time.deltaTime);
        this_transform.Translate(0, 0, z); //카메라를 원래 z축으로 이동
    }
}
