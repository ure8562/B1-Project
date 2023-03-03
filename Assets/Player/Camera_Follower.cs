using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follower : MonoBehaviour
{
    public GameObject Target;             // ����ٴ� Ÿ�� ������Ʈ
    public float follow_speed = 4.0f;    // ���󰡴� �ӵ�
    public float z = -10.0f;            // ������ų ī�޶��� z���� ��

    Transform this_transform;            // ī�޶��� ��ǥ
    Transform Target_transform;         // Ÿ���� ��ǥ

    // Start is called before the first frame update
    /*
     *  Update()�Լ����� ���� this.transform�� target.transform�� ���� ���� �������� �ʰ� Start()�Լ����� GetComponent�� �̿��Ͽ� ������ ����ȭ��Ű�� �ֽ��ϴ�. 
     *  �� ������ ������ �ݷ��� �����ε���, ������ �����ϸ� �������� ����� ���̱� ���ؼ��Դϴ�.
     *  ���� ��ó�� ���� �ʰ� Update()���� �ٷ� �����ϸ� ������ ������ Transform�Ӽ��� �ҷ����� �ǰ�, �ð��� ����Ǵ� ��������.
     */
    void Start()
    {
        this_transform = GetComponent<Transform>();
        Target_transform = Target.GetComponent<Transform>();
    }

    // Update is called once per frame
    /*  Vector2.Lerp(a,b,c)�� a�� ��ǥ���� b�� ��ǥ������ ���̸� ����ϰ�, �ִ� c�� �ӵ��� �̵��� ���� ������� ��ȯ�մϴ�.
     *  �� �� �Ÿ��� ������� ���� �� ��ȯ�� ���� ���� ��ǥ���� ���̰� �������� ������ �ε巯�� �̵��� �����˴ϴ�.
     */
    void Update()
    {
        this_transform.position = Vector2.Lerp(this_transform.position, Target_transform.position, follow_speed * Time.deltaTime);
        this_transform.Translate(0, 0, z); //ī�޶� ���� z������ �̵�
    }
}
