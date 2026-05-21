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
        if (_kyakuGenerator != null)
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
}
