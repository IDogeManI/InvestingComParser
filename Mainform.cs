using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TESTERforWNDFORMS
{

    public partial class Mainform : Form
    {

        public Mainform ()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void StartButton_Click (object sender , EventArgs e)
        {
            TelegramBot.link = Log.Text;
            TelegramBot.pairID = aPairID.Text;
            TelegramBot.InisaliaseBot();
            SetBeforeCourseAsNow();
            if(!Timer.Enabled)
            {
                Timer.Start();
            }
            Refill();
        }

        [Obsolete]
        private void StopButton_Click (object sender , EventArgs e)
        {
            if(Timer.Enabled)
            {
                Timer.Stop();
            }
            ItsTimeToStop.TimeToStop = 0;
            StartButton.Enabled = true;
            TelegramBot.StopReciving();
        }
        private void Timer_Tick (object sender , EventArgs e)
        {
                try
                {
                    if(ItsTimeToStop.TimeToStop % 600 == 0)
                    {
                            Refill();
                            ItsTimeToStop.TimeToStop = 0;
                    }
                    if(ItsTimeToStop.TimeToStop % 5 == 0)
                    {
                            NowCourseSetter();
                            if(ItsTimeToStop.ThisNowCourse >= ItsTimeToStop.BeforeCourse + ItsTimeToStop.BeforeCourse / 100 * 1)
                            {
                                TelegramBot.SendPlusPersent();
                                SetBeforeCourseAsNow();
                            }
                            if(ItsTimeToStop.ThisNowCourse <= ItsTimeToStop.BeforeCourse - ItsTimeToStop.BeforeCourse / 100 * 1)
                            {
                                TelegramBot.SendMinusPersent();
                                SetBeforeCourseAsNow();
                            }
                    }
                    ItsTimeToStop.TimeToStop += 1;
                }
                catch
                {
                }
        }
        #region String To Fill GroupBox
        private async void StringToFillGroupBox
            (string Sum , Label ToSum ,
             string Avg , Label ToAvg ,
             string AvgBuy , Label ToAvgBuy ,
             string AvgSell , Label ToAvgSell ,
             string Tech , Label ToTech ,
             string TechBuy , Label ToTechBuy ,
             string TechSell , Label ToTechSell)
        {
            await Task.Run(() =>
            {
                try
                {
                    ToSum.Text = Sum;
                    ToAvg.Text = Avg;
                    ToAvgBuy.Text = AvgBuy;
                    ToAvgSell.Text = AvgSell;
                    ToTech.Text = Tech;
                    ToTechBuy.Text = TechBuy;
                    ToTechSell.Text = TechSell;
                }
                catch
                {
                }
            });
        }
        #endregion
        private void FillingGropBoxes ()
        {
            string link = Log.Text;
            string pairID = aPairID.Text;
            try
            {
                string[] Per = { Period.FiveMin , Period.FefteenMin , Period.FirtyMin , Period.OneHour , Period.FiveHours , Period.OneDay , Period.OneWeek , Period.OneMonth };
                Label[] Sum = { Resume5min , Resume15min , Resume30min , Resume1h , Resume5h , Resume1d , Resume1ned , Resume1m };
                Label[] Avg = { Avg5min , Avg15min , Avg30min , Avg1h , Avg5h , Avg1d , Avg1ned , Avg1m };
                Label[] AvgBuy = { AvgBuy5min , AvgBuy15min , AvgBuy30min , AvgBuy1h , AvgBuy5h , AvgBuy1d , AvgBuy1ned , AvgBuy1m };
                Label[] AvgSell = { AvgSell5min , AvgSell15min , AvgSell30min , AvgSell1h , AvgSell5h , AvgSell1d , AvgSell1ned , AvgSell1m };
                Label[] Tech = { Tech5min , Tech15min , Tech30min , Tech1h , Tech5h , Tech1d , Tech1ned , Tech1m };
                Label[] TechBuy = { TechBuy5min , TechBuy15min , TechBuy30min , TechBuy1h , TechBuy5h , TechBuy1d , TechBuy1ned , TechBuy1m };
                Label[] TechSell = { TechSell5min , TechSell15min , TechSell30min , TechSell1h , TechSell5h , TechSell1d , TechSell1ned , TechSell1m };

                for(int x = 0; x < 8; x++) 
                {
                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Per[x] , pairID) , out string[] parsing , out string sum);
                    if(parsing != null && sum != null)
                        StringToFillGroupBox(sum , Sum[x] , parsing[1] , Avg[x] , parsing[2] , AvgBuy[x] , parsing[3] , AvgSell[x] , parsing[5] , Tech[x] , parsing[6] , TechBuy[x] , parsing[7] , TechSell[x]);
                }
            }
            catch
            {

            }
        }
        # region StringToFillPivot
        private async void StringToFillPivot
            (string S3 , Label ToS3 ,
             string S2 , Label ToS2 ,
             string S1 , Label ToS1 ,
             string Piv , Label ToPiv ,
             string R1 , Label ToR1 ,
             string R2 , Label ToR2 ,
             string R3 , Label ToR3)
        {
            await Task.Run(() =>
            {
                try
                {
                    ToS3.Text = S3;
                    ToS2.Text = S2;
                    ToS1.Text = S1;
                    ToR1.Text = R1;
                    ToR2.Text = R2;
                    ToR3.Text = R3;
                    ToPiv.Text = Piv;
                }
                catch
                {
                }
            });
        }
        #endregion
        private void FillingPivot ()
        {
            string link = Log.Text;
            string pairID = aPairID.Text;
            try
            {
                string[] Per = { Period.FiveMin , Period.FefteenMin , Period.FirtyMin , Period.OneHour , Period.FiveHours , Period.OneDay , Period.OneWeek , Period.OneMonth };
                Label[] S3 = { S35minClassic , S315minClassic , S330minClassic , S31hClassic , S35hClassic , S31dClassic , S31nedClassic , S31mClassic };
                Label[] S2 = { S25minClassic , S215minClassic , S230minClassic , S21hClassic , S25hClassic , S21dClassic , S21nedClassic , S21mClassic };
                Label[] S1 = { S15minClassic , S115minClassic , S130minClassic , S11hClassic , S15hClassic , S11dClassic , S11nedClassic , S11mClassic };
                Label[] P = { P5minClassic , P15minClassic , P30minClassic , P1hClassic , P5hClassic , P1dClassic , P1nedClassic , P1mClassic };
                Label[] R1 = { R15minClassic , R115minClassic , R130minClassic , R11hClassic , R15hClassic , R11dClassic , R11nedClassic , R11mClassic };
                Label[] R2 = { R25minClassic , R215minClassic , R230minClassic , R21hClassic , R25hClassic , R21dClassic , R21nedClassic , R21mClassic };
                Label[] R3 = { R35minClassic , R315minClassic , R330minClassic , R31hClassic , R35hClassic , R31dClassic , R31nedClassic , R31mClassic };
                Enumerable.Range(0 , 8).AsParallel().ForAll(x =>
                {
                    List<string> ClassicPivot = TechnicalSiteParser.ParsPivot(TechnicalSiteParser.GetPage(link , Per[x] , pairID));
                    if(ClassicPivot != null)
                        StringToFillPivot(ClassicPivot[0] , S3[x] , ClassicPivot[1] , S2[x] , ClassicPivot[2] , S1[x] , ClassicPivot[3] , P[x] , ClassicPivot[4] , R1[x] , ClassicPivot[5] , R2[x] , ClassicPivot[6] , R3[x]);
                });
            }
            catch
            {

            }
        }
        private void Graphici ()
        {
            string link = Log.Text;
            string PairID = aPairID.Text;

            try
            {
                string[] Per = { Period.FiveMin , Period.FefteenMin , Period.FirtyMin , Period.OneHour , Period.FiveHours , Period.OneDay , Period.OneWeek , Period.OneMonth };
                PictureBox[] pictureBoxes = { PictureBox5min , PictureBox15min , PictureBox30min , PictureBox1h , PictureBox5h , PictureBox1d , PictureBox1ned , PictureBox1m };
                Enumerable.Range(0 , 8).AsParallel().ForAll(x =>
                {
                    ChartSiteParser.ParsTover(ChartSiteParser.GetPage(link , Per[x] , PairID) , Per[x].Length , PairID.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                    if(ThisNowCourse != null && CandlesAvg != null)
                    {
                        Bitmap AvgLine = new Bitmap(pictureBoxes[x].Width , pictureBoxes[x].Height);
                        Graphics NeposredstvennoLine = Graphics.FromImage(AvgLine);
                        Pen pen = new Pen(Color.Black);
                        for(int i = 0; i < CandlesAvg.Count - 1; i++)
                        {
                            PointF First = new PointF(float.Parse((i * 5).ToString()) , float.Parse(((CandlesAvg[i] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                            PointF Second = new PointF(float.Parse(((i + 1) * 5).ToString()) , float.Parse(((CandlesAvg[i + 1] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                            NeposredstvennoLine.DrawLine(pen , First , Second);
                        }
                        pictureBoxes[x].Image = AvgLine;
                    }
                });
            }
            catch
            {
            }
        }
        private async void Refill ()
        {
            await Task.Run(() =>
            {
                try
                {
                    StartButton.Enabled = false;
                    Log.Enabled = false;
                    aPairID.Enabled = false;

                    FillingGropBoxes();
                    Graphici();
                    FillingPivot();
                }
                catch
                {
                }
            });
        }
        private async void NowCourseSetter ()
        {
            try
            {
                await Task.Run(() =>
                {
                    ChartSiteParser.ParsTover(ChartSiteParser.GetPage(Log.Text , Period.FiveMin , aPairID.Text) , Period.FiveMin.Length , aPairID.Text.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                    if(ThisNowCourse != null)
                    {
                        NowCourse.Text = ThisNowCourse;
                        ItsTimeToStop.ThisNowCourse = double.Parse(ThisNowCourse , System.Globalization.CultureInfo.InvariantCulture);
                    }
                });
            }
            catch
            {
            }
        }

        private void SetBeforeCourseAsNow ()
        {
            try
            {
                ChartSiteParser.ParsTover(ChartSiteParser.GetPage(Log.Text , Period.FiveMin , aPairID.Text) , Period.FiveMin.Length , aPairID.Text.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                if(ThisNowCourse != null)
                {
                    ItsTimeToStop.BeforeCourse = double.Parse(ThisNowCourse , System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            catch
            {
            }
        }

        
    }
}
