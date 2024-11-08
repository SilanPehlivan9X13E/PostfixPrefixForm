namespace Ödev_6
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string PostfixDonusumu(string infix)
        {

            Stack<char> yıgın = new Stack<char>(); // Operatörleri tutmak için yazılan kod satırındaki yığın 
            string cıktı = ""; // Postfix ifadesi

            foreach (char a in infix)
            {
                if (char.IsLetterOrDigit(a)) // Harf veya rakam kontrolü
                //İfadenin harf (letter) ya da rakam(digit) olup olmadığını kontrol eder.
                {
                    cıktı += a; // Sonuna ekleme işlemi için
                }
                else if (a == '(') // Parantez açma
                {
                    yıgın.Push(a); // Yığına ekleme yaparız
                }
                else if (a == ')') // Parantez kapama
                {
                    while (yıgın.Count > 0 && yıgın.Peek() != '(')
                    {
                        cıktı += yıgın.Pop(); // Yığından eleman al
                    }
                    if (yıgın.Count > 0) // Açık parantez varsa yapıdan çıkarır.
                    {
                        yıgın.Pop(); // Parantezi çıkart
                    }
                }
                else // Operatör
                {
                    while (yıgın.Count > 0 && OncelikSırası(a) <= OncelikSırası(yıgın.Peek()))
                    {
                        cıktı += yıgın.Pop(); // Yığından eleman al
                    }
                    yıgın.Push(a); // Yığına operatör ekleme işlemi için
                }
            }
            while (yıgın.Count > 0)
            {
                cıktı += yıgın.Pop(); // Yığındaki tüm operatörleri almasını sağladım.
            }
            //MessageBox.Show("Postfix ifadeye döndürüldü"); // Postfix ifadeyi döndür dedim
            return cıktı;
        }

        private int OncelikSırası(char o) 
        {
            switch (o)// Operatör önceliğini belirtmek için switch case yapısı ile kontrol ettiğim matematiksel operatörler
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 0;
            }
        }

        private string PrefixDonustur(string infix) // Prefix ifadeye dönüştür
        {
            // Infix ifadeyi ters çevirip işlem yapıyoruz
            char[] karakterDizisi = infix.ToCharArray();
            Array.Reverse(karakterDizisi);
            string tersInfix = new string(karakterDizisi);

            // Ters çevrilmiş infix ifadedeki parantezleri değiştir.
            //Bu kkod satırı yazılmaz ise prefix ifadesi yanlış hesaplarım.
            tersInfix = tersInfix.Replace('(', 'X').Replace(')', '(').Replace('X', ')'); //Bu kısma dikkat et!!!

            string postfix = PostfixDonusumu(tersInfix); // Ters infix'i postfix'e çevir

            // Postfix ifadeyi ters çevirerek prefix ifadesini al
            char[] postfixDizisi = postfix.ToCharArray();
            Array.Reverse(postfixDizisi);
           // MessageBox.Show("Prefix dönüşümü yapıldı.");
            return new string(postfixDizisi); // Prefix ifadeyi döndür

        
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string infix = textBox1.Text;
            string postfix = PostfixDonusumu(infix);
            label2.Text = "Postfix:  " + postfix;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string infix = textBox1.Text;
            string prefix = PrefixDonustur(infix);
            label3.Text = "Prefix:  " + prefix;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
