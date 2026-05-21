using System.Collections;
using UnityEngine;

public class SizeMatch : MonoBehaviour
{
    private bool isMatched = false;
    private ClothesSize ClothesSize;
    private Customer _customer;
    private KyakuGenerator _kyakuGenerator;
    private Score _score;
    public Vector2 targetPos;

    public GameObject EffectPrefab;
    [SerializeField] private float _leaveDelay = 5f; //退出までの遅延時間
    private void Start()
    {
        StartCoroutine(LeaveAfterDelay(_leaveDelay));  //指定された秒数後にLeaveAfterDelayコルーチンを開始
        ClothesSize = GetComponent<ClothesSize>();
        _customer = GetComponent<Customer>();
        _kyakuGenerator = FindObjectOfType<KyakuGenerator>();
        _score = FindObjectOfType<Score>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Clothes"))
        {
            if (collision.TryGetComponent<ClothesSize>(out var component) && collision.TryGetComponent<Hander>(out var hander))
            {
                if (hander.IsPointerUp == true && !isMatched)
                {
                    Destroy(collision.gameObject);
                    if (ClothesSize.CurrentSize == component.CurrentSize)
                    {
                        isMatched = true;
                        Match();
                        if (EffectPrefab != null)
                        {
                            var effect = Instantiate(EffectPrefab, transform.position, Quaternion.identity);
                            DestroyEffect(effect);
                        }
                    }
                    else
                    {
                        AudioManager.Instance.PlaySE("Miss");
                    }
                }
            }
        }
    }

    private void Match()
    {
        AudioManager.Instance.PlaySE("Match");
        if (_kyakuGenerator != null && _customer.iscorected == false)
        {
            _kyakuGenerator.NewGenerate(targetPos);
        }
        _customer.iscorected = true;
        //ŁAXRAZ鏈Ăяo
        if (_score != null)
        {
            _score.ScoreUpdate(_customer.HaveScore);
        }
    }

    private async void DestroyEffect(GameObject effect)
    {
        await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(1));
        if (effect != null)
        {
            Destroy(effect);
        }
    }
    IEnumerator LeaveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (_kyakuGenerator != null && _customer.iscorected == false)
        {
            _kyakuGenerator.NewGenerate(targetPos);
        }
        _customer.iscorected = true;
    }
}
