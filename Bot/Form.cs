using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();

            I = (I.Opening() as Me);

            lbWordsCount.Text = I.Dictionary.Count.ToString();
            lbPhrasesCount.Text = I.AllReactions.Count.ToString();
        }

        Interlocutor Itr = new Interlocutor();
        Me I = new Me();



        /// <summary>
        /// Нажата кнопка Отправить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string ItrMessage = rtbInput.Text.Trim();
            ItrMessage = ItrMessage.Replace("  ", " ");

            rtbInput.Text = null;

            if (ItrMessage != "")
            {
                rtbDialog.Text += Itr.Name + ":\n" + ItrMessage + "\n\n";

                rtbInput.Update();
                rtbDialog.Update();

                object Reaction = I.GetReactionOn(ItrMessage);

                if (Reaction is string)
                {
                    rtbDialog.Text += I.Name + ":\n" + (Reaction as string) + "\n\n";
                }

                rtbDialog.SelectionStart = rtbDialog.Text.Length;
                rtbDialog.ScrollToCaret();

                lbWordsCount.Text = I.Dictionary.Count.ToString();
                lbPhrasesCount.Text = I.AllReactions.Count.ToString();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        void Prediction()
        {
            string previousText = rtbInput.Text.Substring(0, rtbInput.Text.Length - 1);
            previousText = previousText.Trim();

            string lastWord = "";

            int i = previousText.Length - 1;
            while (--i > -1)
            {
                if (previousText.Substring(i, 1) == " ")
                {
                    lastWord = previousText.Substring(i, previousText.Length - i);
                }
            }
            if (i == -1)
            {
                lastWord = previousText;

            }

            char[] rej = { ',', '-', ' ' };
            lastWord = lastWord.Trim(rej);
            lastWord = lastWord.ToLower();

            List<string> Predicted = I.Prediction(lastWord, null);

            if (Predicted.Count > 0)
            {
                predict1.Text = Predicted.ElementAt(0);

                if (Predicted.Count > 1)
                {
                    predict2.Text = Predicted.ElementAt(1);

                    if (Predicted.Count > 2)
                    {
                        predict3.Text = Predicted.ElementAt(2);
                    }
                    else
                    {
                        predict3.Text = "";
                    }
                }
                else
                {
                    predict2.Text = "";
                    predict3.Text = "";
                }
            }
            else
            {
                predict1.Text = "";
                predict2.Text = "";
                predict3.Text = "";
            }
        }



        private void rtbInput_TextChanged(object sender, EventArgs e)
        {
            if (chbPrediction.Enabled == true) //если включён режим предсказания
            {
                string Text = rtbInput.Text;

                if (Text.Length >= 2 && Text.Substring(Text.Length - 1, 1) == " ")//если последним был введён пробел
                {
                    Prediction();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if(predict1.Text != "" && predict1.Text != "...")
                {
                    rtbInput.AppendText(predict1.Text);
                    rtbInput.Refresh();
                    Prediction();
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                if (predict2.Text != "" && predict2.Text != "...")
                {
                    rtbInput.AppendText(predict2.Text);
                    rtbInput.Refresh();
                    Prediction();
                }
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (predict3.Text != "" && predict3.Text != "...")
                {
                    rtbInput.AppendText(predict3.Text);Prediction();
                    rtbInput.Refresh();
                    Prediction();
                }
            }
        }
    }
}
