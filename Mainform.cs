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

        private void StartButton_Click (object sender , EventArgs e)
        {
            if(!Timer.Enabled)
            {
                Timer.Start();
            }
            Refill();
        }
        private async void Refill ()
        {
            await Task.Run(() =>
            {
                StartButton.Enabled = false;
                Log.Enabled = false;
                aPairID.Enabled = false;

                Graphici();
                FillingGropBoxes();
                FillingPivot();
            });
        }

        #region String To Fill GroupBox
        private void StringToFillGroupBox
            (string Sum , Label ToSum ,
             string Avg , Label ToAvg ,
             string AvgBuy , Label ToAvgBuy ,
             string AvgSell , Label ToAvgSell ,
             string Tech , Label ToTech ,
             string TechBuy , Label ToTechBuy ,
             string TechSell , Label ToTechSell)
        {
                    ToSum.Text = Sum;
                    ToAvg.Text = Avg;
                    ToAvgBuy.Text = AvgBuy;
                    ToAvgSell.Text = AvgSell;
                    ToTech.Text = Tech;
                    ToTechBuy.Text = TechBuy;
                    ToTechSell.Text = TechSell;
        }
        #endregion
        private void FillingGropBoxes ()
        {
                string link = Log.Text;
                string pairID = aPairID.Text;
                try
                {
                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.FiveMin , pairID) , out string[] parsing , out string sum);
                    if(parsing != null && sum != null)
                        StringToFillGroupBox(sum , Resume5min , parsing[1] , Avg5min , parsing[2] , AvgBuy5min , parsing[3] , AvgSell5min , parsing[5] , Tech5min , parsing[6] , TechBuy5min , parsing[7] , TechSell5min);

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.FefteenMin , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        StringToFillGroupBox(sum , Resume15min , parsing[1] , Avg15min , parsing[2] , AvgBuy15min , parsing[3] , AvgSell15min , parsing[5] , Tech15min , parsing[6] , TechBuy15min , parsing[7] , TechSell15min);

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.FirtyMin , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        StringToFillGroupBox(sum , Resume30min , parsing[1] , Avg30min , parsing[2] , AvgBuy30min , parsing[3] , AvgSell30min , parsing[5] , Tech30min , parsing[6] , TechBuy30min , parsing[7] , TechSell30min);

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.OneHour , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        StringToFillGroupBox(sum , Resume1h , parsing[1] , Avg1h , parsing[2] , AvgBuy1h , parsing[3] , AvgSell1h , parsing[5] , Tech1h , parsing[6] , TechBuy1h , parsing[7] , TechSell1h);

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.FiveHours , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        StringToFillGroupBox(sum , Resume5h , parsing[1] , Avg5h , parsing[2] , AvgBuy5h , parsing[3] , AvgSell5h , parsing[5] , Tech5h , parsing[6] , TechBuy5h , parsing[7] , TechSell5h);


                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.OneDay , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        StringToFillGroupBox(sum , Resume1d , parsing[1] , Avg1d , parsing[2] , AvgBuy1d , parsing[3] , AvgSell1d , parsing[5] , Tech1d , parsing[6] , TechBuy1d , parsing[7] , TechSell1d);

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.OneWeek , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        StringToFillGroupBox(sum , Resume1ned , parsing[1] , Avg1ned , parsing[2] , AvgBuy1ned , parsing[3] , AvgSell1ned , parsing[5] , Tech1ned , parsing[6] , TechBuy1ned , parsing[7] , TechSell1ned);

                    TechnicalSiteParser.ParsTover(TechnicalSiteParser.GetPage(link , Period.OneMonth , pairID) , out parsing , out sum);
                    if(parsing != null && sum != null)
                        StringToFillGroupBox(sum , Resume1m , parsing[1] , Avg1m , parsing[2] , AvgBuy1m , parsing[3] , AvgSell1m , parsing[5] , Tech1m , parsing[6] , TechBuy1m , parsing[7] , TechSell1m);

                }
                catch
                {

                }
        }

        # region StringToFillPivot
        private void StringToFillPivot
            (string S3 , Label ToS3 ,
             string S2 , Label ToS2 ,
             string S1 , Label ToS1 ,
             string Piv , Label ToPiv ,
             string R1 , Label ToR1 ,
             string R2 , Label ToR2 ,
             string R3 , Label ToR3)
        {
            ToS3.Text = S3;
            ToS2.Text = S2;
            ToS1.Text = S1;
            ToR1.Text = R1;
            ToR2.Text = R2;
            ToR3.Text = R3;
            ToPiv.Text = Piv;
        }
        #endregion
        private void FillingPivot ()
        {
                string link = Log.Text;
                string pairID = aPairID.Text;
                try
                {
                    List<string> ClassicPivot = TechnicalSiteParser.ParsPivot(TechnicalSiteParser.GetPage(link , Period.FiveMin , pairID));
                    if(ClassicPivot != null)
                        StringToFillPivot(ClassicPivot[0] , S35minClassic , ClassicPivot[1] , S25minClassic , ClassicPivot[2] , S15minClassic , ClassicPivot[3] , P5minClassic , ClassicPivot[4] , R15minClassic , ClassicPivot[5] , R25minClassic , ClassicPivot[6] , R35minClassic);

                    ClassicPivot = TechnicalSiteParser.ParsPivot(TechnicalSiteParser.GetPage(link , Period.FefteenMin , pairID));
                    if(ClassicPivot != null)
                        StringToFillPivot(ClassicPivot[0] , S315minClassic , ClassicPivot[1] , S215minClassic , ClassicPivot[2] , S115minClassic , ClassicPivot[3] , P15minClassic , ClassicPivot[4] , R115minClassic , ClassicPivot[5] , R215minClassic , ClassicPivot[6] , R315minClassic);

                    ClassicPivot = TechnicalSiteParser.ParsPivot(TechnicalSiteParser.GetPage(link , Period.FirtyMin , pairID));
                    if(ClassicPivot != null)
                        StringToFillPivot(ClassicPivot[0] , S330minClassic , ClassicPivot[1] , S230minClassic , ClassicPivot[2] , S130minClassic , ClassicPivot[3] , P30minClassic , ClassicPivot[4] , R130minClassic , ClassicPivot[5] , R230minClassic , ClassicPivot[6] , R330minClassic);

                    ClassicPivot = TechnicalSiteParser.ParsPivot(TechnicalSiteParser.GetPage(link , Period.OneHour , pairID));
                    if(ClassicPivot != null)
                        StringToFillPivot(ClassicPivot[0] , S31hClassic , ClassicPivot[1] , S21hClassic , ClassicPivot[2] , S11hClassic , ClassicPivot[3] , P1hClassic , ClassicPivot[4] , R11hClassic , ClassicPivot[5] , R21hClassic , ClassicPivot[6] , R31hClassic);

                    ClassicPivot = TechnicalSiteParser.ParsPivot(TechnicalSiteParser.GetPage(link , Period.FiveHours , pairID));
                    if(ClassicPivot != null)
                        StringToFillPivot(ClassicPivot[0] , S35hClassic , ClassicPivot[1] , S25hClassic , ClassicPivot[2] , S15hClassic , ClassicPivot[3] , P5hClassic , ClassicPivot[4] , R15hClassic , ClassicPivot[5] , R25hClassic , ClassicPivot[6] , R35hClassic);

                    ClassicPivot = TechnicalSiteParser.ParsPivot(TechnicalSiteParser.GetPage(link , Period.OneDay , pairID));
                    if(ClassicPivot != null)
                        StringToFillPivot(ClassicPivot[0] , S31dClassic , ClassicPivot[1] , S21dClassic , ClassicPivot[2] , S11dClassic , ClassicPivot[3] , P1dClassic , ClassicPivot[4] , R11dClassic , ClassicPivot[5] , R21dClassic , ClassicPivot[6] , R31dClassic);

                    ClassicPivot = TechnicalSiteParser.ParsPivot(TechnicalSiteParser.GetPage(link , Period.OneWeek , pairID));
                    if(ClassicPivot != null)
                        StringToFillPivot(ClassicPivot[0] , S31nedClassic , ClassicPivot[1] , S21nedClassic , ClassicPivot[2] , S11nedClassic , ClassicPivot[3] , P1nedClassic , ClassicPivot[4] , R11nedClassic , ClassicPivot[5] , R21nedClassic , ClassicPivot[6] , R31nedClassic);

                    ClassicPivot = TechnicalSiteParser.ParsPivot(TechnicalSiteParser.GetPage(link , Period.OneMonth , pairID));
                    if(ClassicPivot != null)
                        StringToFillPivot(ClassicPivot[0] , S31mClassic , ClassicPivot[1] , S21mClassic , ClassicPivot[2] , S11mClassic , ClassicPivot[3] , P1mClassic , ClassicPivot[4] , R11mClassic , ClassicPivot[5] , R21mClassic , ClassicPivot[6] , R31mClassic);
                }
                catch
                {

                }
        }

        private void StopButton_Click (object sender , EventArgs e)
        {
            if(Timer.Enabled)
            {
                Timer.Stop();
            }
            ItsTimeToStop.TimeToStop = 0;
            StartButton.Enabled = true;
        }

        private void Graphici ()
        {
                try
                {
                    string link = Log.Text;
                    string PairID = aPairID.Text;
                    Parallel.Invoke(
                    () =>
                    {
                        ChartSiteParser.ParsTover(ChartSiteParser.GetPage(link , Period.FiveMin , PairID) , Period.FiveMin.Length , PairID.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                        if(ThisNowCourse != null && CandlesAvg != null)
                        {
                            Bitmap AvgLine = new Bitmap(PictureBox5min.Width , PictureBox5min.Height);
                            Graphics NeposredstvennoLine = Graphics.FromImage(AvgLine);
                            Pen pen = new Pen(Color.Black);
                            for(int i = 0; i < CandlesAvg.Count - 1; i++)
                            {
                                PointF First = new PointF(float.Parse((i * 5).ToString()) , float.Parse(((CandlesAvg[i] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                PointF Second = new PointF(float.Parse(((i + 1) * 5).ToString()) , float.Parse(((CandlesAvg[i + 1] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                NeposredstvennoLine.DrawLine(pen , First , Second);
                            }
                            PictureBox5min.Image = AvgLine;
                        }
                    } ,
                    () =>
                    {
                        ChartSiteParser.ParsTover(ChartSiteParser.GetPage(link , Period.FefteenMin , PairID) , Period.FefteenMin.Length , PairID.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                        if(ThisNowCourse != null && CandlesAvg != null)
                        {
                            Bitmap AvgLine = new Bitmap(PictureBox15min.Width , PictureBox15min.Height);
                            Graphics NeposredstvennoLine = Graphics.FromImage(AvgLine);
                            Pen pen = new Pen(Color.Black);
                            for(int i = 0; i < CandlesAvg.Count - 1; i++)
                            {
                                PointF First = new PointF(float.Parse((i * 5).ToString()) , float.Parse(((CandlesAvg[i] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                PointF Second = new PointF(float.Parse(((i + 1) * 5).ToString()) , float.Parse(((CandlesAvg[i + 1] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                NeposredstvennoLine.DrawLine(pen , First , Second);
                            }
                            PictureBox15min.Image = AvgLine;
                        }
                    } ,
                    () =>
                    {
                        ChartSiteParser.ParsTover(ChartSiteParser.GetPage(link , Period.FirtyMin , PairID) , Period.FirtyMin.Length , PairID.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                        if(ThisNowCourse != null && CandlesAvg != null)
                        {
                            Bitmap AvgLine = new Bitmap(PictureBox30min.Width , PictureBox30min.Height);
                            Graphics NeposredstvennoLine = Graphics.FromImage(AvgLine);
                            Pen pen = new Pen(Color.Black);
                            for(int i = 0; i < CandlesAvg.Count - 1; i++)
                            {
                                PointF First = new PointF(float.Parse((i * 5).ToString()) , float.Parse(((CandlesAvg[i] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                PointF Second = new PointF(float.Parse(((i + 1) * 5).ToString()) , float.Parse(((CandlesAvg[i + 1] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                NeposredstvennoLine.DrawLine(pen , First , Second);
                            }
                            PictureBox30min.Image = AvgLine;
                        }
                    } ,
                    () =>
                    {
                        ChartSiteParser.ParsTover(ChartSiteParser.GetPage(link , Period.OneHour , PairID) , Period.OneHour.Length , PairID.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                        if(ThisNowCourse != null && CandlesAvg != null)
                        {
                            Bitmap AvgLine = new Bitmap(PictureBox1h.Width , PictureBox1h.Height);
                            Graphics NeposredstvennoLine = Graphics.FromImage(AvgLine);
                            Pen pen = new Pen(Color.Black);
                            for(int i = 0; i < CandlesAvg.Count - 1; i++)
                            {
                                PointF First = new PointF(float.Parse((i * 5).ToString()) , float.Parse(((CandlesAvg[i] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                PointF Second = new PointF(float.Parse(((i + 1) * 5).ToString()) , float.Parse(((CandlesAvg[i + 1] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                NeposredstvennoLine.DrawLine(pen , First , Second);
                            }
                            PictureBox1h.Image = AvgLine;
                        }
                    } ,
                    () =>
                    {
                        ChartSiteParser.ParsTover(ChartSiteParser.GetPage(link , Period.FiveHours , PairID) , Period.FiveHours.Length , PairID.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                        if(ThisNowCourse != null && CandlesAvg != null)
                        {
                            Bitmap AvgLine = new Bitmap(PictureBox5h.Width , PictureBox5h.Height);
                            Graphics NeposredstvennoLine = Graphics.FromImage(AvgLine);
                            Pen pen = new Pen(Color.Black);
                            for(int i = 0; i < CandlesAvg.Count - 1; i++)
                            {
                                PointF First = new PointF(float.Parse((i * 5).ToString()) , float.Parse(((CandlesAvg[i] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                PointF Second = new PointF(float.Parse(((i + 1) * 5).ToString()) , float.Parse(((CandlesAvg[i + 1] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                NeposredstvennoLine.DrawLine(pen , First , Second);
                            }
                            PictureBox5h.Image = AvgLine;
                        }
                    } ,
                    () =>
                    {
                        ChartSiteParser.ParsTover(ChartSiteParser.GetPage(link , Period.OneDay , PairID) , Period.OneDay.Length , PairID.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                        if(ThisNowCourse != null && CandlesAvg != null)
                        {
                            Bitmap AvgLine = new Bitmap(PictureBox1d.Width , PictureBox1d.Height);
                            Graphics NeposredstvennoLine = Graphics.FromImage(AvgLine);
                            Pen pen = new Pen(Color.Black);
                            for(int i = 0; i < CandlesAvg.Count - 1; i++)
                            {
                                PointF First = new PointF(float.Parse((i * 5).ToString()) , float.Parse(((CandlesAvg[i] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                PointF Second = new PointF(float.Parse(((i + 1) * 5).ToString()) , float.Parse(((CandlesAvg[i + 1] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                NeposredstvennoLine.DrawLine(pen , First , Second);
                            }
                            PictureBox1d.Image = AvgLine;
                        }
                    } ,
                    () =>
                    {
                        ChartSiteParser.ParsTover(ChartSiteParser.GetPage(link , Period.OneWeek , PairID) , Period.OneWeek.Length , PairID.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                        if(ThisNowCourse != null && CandlesAvg != null)
                        {
                            Bitmap AvgLine = new Bitmap(PictureBox1ned.Width , PictureBox1ned.Height);
                            Graphics NeposredstvennoLine = Graphics.FromImage(AvgLine);
                            Pen pen = new Pen(Color.Black);
                            for(int i = 0; i < CandlesAvg.Count - 1; i++)
                            {
                                PointF First = new PointF(float.Parse((i * 5).ToString()) , float.Parse(((CandlesAvg[i] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                PointF Second = new PointF(float.Parse(((i + 1) * 5).ToString()) , float.Parse(((CandlesAvg[i + 1] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                NeposredstvennoLine.DrawLine(pen , First , Second);
                            }
                            PictureBox1ned.Image = AvgLine;
                        }
                    } ,
                    () =>
                    {
                        ChartSiteParser.ParsTover(ChartSiteParser.GetPage(link , Period.OneMonth , PairID) , Period.OneMonth.Length , PairID.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                        if(ThisNowCourse != null && CandlesAvg != null)
                        {
                            Bitmap AvgLine = new Bitmap(PictureBox1m.Width , PictureBox1m.Height);
                            Graphics NeposredstvennoLine = Graphics.FromImage(AvgLine);
                            Pen pen = new Pen(Color.Black);
                            for(int i = 0; i < CandlesAvg.Count - 1; i++)
                            {
                                PointF First = new PointF(float.Parse((i * 5).ToString()) , float.Parse(((CandlesAvg[i] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                PointF Second = new PointF(float.Parse(((i + 1) * 5).ToString()) , float.Parse(((CandlesAvg[i + 1] - CandlesAvg.Min()) * 86 / (CandlesAvg.Max() - CandlesAvg.Min())).ToString()));
                                NeposredstvennoLine.DrawLine(pen , First , Second);
                            }
                            PictureBox1m.Image = AvgLine;
                        }
                    }
                    );

                }
                catch
                {
                }
        }

        private async void NowCourseSetter ()
        {
            await Task.Run(() =>
            {
                ChartSiteParser.ParsTover(ChartSiteParser.GetPage(Log.Text , Period.FiveMin , aPairID.Text) , Period.FiveMin.Length , aPairID.Text.Length , out string ThisNowCourse , out List<double> CandlesAvg);
                if(ThisNowCourse != null)
                    NowCourse.Text = ThisNowCourse;
            });
        }

        private void Timer_Tick (object sender , EventArgs e)
        {
            ItsTimeToStop.TimeToStop += 1;
            if(ItsTimeToStop.TimeToStop % 607 == 0)
            {
                Refill();
            }
            if(ItsTimeToStop.TimeToStop % 5 == 0)
            {
                NowCourseSetter();
            }
        }
        
    }
}
