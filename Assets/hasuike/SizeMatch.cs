using UnityEngine;

public class SizeMatch : MonoBehaviour
{
    private bool isMatched = false;
    private ClothesSize ClothesSize;
    private Customer _customer;
    private KyakuGenerator _kyakuGenerator;
    private Score _score;

    private void Start()
    {
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
                Debug.Log("取得");
                if (hander.IsPointerUp == true && !isMatched)
                {
                    Destroy(collision.gameObject);
                    if (ClothesSize.CurrentSize == component.CurrentSize)
                    {
                        Debug.Log("成功");
                        isMatched = true;
                        Match();
                    }
                }
            }
        }
    }

    private void Match()
    {
        if (_kyakuGenerator != null)
        {
            _kyakuGenerator.NewGenerate(this.transform.position);
        }
        _customer.iscorected = true;
        // ここで、スコアを加算する処理を呼び出す
        if (_score != null)
        {
            _score.ScoreUpdate(_customer.HaveScore);
        }
    }
}
