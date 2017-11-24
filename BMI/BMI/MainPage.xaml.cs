using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BMI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            _md = new Model();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //データバインディングオブジェクトと関連付け
            modelBindingSource.DataSource = _md;
        }

        //計算実行ボタンクリックハンドラ
        private void button1_Click(object sender, EventArgs e)
        {
            _md.Calc();
        }
        class Model : INotifyPropertyChanged
        {
            private float nWeight;//体重
            private float nHeight;//身長
            private float nBMI;   //BMI

            //体重プロパティ
            public float propWeight
            {
                get { return nWeight; }
                set { nWeight = value; }
            }

            //身長プロパティ
            public float propHeight
            {
                get { return nHeight; }
                set { nHeight = value; }
            }

            //BMIプロパティ
            public float propBMI
            {
                get { return nBMI; }
                set { nBMI = value; }
            }

            //コンストラクタ
            public Model()
            {
                //とりあえず初期化
                propWeight = 0;
                propHeight = 0;
                propBMI = 0;
            }


            //イベントを宣言
            #region INotifyPropertyChanged メンバ

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion

            //イベントの実装
            public void NotifyPropertyChanged(string info)
            {
                if (PropertyChanged != null)
                {
                    //デリゲートを介してイベントを発生させる
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }

            public void Calc()
            {

                propBMI = propWeight / (propHeight / 100 * propHeight / 100);

                //イベントを起こしてプロパティを書き換える
                NotifyPropertyChanged("propWeight");
                NotifyPropertyChanged("propHeight");
                NotifyPropertyChanged("propBMI");
            }


        }
    }
}
