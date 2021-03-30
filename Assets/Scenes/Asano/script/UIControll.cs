using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{
    public Slider kusa_kuuhuku;
    int kusa_kuuhuku_num = 0;
    public Slider niku_kuuhuku;
    int niku_kuuhuku_num = 0;
    public Text Animal_kusa;
    int Animal_kusa_num = 0;
    public Text Animal_niku;
    int Animal_niku_num = 0;
    public Text Esa;
    int Esa_num = 0;
    const string kusa = "草食動物：";
    const string niku = "肉食動物：";
    const string esa = "エサ：";


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //値を更新する
        kusa_kuuhuku_num = 0;
        niku_kuuhuku_num = 0;
        Animal_kusa_num = 0;
        Animal_niku_num = 0;
        Esa_num = 0;
        //表示を更新する
        Animal_kusa.text = kusa + Animal_kusa_num;
        Animal_niku.text = niku + Animal_niku_num;
        Esa.text = esa + Esa_num;
        kusa_kuuhuku.value = kusa_kuuhuku_num;
        niku_kuuhuku.value = niku_kuuhuku_num;
    }
}
