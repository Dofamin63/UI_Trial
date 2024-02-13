using UnityEngine;
//--------------------------------------------------------------------
//Follows the player along the 2d plane, using a continuous lerp
//--------------------------------------------------------------------
public class CameraPlayer : MonoBehaviour
{
    private GameObject m_Target;
    [SerializeField] float m_InterpolationFactor;
    [SerializeField] float m_ZDistance = 10.0f;

    public GameObject _player;

    private bool follow = true;
    private float duration = .15f;
    private int type_shake = 0;


    private void Awake()
    {
        m_Target = GameObject.Find("Camera");
        //_player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (follow)
        {
            Interpolate(Time.fixedDeltaTime);
        }
        else if (type_shake == 1)
        {
            _Shake_faded();
        }
        else if (type_shake == 2)
        {
            _Shake_once();
        }
    }


    void Interpolate(float a_DeltaTime)
    {
        if (_player == null)
        {
            return;
        }
        Vector3 diff = _player.transform.position + Vector3.back * m_ZDistance - transform.position;
        transform.position += diff * m_InterpolationFactor * a_DeltaTime;
    }

    private void _Shake_faded()
    {
        if (duration >= 0)
        {
            float x = Random.Range(-1f, 1f) * 0.05f;
            float y = Random.Range(-1f, 1f) * 0.05f;

            transform.localPosition = new Vector3(_player.transform.position.x + x, _player.transform.position.y + y, -60f);

            duration -= Time.fixedDeltaTime;
        }
        else
        {
            duration = 0.15f;
            follow = true;
        }
    }

    private void _Shake_once()
    {
        float x = Random.Range(-1f, 1f) * 4;
        float y = Random.Range(-1f, 1f) * 4;

        transform.localPosition = new Vector3(_player.transform.position.x + x, _player.transform.position.y + y, -60f);

        follow = true;
    }

    public void Shake_once()
    {
        follow = false;
        type_shake = 2;
    }
    public void Shake_faded()
    {
        follow = false;
        type_shake = 1;
    }

}