using System;
using System.Media;
using System.Windows.Forms;

namespace JogoVelha1._0
{
    public partial class Form1 : Form
    {

        private SoundPlayer _soundPlayer;


        bool turn = true, jogo_fim = false; // true x ; false y
        int turn_count = 0, jogadorxpontos = 0, jogadoropontos = 0;
        string[] game = new string[9];


        public Form1()
        {
            InitializeComponent();
            _soundPlayer = new SoundPlayer("som1.wav");
            _soundPlayer.PlayLooping();
            rodadaslb.Text = turn_count.ToString();
        }

        public string jogadorAtual = "X";





        private void button2_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int buttonIndex = b.TabIndex;

            if (b.Text == "" && jogo_fim == false)
            {

                if (turn)
                {
                    b.Text = "X";
                    game[buttonIndex] = "X";
                    b.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\x.png");
                    turn_count++;
                    rodadaslb.Text = turn_count.ToString();
                    turn = !turn;
                    Check(1);
                }
                else
                {
                    b.Text = "0";
                    game[buttonIndex] = "O";
                    b.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\circulo.png");
                    turn_count++;
                    rodadaslb.Text = turn_count.ToString();
                    turn = !turn;
                    Check(2);
                }
            }


        }

        void Win(int PlayerWin)
        {
            jogo_fim = true;

            if (PlayerWin == 1)
            {
                jogadorxpontos = Convert.ToInt32(ptjogadorX.Text)+1;
                button1.Visible = true;
                playerxwin.Visible = true;
                //turn = true;
                ptjogadorX.Text = jogadorxpontos.ToString();
                            
            }
            else 
            {
                jogadoropontos = Convert.ToInt32(ptjogadorO.Text) + 1;
                button1.Visible = true;
                playerowin.Visible = true;
                //turn = false;
                ptjogadorO.Text = jogadoropontos.ToString();
            }
        }



        void Check(int checkPlayer)
        {
            string suport = "";

            if (checkPlayer == 1)
            {
                suport = "X";
            }
            else
            {
                suport = "O";
            }

            //VERIFICAÇÃO DAS HORIZONTAIS
            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suport == game[horizontal])
                {
                    if (game[horizontal] == game[horizontal + 1] && game[horizontal]== game[horizontal + 2])
                    {
                        Win(checkPlayer);
                        return;
                    }
                }//FIM VERIFICAÇÃO HORIZONTAL
            }// FIM DO LOOP HORIZONTAL

            //VERIFICAÇÃO DAS VERTICAIS
            for (int vertical = 0; vertical < 3; vertical ++)
            {
                if (suport == game[vertical])
                {
                    if (game[vertical] == game[vertical + 3] && game[vertical] == game[vertical + 6])
                    {
                        Win(checkPlayer);
                        return;
                    }
                }//FIM VERIFICAÇÃO VERTICAL
            }// FIM DO LOOP VERTICAL

            //VERIFICAÇÃO DAS DIAGONAIS
            if (game[0] == suport)
            {
                if (game[0] == game[4] && game[0] == game[8])
                {
                    Win(checkPlayer);
                    return;
                }//FIM DA VERIFICAÇÃO DIAGONAL PRINCIPAL
            }

            if (game[2] == suport)
            {
                if (game[2] == game[4] && game[2] == game[6])
                {
                    Win(checkPlayer);
                    return;
                }//FIM DA VERIFICAÇÃO DIAGONAL SECUNDARIA
            }
            if (rodadaslb.Text == "9")
            {
                MessageBox.Show("Deu velha! Vai de novo :) ");
                Limpar();
            }
        }

        void Limpar()
        { 
            btnUpLeft.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\vazio.png");
            btnUpCenter.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\vazio.png");
            btnUpRigth.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\vazio.png");
            btnCenterLeft.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\vazio.png");
            btnCenterCenter.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\vazio.png");
            btnCenterRigth.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\vazio.png");
            btnBottonLeft.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\vazio.png");
            btnBottonCenter.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\vazio.png");
            btnBottonRigth.Image = System.Drawing.Image.FromFile(@"C:\Users\William\source\repos\JogoVelha1.0\JogoVelha1.0\bin\Debug\netcoreapp3.1\vazio.png");

            btnUpLeft.Text = "";
            btnUpCenter.Text = "";
            btnUpRigth.Text = "";
            btnCenterLeft.Text = "";
            btnCenterCenter.Text = "";
            btnCenterRigth.Text = "";
            btnBottonLeft.Text = "";
            btnBottonCenter.Text = "";
            btnBottonRigth.Text = "";

            game[0] = "";
            game[1] = "";
            game[2] = "";
            game[3] = "";
            game[4] = "";
            game[5] = "";
            game[6] = "";
            game[7] = "";
            game[8] = "";

            turn_count = 0;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            playerowin.Visible = false;
            playerxwin.Visible = false;
            button1.Visible = false;
            Limpar();
            jogo_fim = false;
        }
    }
}
